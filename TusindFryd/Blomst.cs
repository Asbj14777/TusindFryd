namespace TusindFryd
{
    public class Blomst
    {

        public string Navn { get; private set; }
        public byte[] Billede { get; private set; }
        public int Produktionstid { get; private set; }
        public int Halveringstid { get; private set; }
        public int Størrelse { get; private set; }
        public DateTime StartDato { get; private set; }

        public Blomst(string navn, byte[] billede, int produktionstid, int halveringstid, int størrelse)
        {
            Navn = navn;
            Billede = billede;
            Produktionstid = produktionstid;
            Halveringstid = halveringstid;
            Størrelse = størrelse;
        }

        public Blomst etablerNyBlomstersort(string navn, byte[] billede, int produktionstid, int halveringstid, int størrelse)
        {
            if (string.IsNullOrWhiteSpace(navn))
                throw new ArgumentException("Navn må ikke være tomt.", nameof(navn));
            else if (billede == null || billede.Length == 0)
                throw new ArgumentException("Billede må ikke være null eller tomt.", nameof(billede));
            else if (produktionstid <= 0)
                throw new ArgumentOutOfRangeException(nameof(produktionstid), "Produktionstid skal være > 0.");
            else if (halveringstid <= 0)
                throw new ArgumentOutOfRangeException(nameof(halveringstid), "Halveringstid skal være > 0.");
            else if (størrelse <= 0)
                throw new ArgumentOutOfRangeException(nameof(størrelse), "Størrelse skal være > 0.");

            return new Blomst(navn, billede, produktionstid, halveringstid, størrelse);
        }
    }
}