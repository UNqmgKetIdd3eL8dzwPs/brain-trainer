using System;

namespace BrainTrainer.Client.UrlSerializer.Attributes.ConditionalConvertionAttributes
{
    public abstract class UrlConvertIfAttribute : Attribute
    {
        public string PropertyName { get; set; }
        public abstract bool IsNull { get; }
        protected UrlConvertIfAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}