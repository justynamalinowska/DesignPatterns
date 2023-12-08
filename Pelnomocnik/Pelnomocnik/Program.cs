using System;
using System.Collections.Generic;

namespace Pelnomocnik
{

    public class User
    {

        private bool HasAdminPrivilages;

        public User(bool hasAdminPrivilages)
        {
            HasAdminPrivilages = hasAdminPrivilages;
        }

        public void MakeAdmin()
        {
            HasAdminPrivilages = true;
        }

        public bool IsAdmin()
        {
            return HasAdminPrivilages;
        }

    }

    public interface Information
    {
        public abstract void DisplayData();
        public abstract void DisplayRestrictedData();
    }

    public class Database : Information
    {

        private Dictionary<string, double> Map;

        public Database()
        {
            // stworzenie bazy użytkowników
            // i uzupełnienie wartości
            Map = new Dictionary<string, double>();
            Map.Add("Zyzio McKwacz", 2500);
            Map.Add("Scooby Doo", 11.4);
            Map.Add("Adam Mackiewicz", 15607.95);
            Map.Add("Rick Morty", 429.18);
        }

        public void DisplayData()
        {
            Console.WriteLine("Użytkownicy:");
            foreach (var u in Map)
            {
                Console.WriteLine(u.Key);
            }
        }

        public void DisplayRestrictedData()
        {

            foreach (var u in Map)
            {
                Console.WriteLine($"{u.Key} zarabia {u.Value} zł miesięcznie");
            }
        }

    }

    public class DatabaseGuard : Information
    {

        private Database DB;
        private User user;

        public DatabaseGuard(User u)
        {
            user = u;
            DB = new Database();
            // stworzenie obiektu DB i przypisanie do pola
            // u? pewnie pole ;)
        }

        public void DisplayData()
        {
            DB.DisplayData();
        }

        public void DisplayRestrictedData()
        {
            if (user.IsAdmin())
            {
                DB.DisplayRestrictedData();
            }
            else
            {
                Console.WriteLine("Nie masz wystarczających uprawnień");
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            var Zbyszek = new User(false);
            var db = new DatabaseGuard(Zbyszek);

            db.DisplayData();

            Console.WriteLine("---------------------------------------------------------");

            db.DisplayRestrictedData();

            Console.WriteLine("---------------------------------------------------------");

            Zbyszek.MakeAdmin();
            db.DisplayRestrictedData();

        }
    }

}