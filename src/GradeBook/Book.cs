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
            if(grade <= 100 && grade >= 0) {
                // Add grade to list below
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}: {grade}");
            }
            
        }

        public void AddLetterGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                case 'F':
                    AddGrade(20);
                    break;
                default:
                    AddGrade(0);
                    break;
            }

        }

        public Statistics GetStatistics()
        {
            // Construct statistics object (from Statistics.cs) & define initial values
            var result = new Statistics();
            result.Average = 0.00;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            result.Total = 0.00;

    
            // Loop through list of grades - few ways to do it

            // 1) FOREACH
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

            // 2) WHILE LOOP
            // var index = 0;
            // while(index < grades.Count )
            // {
            //     if(grades[index] > result.High){
            //         result.High = grades[index];
            //     }

            //     if(grades[index] < result.Low){
            //         result.Low = grades[index];
            //     }
        
            //     result.Total += grades[index];

            //     index++;
            // };

            // 3) FOR LOOP
            // for(var i = 0; i < grades.Count; i++)
            // {
            //     if(grades[i] > result.High){
            //         result.High = grades[i];
            //     }

            //     if(grades[i] < result.Low){
            //         result.Low = grades[i];
            //     }
        
            //     result.Total += grades[i];
            // };


            // Calc average based on length of grade list
            result.Average = result.Total / grades.Count;
            
            // Calc letter grade equivalent based on avg number grade
            switch(result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }

            return result;
            
        }

        // Fields - list of grades (doubles) & book name
        public List<double> grades;
        public string Name;
    }
}
    