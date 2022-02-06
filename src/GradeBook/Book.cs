using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }
        // Called from Program.cs
        public void AddGrade(double grade)
        {
            // Add grade to list below
            grades.Add(grade);
        }

        public Statistics GetStatistics()
        {
            // Construct statistics object (from Statistics.cs) & define initial values
            var result = new Statistics();
            result.Average = 0.00;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            result.Total = 0.00;

    
            // Loop through list of grades
            foreach(var grade in grades) {
                // Check if grade is higher than current highest - change if so
                if(grade > result.High){
                    result.High = grade;
                }
                // Could use this instead of the if statement - returns highest of the two values
                // result.High = Math.Max(grade, result.High);

                // Same for lowest grade
                if(grade < result.Low){
                    result.Low = grade;
                }
                // result.Low = Math.Min(grade, result.Low);
           
                // Add grade to total
                result.Total += grade;
            }

            // Calc average based on length of grade list
            result.Average = result.Total / grades.Count;

            return result;
            
        }

        // Fields - list of grades (doubles) & book name
        private List<double> grades;
        public string Name;
    }
}
    