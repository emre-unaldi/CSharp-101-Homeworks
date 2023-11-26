using System;
using System.Collections;

namespace CollectionsQuestionThree
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.Write("Bir cümle girin : ");
                string sentence = Console.ReadLine();

                if (!(sentence.Trim().Contains(' ')))
                {
                    throw new FormatException("Please enter a sentence!!!");
                }

                string sentenceTrim = sentence.Replace(" ", "");
                char[] vowels = { 'A', 'a', 'E', 'e', 'I', 'ı', 'İ', 'i', 'O', 'o', 'Ö', 'ö', 'U', 'u', 'Ü', 'ü' };
                ArrayList vowelsFound = new ArrayList();

                foreach (char vowel in sentenceTrim)
                {
                    if (vowels.Contains(vowel)) vowelsFound.Add(vowel);
                }
                vowelsFound.Sort();

                Console.WriteLine("Girilen cümlede bulunan sıralanmış sesli harfler :");
                foreach(char vowel in vowelsFound)
                {
                    Console.Write(" " + vowel);
                }
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