using System;

namespace Hangman
{
    public class WordGenerator
    {
        private string[] easyWords;
        private string[] mediumWords;
        private string[] hardWords;


        public WordGenerator()
        {
            easyWords = new string[] { "apple", "banana", "grape", "pear", "kiwi" };

            mediumWords = new string[] { "pineapple", "strawberry", "blueberry", "orange", "raspberry" };

            hardWords = new string[] { "pomegranate", "watermelon", "blackcurrant", "dragonfruit", "rockmelon", "honeydew" };
        }

        public string GetRandomWord(string difficulty)
        {
            Random random = new();

            switch (difficulty)
            {
                case "1":
                    return easyWords[random.Next(easyWords.Length)];
                case "2":
                    return mediumWords[random.Next(mediumWords.Length)];
                case "3":
                    return hardWords[random.Next(hardWords.Length)];
                default:
                    throw new ArgumentException("Unavailable choice. Please choose between 'easy', 'medium' or 'hard'.");
            }
            
        }
    }
}