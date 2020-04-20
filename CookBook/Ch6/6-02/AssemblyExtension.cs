using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CookBook.Ch6
{
    public static class AssemblyExtension
    {
        public static IEnumerable<MemberInfo> GetMembersInAssembly(
            this Assembly asm, string memberName) =>
            from type in asm.GetTypes()
            from ms in type.GetMember(memberName, MemberTypes.All,
                BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Static | BindingFlags.Instance)
            select ms;

        public static IEnumerable<Type> GetSerializableTypes(this Assembly asm) =>
            from type in asm.GetTypes()
            where type.IsSerializable && !type.IsNestedPrivate // filters out anonymous types
            select type;

        public static IEnumerable<Type> GetSubclassesForType(this Assembly asm,
            Type baseClassType) =>
            from type in asm.GetTypes()
            where type.IsSubclassOf(baseClassType)
            select type;

        public static IEnumerable<Type> GetNestedTypes(this Assembly asm) =>
            from t in asm.GetTypes()
            from t2 in t.GetNestedTypes(BindingFlags.Instance |
                BindingFlags.Static |
                BindingFlags.Public |
                BindingFlags.NonPublic)
            where !t2.IsEnum && !t2.IsInterface &&
                  !t2.IsNestedPrivate
            select t2;

        public static IEnumerable<TypeHierarchy> GetTypeHierarchies(
            this Assembly asm) =>
            from Type type in asm.GetTypes()
            select new TypeHierarchy
            {
                DerivedType = type,
                InheritanceChain = type.GetInheritanceChain()
            };
    }


}
