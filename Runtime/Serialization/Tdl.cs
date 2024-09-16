using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace InitialSolution.Persistence.Serialization
{
    /// <summary>
    /// Type Definition Language.
    /// <br>轻量数据交换语言。</br>
    /// </summary>
    public static class Tdl
    {
        private static readonly Dictionary<Type, string> supportedType = new()
        {
            { typeof(int), "int" },
            { typeof(float), "float" },
            { typeof(bool), "bool" },
            { typeof(Guid), "guid" },
            { typeof(string), "string" },
        };


        public static bool GetTypeName(Type type, out string name)
        {
            if (supportedType.TryGetValue(type, out string value))
            {
                name = value;
                return true;
            }

            name = null;
            return false;
        }


        public static string BuildStatement(string type, string name, string value) => $"{type} {name} = {value};";
        public static string BuildStatement(FieldInfo info, object obj)
        {
            if (!GetTypeName(info.FieldType, out string name)) return null;

            object value = info.GetValue(obj);

            string strVal = value == null ? "null" : value.ToString();
            if (name is "string") strVal = $"\"{strVal}\"";

            return BuildStatement(name, info.Name, strVal);
        }



        public static bool IsSerializableField(MemberInfo memberInfo) =>
            !memberInfo.IsDefined(typeof(NonSerializedAttribute), true) ||
            memberInfo.IsDefined(typeof(SerializeField), true);
        public static bool IsSerializableType(Type type) =>
            type.IsDefined(typeof(SerializableAttribute), true);


        public static bool Serialization(object obj, out string tdl)
        {
            tdl = null;
            Type type = obj.GetType();

            if (!IsSerializableType(type)) return false;

            StringBuilder builder = new();

            foreach (FieldInfo variable in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                if (!IsSerializableField(variable)) continue;

                builder.Append(BuildStatement(variable, obj) + "\n");
            }

            tdl = builder.ToString();
            return true;
        }
    }
}
