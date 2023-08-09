﻿// <auto-generated />
#nullable enable

using MongoDB.Bson.Serialization;
using NUnit.Framework;
using Realms;
using Realms.Exceptions;
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
using TestRealmObject = Realms.IRealmObject;

namespace Realms.Tests.Database
{
    public partial class AddOrUpdateTests
    {
        [Generated]
        [Woven(typeof(PrimaryKeyWithPKListObjectHelper)), Realms.Preserve(AllMembers = true)]
        public partial class PrimaryKeyWithPKList : IRealmObject, INotifyPropertyChanged, IReflectableType
        {

            [Realms.Preserve]
            static PrimaryKeyWithPKList()
            {
                Realms.Serialization.RealmObjectSerializer.Register(new PrimaryKeyWithPKListSerializer());
            }

            /// <summary>
            /// Defines the schema for the <see cref="PrimaryKeyWithPKList"/> class.
            /// </summary>
            public static Realms.Schema.ObjectSchema RealmSchema = new Realms.Schema.ObjectSchema.Builder("PrimaryKeyWithPKList", ObjectSchema.ObjectType.RealmObject)
            {
                Realms.Schema.Property.Primitive("Id", Realms.RealmValueType.Int, isPrimaryKey: true, indexType: IndexType.None, isNullable: false, managedName: "Id"),
                Realms.Schema.Property.Primitive("StringValue", Realms.RealmValueType.String, isPrimaryKey: false, indexType: IndexType.None, isNullable: true, managedName: "StringValue"),
                Realms.Schema.Property.ObjectList("ListValue", "PrimaryKeyObject", managedName: "ListValue"),
            }.Build();

            #region IRealmObject implementation

            private IPrimaryKeyWithPKListAccessor? _accessor;

            Realms.IRealmAccessor Realms.IRealmObjectBase.Accessor => Accessor;

            internal IPrimaryKeyWithPKListAccessor Accessor => _accessor ??= new PrimaryKeyWithPKListUnmanagedAccessor(typeof(PrimaryKeyWithPKList));

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
                var newAccessor = (IPrimaryKeyWithPKListAccessor)managedAccessor;
                var oldAccessor = _accessor;
                _accessor = newAccessor;

                if (helper != null && oldAccessor != null)
                {
                    if (!skipDefaults)
                    {
                        newAccessor.ListValue.Clear();
                    }

                    if (!skipDefaults || oldAccessor.Id != default(long))
                    {
                        newAccessor.Id = oldAccessor.Id;
                    }
                    if (!skipDefaults || oldAccessor.StringValue != default(string?))
                    {
                        newAccessor.StringValue = oldAccessor.StringValue;
                    }
                    Realms.CollectionExtensions.PopulateCollection(oldAccessor.ListValue, newAccessor.ListValue, update, skipDefaults);
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
            /// Converts a <see cref="Realms.RealmValue"/> to <see cref="PrimaryKeyWithPKList"/>. Equivalent to <see cref="Realms.RealmValue.AsNullableRealmObject{T}"/>.
            /// </summary>
            /// <param name="val">The <see cref="Realms.RealmValue"/> to convert.</param>
            /// <returns>The <see cref="PrimaryKeyWithPKList"/> stored in the <see cref="Realms.RealmValue"/>.</returns>
            public static explicit operator PrimaryKeyWithPKList?(Realms.RealmValue val) => val.Type == Realms.RealmValueType.Null ? null : val.AsRealmObject<PrimaryKeyWithPKList>();

            /// <summary>
            /// Implicitly constructs a <see cref="Realms.RealmValue"/> from <see cref="PrimaryKeyWithPKList"/>.
            /// </summary>
            /// <param name="val">The value to store in the <see cref="Realms.RealmValue"/>.</param>
            /// <returns>A <see cref="Realms.RealmValue"/> containing the supplied <paramref name="val"/>.</returns>
            public static implicit operator Realms.RealmValue(PrimaryKeyWithPKList? val) => val == null ? Realms.RealmValue.Null : Realms.RealmValue.Object(val);

            /// <summary>
            /// Implicitly constructs a <see cref="Realms.QueryArgument"/> from <see cref="PrimaryKeyWithPKList"/>.
            /// </summary>
            /// <param name="val">The value to store in the <see cref="Realms.QueryArgument"/>.</param>
            /// <returns>A <see cref="Realms.QueryArgument"/> containing the supplied <paramref name="val"/>.</returns>
            public static implicit operator Realms.QueryArgument(PrimaryKeyWithPKList? val) => (Realms.RealmValue)val;

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
            private class PrimaryKeyWithPKListObjectHelper : Realms.Weaving.IRealmObjectHelper
            {
                public void CopyToRealm(Realms.IRealmObjectBase instance, bool update, bool skipDefaults)
                {
                    throw new InvalidOperationException("This method should not be called for source generated classes.");
                }

                public Realms.ManagedAccessor CreateAccessor() => new PrimaryKeyWithPKListManagedAccessor();

                public Realms.IRealmObjectBase CreateInstance() => new PrimaryKeyWithPKList();

                public bool TryGetPrimaryKeyValue(Realms.IRealmObjectBase instance, out RealmValue value)
                {
                    value = ((IPrimaryKeyWithPKListAccessor)instance.Accessor).Id;
                    return true;
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never), Realms.Preserve(AllMembers = true)]
            internal interface IPrimaryKeyWithPKListAccessor : Realms.IRealmAccessor
            {
                long Id { get; set; }

                string? StringValue { get; set; }

                System.Collections.Generic.IList<Realms.Tests.Database.AddOrUpdateTests.PrimaryKeyObject> ListValue { get; }
            }

            [EditorBrowsable(EditorBrowsableState.Never), Realms.Preserve(AllMembers = true)]
            private class PrimaryKeyWithPKListManagedAccessor : Realms.ManagedAccessor, IPrimaryKeyWithPKListAccessor
            {
                public long Id
                {
                    get => (long)GetValue("Id");
                    set => SetValueUnique("Id", value);
                }

                public string? StringValue
                {
                    get => (string?)GetValue("StringValue");
                    set => SetValue("StringValue", value);
                }

                private System.Collections.Generic.IList<Realms.Tests.Database.AddOrUpdateTests.PrimaryKeyObject> _listValue = null!;
                public System.Collections.Generic.IList<Realms.Tests.Database.AddOrUpdateTests.PrimaryKeyObject> ListValue
                {
                    get
                    {
                        if (_listValue == null)
                        {
                            _listValue = GetListValue<Realms.Tests.Database.AddOrUpdateTests.PrimaryKeyObject>("ListValue");
                        }

                        return _listValue;
                    }
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never), Realms.Preserve(AllMembers = true)]
            private class PrimaryKeyWithPKListUnmanagedAccessor : Realms.UnmanagedAccessor, IPrimaryKeyWithPKListAccessor
            {
                public override ObjectSchema ObjectSchema => PrimaryKeyWithPKList.RealmSchema;

                private long _id;
                public long Id
                {
                    get => _id;
                    set
                    {
                        _id = value;
                        RaisePropertyChanged("Id");
                    }
                }

                private string? _stringValue;
                public string? StringValue
                {
                    get => _stringValue;
                    set
                    {
                        _stringValue = value;
                        RaisePropertyChanged("StringValue");
                    }
                }

                public System.Collections.Generic.IList<Realms.Tests.Database.AddOrUpdateTests.PrimaryKeyObject> ListValue { get; } = new List<Realms.Tests.Database.AddOrUpdateTests.PrimaryKeyObject>();

                public PrimaryKeyWithPKListUnmanagedAccessor(Type objectType) : base(objectType)
                {
                }

                public override Realms.RealmValue GetValue(string propertyName)
                {
                    return propertyName switch
                    {
                        "Id" => _id,
                        "StringValue" => _stringValue,
                        _ => throw new MissingMemberException($"The object does not have a gettable Realm property with name {propertyName}"),
                    };
                }

                public override void SetValue(string propertyName, Realms.RealmValue val)
                {
                    switch (propertyName)
                    {
                        case "Id":
                            throw new InvalidOperationException("Cannot set the value of a primary key property with SetValue. You need to use SetValueUnique");
                        case "StringValue":
                            StringValue = (string?)val;
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

                    Id = (long)val;
                }

                public override IList<T> GetListValue<T>(string propertyName)
                {
                    return propertyName switch
                    {
                        "ListValue" => (IList<T>)ListValue,
                        _ => throw new MissingMemberException($"The object does not have a Realm list property with name {propertyName}"),
                    };
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
            private class PrimaryKeyWithPKListSerializer : Realms.Serialization.RealmObjectSerializer<PrimaryKeyWithPKList>
            {
                protected override void SerializeValue(MongoDB.Bson.Serialization.BsonSerializationContext context, BsonSerializationArgs args, PrimaryKeyWithPKList value)
                {
                    context.Writer.WriteStartDocument();

                    WriteValue(context, args, "Id", value.Id);
                    WriteValue(context, args, "StringValue", value.StringValue);
                    WriteList(context, args, "ListValue", value.ListValue);

                    context.Writer.WriteEndDocument();
                }

                protected override PrimaryKeyWithPKList CreateInstance() => new PrimaryKeyWithPKList();

                protected override void ReadValue(PrimaryKeyWithPKList instance, string name, BsonDeserializationContext context)
                {
                    switch (name)
                    {
                        case "Id":
                            instance.Id = BsonSerializer.LookupSerializer<long>().Deserialize(context);
                            break;
                        case "StringValue":
                            instance.StringValue = BsonSerializer.LookupSerializer<string?>().Deserialize(context);
                            break;
                    }
                }

                protected override void ReadArrayElement(PrimaryKeyWithPKList instance, string name, BsonDeserializationContext context)
                {
                    switch (name)
                    {
                        case "ListValue":
                            instance.ListValue.Add(LookupSerializer<Realms.Tests.Database.AddOrUpdateTests.PrimaryKeyObject>()!.DeserializeById(context)!);
                            break;
                    }
                }
            }
        }
    }
}
