using System;

namespace FindingEqualsNumbers
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.Write("Birinci pozitif sayıyı girin : ");
                uint numberOne = Convert.ToUInt32(Console.ReadLine());

                Console.Write("İkinci pozitif sayıyı girin : ");
                uint numberTwo = Convert.ToUInt32(Console.ReadLine());

                uint[] positiveNumbersArr = new uint[numberOne];

                for(int i = 0; i < positiveNumbersArr.Length; i++)
                {
                    Console.Write($"{i + 1}. sayıyı girin :");
                    positiveNumbersArr[i] = Convert.ToUInt32(Console.ReadLine());
                }

                Console.WriteLine($"{numberTwo} sayısına eşit olan veya tam bölünen sayılar : ");

                for(int i = 0;i < positiveNumbersArr.Length; i++)
                {
                    if ((positiveNumbersArr[i] == numberTwo) || (numberTwo % positiveNumbersArr[i] == 0))
                    {
                        Console.WriteLine(positiveNumbersArr[i]);
                    }
                }
            } catch (FormatException exception) 
            { 
                Console.WriteLine($"Format Exception : {exception.Message}");
            } catch (OverflowException exception)
            { 
                Console.WriteLine($"Negative Number Exception : {exception.Message}");
            } catch (Exception exception) 
            {
                Console.WriteLine($"Exception : {exception.Message}");
            }
        }
    }
}