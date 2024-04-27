using System;

public enum Karki
{
    PUU = 3,
    TERAS = 5,
    TIMANTTI = 50
}

public enum Pera
{
    LEHTI = 0,
    KANANSULKA = 1,
    KOTKANSULKA = 5
}

public class Nuoli
{
    public Karki Karki { get; private set; }
    public Pera Pera { get; private set; }
    public int VarrenPituus { get; private set; }

    public Nuoli(Karki karki, Pera pera, int varren_pituus)
    {
        Karki = karki;
        Pera = pera;
        VarrenPituus = varren_pituus;
    }

    public double PalautaHinta()
    {
        double karki_hinta = (double)Karki;
        double pera_hinta = (double)Pera;
        double varsi_hinta = VarrenPituus * 0.05;
        return karki_hinta + pera_hinta + varsi_hinta;
    }

    public static Nuoli LuoEliittiNuoli()
    {
        return new Nuoli(Karki.TIMANTTI, Pera.KOTKANSULKA, 100);
    }

    public static Nuoli LuoAloittelijanuoli()
    {
        return new Nuoli(Karki.PUU, Pera.KANANSULKA, 70);
    }

    public static Nuoli LuoPerusnuoli()
    {
        return new Nuoli(Karki.TERAS, Pera.KANANSULKA, 85);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Valitse nuolen tyyppi:");
        Console.WriteLine("1. Eliittinuoli");
        Console.WriteLine("2. Aloittelijanuoli");
        Console.WriteLine("3. Perusnuoli");
        Console.WriteLine("4. Luo kustomoitu nuoli");

        int valinta = int.Parse(Console.ReadLine());

        Nuoli valittu_nuoli;

        switch (valinta)
        {
            case 1:
                valittu_nuoli = Nuoli.LuoEliittiNuoli();
                break;
            case 2:
                valittu_nuoli = Nuoli.LuoAloittelijanuoli();
                break;
            case 3:
                valittu_nuoli = Nuoli.LuoPerusnuoli();
                break;
            case 4:
                Console.WriteLine("Valitse nuolen kärki:");
                Console.WriteLine("1. PUU (3 kultaa)");
                Console.WriteLine("2. TERÄS (5 kultaa)");
                Console.WriteLine("3. TIMANTTI (50 kultaa)");
                int karkiValinta = int.Parse(Console.ReadLine());
                Karki valittu_karki = (Karki)karkiValinta;

                Console.WriteLine("Valitse nuolen perä:");
                Console.WriteLine("1. LEHTI (0 kultaa)");
                Console.WriteLine("2. KANANSULKA (1 kulta)");
                Console.WriteLine("3. KOTKANSULKA (5 kultaa)");
                int peraValinta = int.Parse(Console.ReadLine());
                Pera valittu_pera = (Pera)peraValinta;

                Console.WriteLine("Syötä nuolen pituus (senttimetreinä):");
                int valittu_varren_pituus = int.Parse(Console.ReadLine());

                valittu_nuoli = new Nuoli(valittu_karki, valittu_pera, valittu_varren_pituus);
                break;
            default:
                Console.WriteLine("Virheellinen valinta. Luo kustomoitu nuoli.");
                valittu_nuoli = new Nuoli(Karki.PUU, Pera.KANANSULKA, 60);
                break;
        }

        Console.WriteLine("Nuolen hinta on: " + valittu_nuoli.PalautaHinta() + " kultaa");
    }
}
