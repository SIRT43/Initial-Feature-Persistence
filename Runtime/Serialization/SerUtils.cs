using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace InitialSolution.Persistence.Serialization
{
    /// <summary>
    /// 序列化工具，本类遵循 Unity 序列化规则。
    /// </summary>
    public static class SerUtils
    {
        public static bool IsSerableField(this FieldInfo fieldInfo) =>
            !fieldInfo.IsDefined(typeof(NonSerializedAttribute), true) ||
            fieldInfo.IsDefined(typeof(SerializeField), true);

        public static bool IsSerableType(this Type type) =>
            type.IsDefined(typeof(SerializableAttribute), true);



        /// <summary>
        /// 获取所有可序列化字段。
        /// </summary>
        public static FieldInfo[] GetSerableFields(this Type type)
        {
            if (!IsSerableType(type)) throw new ArgumentException($"Type {type.FullName} is not marked as serializable", nameof(type));

            List<FieldInfo> serable = new();

            foreach (FieldInfo fieldInfo in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                if (IsSerableField(fieldInfo)) serable.Add(fieldInfo);
            }

            return serable.ToArray();
        }
        public static FieldInfo[] GetSerableFields(object obj) => GetSerableFields(obj.GetType());
    }
}
