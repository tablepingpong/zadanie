using System;

namespace zadanieApp
{
    public class Statistics
    {
        public double Sum;

        public int Count;

        public double High;

        public double Low;

        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 5.0:
                        return 'A';

                    case var d when d >= 4.0:
                        return 'B';

                    case var d when d >= 3.0:
                        return 'C';

                    case var d when d >= 3.0:
                        return 'D';

                    default:
                        return 'F';
                }
            }
        }

        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }

        public Statistics()
        {
            Count = 0;
            Sum = 0.0;
            High = double.MinValue;
            Low = double.MaxValue;
        }

        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);
        }
    }
}