using System;

public enum PääraakaAine
{
    Nauta,
    Kana,
    Kasvikset
}

public enum Lisuke
{
    Peruna,
    Riisi,
    Pasta
}

public enum Kastike
{
    Curry,
    Hapanimelä,
    Pippuri,
    Chili
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Valitse pääraaka-aine (0: Nauta, 1: Kana, 2: Kasvikset): ");
        PääraakaAine valittuPääraakaAine = (PääraakaAine)int.Parse(Console.ReadLine());

        Console.WriteLine("Valitse lisuke (0: Peruna, 1: Riisi, 2: Pasta): ");
        Lisuke valittuLisuke = (Lisuke)int.Parse(Console.ReadLine());

        Console.WriteLine("Valitse kastike (0: Curry, 1: Hapanimelä, 2: Pippuri, 3: Chili): ");
        Kastike valittuKastike = (Kastike)int.Parse(Console.ReadLine());

        var ruokaAnnos = (valittuPääraakaAine, valittuLisuke, valittuKastike);

        Console.WriteLine($"Ruoka-annos: {ruokaAnnos}");
    }
}

