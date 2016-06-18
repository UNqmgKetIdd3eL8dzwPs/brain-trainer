using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BrainTrainer.Client.Attributes;

namespace BrainTrainer.Client.Extensions
{
    public static class EnumExtensions
    {
        public static string GetUrlString(this Enum enumValue)
        {
            var type = enumValue.GetType();
            var typeInfo = type.GetTypeInfo();

            var urlPartAttibute = typeInfo.GetCustomAttribute<UrlPartAttribute>();

            if (urlPartAttibute == null)
            {
                return enumValue.ToString();
            }

            var hasFlagsAttribute = typeInfo.GetCustomAttribute(typeof(FlagsAttribute)) != null;

            var stringValue = string.Empty;
            if (!hasFlagsAttribute)
            {
                stringValue = GetMemberUrlValue(typeInfo, enumValue);
            }
            else
            {
                var urlValues = new List<string>();
                foreach (var value in Enum.GetValues(type).Cast<Enum>())
                {
                    if (enumValue.HasFlag(value))
                    {
                        urlValues.Add(GetMemberUrlValue(typeInfo, value));
                    }
                }
                stringValue = string.Join(string.Empty, urlValues.ToArray());
            }

            return string.Format($"{urlPartAttibute.Separator}{urlPartAttibute.BaseValue}{stringValue}");
        }

        private static string GetMemberUrlValue(TypeInfo typeInfo, Enum enumValue)
        {
            var attribute = typeInfo.GetDeclaredField(enumValue.ToString()).GetCustomAttribute<UrlValueAttribute>();
            return attribute == null ? enumValue.ToString() : attribute.Value;
        }
    }
}