using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    // public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name {get;}
        // event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        // public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();

    }

    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }
        // Called from Program.cs
        public override void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0) {
                // Add grade to list below
                grades.Add(grade);
                // if(GradeAdded != null)
                // {
                //     GradeAdded(this, new EventArgs());
                // }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}: {grade}");
            }
            
        }

        public void AddGrade(char letter)
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

        public override Statistics GetStatistics()
        {
            // Construct statistics object (from Statistics.cs) & define initial values
            var result = new Statistics();
    
            // Loop through list of grades
            foreach(var grade in grades) {
                result.Add(grade);
            }

            return result;
        }

        // Fields - list of grades (doubles) & book name
        public List<double> grades;  

        // Now inherited from base class NamedObject
        // public string Name
        // {
        //     get;
        //     // Prevents book name from being changed - can only set name from this file when Book first created above
        //     private set;
        // }

        public const string CATEGORY = "Science";

        // public override event GradeAddedDelegate GradeAdded;
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override void AddGrade(double grade)
        {
            // Open text file if exists, otherwise create it - then add entered grade to the file
            // Using statement ensures Dispose() is called (to release the file) regardless of successful grade write (similar to trycatch-finally statement)
           using(var writer = File.AppendText($"{Name}.txt"))
           {
                writer.WriteLine(grade);    
           }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            // Open text file containing grades
            using(var reader = File.OpenText($"{Name}.txt"))
            {
                // Read grade
                var line = reader.ReadLine();
              
                while(line != null){
                    // Convert from str to double & call Add method in Statistics.cs
                    var number = double.Parse(line);
                    result.Add(number);
                    // Read next line from file & repeat - if no next line, break out of while loop
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }
}
    