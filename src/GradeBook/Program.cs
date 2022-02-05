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

            book.CalculateStats();        
        }
    }
}
