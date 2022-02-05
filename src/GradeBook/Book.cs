using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }
        // Called from Program.cs
        public void AddGrade(double grade)
        {
            // Add grade to list below
            grades.Add(grade);
        }

        public void CalculateStats()
        {
            var result = 0.00;
            var average = 0.00;
            var highestGrade = double.MinValue;
            var lowestGrade = double.MaxValue;

    
            // Loop through list of grades
            foreach(var grade in grades) {
                // Check if grade is higher than current highest - change if so
                if(grade > highestGrade){
                    highestGrade = grade;
                }
                // Could use this instead of the if statement - returns highest of the two values
                // highestGrade = Math.Max(grade, highestGrade);

                // Same for lowest grade
                if(grade < lowestGrade){
                    lowestGrade = grade;
                }
                // lowestGrade = Math.Min(grade, lowestGrade);
           
                // Add grade to total
                result += grade;
            }

            // Calc average based on length of grade list
            average = result / grades.Count;

            // Ouput - :N1 limits to 1dp
            Console.WriteLine(name);
            Console.WriteLine($"The highest grade score is: {highestGrade:N1}");
            Console.WriteLine($"The lowest grade score is: {lowestGrade:N1}");
            Console.WriteLine($"The average grade score is: {average:N1}");
        }

        // Fields - list of grades (doubles) & book name
        private List<double> grades;
        private string name;
    }
}
    