using Varastonhallinta;

Main();

static void Main()
{
    bool jatkuu = true;

    while (jatkuu)
    {
        Console.WriteLine("VARASTONHALLINTA");
        Console.WriteLine("1 – Lisää uusi tuote");
        Console.WriteLine("2 – Poista tuote");
        Console.WriteLine("3 – Tulosta eri tuotteiden määrät");
        Console.WriteLine("4 – Muokkaa tuotenimeä");
        Console.WriteLine("0 – Lopeta sovellus");
        Console.Write("Valintasi on: ");

        switch (Console.ReadLine())
        {
            case "1":
                LisaaUusiTuote();
                break;
            case "2":
                PoistaTuote();
                break;
            case "3":
                TulostaTuotteidenMaara();
                break;
            case "4":
                MuokkaaTuotenimea();
                break;
            case "0":
                jatkuu = false;
                break;
            default:
                Console.WriteLine("Virheellinen valinta.");
                break;
        }
    }
}

static void LisaaUusiTuote()
{
    Console.Write("Anna tuotteen nimi: ");
    var nimi = Console.ReadLine();

    Console.Write("Anna tuotteen hinta: ");
    int hinta = int.Parse(Console.ReadLine());

    Console.Write("Anna tuotteen varastosaldo: ");
    int saldo = int.Parse(Console.ReadLine());

    using var db = new VarastonhallintaContext();
    db.Tuotteet.Add(new Tuote { Tuotenimi = nimi, Tuotenhinta = hinta, VarastoSaldo = saldo });
    db.SaveChanges();
    Console.WriteLine("Tuote lisätty onnistuneesti!");
}

static void PoistaTuote()
{
    Console.Write("Anna poistettavan tuotteen ID: ");
    int id = int.Parse(Console.ReadLine());

    using var db = new VarastonhallintaContext();
    var tuote = db.Tuotteet.Find(id);
    if (tuote != null)
    {
        db.Tuotteet.Remove(tuote);
        db.SaveChanges();
        Console.WriteLine("Tuote poistettu onnistuneesti.");
    }
    else
    {
        Console.WriteLine("Tuotetta ei löydy.");
    }
}

static void TulostaTuotteidenMaara()
{
    using var db = new VarastonhallintaContext();
    var tuotteet = db.Tuotteet.ToList();

    Console.WriteLine("Tuotteet varastossa:");
    foreach (var tuote in tuotteet)
    {
        Console.WriteLine($"ID: {tuote.Id}, Nimi: {tuote.Tuotenimi}, Hinta: {tuote.Tuotenhinta}, Varasto: {tuote.VarastoSaldo}");
    }
}

static void MuokkaaTuotenimea()
{
    Console.Write("Anna muokattavan tuotteen ID: ");
    int id = int.Parse(Console.ReadLine());

    using var db = new VarastonhallintaContext();
    var tuote = db.Tuotteet.Find(id);

    if (tuote != null)
    {
        Console.Write("Anna uusi nimi: ");
        tuote.Tuotenimi = Console.ReadLine();
        db.SaveChanges();
        Console.WriteLine("Tuotenimi päivitetty.");
    }
    else
    {
        Console.WriteLine("Tuotetta ei löydy.");
    }
}

