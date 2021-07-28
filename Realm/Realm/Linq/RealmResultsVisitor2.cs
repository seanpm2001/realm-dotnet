﻿using System;
using System.Linq;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Realms
{
    internal class RealmResultsVisitor2 : ExpressionVisitor
    {
        private readonly Realm _realm;
        private readonly RealmObjectBase.Metadata _metadata;
        private QueryModel _query;

        private QueryHandle _coreQueryHandle;
        private SortDescriptorHandle _sortDescriptor;

        internal RealmResultsVisitor2(Realm realm, RealmObjectBase.Metadata metadata)
        {
            _realm = realm;
            _metadata = metadata;
            _query = new QueryModel();
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.DeclaringType == typeof(Queryable))
            {
                if (node.Method.Name == nameof(Queryable.Where))
                {
                    Visit(node.Arguments[0]);
                    var whereClause = new WhereClauseVisitor(_metadata);
                    var lambda = (LambdaExpression)StripQuotes(node.Arguments[1]);
                    _query.WhereClause = whereClause.VisitWhere(lambda);
                    return node;
                }

                // just check if sortclause in here
                if (node.Method.Name == nameof(Queryable.OrderBy))
                {
                    Visit(node.Arguments[0]);
                    var orderClause = new OrderByClauseVisitor();
                    _query.OrderByClause = orderClause.VisitOrderBy((LambdaExpression)StripQuotes(node.Arguments[1]));
                    return node;
                }
                else
                {
                    throw new NotSupportedException($"The method call '{node.Method.Name}' is not supported");
                }
            }
            else
            {
                throw new NotSupportedException($"The method '{node.Method.Name}' is not supported");
            }
        }

        private static Expression StripQuotes(Expression e)
        {
            while (e.NodeType == ExpressionType.Quote)
            {
                e = ((UnaryExpression)e).Operand;
            }

            return e;
        }

        private static bool IsSortClause(string methodName, out bool isAscending, out bool isReplacing)
        {
            switch (methodName)
            {
                case nameof(Queryable.OrderBy):
                    isAscending = true;
                    isReplacing = true;
                    return true;
                case nameof(Queryable.ThenBy):
                    isAscending = true;
                    isReplacing = false;
                    return true;
                case nameof(Queryable.OrderByDescending):
                    isAscending = false;
                    isReplacing = true;
                    return true;
                case nameof(Queryable.ThenByDescending):
                    isAscending = false;
                    isReplacing = false;
                    return true;
                default:
                    isAscending = false;
                    isReplacing = false;
                    return false;
            }
        }

        public ResultsHandle MakeResultsForQuery()
        {
            var json = JsonConvert.SerializeObject(_query, formatting: Formatting.Indented);
            return _coreQueryHandle.CreateResults(_realm.SharedRealmHandle, _sortDescriptor);
        }
    }
}
