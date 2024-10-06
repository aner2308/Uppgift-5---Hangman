using System;
using System.Collections.Generic;

namespace Hangman
{
    public class Game
    {
        public string playerName;
        public string wordToGuess;
        public string guessedWord;
        public int attemptsLeft;

        public Game(string playerName, string wordToGuess)
        {
            this.playerName = playerName;
            this.wordToGuess = wordToGuess;
            this.guessedWord = new string('_', wordToGuess.Length);
            this.attemptsLeft = 10;
        }

        public void Start()
        {
            Console.WriteLine($"Hello {playerName}, time to play HANGMAN!");
            Console.WriteLine($"The word has {wordToGuess.Length} letters.");
            Console.WriteLine($"You have {attemptsLeft} attempts!");

            while (attemptsLeft > 0 && guessedWord != wordToGuess)
            {
                Console.WriteLine("");
                Console.WriteLine($"Guessed so far: {guessedWord}");
                Console.Write("Guess a letter: ");
                char guess = Console.ReadLine()[0];

                if (wordToGuess.Contains(guess))
                {
                    guessedWord = RevealGuessedLetters(guess);
                    Console.WriteLine("Your guess was correct!");
                }

                else
                {
                    attemptsLeft--;
                    Console.WriteLine($"Wrong! You have {attemptsLeft} attempts left.");
                }
            }
        }

        private string RevealGuessedLetters(char guess)
        {
            char[] result = guessedWord.ToCharArray();

            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if(wordToGuess[i] == guess)
                {
                    result[i] = guess;
                }
            }

            return new string(result);
        }
    }
}