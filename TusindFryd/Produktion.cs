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

        public Produktion(Blomst blomstersort, Produktionsbakke produktionsbakke, int startAntal, DateTime startDato)
        {
            Blomstersort = blomstersort ?? throw new ArgumentNullException(nameof(blomstersort));
            Produktionsbakke = produktionsbakke ?? throw new ArgumentNullException(nameof(produktionsbakke));
            StartAntal = startAntal > 0 ? startAntal : throw new ArgumentOutOfRangeException(nameof(startAntal));
            StartDato = startDato;
            ForventetSlutDato = startDato.AddDays(blomstersort.Produktionstid);
        }
    }
}
