using System;

namespace BrainTrainer.Client.UrlSerializer.Attributes
{
    public class UrlEnumValueAttribute : Attribute
    {
        public string Value { get; }

        public UrlEnumValueAttribute(string value = "")
        {
            Value = value;
        }
    }
}