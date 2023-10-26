using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WzorzecFasada
{

    interface IUserService
    {
        void CreateUser(string email);
        void DeleteUser(string email);
        void Counter();
    }

    static class EmailNotification
    {
        public static void SendEmail(string to, string subject)
        {
            Console.WriteLine("Sending an email");
        }
    }

    class UserRepository
    {
        private readonly List<string> users = new List<string>
        {
            "john.doe@gmail.com", "sylvester.stallone@gmail.com"
        };

        public bool IsEmailFree(string email)
        {
            foreach (var u in users)
            {
                if (email == u)
                {
                    return false;
                }
            }
            return true;
            //dopisz implementacje, która zwróci informacje o tym czy email jest dostępny
        }

        public void AddUser(string email)
        {
            users.Add(email);
            //dopisz implementacje, która doda użytkownika do listy
        }

        public void RemoveUser(string email)
        {
            users.Remove(email);
        }
    }

    static class Validators
    {
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase);
        }
    }

    class UserService : IUserService
    {
        int counter = 2;
        private readonly UserRepository userRepository = new UserRepository();
        public void CreateUser(string email)
        {
            if (!Validators.IsValidEmail(email))
            {
                throw new ArgumentException("Błędny email");
            }

            if (!userRepository.IsEmailFree(email))
            {
                throw new ArgumentException("Zajęty email");
            }

            userRepository.AddUser(email);
            EmailNotification.SendEmail(email, "Welcome to our service");
            Console.WriteLine("Welcome to our service " + email);
            counter++;
        }

        public void DeleteUser(string email)
        {
            if (userRepository.IsEmailFree(email))
            {
                throw new ArgumentException("Użytkownik nie istnieje");
            }
            userRepository.RemoveUser(email);
            EmailNotification.SendEmail(email, "Goodbye from our service");
            Console.WriteLine("Goodbye " + email);
            counter--;
        }

        public void Counter()
        {
            Console.WriteLine("Aktualna liczba adresów: " + counter);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IUserService userService = new UserService();
            userService.Counter();
            userService.CreateUser("someemail@gmail.com");
            userService.Counter();
            userService.DeleteUser("john.doe@gmail.com");
            userService.Counter();
        }
    }

}