using System;

namespace Hangman
{
    public class AIPlayer : Player{
        public AIPlayer(string name) : base(name)
        {
        }

        public override char MakeGuess()
        {
            Random random = new();
            char guess = (char)('a' + random.Next(0,26));
            Console.WriteLine($"{Name} AI guessed: {guess}");
            return guess;
        }
    }
}