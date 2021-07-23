using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    public static class TypeExtension
    {
        public static T CreateInstance<T>(this Type type) where T : class
        {
            return Activator.CreateInstance(type) as T;
        }
    }
}
