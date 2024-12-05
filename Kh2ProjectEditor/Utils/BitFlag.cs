﻿using System;

namespace Kh2ProjectEditor.Utils
{
    public class BitFlag
    {
        // Ensure the type is an enum and supports flags
        private static void ValidateEnumType<T>() where T : Enum
        {
            if (!typeof(T).IsDefined(typeof(FlagsAttribute), false))
            {
                throw new ArgumentException($"{typeof(T).Name} must have the [Flags] attribute.");
            }
        }

        // Check if a flag is set
        public static bool IsFlagSet<T>(T value, T flag) where T : Enum
        {
            ValidateEnumType<T>();
            var intValue = Convert.ToInt32(value);
            var intFlag = Convert.ToInt32(flag);
            return (intValue & intFlag) == intFlag;
        }

        // Set a flag
        public static T SetFlag<T>(T value, T flag) where T : Enum
        {
            ValidateEnumType<T>();
            var intValue = Convert.ToInt32(value);
            var intFlag = Convert.ToInt32(flag);
            return (T)Enum.ToObject(typeof(T), intValue | intFlag);
        }

        // Clear a flag
        public static T ClearFlag<T>(T value, T flag) where T : Enum
        {
            ValidateEnumType<T>();
            var intValue = Convert.ToInt32(value);
            var intFlag = Convert.ToInt32(flag);
            return (T)Enum.ToObject(typeof(T), intValue & ~intFlag);
        }

        // Toggle a flag
        public static T ToggleFlag<T>(T value, T flag) where T : Enum
        {
            ValidateEnumType<T>();
            var intValue = Convert.ToInt32(value);
            var intFlag = Convert.ToInt32(flag);
            return (T)Enum.ToObject(typeof(T), intValue ^ intFlag);
        }
    }
}
