using System;
using System.Collections.Generic;

namespace Hangman
{
    public abstract class Player
    {
        public string Name { get; set; }
        public List<char> GuessedLetters { get; private set; } // Lagrar gissade bokstäver

        public Player(string name)
        {
            Name = name;
            GuessedLetters = new List<char>(); // Initierar listan
        }

        public abstract char Guess();

        // Lägg till en metod för att kolla om en bokstav redan har gissats
        public bool HasAlreadyGuessed(char letter)
        {
            return GuessedLetters.Contains(letter);
        }

        public void AddGuessedLetter(char letter)
        {
            if (!GuessedLetters.Contains(letter))
            {
                GuessedLetters.Add(letter);
            }
        }
    }
}
