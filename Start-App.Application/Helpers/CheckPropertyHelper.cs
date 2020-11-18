/*
 * Copyright(c) Trickyrat All Rights Reserved.
 * Licensed under the MIT LICENSE.
 */


using System;
using System.Reflection;

namespace Start_App.Application.Helpers
{
    public class CheckPropertyHelper<T>
    {
        public static bool IsValidProperty(string propertyName, bool throwExceptionIfNotFound = true)
        {
            var prop = typeof(T).GetProperty(propertyName,
                BindingFlags.IgnoreCase |
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.Instance);
            if(prop == null && throwExceptionIfNotFound)
            {
                throw new NotSupportedException($"Error: Property {propertyName} does not exist.");
            }
            return prop != null;
        }
    }
}
