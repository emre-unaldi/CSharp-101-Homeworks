using System;
using System.Collections;

namespace CollectionsQuestionTwo
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                ArrayList numbers = new ArrayList();

                for (int i = 0; i < 20; i++)
                {
                    Console.Write($"{i + 1}. sayıyı girin : ");
                    uint number = Convert.ToUInt32(Console.ReadLine());
                    numbers.Add((int)number);
                }

                numbers.Sort();
                ArrayList smallestNumbers = numbers.GetRange(0, 3);
                ArrayList largestNumbers = numbers.GetRange(numbers.Count - 3, 3);

                int smallestNumbersTotal = 0;
                int largestNumbersTotal = 0;

                for (int i = 0; i < 3;i++)
                {
                    smallestNumbersTotal += (int)smallestNumbers[i];
                    largestNumbersTotal += (int)largestNumbers[i];
                }

                float smallestNumberAverage = (float)smallestNumbersTotal / 3;
                float largestNumbersAverage = (float)largestNumbersTotal / 3;
                float averageTotal = smallestNumberAverage + largestNumbersAverage;

                Console.WriteLine($"Girilen sayılardan en küçük 3 tanesinin ortalaması : {smallestNumberAverage}");
                Console.WriteLine($"Girilen sayılardan en büyük 3 tanesinin ortalaması : {largestNumbersAverage}");
                Console.WriteLine($"Ortalamaların toplamı : {smallestNumberAverage + largestNumbersAverage}");
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
    }
}