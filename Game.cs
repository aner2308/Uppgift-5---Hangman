using System;
using System.Collections.Generic;

namespace Hangman
{
    public class Game
    {
        public Player player;
        public string categoryName;
        public string wordToGuess;
        public string guessedWord;
        public int attemptsLeft;
        private int failedAttempts;
        private List<char> guessedLetters;
        private CometDrawing cometDrawing;

        public Game(Player player, string wordToGuess, string categoryChoice)
        {
            this.player = player;
            this.wordToGuess = wordToGuess;
            guessedLetters = new List<char>();

            switch (categoryChoice)
            {
                case "1":
                    categoryName = "fruits";
                    break;
                case "2":
                    categoryName = "animals";
                    break;
                case "3":
                    categoryName = "capital cities";
                    break;
                default:
                    categoryName = "unknown";
                    break;
            }

            guessedWord = new string('_', wordToGuess.Length);
            attemptsLeft = 10;
            failedAttempts = 0;
            cometDrawing = new CometDrawing();
        }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine($"Hello {player.Name}, time to play HANGMAN!");
            Console.WriteLine($"The word has {wordToGuess.Length} letters.");
            Console.WriteLine($"You have {attemptsLeft} attempts!\n");
            Console.WriteLine("Press any key to begin.");
            Console.ReadKey();

            string message = "Good luck!";

            while (attemptsLeft > 0 && guessedWord != wordToGuess)
            {
                Console.Clear();
                Console.WriteLine($"The category is {categoryName}\n");
                cometDrawing.DrawCometStage(failedAttempts);
                Console.WriteLine(message);
                Console.WriteLine("");
                Console.WriteLine($"Guessed so far: {guessedWord}");

                if (guessedLetters.Count > 0)
                {
                    Console.WriteLine("Letters already guessed: " + string.Join(", ", guessedLetters));
                }

                char guess = player.Guess();

                if (!guessedLetters.Contains(guess))
                {
                    guessedLetters.Add(guess);
                }

                if (wordToGuess.Contains(guess))
                {
                    guessedWord = RevealGuessedLetters(guess);

                    if (guessedWord == wordToGuess)
                    {
                        Console.WriteLine("\nCongratulations! You have guessed the word!\n");
                        Console.WriteLine($"<| {wordToGuess.ToUpper()} |>");
                        break; // Spelet är över
                    }

                    message = "Your guess was correct!";
                }
                else
                {
                    attemptsLeft--;
                    failedAttempts++;
                    cometDrawing.DrawCometStage(failedAttempts);
                    message = $"Wrong! You have {attemptsLeft} attempts left.";
                }
            }

            if (guessedWord != wordToGuess)
            {
                Console.WriteLine("\nYou've run out of attempts. The correct word was:");
                Console.WriteLine($"<| {wordToGuess.ToUpper()} |>");
            }

            AskToPlayAgain(); // Frågar om att spela igen när spelet är över
        }

        private string RevealGuessedLetters(char guess)
        {
            char[] result = guessedWord.ToCharArray();

            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (wordToGuess[i] == guess)
                {
                    result[i] = guess;
                }
            }

            return new string(result);
        }

        // Metod för att fråga spelaren om de vill spela igen
        private void AskToPlayAgain()
        {
            Console.WriteLine("\nWould you like to play again?");
            Console.WriteLine("[1] Yes");
            Console.WriteLine("[2] No");

            string? choice = Console.ReadLine();
            if (choice == "1")
            {
                Program.StartGame(player.Name); // Startar spelet om från Program-klassen
            }
            else if (choice == "2")
            {
                Console.WriteLine("Thanks for playing!");
            }
            else
            {
                Console.WriteLine("Invalid input. Please choose between [1] and [2].");
                AskToPlayAgain(); // Ställer frågan igen vid ogiltig inmatning
            }
        }
    }
}
