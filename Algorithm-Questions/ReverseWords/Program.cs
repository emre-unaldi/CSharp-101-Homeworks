using System;

namespace ReverseWords
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.Write("Poizitif bir sayı girin : ");
                uint number = Convert.ToUInt32(Console.ReadLine());

                string[] wordsArr = new string[number];

                for (int i = 0; i < wordsArr.Length; i++)
                {
                    Console.Write($"{i + 1}. kelimeyi girin : ");
                    string input = wordsArr[i] = Convert.ToString(Console.ReadLine());

                    if(IsNumeric(input))
                    {
                        throw new FormatException("You cannot enter numbers as words");
                    } else
                    {
                        wordsArr[i] = input;
                    }
                }

                Console.WriteLine("Dizi elemanlarını tersten yazma : ");
                for(int i = wordsArr.Length - 1; i >= 0; i--)
                {
                    Console.WriteLine(wordsArr[i]);
                }
            }
            catch (FormatException exception)
            {
                Console.WriteLine($"Format Exception : {exception.Message}");
            }
            catch (OverflowException exception)
            {
                Console.WriteLine($"Negative Number Exception : {exception.Message}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception : {exception.Message}");
            }
        }

        private static bool IsNumeric(string input)
        {
            return int.TryParse(input, out _) || double.TryParse(input, out _);
        }
    }
}