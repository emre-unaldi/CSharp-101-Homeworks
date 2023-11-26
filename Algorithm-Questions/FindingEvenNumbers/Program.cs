using System;

namespace FindingEvenNumbers
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.Write("Pozitif bir sayı girin : ");
                uint number = Convert.ToUInt32(Console.ReadLine());

                uint[] numberArr = new uint[number];

                for (int i = 0; i < numberArr.Length; i++)
                {
                    Console.Write($"{i + 1}. sayıyı girin : ");
                    numberArr[i] = Convert.ToUInt32(Console.ReadLine());
                }

                Console.WriteLine("Girilen sayılardan çift olan sayılar :");
                for (int i = 0; i < numberArr.Length; i++)
                {
                    if (numberArr[i] % 2 == 0)
                    {
                        Console.WriteLine(numberArr[i]);
                    }
                }
            } catch(FormatException exception)
            {
                Console.WriteLine($"Format Exception : {exception.Message}");
            } catch(OverflowException exception)
            {
                Console.WriteLine($"Negatif Number Exception : {exception.Message}");
            } catch(Exception exception)
            {
                Console.WriteLine($"Exception : {exception}");
            }
        }
    }
}