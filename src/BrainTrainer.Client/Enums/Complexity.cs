using System;
using BrainTrainer.Client.UrlSerializer.Attributes;

namespace BrainTrainer.Client.Enums
{
    [Flags]
    public enum Complexity
    {
        [UrlEnumValue]
        None,
        [UrlEnumValue("1")]
        VeryEasy,
        [UrlEnumValue("2")]
        Easy,
        [UrlEnumValue("3")]
        Average,
        [UrlEnumValue("4")]
        Difficult,
        [UrlEnumValue("5")]
        VeryDifficult,
    }
}