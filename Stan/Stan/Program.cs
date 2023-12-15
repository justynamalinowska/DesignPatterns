using System;

interface Stan
{
    void Alert();
}

class Powiadomienia
{

    private Stan aktualnyStan;

    public Powiadomienia()
    { aktualnyStan = new Wibracja(); }

    public void UstawStan(Stan stan)
    { aktualnyStan = stan; }

    public void Alert()
    { aktualnyStan.Alert(); }

}

class Dzwonek : Stan
{

    public void Alert()
    { Console.WriteLine("dzwonek..."); }
    
}

class Wibracja : Stan
{

    public void Alert()
    { Console.WriteLine("wibracja..."); }

}

class Wyciszenie : Stan
{

    public void Alert()
    { Console.WriteLine("wyciszenie..."); }

}



class Program
{
    public static void Main(string[] args)
    {
        Powiadomienia powiadomienia = new Powiadomienia();
        powiadomienia.Alert();
        powiadomienia.UstawStan(new Dzwonek());
        powiadomienia.Alert();
        powiadomienia.UstawStan(new Wyciszenie());
        powiadomienia.Alert();
        powiadomienia.UstawStan(new Wyciszenie());
        powiadomienia.Alert();
        powiadomienia.UstawStan(new Wibracja());
        powiadomienia.Alert();
    }
}