using System;

namespace Hangman
{

    //En klass som innehåller bilder på en HANGMAN
    public class HangmanDrawings
    {
        private string[] stages;

        public HangmanDrawings()
        {
            stages = new string[]
            {
                @"

                
                
                
                
                
                
                ",
                @"
               




                _________
              /           \
            ================",
            @"
                    ++
                    ||
                    ||
                    ||
                    ||
                ____||___
              /           \
            ================",
            @"
               +====++
                   \||
                    ||
                    ||
                    ||
                ____||___
              /           \
            ================",
                @"
               +====++
               |   \||
                    ||
                    ||
                    ||
                ____||___
              /           \
            ================",
            @"
               +====++
               |   \||
               o    ||
                    ||
                    ||
                ____||___
              /           \
            ================",
            @"
               +====++
               |   \||
               o    ||
               |    ||
                    ||
                ____||___
              /           \
            ================",
            @"
               +====++
               |   \||
               o    ||
              <|    ||
                    ||
                ____||___
              /           \
            ================",
            @"
               +====++
               |   \||
               o    ||
              <|>   ||
                    ||
                ____||___
              /           \
            ================",
            @"
               +====++
               |   \||
               o    ||
              <|>   ||
              /     ||
                ____||___
              /           \
            ================",
            @"
               +====++
               |   \||
               o    ||
              <|>   ||
              / \   ||
                ____||___
              /           \
            ================",
            };
        }

        //Ritar rätt bild beroende på antal felgissningar
        public void DrawHangmanStage(int failedAttempts)
        {
            if (failedAttempts >= 0 && failedAttempts < stages.Length)
             {
                Console.WriteLine(stages[failedAttempts]);
             }
        }
    }
}