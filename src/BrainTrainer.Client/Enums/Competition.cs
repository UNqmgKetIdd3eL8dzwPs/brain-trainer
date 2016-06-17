using System;

namespace BrainTrainer.Client.Enums
{
    [Flags]
    public enum Competition
    {
        ChtoGdeKogda = 1,
        BrainRing = 2,
        Internet = 4,
        Beskrylka = 8,
        SvoyaIgra = 16,
        Eruditka = 32,
    }
}