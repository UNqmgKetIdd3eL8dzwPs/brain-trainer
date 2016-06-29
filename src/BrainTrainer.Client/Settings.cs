using System;
using BrainTrainer.Client.Enums;
using BrainTrainer.Client.Extensions;
using BrainTrainer.Client.UrlSerializer.Attributes;

namespace BrainTrainer.Client
{
    public class Settings
    {
        [UrlOrder(0)]
        public Mode Mode { get; set; } = Mode.Random;
        [UrlOrder(1)]
        [UrlIgnore]
        public Competition Competition { get; set; } = Competition.BrainRing;
        [UrlOrder(2)]
        [UrlIgnore]
        public Complexity Complexity { get; set; } = Complexity.None;
        [UrlOrder(3)]
        [UrlPrefix("limit")]
        public int Limit { get; set; } = 25;
        [UrlIgnore]
        public bool ShowAnswers { get; set; } = true;
        [UrlIgnore]
        public string Search { get; set; }
    }
}