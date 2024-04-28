using System;
using System.Text;

// Tavara-luokka, joka kuvastaa mitä tahansa tavaraa pelissä
class Tavara
{
    public double Paino { get; }
    public double Tilavuus { get; }
    public string Nimi { get; }

    // Tavara-luokan konstruktori
    public Tavara(double paino, double tilavuus, string nimi)
    {
        Paino = paino;
        Tilavuus = tilavuus;
        Nimi = nimi;
    }

    // Ylikirjoitetaan ToString-metodi palauttamaan tavaran nimi
    public override string ToString()
    {
        return Nimi;
    }
}

// Luokat eri tavaroille
class Nuoli : Tavara
{
    public Nuoli() : base(0.1, 0.05, "Nuoli") { }
}

class Jousi : Tavara
{
    public Jousi() : base(1, 4, "Jousi") { }
}

class Köysi : Tavara
{
    public Köysi() : base(1, 1.5, "Köysi") { }
}

class Vesi : Tavara
{
    public Vesi() : base(2, 2, "Vesi") { }
}

class RuokaAnnos : Tavara
{
    public RuokaAnnos() : base(1, 0.5, "Ruoka-annos") { }
}

class Miekka : Tavara
{
    public Miekka() : base(5, 3, "Miekka") { }
}

// Reppu-luokka, johon voidaan tallettaa tavaroita
class Reppu
{
    private Tavara[] sisältö;
    private int maksimiTavaroidenMäärä;
    private double maksimiKantoPaino;
    private double maksimiTilavuus;
    private int tavaroidenMäärä;
    private double tavaroidenPaino;
    private double tavaroidenTilavuus;

    // Reppu-luokan konstruktori
    public Reppu(int maksimiTavaroidenMäärä, double maksimiKantoPaino, double maksimiTilavuus)
    {
        this.maksimiTavaroidenMäärä = maksimiTavaroidenMäärä;
        this.maksimiKantoPaino = maksimiKantoPaino;
        this.maksimiTilavuus = maksimiTilavuus;
        sisältö = new Tavara[maksimiTavaroidenMäärä];
    }

    // Metodi tavaran lisäämiseksi reppuun
    public bool Lisää(Tavara tavara)
    {
        if (tavaroidenMäärä < maksimiTavaroidenMäärä &&
            tavaroidenPaino + tavara.Paino <= maksimiKantoPaino &&
            tavaroidenTilavuus + tavara.Tilavuus <= maksimiTilavuus)
        {
            sisältö[tavaroidenMäärä++] = tavara;
            tavaroidenPaino += tavara.Paino;
            tavaroidenTilavuus += tavara.Tilavuus;
            return true;
        }
        else
        {
            return false;
        }
    }

    // Metodi jäljellä olevan kapasiteetin näyttämiseksi
    public void NäytäKapasiteetti()
    {
        Console.WriteLine($"Reppu sisältää {tavaroidenMäärä} tavaraa.");
        Console.WriteLine($"Paino yhteensä: {tavaroidenPaino}/{maksimiKantoPaino}");
        Console.WriteLine($"Tilavuus yhteensä: {tavaroidenTilavuus}/{maksimiTilavuus}");
    }

    // Ylikirjoitetaan ToString-metodi palauttamaan repun sisällön
    public override string ToString()
    {
        StringBuilder sisältöTeksti = new StringBuilder("Reppussa on seuraavat tavarat: ");
        for (int i = 0; i < tavaroidenMäärä; i++)
        {
            sisältöTeksti.Append(sisältö[i]);
            if (i < tavaroidenMäärä - 1)
            {
                sisältöTeksti.Append(", ");
            }
        }
        return sisältöTeksti.ToString();
    }
}

class Program
{
    // Enum järjestelmä eri tavaroille
    enum TavaraTyypit { Nuoli = 1, Jousi, Köysi, Vesi, RuokaAnnos, Miekka }

    static void Main(string[] args)
    {
        Reppu reppu = new Reppu(5, 10, 10); // Luodaan uusi reppu, jonka maksimikapasiteetit ovat 5 tavaraa, 10 kiloa ja 10 yksikköä tilavuutta

        // Tulostetaan repun sisältö ennen kuin pelaaja lisää tavaroita
        Console.WriteLine(reppu);

        // Lisätään tavaroita reppuun kunnes painoraja ylittyy
        while (true)
        {
            Console.WriteLine("Mitä tavaraa haluat lisätä reppuun?");
            Console.WriteLine("1. Nuoli\n2. Jousi\n3. Köysi\n4. Vesi\n5. Ruoka-annos\n6. Miekka");
            Console.Write("Valitse numero: ");
            int valinta;
            if (!int.TryParse(Console.ReadLine(), out valinta) || valinta < 1 || valinta > 6)
            {
                Console.WriteLine("Virheellinen valinta.");
                continue;
            }

            Tavara tavara = LuoTavara((TavaraTyypit)valinta); // Luodaan valitun tavaran ilmentymä

            // Yritetään lisätä tavara reppuun
            if (tavara != null && reppu.Lisää(tavara))
            {
                Console.WriteLine("Tavara lisätty onnistuneesti reppuun.");
            }
            else
            {
                Console.WriteLine("Tavaran lisäys epäonnistui, reppu on täynnä tai kapasiteetti ylittyy.");
                break;
            }

            // Näytetään reppuun jäljellä olevien kapasiteettien tiedot
            reppu.NäytäKapasiteetti();
        }

        // Näytetään lopuksi reppuun lisättyjen tavaroiden tiedot
        reppu.NäytäKapasiteetti();
    }

    // Metodi, joka luo oikean tavaran valitun enum-arvon perusteella
    static Tavara LuoTavara(TavaraTyypit tyyppi)
    {
        switch (tyyppi)
        {
            case TavaraTyypit.Nuoli:
                return new Nuoli();
            case TavaraTyypit.Jousi:
                return new Jousi();
            case TavaraTyypit.Köysi:
                return new Köysi();
            case TavaraTyypit.Vesi:
                return new Vesi();
            case TavaraTyypit.RuokaAnnos:
                return new RuokaAnnos();
            case TavaraTyypit.Miekka:
                return new Miekka();
            default:
                Console.WriteLine("Virheellinen valinta.");
                return null;
        }
    }
}
