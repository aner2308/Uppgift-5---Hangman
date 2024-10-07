using System;

namespace Hangman
{
    class Program
    {

        //Startsida för programmet
        static void Main(string[] args)
        {

            //Meny
            Console.Clear();
            Console.WriteLine("╔═════════════════╗");
            Console.WriteLine("║ |H|A|N|G|M|A|N| ║");
            Console.WriteLine("╚═════════════════╝\n");

            // Ber om namn
            Console.Write("Enter player name: ");
            string? playerName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(playerName))
            {
                //Startar spel
                StartGame(playerName);
            }
            else
            {
                //Ber om namn igen
                Console.WriteLine("Player name not found.");
            }
        }


        //Startar spelmekanik med spelarens namn som inmatning
        public static void StartGame(string playerName)
        {

            //Ber spelaren välja mellan "AI" och att spela själv
            Console.Clear();
            Console.WriteLine("Choose mode:");
            Console.WriteLine("[1] Play yourself");
            Console.WriteLine("[2] Let AI play");

            string? choice = Console.ReadLine();
            Player player;

            //Använder klassen HumanPlayer eller AIPlayer beroende på spelarens val
            if (choice == "1")
            {
                player = new HumanPlayer(playerName);
            }
            else
            {
                player = new AIPlayer(playerName);
            }

            //Metoder för att välja kategori och svårighet
            string category = ChooseCategory();
            string difficulty = ChooseDifficulty();

            // Hämtar ett slumpat ord utifrån kategori och svårighetsgrad
            WordGenerator generatedWord = new();
            string randomWord = generatedWord.GetRandomWord(category, difficulty);

            //Startar spel med de valda parametrarna
            Game game = new(player, randomWord, category);
            game.Start();
        }

        // Metod för att välja kategori
        static string ChooseCategory()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nChoose a category.\n");
                Console.WriteLine("[1] Fruits");
                Console.WriteLine("[2] Animals");
                Console.WriteLine("[3] Capital cities\n");

                string? category = Console.ReadLine();
                Console.WriteLine("");

                if (category == "1" || category == "2" || category == "3")
                {
                    // Returnerar om det är ett giltigt val
                    return category; 
                }
                else
                {
                    //Felmeddelande om det är ett ogiltigt val
                    Console.WriteLine("Invalid input. Please choose between [1], [2], and [3].");
                }
            }
        }

        // Metod för att välja svårighetsgrad
        static string ChooseDifficulty()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nChoose a difficulty.\n");
                Console.WriteLine("[1] Easy");
                Console.WriteLine("[2] Medium");
                Console.WriteLine("[3] Hard\n");

                string? difficulty = Console.ReadLine();
                Console.WriteLine("");

                if (difficulty == "1" || difficulty == "2" || difficulty == "3")
                {
                    Console.Clear();
                    // Returnerar om det är ett giltigt val
                    return difficulty;
                }
                else
                {
                    //Felmeddelande om det är ett ogiltigt val
                    Console.WriteLine("Invalid input. Please choose between [1], [2], and [3].");
                }
            }
        }
    }
}
