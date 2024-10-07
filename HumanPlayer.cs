using System;

namespace Hangman
{
    //Ärver från klassen Player
    public class HumanPlayer : Player
    {
        public HumanPlayer(string name) : base(name) { }

        //Override med spelarens gissning
        public override char Guess()
        {
            Console.Write("Guess a letter: ");
            string? input = Console.ReadLine();

            // Validerar att gissningen är en bokstav, och bara ett tecken lång
            while (string.IsNullOrWhiteSpace(input) || input.Length != 1 || !char.IsLetter(input[0]))
            {
                Console.WriteLine("Invalid input. Please enter a valid letter.");
                input = Console.ReadLine();
            }

            // Returnerar bokstaven
            return input.ToLower()[0];
        }
    }
}
