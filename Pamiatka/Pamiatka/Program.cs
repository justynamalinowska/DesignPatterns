using System;
using System.Collections.Generic;

namespace Pamiatka
{

    public interface IMovie
    {
        void SetYear(int year);
        IMemento Save();
        void Restore(IMemento memento);
    }

    class BackToTheFuture : IMovie
    {
        private int Year;

        public BackToTheFuture(int year)
        {
            Year = year;
            Console.WriteLine("Początkowy rok: " + year);
        }

        public void SetYear(int year)
        {
            Year = year;
            Console.WriteLine("Rok zmieniony na: " + year);
        }

        public IMemento Save()
        {
            return new Memento(this.Year);
        }

        public void Restore(IMemento memento)
        {
            SetYear(memento.GetYear());
            Console.WriteLine("Przywrócony rok: " + memento.GetYear());
        }
    }

    public interface IMemento
    {
        int GetYear();
    }

    class Memento : IMemento
    {
        private int Year;

        public Memento(int year)
        {
            Year = year;
        }

        public int GetYear()
        {
            return Year;
        }
    }

    class Caretaker
    {
        private List<IMemento> Mementos = new List<IMemento>();

        private IMovie movie;

        public Caretaker(IMovie movie)
        {
            this.movie = movie;
        }

        public void Save()
        {
            IMemento memento = movie.Save();
            Mementos.Add(memento);
            Console.WriteLine("Zapisano pamiątkę z roku: " + memento.GetYear());
        }

        public void Undo()
        {
            if (Mementos.Count == 0)
            {
                Console.WriteLine("Nie można cofnąć - brak zapisanych danych");
                return;

            }

            var memento = this.Mementos[this.Mementos.Count - 1];

            Mementos.Remove(memento);
            movie.Restore(memento);

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BackToTheFuture favoriteMovie = new BackToTheFuture(1985);
            Caretaker caretaker = new Caretaker(favoriteMovie);

            caretaker.Undo(); // test 😉

            Console.WriteLine();

            Console.WriteLine("Część I:");
            favoriteMovie.SetYear(1955);
            caretaker.Save();
            favoriteMovie.SetYear(1985);

            Console.WriteLine();

            Console.WriteLine("Część II:");
            favoriteMovie.SetYear(2015);
            favoriteMovie.SetYear(1985);
            caretaker.Undo();
            favoriteMovie.SetYear(1985);
            caretaker.Save();

            Console.WriteLine();

            Console.WriteLine("Część III:");
            favoriteMovie.SetYear(1885);
            caretaker.Undo();

        }
    }
}