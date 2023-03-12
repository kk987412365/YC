using System;
using System.ComponentModel;
using System.Reflection;


namespace YC.Extension
{
    public static class EnumExtension
    {        
        public static string GetDescription(this Enum value)
        {
            if (value == null)
                throw new Exception("Enum為Null");
            if (!value.GetType().IsEnum)
                throw new Exception($"[T:{ value.GetType().ToString()}]不為Enum");

            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
