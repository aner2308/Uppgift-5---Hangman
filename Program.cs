using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔═════════════════╗");
            Console.WriteLine("║ |H|A|N|G|M|A|N| ║");
            Console.WriteLine("╚═════════════════╝\n");

            Console.WriteLine("Choose a category.\n");
            Console.WriteLine("[1] Fruits");
            Console.WriteLine("[2] Animals");
            Console.WriteLine("[3] Capital cities\n");

            string category = Console.ReadLine();

            Console.WriteLine("Choose a difficulty.\n");
            Console.WriteLine("[1] Easy");
            Console.WriteLine("[2] Medium");
            Console.WriteLine("[3] Hard\n");

            string difficulty = Console.ReadLine();

            WordGenerator generatedWord = new WordGenerator();

            string randomWord = generatedWord.GetRandomWord(category, difficulty);

            Console.WriteLine($"The random word in the cateory of {category} and the difficulty {difficulty} is: {randomWord}");
        }
    }
}