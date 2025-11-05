using TusindFryd;

class Program
{
    static void Main(string[] args)
    {
      
        var drivhus = new Drivhus();

        var Medarbejder = new Medarbejder("", "");  
        drivhus.TilføjBakke(new Produktionsbakke("Bakke A"));
        drivhus.TilføjBakke(new Produktionsbakke("Bakke B"));

        drivhus.TilføjBlomstersort(new Blomst("Tulipan", 40));
        drivhus.TilføjBlomstersort(new Blomst("Rose", 45));


        Medarbejder.TilføjMedarbejder(new Medarbejder("MJ", "Maja Jensen"));
        Medarbejder.TilføjMedarbejder(new Medarbejder("AK", "Anders Kristensen"));
        Medarbejder.TilføjMedarbejder(new Medarbejder("LS", "Lise Sørensen"));


        var produktion = drivhus.StartProduktion(
            produktionsbakkeNavn: "Bakke A",
            blomstersortNavn: "Tulipan",
            startAntal: 150,
            startDato: DateTime.Now
        );


        produktion.GennemseAfMedarbejder("MJ"); 
        produktion.VælgeProduktionsbakke("Bakke A");          
        produktion.AngivOptællingsinformation(140, DateTime.Now); 


        var produktion2 = drivhus.StartProduktion(
            produktionsbakkeNavn: "Bakke B",
            blomstersortNavn: "Rose",
            startAntal: 100,
            startDato: DateTime.Now.AddDays(-5)
        );

        produktion2.GennemseAfMedarbejder("AK");              
        produktion2.VælgeProduktionsbakke("Bakke B");
        produktion2.AngivOptællingsinformation(98, DateTime.Now);


        Console.WriteLine("\n=== PRODUKTIONSOVERSIGT ===");
        foreach (var p in drivhus.HentProduktioner())
        {
            Console.WriteLine($"{p.Blomstersort.Navn} i {p.Produktionsbakke.Navn}");
            Console.WriteLine($"Start: {p.StartAntal} stk.  ({p.StartDato:d})");
            Console.WriteLine($"Forventet slut: {p.ForventetSlutDato:d}");
        }
  
    }
}