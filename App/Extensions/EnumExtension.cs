using System;

namespace BerlinClock.App.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum enumValue)
        {
            var type = enumValue.GetType();
            var memInfo = type.GetMember(enumValue.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
            return attributes.Length > 0 ? ((System.ComponentModel.DescriptionAttribute)attributes[0]).Description : enumValue.ToString();
        }
    }
}
