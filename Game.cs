using System;
using System.Collections.Generic;

namespace Hangman
{
    public class Game
    {
        public string playerName;
        public string categoryName;
        public string wordToGuess;
        public string guessedWord;
        public int attemptsLeft;
        private int failedAttempts;
        private List<char> guessedLetters;
        private CometDrawing cometDrawing;

        public Game(string playerName, string wordToGuess, string categoryChoice)
        {
            this.playerName = playerName;
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
            Console.WriteLine($"Hello {playerName}, time to play HANGMAN!");
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

                char guess = GetValidGuess();

                if (!guessedLetters.Contains(guess))
                {
                    guessedLetters.Add(guess);

                }

                if (wordToGuess.Contains(guess))
                {
                    guessedWord = RevealGuessedLetters(guess);

                    if (guessedWord == wordToGuess)
                    {
                        
                        Console.Clear();
                        Console.WriteLine("Congratulations! You did it!");
                        Console.WriteLine($"the word was: {wordToGuess}");

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
        }

        //Kontrollerar om gissningen är en bokstav a-z
        private char GetValidGuess()
        {
            while (true)
            {
                Console.Write("Guess a letter: ");
                string input = Console.ReadLine().ToLower();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Error: You must enter a letter.");
                }
                else if (input.Length != 1)
                {
                    Console.WriteLine("Error: Please enter only one letter.");
                }
                else if (!char.IsLetter(input[0]))
                {
                    Console.WriteLine("Error: Please enter a valid letter (a-z).");
                }
                else
                {
                    return input[0]; // Returnerar gissningen om den är giltig
                }
            }
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
    }
}