﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Newtonsoft.Json;
using Realms.Schema;

namespace Realms
{
    internal class WhereClauseVisitor : ExpressionVisitor
    {
        private readonly RealmObjectBase.Metadata _metadata;

        private WhereClause _whereClause;

        public WhereClauseVisitor(RealmObjectBase.Metadata metadata)
        {
            _metadata = metadata;
        }

        public WhereClause VisitWhere(LambdaExpression whereClause)
        {
            _whereClause = new WhereClause();
            _whereClause.ExpNode = ParseExpression(whereClause.Body);
            var json = JsonConvert.SerializeObject(_whereClause, formatting: Formatting.Indented);
            Visit(whereClause.Body);
            return _whereClause;
        }

        private ExpressionNode ParseExpression(Expression exp)
        {
            if (exp is BinaryExpression be)
            {
                if (be.NodeType == ExpressionType.AndAlso)
                {
                    var andNode = new AndNode();
                    andNode.Left = ParseExpression(be.Left);
                    andNode.Right = ParseExpression(be.Right);
                    return andNode;
                }

                if (be.NodeType == ExpressionType.OrElse)
                {
                    var orNode = new OrNode();
                    orNode.Left = ParseExpression(be.Left);
                    orNode.Right = ParseExpression(be.Right);
                    return orNode;
                }

                ComparisonNode comparisonNode;
                switch (be.NodeType)
                {
                    case ExpressionType.Equal:
                        comparisonNode = new EqualityNode();
                        break;
                    case ExpressionType.NotEqual:
                        comparisonNode = new NotEqualNode();
                        break;
                    case ExpressionType.LessThan:
                        comparisonNode = new LtNode();
                        break;
                    case ExpressionType.LessThanOrEqual:
                        comparisonNode = new LteNode();
                        break;
                    case ExpressionType.GreaterThan:
                        comparisonNode = new GtNode();
                        break;
                    case ExpressionType.GreaterThanOrEqual:
                        comparisonNode = new GteNode();
                        break;
                    default:
                        throw new NotSupportedException($"The binary operator '{be.NodeType}' is not supported");
                }

                if (be.Left is MemberExpression me)
                {
                    if (me.Expression != null && me.Expression.NodeType == ExpressionType.Parameter)
                    {
                        var leftName = GetColumnName(me, me.NodeType);

                        comparisonNode.Property = leftName;
                    }
                }

                if (be.Right is ConstantExpression co)
                {
                    comparisonNode.Value = co.Value;
                }

                return comparisonNode;
            }

            if (exp != null && exp.NodeType == ExpressionType.Parameter)
            {
                if (exp.Type == typeof(bool))
                {
                    var booleanNode = new BooleanNode();
                    object rhs = true;  // box value
                    var leftName = GetColumnName((MemberExpression)exp, exp.NodeType);
                    booleanNode.Property = leftName;
                    return booleanNode;
                }
            }

            throw new Exception("Expression not supported!");
        }

        private string GetColumnName(MemberExpression memberExpression, ExpressionType? parentType = null)
        {
            var name = memberExpression?.Member.GetMappedOrOriginalName();

            if (parentType.HasValue)
            {
                if (name == null ||
                    memberExpression.Expression.NodeType != ExpressionType.Parameter ||
                    !(memberExpression.Member is PropertyInfo) ||
                    !_metadata.Schema.TryFindProperty(name, out var property) ||
                    property.Type.HasFlag(PropertyType.Array) ||
                    property.Type.HasFlag(PropertyType.Set))
                {
                    throw new NotSupportedException($"The left-hand side of the {parentType} operator must be a direct access to a persisted property in Realm.\nUnable to process '{memberExpression}'.");
                }
            }

            return name;
        }
    }
}
