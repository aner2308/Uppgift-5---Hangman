using System;

namespace Hangman
{
    public class WordGenerator
    {
        private string[] words;

        public WordGenerator()
        {
            words = new string[] {"apple", "banana", "watermelon", "pomegranate"};
        }

        public string GetRandomWord()
        {
            Random random = new();
            return words[random.Next(words.Length)];
        }
    }
}