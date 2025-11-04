using TusindFryd;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Velkommen til TusindFryd!");
        Drivhus drivhus = new Drivhus();

        Produktionsbakke bakke1 = new Produktionsbakke("Bakke-1");
        drivhus.TilføjBakke(bakke1);

        byte[] dummyBillede = new byte[] { 0x01, 0x02, 0x03 }; 
        Blomst tusindfryd = new Blomst("Tulipan", dummyBillede, produktionstid: 14, halveringstid: 30, størrelse: 10);
        drivhus.TilføjBlomstersort(tusindfryd);

        Produktion produktion = drivhus.StartProduktion(
            drivhus: "Drivhus A",
            produktionsbakke: "Bakke-1",
            blomstersort: "Tulipan",
            startAntal: 100,
            startDato: DateTime.Now
        );

        Console.WriteLine($"Blomstersort: {produktion.Blomstersort.Navn}");
        Console.WriteLine($"Startdato: {produktion.StartDato:d}");
        Console.WriteLine($"Forventet slutdato: {produktion.ForventetSlutDato:d}");
        Console.WriteLine($"Antal: {produktion.StartAntal}");
        Console.WriteLine($"Bakke: {produktion.Produktionsbakke.Id}");
    }   
}