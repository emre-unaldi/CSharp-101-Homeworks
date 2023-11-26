using System;

namespace FindingWordAndCharacterCount
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.Write("Bir cümle girin : ");
                string sentence = Console.ReadLine();

                if(!(sentence.Trim().Contains(' '))) {
                    throw new FormatException("Please enter a sentence!!!");
                }

                string[] words = sentence.Split(' ');
                ushort wordCount = 0;
                ushort characterCount = 0;

                foreach (string word in words)
                {
                    wordCount++;
                    characterCount += (ushort)word.Length;
                }

                Console.WriteLine($"Girilen cümle : {sentence}");
                Console.WriteLine($"Girilen cümledeki toplam kelime sayısı : {wordCount}");
                Console.WriteLine($"Girilen cümledeki toplam harf sayısı : {characterCount}");
            }
            catch (FormatException exception)
            {
                Console.WriteLine($"Format dException : {exception.Message}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception : {exception.Message}");
            }
        }
    }
}