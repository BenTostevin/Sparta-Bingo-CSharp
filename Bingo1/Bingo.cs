using System;
using System.Linq;
using System.Collections;
namespace Bingo1
{
    class BingoGame
    {
        static void Main(string[] args)
        {
            
            int number_of_balls = 75;
            int segmentSize = 15;
            int bingoCardRows = 5;
            int bingoCardCols = 5;
            int bingoCardSize = bingoCardRows * bingoCardCols;

            int[,] bingoCard = new int[bingoCardRows, bingoCardCols];



            // Create bingo card by selecting your numbers
            for (var row = 0; row < bingoCardRows; row++)
            {
                for (var col = 0; col < bingoCardCols; col++)
                {
                    bool valid_number = false;

                    while (valid_number == false)
                    {

                        int nthNumber = (row * bingoCardCols) + (col);
                        int lowerBound = bingoMethods.createLowerBound(segmentSize, row, col, bingoCardRows, bingoCardCols);
                        int upperBound = bingoMethods.createUpperBound(segmentSize, row, col, bingoCardRows, bingoCardCols);    


                        Console.WriteLine("Select your {0}th number between {1} and {2}.", nthNumber + 1, lowerBound, upperBound);
                        int candidate = int.Parse(Console.ReadLine());


                        valid_number = bingoMethods.checkValid(candidate, upperBound, lowerBound, bingoCardRows, bingoCardCols, bingoCard);
                        if (valid_number == true)
                        {
                            bingoCard[row, col] = candidate;
                        }
                    }
                }
            }




            // Select numbers for your card - End


            bingoMethods.confirmCard (bingoCardRows, bingoCardCols, bingoCard);



            // Create array list of 1 to 75 START
            ArrayList remaining_numbers = new ArrayList();

            for (int i = 1; i < number_of_balls+1; i++)
            {
                remaining_numbers.Add(i);
            }
            // Create array list of 1 to 75 END



            // There will be 75 rounds - a round for each bingo ball
            //int rounds = remaining_numbers.Count;


            ArrayList chosen_nums = new ArrayList();

            // score - how many turns did it take you to get all of your numbers
            // score is tracked by using the for loop's counter below
            int ownNumbersCalled = 0;


            // This loop removes one number from the list array for each round
            for (int score = 0; score < number_of_balls; score++)
            {
                // Randomly selects one of the remaining numbers
                Random rnd = new Random();
                int next_num_index = rnd.Next(0, remaining_numbers.Count);
                int drawn_ball_number = (int)remaining_numbers[next_num_index];


                Console.WriteLine("The {0}th number is {1}", score + 1, drawn_ball_number);

                chosen_nums.Add(drawn_ball_number);


                // Check the ball that was just drawn against what is on your card
                ownNumbersCalled = bingoMethods.checkNumberWasCalled (bingoCardRows, bingoCardCols, bingoCard, drawn_ball_number, ownNumbersCalled);


                if (ownNumbersCalled == bingoCardSize)
                {
                    Console.WriteLine("Game finished! It took you {0} turns to win.", score+1);
                    break;
                }

                // Removes the randomly selected number
                remaining_numbers.Remove(drawn_ball_number);

                Console.WriteLine("");
            }



        }
    }
}