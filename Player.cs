using System;
using System.Collections.Generic;

namespace Hangman
{
    public abstract class Player
    {
        //Namn på spelare
        public string Name { get; set; }

        // Lagrar gissade bokstäver
        public List<char> GuessedLetters { get; private set; } 

        public Player(string name)
        {
            Name = name;
            GuessedLetters = new List<char>();
        }

        public abstract char Guess();

        // En metod för att kolla om en bokstav redan har gissats
        public bool HasAlreadyGuessed(char letter)
        {
            return GuessedLetters.Contains(letter);
        }

        // Lägger till bokstav om den inte redan har gissats på
        public void AddGuessedLetter(char letter)
        {
            if (!GuessedLetters.Contains(letter))
            {
                GuessedLetters.Add(letter);
            }
        }
    }
}
