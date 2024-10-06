using System;

namespace Hangman
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(string name) : base(name) { }

        public override char Guess()
        {
            Console.Write("Guess a letter: ");
            string input = Console.ReadLine().ToLower();

            // Validering
            while (string.IsNullOrWhiteSpace(input) || input.Length != 1 || !char.IsLetter(input[0]))
            {
                Console.WriteLine("Invalid input. Please enter a valid letter.");
                input = Console.ReadLine().ToLower();
            }

            return input[0]; // Returnerar bokstaven
        }
    }
}
