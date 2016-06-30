namespace BrainTrainer.Client.UrlSerializer.Attributes.ConditionalConvertionAttributes
{
    public class UrlConvertIfBoolAttribute : UrlConvertIfAttribute
    {
        public bool Value { get; set; }

        public UrlConvertIfBoolAttribute(string propertyName, bool value) : base(propertyName)
        {
            Value = value;
        }

        public override bool IsNull => false;
    }
}