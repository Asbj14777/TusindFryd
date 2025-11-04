using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TusindFryd
{
    public class Produktionsbakke
    {
        public string Id { get; private set; }
        public List<Produktion> Produktionen { get; private set; } = new();

        public Produktionsbakke(string id) => Id = id ?? throw new ArgumentNullException(nameof(id));
        
    }
}
