namespace BrainTrainer.Client.UrlSerializer.Attributes.ConditionalConvertionAttributes
{
    public class UrlConvertIfIntAttribute : UrlConvertIfAttribute
    {
        public int Value { get; set; }

        public UrlConvertIfIntAttribute(string propertyName, int value) : base(propertyName)
        {
            Value = value;
        }

        public override bool IsNull => false;
    }
}