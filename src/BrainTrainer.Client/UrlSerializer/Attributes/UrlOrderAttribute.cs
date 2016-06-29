using System;

namespace BrainTrainer.Client.UrlSerializer.Attributes
{
    public class UrlOrderAttribute : Attribute
    {
        public int Order { get; set; }
        public UrlOrderAttribute(int order)
        {
            Order = order;
        }
    }
}