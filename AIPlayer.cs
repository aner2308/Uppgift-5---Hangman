using System;
using System.Threading; // Används för Thread.Sleep

namespace Hangman
{
    public class AIPlayer : Player
    {
        private Random random;

        public AIPlayer(string name) : base(name)
        {
            random = new Random();
        }

        public override char Guess()
        {
            Console.WriteLine("AI is thinking...");
            Thread.Sleep(1500); // Fördröjning för att simulera tänkande

            char guess;
            do
            {
                guess = (char)random.Next('a', 'z' + 1);
            }
            while (HasAlreadyGuessed(guess)); // Kollar om bokstaven redan gissats

            Console.WriteLine($"AI guesses: {guess}");
            Thread.Sleep(1500); // Fördröjning innan nästa gissning visas

            AddGuessedLetter(guess); // Lägger till gissningen i listan
            return guess;
        }
    }
}
