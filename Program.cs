using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("╔═════════════════╗");
            Console.WriteLine("║ |H|A|N|G|M|A|N| ║");
            Console.WriteLine("╚═════════════════╝\n");

            Console.Write("Enter player name: ");
            string? playerName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(playerName))
            {
                PlayGame(playerName);
            }
            else
            {
                Console.WriteLine("Player name not found.");
            }
        }

        static void PlayGame(string playerName)
        {
            string category = ChooseCategory();
            string difficulty = ChooseDifficulty();

            // Hämtar ett slumpat ord utifrån kategori och svårighetsgrad
            WordGenerator generatedWord = new();
            string randomWord = generatedWord.GetRandomWord(category, difficulty);

            Game game = new(playerName, randomWord, category);
            game.Start();
        }

        // Metod för att välja kategori
        static string ChooseCategory()
        {
            while (true)
            {
                Console.WriteLine("\nChoose a category.\n");
                Console.WriteLine("[1] Fruits");
                Console.WriteLine("[2] Animals");
                Console.WriteLine("[3] Capital cities\n");

                string? category = Console.ReadLine();
                Console.WriteLine("");

                // Kontrollerar om inmatningen är korrekt
                if (category == "1" || category == "2" || category == "3")
                {
                    return category; // Returnerar om det är ett giltigt val
                }
                else
                {
                    Console.WriteLine("Invalid input. Please choose between [1], [2], and [3].");
                }
            }
        }

        // Metod för att välja svårighetsgrad
        static string ChooseDifficulty()
        {
            while (true)
            {
                Console.WriteLine("\nChoose a difficulty.\n");
                Console.WriteLine("[1] Easy");
                Console.WriteLine("[2] Medium");
                Console.WriteLine("[3] Hard\n");

                string? difficulty = Console.ReadLine();
                Console.WriteLine("");

                //Kontrollerar om inmatning är korrekt
                if (difficulty == "1" || difficulty == "2" || difficulty == "3")
                {
                    return difficulty; // Returnerar om det är ett giltigt val
                }
                else
                {
                    Console.WriteLine("Invalid input. Please choose between [1], [2], and [3].");
                }
            }
        }
    }
}
