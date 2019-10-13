using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace FilterAttribute
{

    class DynamicObjHelper
    {
        public static dynamic BuildDynamicObj(Dictionary<string, object> properties)
        {
            return new DynamicObj(properties);
        }

        public sealed class DynamicObj : DynamicObject
        {
            private readonly Dictionary<string, object> _properties;

            public DynamicObj(Dictionary<string, object> properties)
            {
                _properties = properties;
            }

            public override IEnumerable<string> GetDynamicMemberNames()
            {
                return _properties.Keys;
            }

            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                if (_properties.ContainsKey(binder.Name))
                {
                    result = _properties[binder.Name];
                    return true;
                }
                else
                {
                    result = null;
                    return false;
                }
            }

            //public override bool TrySetMember(SetMemberBinder binder, object value)
            //{
            //    if (_properties.ContainsKey(binder.Name))
            //    {
            //        _properties[binder.Name] = value;
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
        }
    }
}
