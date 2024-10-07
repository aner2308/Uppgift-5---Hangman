using System;
using System.Threading; // Används för Thread.Sleep

namespace Hangman
{
    //Ärver från klassen Player
    public class AIPlayer : Player
    {
        private Random random;

        public AIPlayer(string name) : base(name)
        {
            random = new Random();
        }

        //Override med AI gissning
        public override char Guess()
        {

             // Meddelande med fördröjning för att simulera tänkande
            Console.WriteLine("AI is thinking...");
            Thread.Sleep(1500);

            char guess;

            do
            {
                // Gissar en slumpad bokstav mellan a-z
                guess = (char)random.Next('a', 'z' + 1);
            }

            // Kollar om bokstaven redan gissats
            while (HasAlreadyGuessed(guess));

            // Fördröjning innan nästa gissning visas
            Console.WriteLine($"AI guesses: {guess}");
            Thread.Sleep(1500); 

            // Lägger till gissningen i listan med gissade bokstäver
            AddGuessedLetter(guess); 
            return guess;
        }
    }
}
