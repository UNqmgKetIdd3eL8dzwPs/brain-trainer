using System;
using BrainTrainer.Client.Attributes;

namespace BrainTrainer.Client.Enums
{
    [UrlPart("competition")]
    [Flags]
    public enum Competition
    {
        //[UrlValue("1")]
        ChtoGdeKogda = 1,
        [UrlValue("2")]
        BrainRing = 2,
        [UrlValue("3")]
        Internet = 4,
        [UrlValue("4")]
        Beskrylka = 8,
        [UrlValue("5")]
        SvoyaIgra = 16,
        [UrlValue("6")]
        Eruditka = 32,
    }
}