using System;
using System.Collections.Generic;

namespace TusindFryd
{
    public class Drivhus
    {
        private readonly List<Produktionsbakke> _bakker = new();
        private readonly List<Blomst> _blomster = new();
        private readonly List<Produktion> _produktioner = new();

        public void TilføjBakke(Produktionsbakke bakke)
        {
            if (bakke == null)
                throw new ArgumentNullException(nameof(bakke));

            _bakker.Add(bakke);
        }

        public void TilføjBlomstersort(Blomst blomst)
        {
            if (blomst == null)
                throw new ArgumentNullException(nameof(blomst));

            _blomster.Add(blomst);
        }
        public Produktion StartProduktion(string produktionsbakkeNavn, string blomstersortNavn,
                                          int startAntal, DateTime startDato)
        {

            var bakke = _bakker.Find(b => b.Navn.Equals(produktionsbakkeNavn, StringComparison.OrdinalIgnoreCase))
                ?? throw new ArgumentException("Produktionsbakke findes ikke.", nameof(produktionsbakkeNavn));


            var blomst = _blomster.Find(b => b.Navn.Equals(blomstersortNavn, StringComparison.OrdinalIgnoreCase))
                ?? throw new ArgumentException("Blomstersort findes ikke.", nameof(blomstersortNavn));


            var produktion = new Produktion(blomst, bakke, startAntal, startDato);

            bakke.TilføjProduktion(produktion);
            _produktioner.Add(produktion);

            Console.WriteLine($"Ny produktion startet: {blomst.Navn} i {bakke.Navn} ({startAntal} stk.)");

            return produktion;
        }

        public IReadOnlyList<Produktion> HentProduktioner() => _produktioner.AsReadOnly();
    }
}
