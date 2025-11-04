using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TusindFryd
{
    public class Drivhus
    {
        private List<Produktionsbakke> _bakker = new();
        private List<Blomst> _blomster = new();
        private List<Produktion> _produktioner = new();

        public void TilføjBakke(Produktionsbakke bakke) => _bakker.Add(bakke);
        public void TilføjBlomstersort(Blomst blomst) => _blomster.Add(blomst);

        public Produktion StartProduktion(string drivhus, string produktionsbakke,
                                          string blomstersort, int startAntal, DateTime startDato)
        {
            var bakke = _bakker.Find(b => b.Id == produktionsbakke)
                ?? throw new ArgumentException("Produktionsbakke findes ikke.", nameof(produktionsbakke));

            var blomst = _blomster.Find(b => b.Navn == blomstersort)
                ?? throw new ArgumentException("Blomstersort findes ikke.", nameof(blomstersort));
    
            var produktion = new Produktion(blomst, bakke, startAntal, startDato);

            bakke.Produktionen.Add(produktion);
            _produktioner.Add(produktion);

            return produktion;
        }
    }
}

