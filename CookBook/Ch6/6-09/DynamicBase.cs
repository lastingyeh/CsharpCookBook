using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace CookBook.Ch6
{
    public class DynamicBase<T> : DynamicObject where T : new()
    {
        private T _containedObject = default(T);

        [JsonExtensionData]
        private Dictionary<string, object> _dynamicMembers =
            new Dictionary<string, object>();

        private List<PropertyInfo> _propertyInfos =
            new List<PropertyInfo>(typeof(T).GetProperties());

        public DynamicBase() { }
        public DynamicBase(T containedObject)
        {
            _containedObject = containedObject;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            if (_dynamicMembers.ContainsKey(binder.Name) &&
                _dynamicMembers[binder.Name] is Delegate)
            {
                result = (_dynamicMembers[binder.Name] as Delegate).DynamicInvoke(args);
                return true;
            }
            return base.TryInvokeMember(binder, args, out result);
        }

        public override IEnumerable<string> GetDynamicMemberNames() =>
            _dynamicMembers.Keys;

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            var propertyInfo = _propertyInfos.Where(pi => pi.Name == binder.Name).FirstOrDefault();

            if (propertyInfo == null)
            {
                if (_dynamicMembers.Keys.Contains(binder.Name))
                {
                    result = _dynamicMembers[binder.Name];
                    return true;
                }
            }
            else
            {
                if (_containedObject != null)
                {
                    result = propertyInfo.GetValue(_containedObject);
                    return true;
                }
            }

            return base.TryGetMember(binder, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            var propertyInfo = _propertyInfos.Where(pi => pi.Name == binder.Name).FirstOrDefault();

            if (propertyInfo == null)
            {
                if (_dynamicMembers.Keys.Contains(binder.Name))
                {
                    _dynamicMembers[binder.Name] = value;
                    return true;
                }
                else
                {
                    _dynamicMembers.Add(binder.Name, value);
                    return true;
                }
            }
            else
            {
                if (_containedObject != null)
                {
                    propertyInfo.SetValue(_containedObject, value);
                    return true;
                }
            }
            return base.TrySetMember(binder, value);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var propInfo in _propertyInfos)
            {
                if (_containedObject != null)
                    builder.AppendFormat("{0}:{1}{2}", propInfo.Name,
                        propInfo.GetValue(_containedObject), Environment.NewLine);
                else
                    builder.AppendFormat("{0}:{1}{2}", propInfo.Name,
                        propInfo.GetValue(this), Environment.NewLine);
            }

            foreach (var addItem in _dynamicMembers)
            {
                Type itemType = addItem.Value.GetType();
                Type genericType = itemType.IsGenericType ?
                    itemType.GetGenericTypeDefinition() : null;

                if (genericType != null)
                {
                    if (genericType != typeof(Func<>) && genericType != typeof(Action<>))
                        builder.AppendFormat("{0}:{1}{2}", addItem.Key,
                            addItem.Value, Environment.NewLine);
                }
                else
                {
                    builder.AppendFormat("{0}:{1}{2}", addItem.Key, addItem.Value,
                        Environment.NewLine);
                }
            }
            return builder.ToString();
        }


    }
}
