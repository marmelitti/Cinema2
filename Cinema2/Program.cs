using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema2
{
    class Program
    {
        static void Main(string[] args)
        {
            int cinemaWorkingMinutes = 840;
            List<Movie> userMoviesList = new List<Movie>();
            int movieCount;

            Console.WriteLine("Введите количество фильмов в прокате:");
            movieCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Для каждого фильма из проката необходимо предоставить более подробную информацию о нем (название и продолжительности фильма в минутах):");
            for (int i = 1; i <= movieCount; i++)
            {
                Console.WriteLine($"Введите название фильма № {i}:");
                string mName = Console.ReadLine();
                Console.WriteLine($"Введите длительность фильма №{i} (в минутах):");
                int mDuration = Convert.ToInt32(Console.ReadLine());
                userMoviesList.Add(new Movie { Duration = mDuration, Name = mName });
            }

            GraphTree cinemaTable = new GraphTree(userMoviesList, cinemaWorkingMinutes);
            cinemaTable.CreateTree();
            TimeTable optimalTable = cinemaTable.FindOptimalTable();
            PrintSchedule.PrintTable(optimalTable);
        }
    }
}
