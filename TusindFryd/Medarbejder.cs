using System;
using System.Collections.Generic;

namespace TusindFryd
{
    public class Medarbejder
    {
        public string Initialer { get; set; }
        public string Navn { get; set; }
        public List<Optælling> Optællinger { get; } = new();

        public Medarbejder(string initialer, string navn)
        {
            Initialer = initialer ?? throw new ArgumentNullException(nameof(initialer));
            Navn = navn ?? throw new ArgumentNullException(nameof(navn));
        }

        public void TilføjOptælling(Optælling optælling)
        {
            if (optælling == null)
                throw new ArgumentNullException(nameof(optælling));
            Optællinger.Add(optælling);
        }
        private static readonly List<Medarbejder> medarbejdere = new() {/*new Medarbejder("")*/ };
        public static Medarbejder FindMedarbejder(string initialer) => medarbejdere.Find(m => m.Initialer.Equals(initialer, StringComparison.OrdinalIgnoreCase));
        public void TilføjMedarbejder(Medarbejder medarbejder)
        {
            if (medarbejder == null)
                throw new ArgumentNullException(nameof(medarbejder));
            medarbejdere.Add(medarbejder);
        }
        public override string ToString() => $"{Navn} ({Initialer})";
    }
}
