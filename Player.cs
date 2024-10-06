using System;

namespace Hangman
{
    public class Player
    {
        public string Name { get; set; }

        public Player(string name)
        {
            Name = name;
        }

        public virtual char MakeGuess()
        {
            Console.WriteLine($"{Name}, guess a letter: ");
            return Console.ReadLine()[0];
        }

        
    }
}