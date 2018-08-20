using System;
using System.Collections;
using System.Collections.Generic;

namespace Bingo1
{
    public class BingoGame
    {

        public int numberOfBalls;
        public int segmentSize;
        public int rows;
        public int cols;
        public int bingoCardSize;
        public int[,] bingoCard;
        public List<BingoBall> balls;
        public int ownNumbersCalled = 0;

        public List<BingoBall> chosenBalls;

        public BingoGame(int _numberOfBalls)
        {
            numberOfBalls = _numberOfBalls;
            MakeBalls();
        }

        public void MakeBalls() 
        {
            for (int i = 1; i == numberOfBalls; i++) 
            {
                this.balls.Add(new BingoBall(i));
            }
        }

        public void DrawBalls()
        {
            for (int score = 0; score < numberOfBalls; score++)
            {
                // Randomly selects one of the remaining numbers
                Random rnd = new Random();
                BingoBall ball = this.balls[rnd.Next(this.balls.Count)];


                Console.WriteLine("The {0}th number is {1}", score + 1, ball.number);

                chosenBalls.Add(ball);


                // Check the ball that was just drawn against what is on your card
                ownNumbersCalled = this.checkNumberWasCalled(ball, ownNumbersCalled);


                if (ownNumbersCalled == this.bingoCardSize)
                {
                    Console.WriteLine("Game finished! It took you {0} turns to win.", score + 1);
                    break;
                }

                // Removes the randomly selected number
                this.balls.Remove(ball);

                Console.WriteLine("");
            }
        }

        public int checkNumberWasCalled(BingoBall ball, int ownNumbersCalled)
        {
            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    if (bingoCard[row, col].Equals(ball.number))
                    {
                        Console.WriteLine("Got that!");
                        ownNumbersCalled++;
                        Console.WriteLine("You have had {0} numbers so far", ownNumbersCalled);

                    }
                }
            }
            return ownNumbersCalled;
        }

    }

}



