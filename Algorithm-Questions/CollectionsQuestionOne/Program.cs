using System;
using System.Collections;

namespace CollectionsQuestionOne
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                ArrayList primeNumbers = new ArrayList();
                ArrayList nonPrimeNumbers = new ArrayList();

                for (int i = 0; i < 20; i++)
                {
                    Console.Write($"{i + 1}. sayıyı girin : ");
                    uint number = Convert.ToUInt32(Console.ReadLine());

                    if (IsPrimeNumber((int)number))
                    {
                        primeNumbers.Add(number);
                    }
                    else
                    {
                        nonPrimeNumbers.Add(number);
                    }
                }

                primeNumbers.Sort();
                primeNumbers.Reverse();

                nonPrimeNumbers.Sort();
                nonPrimeNumbers.Reverse();

                int primeNumbersTotal = 0;
                int nonPrimeNumbersTotal = 0;

                Console.WriteLine("---------------------------------------");
                Console.Write("Girilen dizideki asal olan sayılar :");
                foreach (uint number in primeNumbers)
                {
                    Console.Write(" " + number);
                    primeNumbersTotal += (int)number;
                }
                float primeNumbersAverage = (float)primeNumbersTotal / primeNumbers.Count;
                Console.WriteLine($"\nAsal sayılar olan dizideki eleman sayısı : {primeNumbers.Count}");
                Console.WriteLine($"Asal sayılar olan dizideki elemanların ortalması : {primeNumbersAverage}");

                Console.WriteLine("---------------------------------------");

                Console.Write("Girilen dizideki asal olmayan sayılar :");
                foreach (uint number in nonPrimeNumbers)
                {
                    Console.Write(" " + number);
                    nonPrimeNumbersTotal += (int)number;
                }
                float nonPrimeNumbersAverage = (float)nonPrimeNumbersTotal / nonPrimeNumbers.Count;
                Console.WriteLine($"\nAsal sayılar olmayan dizideki eleman sayısı : {nonPrimeNumbers.Count}");
                Console.WriteLine($"Asal sayılar olmaayan dizideki elemanların ortalması : {nonPrimeNumbersAverage}");
            }
            catch (FormatException exception)
            {
                Console.WriteLine($"Format exception : {exception.Message}");
            }
            catch (OverflowException exception)
            {
                Console.WriteLine($"Negative number exception : {exception.Message}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception : {exception.Message}");
            }
        }

        public static bool IsPrimeNumber(int number)
        {
            if (number < 2) return false;
            if (number == 2) return true;

            int squareRoot = (int)Math.Sqrt(number);

            for (int i = 2; i <= squareRoot; i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}