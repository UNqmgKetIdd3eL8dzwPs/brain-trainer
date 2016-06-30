using System;
using BrainTrainer.Client.UrlSerializer.Attributes;

namespace BrainTrainer.Client.Enums
{
    [Flags]
    public enum Competition
    {
        [UrlEnumValue("1")]
        ChtoGdeKogda = 1,
        [UrlEnumValue("2")]
        BrainRing = 2,
        [UrlEnumValue("3")]
        Internet = 4,
        [UrlEnumValue("4")]
        Beskrylka = 8,
        [UrlEnumValue("5")]
        SvoyaIgra = 16,
        [UrlEnumValue("6")]
        Eruditka = 32,
    }
}