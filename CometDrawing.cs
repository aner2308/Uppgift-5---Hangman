using System;

namespace Hangman
{
    public class CometDrawing
    {
        private string[] stages;

        public CometDrawing()
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

        public void DrawCometStage(int failedAttempts)
        {
            if (failedAttempts >= 0 && failedAttempts < stages.Length)
             {
                Console.WriteLine(stages[failedAttempts]);
             }
        }
    }
}