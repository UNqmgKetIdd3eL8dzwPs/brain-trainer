using System;
using System.Reflection;

namespace BrainTrainer.Client.Attributes
{
    public class UrlPartAttribute : Attribute
    {
        public string BaseValue { get; }
        public string Separator { get; }

        public UrlPartAttribute(string baseValue = "", string separator = @"\")
        {
            BaseValue = baseValue;
            Separator = separator;
        }
    }
}