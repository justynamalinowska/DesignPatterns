using System;


public interface ITelewizor
{
    int Kanal { get; set; }
    void Wlacz();
    void Wylacz();
    void ZmienKanal(int kanal);
}


public class TvLg : ITelewizor
{
    public TvLg()
    {
        this.Kanal = 1;
    }
    public int Kanal { get; set; }
    public void Wlacz()
    {
        Console.WriteLine("Telewizor LG - włączam się.");
    }
    public void Wylacz()
    {
        Console.WriteLine("Telewizor LG - wyłączam się.");
    }
    public void ZmienKanal(int kanal)
    {
        Console.WriteLine($"Telewizor LG - zmieniam kanał: {kanal}");
        Kanal = kanal;
    }
}



public abstract class PilotAbstrakcyjny
{
    protected ITelewizor tv;
    public PilotAbstrakcyjny(ITelewizor tv)
    {
        this.tv = tv;
        
    }

    public void ZmienKanal(int kanal, string pilotInfo)
    {
            Console.WriteLine($"{pilotInfo} zmienia kanał...");
            tv.ZmienKanal(kanal);
    }
}


    public class PilotHarmony : PilotAbstrakcyjny
    {
    public PilotHarmony(ITelewizor tv) : base(tv) { }

    public void DoWlacz()
    {
        Console.WriteLine("Pilot Harmony - włącz telewizor...");
        tv.Wlacz();
    }

    public void DoWylacz()
    {
        Console.WriteLine("Pilot Harmony - wyłącz telewizor...");
        tv.Wylacz();
    }

    public void DoZmienKanal(int kanal)
    {
        base.ZmienKanal(kanal, "Pilot LG");
    }
}

public class PilotLG : PilotAbstrakcyjny
{
    public PilotLG(ITelewizor tv) : base(tv) { }

    public void DoWlacz()
    {
        Console.WriteLine("Pilot LG - włącz telewizor...");
        tv.Wlacz();
    }

    public void DoWylacz()
    {
        Console.WriteLine("Pilot LG - wyłącz telewizor...");
        tv.Wylacz();
    }

    public void DoZmienKanal(int kanal)
    {
        base.ZmienKanal(kanal, "Pilot LG");
    }
}


class MainClass
{
    public static void Main(string[] args)
    {
        ITelewizor tv = new TvLg();
        PilotHarmony pilotHarmony = new PilotHarmony(tv);
        PilotLG pilotLG = new PilotLG(tv);

        pilotHarmony.DoWlacz();
        Console.WriteLine("Sprawdź kanał - bierzący kanał: " + tv.Kanal);
        pilotLG.DoZmienKanal(100);
        Console.WriteLine("Sprawdź kanał - bierzący kanał: " + tv.Kanal);
        pilotHarmony.DoWylacz();
    }
}
