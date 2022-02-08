namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return Total / Count;
            }
        }
        public double High;
        public double Low;
        public double Total;
        public char Letter
        {
            get
            {
                // Calc letter grade equivalent based on avg number grade
                switch(Average)
                {
                case var d when d >= 90.0:
                    return 'A';
                case var d when d >= 80.0:
                    return 'B';
                case var d when d >= 70.0:
                    return 'C';
                case var d when d >= 60.0:
                    return 'D';
                default:
                    return 'F';
                }
            }
        }
        public int Count;

        public void Add(double number)
        {
            Total += number;
            Count++;

            // Check if grade is higher than current highest - change if so
            if(number > High)
            {
                High = number;
            }
            // Could use this instead of the if statement - returns highest of the two values
            // High = Math.Max(number, High);

            // Same for lowest grade
            if(number < Low)
            {
                Low = number;
            }
            // Low = Math.Min(number, Low);
        }

        public Statistics()
        {
            Count = 0;
            High = double.MinValue;
            Low = double.MaxValue;
            Total = 0.00;
        }
    }
}