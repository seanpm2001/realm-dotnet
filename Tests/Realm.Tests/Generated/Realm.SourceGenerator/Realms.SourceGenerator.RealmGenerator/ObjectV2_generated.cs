﻿// <auto-generated />
#nullable enable

using MongoDB.Bson.Serialization;
using NUnit.Framework;
using Realms;
using Realms.Exceptions;
using Realms.Extensions;
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
    [Woven(typeof(ObjectV2ObjectHelper)), Realms.Preserve(AllMembers = true)]
    public partial class ObjectV2 : IRealmObject, INotifyPropertyChanged, IReflectableType
    {

        [Realms.Preserve]
        static ObjectV2()
        {
            Realms.Serialization.RealmObjectSerializer.Register(new ObjectV2Serializer());
        }

        /// <summary>
        /// Defines the schema for the <see cref="ObjectV2"/> class.
        /// </summary>
        public static Realms.Schema.ObjectSchema RealmSchema = new Realms.Schema.ObjectSchema.Builder("Object", ObjectSchema.ObjectType.RealmObject)
        {
            Realms.Schema.Property.Primitive("Id", Realms.RealmValueType.String, isPrimaryKey: true, indexType: IndexType.None, isNullable: true, managedName: "Id"),
            Realms.Schema.Property.Primitive("Value", Realms.RealmValueType.String, isPrimaryKey: false, indexType: IndexType.None, isNullable: true, managedName: "Value"),
        }.Build();

        #region IRealmObject implementation

        private IObjectV2Accessor? _accessor;

        Realms.IRealmAccessor Realms.IRealmObjectBase.Accessor => Accessor;

        private IObjectV2Accessor Accessor => _accessor ??= new ObjectV2UnmanagedAccessor(typeof(ObjectV2));

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

        void ISettableManagedAccessor.SetManagedAccessor(Realms.IRealmAccessor managedAccessor, Realms.Weaving.IRealmObjectHelper? helper, bool update, bool skipDefaults)
        {
            var newAccessor = (IObjectV2Accessor)managedAccessor;
            var oldAccessor = _accessor;
            _accessor = newAccessor;

            if (helper != null && oldAccessor != null)
            {
                if (!skipDefaults || oldAccessor.Id != default(string?))
                {
                    newAccessor.Id = oldAccessor.Id;
                }
                if (!skipDefaults || oldAccessor.Value != default(string?))
                {
                    newAccessor.Value = oldAccessor.Value;
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
        /// Converts a <see cref="Realms.RealmValue"/> to <see cref="ObjectV2"/>. Equivalent to <see cref="Realms.RealmValue.AsNullableRealmObject{T}"/>.
        /// </summary>
        /// <param name="val">The <see cref="Realms.RealmValue"/> to convert.</param>
        /// <returns>The <see cref="ObjectV2"/> stored in the <see cref="Realms.RealmValue"/>.</returns>
        public static explicit operator ObjectV2?(Realms.RealmValue val) => val.Type == Realms.RealmValueType.Null ? null : val.AsRealmObject<ObjectV2>();

        /// <summary>
        /// Implicitly constructs a <see cref="Realms.RealmValue"/> from <see cref="ObjectV2"/>.
        /// </summary>
        /// <param name="val">The value to store in the <see cref="Realms.RealmValue"/>.</param>
        /// <returns>A <see cref="Realms.RealmValue"/> containing the supplied <paramref name="val"/>.</returns>
        public static implicit operator Realms.RealmValue(ObjectV2? val) => val == null ? Realms.RealmValue.Null : Realms.RealmValue.Object(val);

        /// <summary>
        /// Implicitly constructs a <see cref="Realms.QueryArgument"/> from <see cref="ObjectV2"/>.
        /// </summary>
        /// <param name="val">The value to store in the <see cref="Realms.QueryArgument"/>.</param>
        /// <returns>A <see cref="Realms.QueryArgument"/> containing the supplied <paramref name="val"/>.</returns>
        public static implicit operator Realms.QueryArgument(ObjectV2? val) => (Realms.RealmValue)val;

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
        private class ObjectV2ObjectHelper : Realms.Weaving.IRealmObjectHelper
        {
            public void CopyToRealm(Realms.IRealmObjectBase instance, bool update, bool skipDefaults)
            {
                throw new InvalidOperationException("This method should not be called for source generated classes.");
            }

            public Realms.ManagedAccessor CreateAccessor() => new ObjectV2ManagedAccessor();

            public Realms.IRealmObjectBase CreateInstance() => new ObjectV2();

            public bool TryGetPrimaryKeyValue(Realms.IRealmObjectBase instance, out RealmValue value)
            {
                value = ((IObjectV2Accessor)instance.Accessor).Id;
                return true;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Realms.Preserve(AllMembers = true)]
        internal interface IObjectV2Accessor : Realms.IRealmAccessor
        {
            string? Id { get; set; }

            string? Value { get; set; }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Realms.Preserve(AllMembers = true)]
        private class ObjectV2ManagedAccessor : Realms.ManagedAccessor, IObjectV2Accessor
        {
            public string? Id
            {
                get => (string?)GetValue("Id");
                set => SetValueUnique("Id", value);
            }

            public string? Value
            {
                get => (string?)GetValue("Value");
                set => SetValue("Value", value);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Realms.Preserve(AllMembers = true)]
        private class ObjectV2UnmanagedAccessor : Realms.UnmanagedAccessor, IObjectV2Accessor
        {
            public override ObjectSchema ObjectSchema => ObjectV2.RealmSchema;

            private string? _id;
            public string? Id
            {
                get => _id;
                set
                {
                    _id = value;
                    RaisePropertyChanged("Id");
                }
            }

            private string? _value;
            public string? Value
            {
                get => _value;
                set
                {
                    _value = value;
                    RaisePropertyChanged("Value");
                }
            }

            public ObjectV2UnmanagedAccessor(Type objectType) : base(objectType)
            {
            }

            public override Realms.RealmValue GetValue(string propertyName)
            {
                return propertyName switch
                {
                    "Id" => _id,
                    "Value" => _value,
                    _ => throw new MissingMemberException($"The object does not have a gettable Realm property with name {propertyName}"),
                };
            }

            public override void SetValue(string propertyName, Realms.RealmValue val)
            {
                switch (propertyName)
                {
                    case "Id":
                        throw new InvalidOperationException("Cannot set the value of a primary key property with SetValue. You need to use SetValueUnique");
                    case "Value":
                        Value = (string?)val;
                        return;
                    default:
                        throw new MissingMemberException($"The object does not have a settable Realm property with name {propertyName}");
                }
            }

            public override void SetValueUnique(string propertyName, Realms.RealmValue val)
            {
                if (propertyName != "Id")
                {
                    throw new InvalidOperationException($"Cannot set the value of non primary key property ({propertyName}) with SetValueUnique");
                }

                Id = (string?)val;
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
        private class ObjectV2Serializer : Realms.Serialization.RealmObjectSerializer<ObjectV2>
        {
            protected override void SerializeValue(MongoDB.Bson.Serialization.BsonSerializationContext context, BsonSerializationArgs args, ObjectV2 value)
            {
                context.Writer.WriteStartDocument();

                WriteValue(context, args, "Id", value.Id);
                WriteValue(context, args, "Value", value.Value);

                context.Writer.WriteEndDocument();
            }

            protected override ObjectV2 CreateInstance() => new ObjectV2();

            protected override void ReadValue(ObjectV2 instance, string name, BsonDeserializationContext context)
            {
                switch (name)
                {
                    case "Id":
                        instance.Id = BsonSerializer.LookupSerializer<string?>().Deserialize(context);
                        break;
                    case "Value":
                        instance.Value = BsonSerializer.LookupSerializer<string?>().Deserialize(context);
                        break;
                }
            }

            protected override void ReadArrayElement(ObjectV2 instance, string name, BsonDeserializationContext context)
            {
                // No persisted list/set properties to deserialize
            }

            protected override void ReadDocumentField(ObjectV2 instance, string name, string fieldName, BsonDeserializationContext context)
            {
                // No persisted dictionary properties to deserialize
            }
        }
    }
}
