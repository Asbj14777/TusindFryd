using System;

namespace TusindFryd
{
    public class Blomst
    {
        public string Navn { get; }
        public int Produktionstid { get; } // dage

        public Blomst(string navn, int produktionstid)
        {
            Navn = navn ?? throw new ArgumentNullException(nameof(navn));
            Produktionstid = produktionstid > 0 ? produktionstid : throw new ArgumentOutOfRangeException(nameof(produktionstid));
        }

        public override string ToString() => $"{Navn} ({Produktionstid} dage)";
    }
}
