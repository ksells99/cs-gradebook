using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Kai's Gradebook");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(56.2);

            var stats = book.GetStatistics();
            
            // Ouput - :N1 limits to 1dp
            Console.WriteLine(book.name);
            Console.WriteLine($"The highest grade score is: {stats.High:N1}");
            Console.WriteLine($"The lowest grade score is: {stats.Low:N1}");
            Console.WriteLine($"The average grade score is: {stats.Average:N1}");        
        }
    }
}
