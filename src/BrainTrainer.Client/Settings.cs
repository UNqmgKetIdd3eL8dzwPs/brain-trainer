using System;
using BrainTrainer.Client.Enums;
using BrainTrainer.Client.Extensions;
using BrainTrainer.Client.UrlSerializer.Attributes;
using BrainTrainer.Client.UrlSerializer.Attributes.ConditionalConvertionAttributes;

namespace BrainTrainer.Client
{
    public class Settings
    {
        [UrlOrder(0)]
        public Mode Mode { get; set; } = Mode.Random;

        [UrlOrder(1)]
        [UrlPrefix("types")]
        public Competition Competition { get; set; } = Competition.BrainRing;

        [UrlOrder(2)]
        [UrlPrefix("complexity")]
        [UrlConvertIfEnum("Competition", (int)Competition.ChtoGdeKogda)] // only Competition.ChtoGdeKogda has complexity
        public Complexity Complexity { get; set; } = Complexity.None;

        [UrlOrder(3)]
        [UrlPrefix("limit")]
        public int Limit { get; set; } = 25;

        [UrlOrder(4)]
        [UrlConvertIfEnum("Mode", (int)Mode.Search)]
        public string Search { get; set; }

        [UrlOrder(5)]
        [UrlConvertIfEnum("Mode", (int)Mode.Search)]
        [UrlBoolValue("A", "")]
        public bool ShowAnswers { get; set; } = true;

    }
}