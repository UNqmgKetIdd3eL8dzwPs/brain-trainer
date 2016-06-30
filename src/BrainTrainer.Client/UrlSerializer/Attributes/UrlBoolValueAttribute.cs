using System;

namespace BrainTrainer.Client.UrlSerializer.Attributes
{
    public class UrlBoolValueAttribute : Attribute
    {
        public string TrueValue { get; }
        public string FalseValue { get; }
        public UrlBoolValueAttribute(string trueValue = "true", string falseValue = "false")
        {
            TrueValue = trueValue;
            FalseValue = FalseValue;
        }
    }
}