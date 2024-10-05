using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till Hangman!");

            WordGenerator generatedWord = new WordGenerator();

            string randomWord = generatedWord.GetRandomWord();

            Console.WriteLine($"{randomWord}");
        }
    }
}