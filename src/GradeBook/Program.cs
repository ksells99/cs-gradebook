using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new InMemoryBook("Kai's Gradebook");

            EnterGrades(book);

            var stats = book.GetStatistics();

            // Ouput - :N1 limits to 1dp. Category comes from InMemoryBook itself, not via a reference - due to it being a const
            Console.WriteLine($"{book.Name} for {InMemoryBook.CATEGORY}");
            Console.WriteLine($"The highest grade score is: {stats.High:N1}");
            Console.WriteLine($"The lowest grade score is: {stats.Low:N1}");
            Console.WriteLine($"The average grade score is: {stats.Average:N1}");
            Console.WriteLine($"This equates to letter grade: {stats.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            // Get input from user from command line
            while (true)
            {
                Console.WriteLine("Enter a grade value or 'q' when finished");
                var input = Console.ReadLine();

                // If user types 'q', proceed to calc stats
                if (input == "q")
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
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                // Runs regardless of successful try or catch
                finally
                {
                    Console.WriteLine("**");
                }

            }
        }
    }
}
