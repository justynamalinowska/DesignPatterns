using System;
using System.Collections.Generic;

public interface Kompozyt
{
    void Renderuj();
    void DodajElement(Kompozyt element);
    void UsunElement(Kompozyt element);
}

public class Lisc : Kompozyt
{
    public string nazwa { get; set; }

    public Lisc(string nazwa)
    {
        this.nazwa = nazwa;
    }

    public void DodajElement(Kompozyt element)
    {
        Console.WriteLine("Nie można dodać elementu do liścia");
    }

    public void Renderuj()
    {
        Console.WriteLine("Liść " + nazwa + " rednderowanie...");
    }

    public void UsunElement(Kompozyt element)
    {
        Console.WriteLine("Nie można usunąć elementu z liścia");
    }

}


public class Wezel : Kompozyt
{

    protected List<Kompozyt> Lista = new List<Kompozyt>();

    public string nazwa { get; set; }

    public Wezel(string nazwa)
    {
        this.nazwa = nazwa;     
    }

    public void DodajElement(Kompozyt element)
    {
        Lista.Add(element);
    }

    public void UsunElement(Kompozyt element)
    {
        Lista.Remove(element);
    }

    public void Renderuj()
    {
        Console.WriteLine(nazwa + " rozpoczęcie renderowania");
        foreach (var item in Lista) item.Renderuj();
        Console.WriteLine(nazwa + " zakończenie renderowania");
    }
}


class MainClass
{
    public static void Main(string[] args)
    {
        var korzen = new Wezel("Korzeń");
        korzen.DodajElement(new Lisc("1.1"));

        var wezel2 = new Wezel("Węzeł 2");
        wezel2.DodajElement(new Lisc("2.1"));
        wezel2.DodajElement(new Lisc("2.1"));
        wezel2.DodajElement(new Lisc("2.1"));

        var wezel3 = new Wezel("Węzeł 3");
        wezel3.DodajElement(new Lisc("3.1"));
        wezel3.DodajElement(new Lisc("3.1"));

        var wezel33 = new Wezel("Węzeł 3.3");
        wezel33.DodajElement(new Lisc("3.3.1"));

        korzen.DodajElement(wezel2);
        korzen.DodajElement(wezel3);
        wezel3.DodajElement(wezel33);

        korzen.Renderuj();
    }
}