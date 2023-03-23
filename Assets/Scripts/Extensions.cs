using System;

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
}