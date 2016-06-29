using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BrainTrainer.Client.UrlSerializer.Attributes;

namespace BrainTrainer.Client.UrlSerializer
{
    public class UrlConverter
    {
        public static string ToUrl<T>(T value)
        {
            dynamic dynamicValue = value;
            return dynamicValue != null
                ? Convert(dynamicValue, new List<Attribute>())
                : Convert(new List<Attribute>());
        }

        #region Converters

        private static string Convert(object value, IEnumerable<Attribute> attributes)
        {
            var type = value.GetType();

            var convertedProperties = type
                .GetRuntimeProperties()
                .Where(p => p.GetCustomAttribute<UrlIgnoreAttribute>() == null)
                .OrderBy(p => p.GetCustomAttribute<UrlOrderAttribute>()?.Order ?? int.MaxValue)
                .Select(p =>
                {
                    dynamic dynamicValue = p.GetValue(value);
                    return dynamicValue != null
                        ? Convert(dynamicValue, p.GetCustomAttributes())
                        : Convert(p.GetCustomAttributes());
                });

            var stringValue = string.Join("/", convertedProperties.Where(p => !string.IsNullOrEmpty(p)));
            return string.Format($"{GetPrefix(attributes)}{stringValue}");
        }

        private static string Convert(Enum value, IEnumerable<Attribute> attributes)
        {
            var type = value.GetType();
            var typeInfo = type.GetTypeInfo();

            var hasFlagsAttribute = typeInfo.GetCustomAttribute<FlagsAttribute>() != null;

            string stringValue;
            if (!hasFlagsAttribute)
            {
                stringValue = GetEnumMemberUrlValue(typeInfo, value);
            }
            else
            {
                var urlValues = new List<string>();
                foreach (var enumValue in Enum.GetValues(type).Cast<Enum>())
                {
                    if (value.HasFlag(enumValue))
                    {
                        urlValues.Add(GetEnumMemberUrlValue(typeInfo, value));
                    }
                }
                stringValue = string.Join(string.Empty, urlValues.ToArray());
            }

            return string.Format($"{GetPrefix(attributes)}{stringValue}");
        }

        private static string Convert(int value, IEnumerable<Attribute> attributes)
        {
            return string.Format($"{GetPrefix(attributes)}{value}");
        }

        private static string Convert(bool value, IEnumerable<Attribute> attributes)
        {
            var boolValueAttribute = attributes.OfType<UrlBoolValueAttribute>().FirstOrDefault();
            var stringValue = boolValueAttribute == null
                ? value.ToString()
                : value ? boolValueAttribute.TrueValue : boolValueAttribute.FalseValue;
            return string.Format($"{GetPrefix(attributes)}{stringValue}");
        }

        private static string Convert(string value, IEnumerable<Attribute> attributes)
        {
            return string.Format($"{GetPrefix(attributes)}{value}");
        }

        private static string Convert(ValueType value, IEnumerable<Attribute> attributes)
        {
            return string.Format($"{GetPrefix(attributes)}{value}");
        }

        // method to convert null values 
        private static string Convert(IEnumerable<Attribute> attributes)
        {
            return string.Format($"{GetPrefix(attributes)}");
        }

        #endregion


        #region Helpers

        private static string GetEnumMemberUrlValue(TypeInfo typeInfo, Enum enumValue)
        {
            var attribute = typeInfo.GetDeclaredField(enumValue.ToString()).GetCustomAttribute<UrlEnumValueAttribute>();
            return attribute == null ? enumValue.ToString() : attribute.Value;
        }
        private static string GetPrefix(IEnumerable<Attribute> attributes)
        {
            return attributes.OfType<UrlPrefixAttribute>().FirstOrDefault()?.Prefix ?? string.Empty;
        }

        #endregion
    }
}