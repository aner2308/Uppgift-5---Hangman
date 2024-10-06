using System;

namespace Hangman
{
    public class WordGenerator
    {
        private string[] easyFruits;
        private string[] mediumFruits;
        private string[] hardFruits;

        private string[] easyAnimals;
        private string[] mediumAnimals;
        private string[] hardAnimals;

        private string[] easyCities;
        private string[] mediumCities;
        private string[] hardCities;

        public WordGenerator()
        {
            //Fruktkategori
            easyFruits = ["apple", "banana", "cherry", "grape", "pear", "kiwi"];
            mediumFruits = ["pineapple", "strawberry", "blueberry", "papaya", "orange", "raspberry"];
            hardFruits = ["pomegranate", "watermelon", "blackcurrant", "dragonfruit", "rockmelon", "honeydew"];

            // Djurkategori
            easyAnimals = ["cat", "dog", "horse", "cow", "rat", "snake", "chicken"];
            mediumAnimals = ["elephant", "giraffe", "cheetah", "dolphin", "kangaroo", "octopus", "falcon"];
            hardAnimals = ["chameleon", "rhinoceros", "hippopotamus", "crocodile", "caribou"];

            // Huvudstäder
            easyCities = ["paris", "london", "oslo", "berlin", "rome", "cairo", "tokyo"];
            mediumCities = ["stockholm", "budapest", "ottawa", "lisbon", "vienna", "helsinki"];
            hardCities = ["ouagadougou", "thimphu", "ulaanbaatar", "antanarivo", "zagreb"];
        }

        public string GetRandomWord(string category, string difficulty)
        {
            Random random = new();

            switch (category)
            {
                //Frukter
                case "1":
                    switch (difficulty)
                    {
                        case "1":
                            return easyFruits[random.Next(easyFruits.Length)];
                        case "2":
                            return mediumFruits[random.Next(mediumFruits.Length)];
                        case "3":
                            return hardFruits[random.Next(hardFruits.Length)];
                        default:
                            throw new ArgumentException("Unavailable choice. Please choose between 'easy', 'medium' or 'hard'.");
                    }

                //Djur
                case "2":
                    switch (difficulty)
                    {
                        case "1":
                            return easyAnimals[random.Next(easyAnimals.Length)];
                        case "2":
                            return mediumAnimals[random.Next(mediumAnimals.Length)];
                        case "3":
                            return hardAnimals[random.Next(hardAnimals.Length)];
                        default:
                            throw new ArgumentException("Unavailable choice. Please choose between 'easy', 'medium' or 'hard'.");
                    }

                //Huvudstäder
                case "3":
                    switch (difficulty)
                    {
                        case "1":
                            return easyCities[random.Next(easyCities.Length)];
                        case "2":
                            return mediumCities[random.Next(mediumCities.Length)];
                        case "3":
                            return hardCities[random.Next(hardCities.Length)];
                        default:
                            throw new ArgumentException("Unavailable choice. Please choose between 'easy', 'medium' or 'hard'.");
                    }

                default:
                    throw new ArgumentException("Unavailable choice. Please choose between option [1], [2] and [3]");
            }

        }
    }
}