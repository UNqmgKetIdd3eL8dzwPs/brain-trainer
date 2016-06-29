using System;

namespace BrainTrainer.Client.UrlSerializer.Attributes
{
    public class UrlPrefixAttribute : Attribute
    {
        public string Prefix { get; }
        public UrlPrefixAttribute(string prefix = "")
        {
            Prefix = prefix;
        }
    }
}