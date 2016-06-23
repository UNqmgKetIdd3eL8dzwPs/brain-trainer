using System;
using BrainTrainer.Client.Attributes;

namespace BrainTrainer.Client.Enums
{

    [UrlPart("complexity")]
    [Flags]
    public enum Complexity
    {
        [UrlValue]
        None,
        [UrlValue("1")]
        VeryEasy,
        [UrlValue("2")]
        Easy,
        [UrlValue("3")]
        Average,
        [UrlValue("4")]
        Difficult,
        [UrlValue("5")]
        VeryDifficult,
    }
}