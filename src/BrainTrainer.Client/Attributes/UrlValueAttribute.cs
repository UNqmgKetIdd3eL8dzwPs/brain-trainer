using System;

namespace BrainTrainer.Client.Attributes
{
    public class UrlValueAttribute : Attribute
    {
        public string Value { get; }

        public UrlValueAttribute(string value = "")
        {
            Value = value;
        }
    }
}