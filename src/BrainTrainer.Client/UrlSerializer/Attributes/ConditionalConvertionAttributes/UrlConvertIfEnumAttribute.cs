using System;

namespace BrainTrainer.Client.UrlSerializer.Attributes.ConditionalConvertionAttributes
{
    public class UrlConvertIfEnumAttribute : UrlConvertIfAttribute
    {
        public int Value { get; set; }

        public UrlConvertIfEnumAttribute(string propertyName, int value) : base(propertyName)
        {
            Value = value;
        }

        public override bool IsNull => false;
    }
}