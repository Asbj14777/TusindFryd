using System;
using System.Collections.Generic;

namespace TusindFryd
{
    public class Produktionsbakke
    {
        public string Navn { get; set; }
        public List<Optælling> Optællinger { get; } = new();
        public List<Produktion> Produktioner { get; } = new();
        public Produktionsbakke(string navn)
        {
            Navn = navn ?? throw new ArgumentNullException(nameof(navn));
        }

        public void TilføjOptælling(Optælling optælling)
        {
            if (optælling == null)
                throw new ArgumentNullException(nameof(optælling));
            Optællinger.Add(optælling);
        }
        public void TilføjProduktion(Produktion produktion)
        {
            if (produktion == null)
                throw new ArgumentNullException(nameof(produktion));
            Produktioner.Add(produktion);
        }
        public override string ToString() => Navn;
    }
}
