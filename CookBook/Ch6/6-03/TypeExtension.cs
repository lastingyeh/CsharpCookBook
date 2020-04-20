using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CookBook.Ch6
{
    public static class TypeExtension
    {
        private static IEnumerable<Type> GetBaseTypes(this Type type)
        {
            Type current = type;
            while (current != null)
            {
                yield return current;
                current = current.BaseType;
            }
        }

        public static IEnumerable<Type> GetInheritanceChain(this Type derivedType) =>
            (from t in derivedType.GetBaseTypes()
             select t).Reverse();

        public static IEnumerable<MemberInfo> GetMethodOverrides(this Type type) =>
           from ms in type.GetMethods(BindingFlags.Instance |
           BindingFlags.NonPublic | BindingFlags.Public |
               BindingFlags.Static | BindingFlags.DeclaredOnly)
           where ms != ms.GetBaseDefinition()
           select ms.GetBaseDefinition();

        public static MethodInfo GetBaseMethodOverridden(this Type type,
            string methodName, Type[] paramTypes)
        {
            MethodInfo method = type.GetMethod(methodName, paramTypes);
            MethodInfo baseDef = method?.GetBaseDefinition();

            if (baseDef != method)
            {
                bool foundMatch = (from p in baseDef.GetParameters()
                                   join op in paramTypes
                                   on p.ParameterType.UnderlyingSystemType
                                   equals op.UnderlyingSystemType
                                   select p).Any();

                if (foundMatch)
                    return baseDef;
            }
            return null;
        }
    }
}
