using System;
using System.Collections.Generic;

namespace Hangman
{
    public class Game
    {
        public Player player;
        public string categoryName;
        public string wordToGuess;
        public string guessedWord;
        public int attemptsLeft;
        private int failedAttempts;
        private List<char> guessedLetters;
        private HangmanDrawings hangmanDrawing;

        public Game(Player player, string wordToGuess, string categoryChoice)
        {
            this.player = player;
            this.wordToGuess = wordToGuess;
            guessedLetters = new List<char>();

            switch (categoryChoice)
            {
                case "1":
                    categoryName = "fruits";
                    break;
                case "2":
                    categoryName = "animals";
                    break;
                case "3":
                    categoryName = "capital cities";
                    break;
                default:
                    categoryName = "unknown";
                    break;
            }

            guessedWord = new string('_', wordToGuess.Length);
            attemptsLeft = 10;
            failedAttempts = 0;
            hangmanDrawing = new HangmanDrawings();
        }

        //Startar spelet
        public void Start()
        {
            Console.Clear();
            Console.WriteLine($"Hello {player.Name}, time to play HANGMAN!");
            Console.WriteLine($"The word has {wordToGuess.Length} letters.");
            Console.WriteLine($"You have {attemptsLeft} attempts!\n");
            Console.WriteLine("Press any key to begin.");
            Console.ReadKey();

            string message = "Good luck!";

            //Loop som kontrollerar om man har några försök kvar, eller gissat rätt
            while (attemptsLeft > 0 && guessedWord != wordToGuess)
            {
                Console.Clear();
                Console.WriteLine($"The category is {categoryName}\n");
                hangmanDrawing.DrawHangmanStage(failedAttempts);
                Console.WriteLine(message);
                Console.WriteLine("");
                Console.WriteLine($"Guessed so far: {guessedWord}");

                //Visar gissade bokstäver
                if (guessedLetters.Count > 0)
                {
                    Console.WriteLine("Letters already guessed: " + string.Join(", ", guessedLetters));
                }

                //Tar spelarens gissade bokstav och binder den till variabeln guess
                char guess = player.Guess();

                //Lägger till gissad bokstav i lista med gissade bokstäver om den inte redan finns
                if (!guessedLetters.Contains(guess))
                {
                    guessedLetters.Add(guess);
                }

                //Kollar om bokstaven är korrekt
                if (wordToGuess.Contains(guess))
                {

                    //Lägger till bokstav i gissade ordet
                    guessedWord = RevealGuessedLetters(guess);

                    //Kontrollerar om alla bokstäver i ordet är hittade
                    if (guessedWord == wordToGuess)
                    {
                        Console.WriteLine("\nCongratulations! You have guessed the word!\n");
                        Console.WriteLine($"<| {wordToGuess.ToUpper()} |>");
                        break; // Grattis! Spelet är över. Bryter loopen
                    }

                    message = "Your guess was correct!";
                }
                //Om man gissat fel...
                else
                {
                    attemptsLeft--;
                    failedAttempts++;
                    hangmanDrawing.DrawHangmanStage(failedAttempts);
                    message = $"Wrong! You have {attemptsLeft} attempts left.";
                }
            }

            //Om spelaren har slut på försök och ordet inte är korrekt gissat
            if (guessedWord != wordToGuess)
            {

                //Meddelande om man förlorat
                Console.WriteLine("\nYou've run out of attempts. The correct word was:");
                Console.WriteLine($"<| {wordToGuess.ToUpper()} |>");
            }

            // Frågar om att spela igen när spelet är över
            AskToPlayAgain();
        }

        //Funktion för att visa korrekt gissade bokstäver
        private string RevealGuessedLetters(char guess)
        {
            //Skapar en lista och fyller den med bokstäverna som man gissat rätt på
            char[] result = guessedWord.ToCharArray();

            //Loopar igenom det hemliga ordet
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                //Om den gissade bokstaven matchar en plats i det hemliga ordet...
                if (wordToGuess[i] == guess)
                {

                    //Byt ut "_" mot den korrekta bokstaven
                    result[i] = guess;
                }
            }

            //Returnerar det updaterade "korrekta gissningar" ordet
            return new string(result);
        }

        // Metod för att fråga spelaren om de vill spela igen
        private void AskToPlayAgain()
        {
            Console.WriteLine("\nWould you like to play again?");
            Console.WriteLine("[1] Yes");
            Console.WriteLine("[2] No\n");

            string? choice = Console.ReadLine();
            if (choice == "1")
            {
                //Startar om spelet från Program-klassen, behåller namn
                Program.StartGame(player.Name); 
            }
            else if (choice == "2")
            {
                //Avslutar spelet
                Console.WriteLine("Thanks for playing!");
            }
            else
            {
                //Kontroll av svar. Ställer frågan igen vid ogiltig inmatning
                Console.WriteLine("Invalid input. Please choose between [1] and [2].");
                AskToPlayAgain(); 
            }
        }
    }
}
