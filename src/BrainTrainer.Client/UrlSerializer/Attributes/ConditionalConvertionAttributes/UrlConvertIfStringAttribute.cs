namespace BrainTrainer.Client.UrlSerializer.Attributes.ConditionalConvertionAttributes
{
    public class UrlConvertIfStringAttribute : UrlConvertIfAttribute
    {
        public string Value { get; set; }

        public UrlConvertIfStringAttribute(string propertyName, string value) : base(propertyName)
        {
            Value = value;
        }

        public override bool IsNull => Value == null;
    }
}