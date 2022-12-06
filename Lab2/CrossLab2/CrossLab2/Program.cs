﻿namespace Lab2
{

    internal class Program
    {
        private static int Counter(int number)
        {
            int sum = 0;
            if (1 <= number && number <= Int32.MaxValue)
            {
                if (number == 3)
                {
                    sum = 1;
                }
                for (int i = 4; i < number; i++)
                {
                    sum += (i % 2) + (i + 1) % 2;

                }
                return sum;
            }
            else
            {
                throw new ArgumentException("Number should be within 1 and 2147483647.");
            }
        }

        static void Main(string[] args)
        {
            try
            {
                File.WriteAllText("INPUT.txt", Convert.ToString("3"));

                string number = File.ReadAllText(Path.GetFullPath("INPUT.txt"));
                int n = Int32.Parse(number);
                Console.WriteLine("Number is {0}", number);

                int numb = Counter(n);
                Console.WriteLine("Number of variants is {0}", numb);
                File.WriteAllText("OUTPUT.txt", Convert.ToString(numb));



            }
            catch (Exception ex)
            {
                throw new ArgumentOutOfRangeException("Something went wrong.\n", ex);
            }
        }
    }
}