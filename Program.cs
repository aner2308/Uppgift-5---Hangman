using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till Hangman!\n");

            Console.WriteLine("Choose a difficulty.\n");
            Console.WriteLine("[1] Easy");
            Console.WriteLine("[2] Medium");
            Console.WriteLine("[3] Hard");

            string difficulty = Console.ReadLine();

            WordGenerator generatedWord = new WordGenerator();

            string randomWord = generatedWord.GetRandomWord(difficulty);

            Console.WriteLine($"{randomWord}");
        }
    }
}