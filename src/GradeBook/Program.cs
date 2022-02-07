using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Kai's Gradebook");

            // Get input from user from command line
            while(true)
            {
                Console.WriteLine("Enter a grade value or 'q' when finished");
                var input = Console.ReadLine();

                // If user types 'q', proceed to calc stats
                if(input == "q")
                {
                    break;
                }

                // Otherwise convert user input from str to double & add grade
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                // If argument exception returned from Book.cs (invalid grade etc.)
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                // Runs regardless of successful try or catch
                finally
                {
                    Console.WriteLine("**");
                }
               
            }

            // book.AddGrade(89.1);
            // book.AddGrade(90.5);
            // book.AddGrade(56.2);

            var stats = book.GetStatistics();
            
            // Ouput - :N1 limits to 1dp
            Console.WriteLine(book.Name);
            Console.WriteLine($"The highest grade score is: {stats.High:N1}");
            Console.WriteLine($"The lowest grade score is: {stats.Low:N1}");
            Console.WriteLine($"The average grade score is: {stats.Average:N1}");      
            Console.WriteLine($"This equates to letter grade: {stats.Letter}");
        }
    }
}
