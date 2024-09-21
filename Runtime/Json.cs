using InitialFramework.IO;
using System;
using UnityEngine;

namespace InitialSolution.Persistence
{
    public static class Json
    {
        public static string ToJson(object obj, bool readability = true) =>
            JsonUtility.ToJson(obj, readability);

        public static object FromJson(string json, Type type) =>
             JsonUtility.FromJson(json, type);

        public static T FromJson<T>(string json) =>
             JsonUtility.FromJson<T>(json);

        public static void FromJson(string json, object container) =>
             JsonUtility.FromJsonOverwrite(json, container);


        public static void ToFile(object obj, UnityFile file) =>
            file.WriteAllText(ToJson(obj));

        public static bool FromFile(UnityFile file, Type type, out object obj)
        {
            obj = default;

            if (!file.ReadAllText(out string content)) return false;
            if (string.IsNullOrEmpty(content)) return false;

            obj = FromJson(content, type);
            return true;
        }

        public static bool FromFile<T>(UnityFile file, out object obj)
        {
            obj = default;

            if (!file.ReadAllText(out string content)) return false;
            if (string.IsNullOrEmpty(content)) return false;

            obj = FromJson<T>(content);
            return true;
        }

        public static bool FromFile(object container, UnityFile file)
        {
            if (!file.ReadAllText(out string json)) return false;
            if (string.IsNullOrEmpty(json)) return false;

            FromJson(json, container);
            return true;
        }
    }
}
