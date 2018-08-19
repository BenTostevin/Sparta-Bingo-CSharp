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




            for (var row = 0; row < bingoCardRows; row++)
            {
                for (var col = 0; col < bingoCardCols; col++)
                {
                    bool valid_number = false;

                    while (valid_number == false)
                    {

                        bool checkChosen = false;

                        int nthNumber = (row * bingoCardCols) + (col);

                        double rowD = row;
                        double colD = col;
                        double bingoCardRowsD = bingoCardRows;
                        double nthNumberD = nthNumber;

                        int lowerBound = Convert.ToInt32(((Math.Floor(nthNumberD / bingoCardRowsD)) * segmentSize) + 1);
                        int upperBound = Convert.ToInt32((Math.Ceiling((nthNumberD + 1) / bingoCardRowsD)) * segmentSize);
                       

                        Console.WriteLine("Select your {0}th number between {1} and {2}.", nthNumber + 1, lowerBound, upperBound);
                        int candidate = int.Parse(Console.ReadLine());

                        // Check number entered has been entered already
                        //for (var i = 0; i < bingoCardRows; i++)
                        //{
                        //    for (var j = 0; j < bingoCardCols; j++)
                        //    {
                        //        if (bingoCard[i, j].Equals(candidate))
                        //        {
                        //            alreadyChosen = true;
                        //        }
                        //    }
                        //}

                        // Check what the user entered is valid
                        if ((candidate <= upperBound) && (candidate >= lowerBound) && (chosen.alreadyChosen (bingoCardRows, bingoCardCols, bingoCard, candidate) == false))
                        {
                            bingoCard[row, col] = candidate;
                            valid_number = true;
                        }
                        else
                        {
                            Console.WriteLine("Number is not valid. Choose again.");
                        }
                    }
                }
            }
                



            // Select numbers for your card - End

            Console.WriteLine("You have selected the following numbers:");
            for (var i = 0; i < bingoCardRows; i++)
            {
                for (var j = 0; j < bingoCardCols; j++)
                {
                    Console.WriteLine(bingoCard[i,j]);
                }
            }


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
                //int drawn_ball_number = remaining_numbers[next_num_index];


                Console.WriteLine("The {0}th number is {1}", score + 1, remaining_numbers[next_num_index]);

                chosen_nums.Add(remaining_numbers[next_num_index]);


                // Check number is on your card
                for (var row = 0; row < bingoCardRows; row++)
                {
                    for (var col = 0; col < bingoCardCols; col++)
                    {
                        if (bingoCard[row, col].Equals(remaining_numbers[next_num_index]))
                        {
                            Console.WriteLine("Got that!");
                            ownNumbersCalled++;
                            Console.WriteLine("You have had {0} numbers so far", ownNumbersCalled);

                        }
                    }
                }

                if (ownNumbersCalled == bingoCardSize)
                {
                    Console.WriteLine("Game finished! It took you {0} turns to win.", score+1);
                    break;
                }


                // Removes the randomly selected number
                remaining_numbers.Remove(remaining_numbers[next_num_index]);

                Console.WriteLine("");
            }



        }
    }
}