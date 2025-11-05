using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TusindFryd
{
    public class Produktion
    {
        public Blomst Blomstersort { get; private set; }
        public int StartAntal { get; private set; }
        public DateTime StartDato { get; private set; }
        public DateTime ForventetSlutDato { get; private set; }
        public Produktionsbakke Produktionsbakke { get; private set; }
        private List<Produktionsbakke> produktionsbakker = new();
        private List<Optælling> Optællinger = new();
        private Medarbejder valgtMedarbejder;
        private Produktionsbakke valgtBakke;

        public Produktion(Blomst blomstersort, Produktionsbakke produktionsbakke, int startAntal, DateTime startDato)
        {
            Blomstersort = blomstersort ?? throw new ArgumentNullException(nameof(blomstersort));
            Produktionsbakke = produktionsbakke ?? throw new ArgumentNullException(nameof(produktionsbakke));
            StartAntal = startAntal > 0 ? startAntal : throw new ArgumentOutOfRangeException(nameof(startAntal));
            StartDato = startDato;
            ForventetSlutDato = startDato.AddDays(blomstersort.Produktionstid);
            produktionsbakker.Add(produktionsbakke);
        }

        public void GennemseAfMedarbejder(string initialer)
        {
            valgtMedarbejder = Medarbejder.FindMedarbejder(initialer);
            if (valgtMedarbejder == null)
                throw new InvalidOperationException("Medarbejder ikke fundet.");

            Console.WriteLine($"Gennemse produktion udført af: {valgtMedarbejder.Navn}");
        }


        public void VælgeProduktionsbakke(string navn)
        {
            valgtBakke = produktionsbakker.Find(b => b.Navn.Equals(navn, StringComparison.OrdinalIgnoreCase));
            if (valgtBakke == null)
                throw new InvalidOperationException("Produktionsbakke ikke fundet.");

            Console.WriteLine($"Produktionsbakke valgt: {valgtBakke.Navn}");
        }

        public void AngivOptællingsinformation(int antal, DateTime dato)
        {
            if (valgtBakke == null)
                throw new InvalidOperationException("Produktionsobjekt ikke fundet.");
            if (valgtMedarbejder == null)
                throw new InvalidOperationException("Medarbejder er ikke valgt.");

            var Optælling = new Optælling(antal, dato, valgtBakke, valgtMedarbejder);
            Optælling.BeregnSlutAntal();
            Optælling.BeregnAfvigelseProcent();

            Optællinger.Add(Optælling);
            valgtBakke.TilføjOptælling(Optælling);
            valgtMedarbejder.TilføjOptælling(Optælling);

            Console.WriteLine($"Optælling oprettet: {antal} stk på {dato:d}");
        }



        public void TilføjProduktionsbakke(Produktionsbakke bakke)
        {
            if (bakke == null)
                throw new ArgumentNullException(nameof(bakke));

            produktionsbakker.Add(bakke);
        }   

    }
}
