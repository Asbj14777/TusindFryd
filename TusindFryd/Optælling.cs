using System;

namespace TusindFryd
{
    public class Optælling
    {
        public int Antal { get; }
        public DateTime Dato { get; }
        public Produktionsbakke Bakke { get; }
        public Medarbejder Medarbejder { get; }

        public int SlutAntal { get; private set; }
        public double AfvigelseProcent { get; private set; }

        public Optælling(int antal, DateTime dato, Produktionsbakke bakke, Medarbejder medarbejder)
        {
            Antal = antal;
            Dato = dato;
            Bakke = bakke ?? throw new ArgumentNullException(nameof(bakke));
            Medarbejder = medarbejder ?? throw new ArgumentNullException(nameof(medarbejder));
        }

        public void BeregnSlutAntal() =>
            SlutAntal = Antal;

        public void BeregnAfvigelseProcent() =>
            AfvigelseProcent = 0.0;

        public override string ToString() =>
            $"{Dato:d}: {Antal} stk. ({Medarbejder.Initialer})";
    }
}
