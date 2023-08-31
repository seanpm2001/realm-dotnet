﻿// <auto-generated />
#nullable enable

using MongoDB.Bson.Serialization;
using NUnit.Framework;
using Realms;
using Realms.Schema;
using Realms.Tests.Database;
using Realms.Weaving;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using TestEmbeddedObject = Realms.IEmbeddedObject;
using TestRealmObject = Realms.IRealmObject;

namespace Realms.Tests.Database
{
    [Generated]
    [Woven(typeof(DynamicSubSubTaskObjectHelper)), Realms.Preserve(AllMembers = true)]
    public partial class DynamicSubSubTask : IEmbeddedObject, INotifyPropertyChanged, IReflectableType
    {

        [Realms.Preserve]
        static DynamicSubSubTask()
        {
            Realms.Serialization.RealmObjectSerializer.Register(new DynamicSubSubTaskSerializer());
        }

        /// <summary>
        /// Defines the schema for the <see cref="DynamicSubSubTask"/> class.
        /// </summary>
        public static Realms.Schema.ObjectSchema RealmSchema = new Realms.Schema.ObjectSchema.Builder("DynamicSubSubTask", ObjectSchema.ObjectType.EmbeddedObject)
        {
            Realms.Schema.Property.Primitive("Summary", Realms.RealmValueType.String, isPrimaryKey: false, indexType: IndexType.None, isNullable: true, managedName: "Summary"),
            Realms.Schema.Property.Backlinks("ParentSubTask", "DynamicSubTask", "SubSubTasks", managedName: "ParentSubTask"),
            Realms.Schema.Property.Backlinks("ParentTask", "DynamicTask", "SubSubTasks", managedName: "ParentTask"),
        }.Build();

        #region IEmbeddedObject implementation

        private IDynamicSubSubTaskAccessor? _accessor;

        Realms.IRealmAccessor Realms.IRealmObjectBase.Accessor => Accessor;

        internal IDynamicSubSubTaskAccessor Accessor => _accessor ??= new DynamicSubSubTaskUnmanagedAccessor(typeof(DynamicSubSubTask));

        /// <inheritdoc />
        [IgnoreDataMember, XmlIgnore]
        public bool IsManaged => Accessor.IsManaged;

        /// <inheritdoc />
        [IgnoreDataMember, XmlIgnore]
        public bool IsValid => Accessor.IsValid;

        /// <inheritdoc />
        [IgnoreDataMember, XmlIgnore]
        public bool IsFrozen => Accessor.IsFrozen;

        /// <inheritdoc />
        [IgnoreDataMember, XmlIgnore]
        public Realms.Realm? Realm => Accessor.Realm;

        /// <inheritdoc />
        [IgnoreDataMember, XmlIgnore]
        public Realms.Schema.ObjectSchema ObjectSchema => Accessor.ObjectSchema!;

        /// <inheritdoc />
        [IgnoreDataMember, XmlIgnore]
        public Realms.DynamicObjectApi DynamicApi => Accessor.DynamicApi;

        /// <inheritdoc />
        [IgnoreDataMember, XmlIgnore]
        public int BacklinksCount => Accessor.BacklinksCount;

        /// <inheritdoc />
        [IgnoreDataMember, XmlIgnore]
        public Realms.IRealmObjectBase? Parent => Accessor.GetParent();

        void ISettableManagedAccessor.SetManagedAccessor(Realms.IRealmAccessor managedAccessor, Realms.Weaving.IRealmObjectHelper? helper, bool update, bool skipDefaults)
        {
            var newAccessor = (IDynamicSubSubTaskAccessor)managedAccessor;
            var oldAccessor = _accessor;
            _accessor = newAccessor;

            if (helper != null && oldAccessor != null)
            {
                if (!skipDefaults || oldAccessor.Summary != default(string?))
                {
                    newAccessor.Summary = oldAccessor.Summary;
                }
            }

            if (_propertyChanged != null)
            {
                SubscribeForNotifications();
            }

            OnManaged();
        }

        #endregion

        /// <summary>
        /// Called when the object has been managed by a Realm.
        /// </summary>
        /// <remarks>
        /// This method will be called either when a managed object is materialized or when an unmanaged object has been
        /// added to the Realm. It can be useful for providing some initialization logic as when the constructor is invoked,
        /// it is not yet clear whether the object is managed or not.
        /// </remarks>
        partial void OnManaged();

        private event PropertyChangedEventHandler? _propertyChanged;

        /// <inheritdoc />
        public event PropertyChangedEventHandler? PropertyChanged
        {
            add
            {
                if (_propertyChanged == null)
                {
                    SubscribeForNotifications();
                }

                _propertyChanged += value;
            }

            remove
            {
                _propertyChanged -= value;

                if (_propertyChanged == null)
                {
                    UnsubscribeFromNotifications();
                }
            }
        }

        /// <summary>
        /// Called when a property has changed on this class.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <remarks>
        /// For this method to be called, you need to have first subscribed to <see cref="PropertyChanged"/>.
        /// This can be used to react to changes to the current object, e.g. raising <see cref="PropertyChanged"/> for computed properties.
        /// </remarks>
        /// <example>
        /// <code>
        /// class MyClass : IRealmObject
        /// {
        ///     public int StatusCodeRaw { get; set; }
        ///     public StatusCodeEnum StatusCode => (StatusCodeEnum)StatusCodeRaw;
        ///     partial void OnPropertyChanged(string propertyName)
        ///     {
        ///         if (propertyName == nameof(StatusCodeRaw))
        ///         {
        ///             RaisePropertyChanged(nameof(StatusCode));
        ///         }
        ///     }
        /// }
        /// </code>
        /// Here, we have a computed property that depends on a persisted one. In order to notify any <see cref="PropertyChanged"/>
        /// subscribers that <c>StatusCode</c> has changed, we implement <see cref="OnPropertyChanged"/> and
        /// raise <see cref="PropertyChanged"/> manually by calling <see cref="RaisePropertyChanged"/>.
        /// </example>
        partial void OnPropertyChanged(string? propertyName);

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            _propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            OnPropertyChanged(propertyName);
        }

        private void SubscribeForNotifications()
        {
            Accessor.SubscribeForNotifications(RaisePropertyChanged);
        }

        private void UnsubscribeFromNotifications()
        {
            Accessor.UnsubscribeFromNotifications();
        }

        /// <summary>
        /// Converts a <see cref="Realms.RealmValue"/> to <see cref="DynamicSubSubTask"/>. Equivalent to <see cref="Realms.RealmValue.AsNullableRealmObject{T}"/>.
        /// </summary>
        /// <param name="val">The <see cref="Realms.RealmValue"/> to convert.</param>
        /// <returns>The <see cref="DynamicSubSubTask"/> stored in the <see cref="Realms.RealmValue"/>.</returns>
        public static explicit operator DynamicSubSubTask?(Realms.RealmValue val) => val.Type == Realms.RealmValueType.Null ? null : val.AsRealmObject<DynamicSubSubTask>();

        /// <summary>
        /// Implicitly constructs a <see cref="Realms.RealmValue"/> from <see cref="DynamicSubSubTask"/>.
        /// </summary>
        /// <param name="val">The value to store in the <see cref="Realms.RealmValue"/>.</param>
        /// <returns>A <see cref="Realms.RealmValue"/> containing the supplied <paramref name="val"/>.</returns>
        public static implicit operator Realms.RealmValue(DynamicSubSubTask? val) => val == null ? Realms.RealmValue.Null : Realms.RealmValue.Object(val);

        /// <summary>
        /// Implicitly constructs a <see cref="Realms.QueryArgument"/> from <see cref="DynamicSubSubTask"/>.
        /// </summary>
        /// <param name="val">The value to store in the <see cref="Realms.QueryArgument"/>.</param>
        /// <returns>A <see cref="Realms.QueryArgument"/> containing the supplied <paramref name="val"/>.</returns>
        public static implicit operator Realms.QueryArgument(DynamicSubSubTask? val) => (Realms.RealmValue)val;

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TypeInfo GetTypeInfo() => Accessor.GetTypeInfo(this);

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is InvalidObject)
            {
                return !IsValid;
            }

            if (obj is not Realms.IRealmObjectBase iro)
            {
                return false;
            }

            return Accessor.Equals(iro.Accessor);
        }

        /// <inheritdoc />
        public override int GetHashCode() => IsManaged ? Accessor.GetHashCode() : base.GetHashCode();

        /// <inheritdoc />
        public override string? ToString() => Accessor.ToString();

        [EditorBrowsable(EditorBrowsableState.Never), Realms.Preserve(AllMembers = true)]
        private class DynamicSubSubTaskObjectHelper : Realms.Weaving.IRealmObjectHelper
        {
            public void CopyToRealm(Realms.IRealmObjectBase instance, bool update, bool skipDefaults)
            {
                throw new InvalidOperationException("This method should not be called for source generated classes.");
            }

            public Realms.ManagedAccessor CreateAccessor() => new DynamicSubSubTaskManagedAccessor();

            public Realms.IRealmObjectBase CreateInstance() => new DynamicSubSubTask();

            public bool TryGetPrimaryKeyValue(Realms.IRealmObjectBase instance, out RealmValue value)
            {
                value = RealmValue.Null;
                return false;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Realms.Preserve(AllMembers = true)]
        internal interface IDynamicSubSubTaskAccessor : Realms.IRealmAccessor
        {
            string? Summary { get; set; }

            System.Linq.IQueryable<Realms.Tests.Database.DynamicSubTask> ParentSubTask { get; }

            System.Linq.IQueryable<Realms.Tests.Database.DynamicTask> ParentTask { get; }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Realms.Preserve(AllMembers = true)]
        private class DynamicSubSubTaskManagedAccessor : Realms.ManagedAccessor, IDynamicSubSubTaskAccessor
        {
            public string? Summary
            {
                get => (string?)GetValue("Summary");
                set => SetValue("Summary", value);
            }

            private System.Linq.IQueryable<Realms.Tests.Database.DynamicSubTask> _parentSubTask = null!;
            public System.Linq.IQueryable<Realms.Tests.Database.DynamicSubTask> ParentSubTask
            {
                get
                {
                    if (_parentSubTask == null)
                    {
                        _parentSubTask = GetBacklinks<Realms.Tests.Database.DynamicSubTask>("ParentSubTask");
                    }

                    return _parentSubTask;
                }
            }

            private System.Linq.IQueryable<Realms.Tests.Database.DynamicTask> _parentTask = null!;
            public System.Linq.IQueryable<Realms.Tests.Database.DynamicTask> ParentTask
            {
                get
                {
                    if (_parentTask == null)
                    {
                        _parentTask = GetBacklinks<Realms.Tests.Database.DynamicTask>("ParentTask");
                    }

                    return _parentTask;
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Realms.Preserve(AllMembers = true)]
        private class DynamicSubSubTaskUnmanagedAccessor : Realms.UnmanagedAccessor, IDynamicSubSubTaskAccessor
        {
            public override ObjectSchema ObjectSchema => DynamicSubSubTask.RealmSchema;

            private string? _summary;
            public string? Summary
            {
                get => _summary;
                set
                {
                    _summary = value;
                    RaisePropertyChanged("Summary");
                }
            }

            public System.Linq.IQueryable<Realms.Tests.Database.DynamicSubTask> ParentSubTask => throw new NotSupportedException("Using backlinks is only possible for managed(persisted) objects.");

            public System.Linq.IQueryable<Realms.Tests.Database.DynamicTask> ParentTask => throw new NotSupportedException("Using backlinks is only possible for managed(persisted) objects.");

            public DynamicSubSubTaskUnmanagedAccessor(Type objectType) : base(objectType)
            {
            }

            public override Realms.RealmValue GetValue(string propertyName)
            {
                return propertyName switch
                {
                    "Summary" => _summary,
                    "ParentSubTask" => throw new NotSupportedException("Using backlinks is only possible for managed(persisted) objects."),
                    "ParentTask" => throw new NotSupportedException("Using backlinks is only possible for managed(persisted) objects."),
                    _ => throw new MissingMemberException($"The object does not have a gettable Realm property with name {propertyName}"),
                };
            }

            public override void SetValue(string propertyName, Realms.RealmValue val)
            {
                switch (propertyName)
                {
                    case "Summary":
                        Summary = (string?)val;
                        return;
                    default:
                        throw new MissingMemberException($"The object does not have a settable Realm property with name {propertyName}");
                }
            }

            public override void SetValueUnique(string propertyName, Realms.RealmValue val)
            {
                throw new InvalidOperationException("Cannot set the value of an non primary key property with SetValueUnique");
            }

            public override IList<T> GetListValue<T>(string propertyName)
            {
                throw new MissingMemberException($"The object does not have a Realm list property with name {propertyName}");
            }

            public override ISet<T> GetSetValue<T>(string propertyName)
            {
                throw new MissingMemberException($"The object does not have a Realm set property with name {propertyName}");
            }

            public override IDictionary<string, TValue> GetDictionaryValue<TValue>(string propertyName)
            {
                throw new MissingMemberException($"The object does not have a Realm dictionary property with name {propertyName}");
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Realms.Preserve(AllMembers = true)]
        private class DynamicSubSubTaskSerializer : Realms.Serialization.RealmObjectSerializer<DynamicSubSubTask>
        {
            protected override void SerializeValue(MongoDB.Bson.Serialization.BsonSerializationContext context, BsonSerializationArgs args, DynamicSubSubTask value)
            {
                context.Writer.WriteStartDocument();

                WriteValue(context, args, "Summary", value.Summary);

                context.Writer.WriteEndDocument();
            }

            protected override DynamicSubSubTask CreateInstance() => new DynamicSubSubTask();

            protected override void ReadValue(DynamicSubSubTask instance, string name, BsonDeserializationContext context)
            {
                switch (name)
                {
                    case "Summary":
                        instance.Summary = BsonSerializer.LookupSerializer<string?>().Deserialize(context);
                        break;
                }
            }

            protected override void ReadArrayElement(DynamicSubSubTask instance, string name, BsonDeserializationContext context)
            {
                // No persisted list/set properties to deserialize
            }

            protected override void ReadDocumentField(DynamicSubSubTask instance, string name, string fieldName, BsonDeserializationContext context)
            {
                // No persisted dictionary properties to deserialize
            }
        }
    }
}
