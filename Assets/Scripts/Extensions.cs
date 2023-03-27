using System;
using ECSShooter.Data;
using UnityEngine;

namespace ECSShooter
{
    public static class Extensions
    {
        public static T With<T>(this T obj, Action<T> action)
        {
            action?.Invoke(obj);
            return obj;
        }
    }

    public static class DataExtensions
    {
        public static Vector3Data AsVectorData(this Vector3 data) => new (data);
        public static Vector3 AsUnityVector3(this Vector3Data data) => new(data.X, data.Y, data.Z);
    }
}