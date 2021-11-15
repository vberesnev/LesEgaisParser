using System;
using System.ComponentModel;

namespace LesegaisParser.Common.Extensions
{
    public static class EnumExtensions
    {
        public static string GetEnumDescription<T>(this T value)
            where T: struct
        {
            var type = value.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("Value must be of Enum type", "value");
            }
            
            var memberInfo = type.GetMember(value.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return value.ToString();
        }
    }
}