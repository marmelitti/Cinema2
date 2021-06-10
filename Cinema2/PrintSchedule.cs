using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema2
{
    public class PrintSchedule
    {
        public static void PrintTable(TimeTable bestTable)
        {

            Console.WriteLine("\nОптимальное расписание работы зала кинотеатра:");

            DateTime startMovieTime = new DateTime(2021, 05, 13, 10, 00, 00);
            Console.WriteLine($"\nРасписание работы зала :");
            foreach (var currentMovie in bestTable.Table)
            {
                DateTime endMovieTime = startMovieTime.AddMinutes(currentMovie.Duration);
                Console.WriteLine($"{startMovieTime.ToShortTimeString()}-{endMovieTime.ToShortTimeString()}  {currentMovie.Name}, продолжительность:{currentMovie.Duration} минут");
                startMovieTime = endMovieTime;
            }
            Console.WriteLine($"Оставшееся свободное время в зале: {bestTable.FreeTime} минут");

        }
    }
}
