using System;
namespace Bingo1
{
    class bingoMethods
    {
        public static bool alreadyChosen(int bingoCardRows, int bingoCardCols, int[,] bingoCard, int candidate)
        {
            bool checkChosen = false;
            for (var i = 0; i < bingoCardRows; i++)
            {
                for (var j = 0; j < bingoCardCols; j++)
                {
                    if (bingoCard[i, j].Equals(candidate))
                    {
                        checkChosen = true;
                    }

                }
            }
            return checkChosen;
        }

        public static bool checkValid(int candidate, int upperBound, int lowerBound, int bingoCardRows, int bingoCardCols, int[,] bingoCard)
        {
            if ((candidate <= upperBound) && (candidate >= lowerBound) && (bingoMethods.alreadyChosen(bingoCardRows, bingoCardCols, bingoCard, candidate) == false))
            {
                bool valid_number = true;
                return valid_number;
            }
            else
            {
                Console.WriteLine("Number is not valid. Choose again.");
                bool valid_number = false;
                return valid_number;
            }
        }

        public static int createUpperBound(int segmentSize, int row, int col, int bingoCardRows, int bingoCardCols)
        {
            double nthNumber = (row * bingoCardCols) + (col);

            double rowD = row;
            double colD = col;
            double bingoCardRowsD = bingoCardRows;

            return Convert.ToInt32((Math.Ceiling((nthNumber + 1) / bingoCardRowsD)) * segmentSize);

        }

        public static int createLowerBound(int segmentSize, int row, int col, int bingoCardRows, int bingoCardCols)
        {
            double nthNumber = (row * bingoCardCols) + (col);

            double rowD = row;
            double colD = col;
            double bingoCardRowsD = bingoCardRows;

            return Convert.ToInt32(((Math.Floor(nthNumber / bingoCardRowsD)) * segmentSize) + 1);

        }

        public static void confirmCard (int bingoCardRows, int bingoCardCols, int[,] bingoCard)
        {
            Console.WriteLine("You have selected the following numbers:");
            for (var i = 0; i < bingoCardRows; i++)
            {
                for (var j = 0; j < bingoCardCols; j++)
                {
                    Console.WriteLine(bingoCard[i, j]);
                }
            } 
        }

        public static int checkNumberWasCalled (int bingoCardRows, int bingoCardCols, int[,] bingoCard, int drawn_ball_number, int ownNumbersCalled)
        {
            for (var row = 0; row < bingoCardRows; row++)
            {
                for (var col = 0; col < bingoCardCols; col++)
                {
                    if (bingoCard[row, col].Equals(drawn_ball_number))
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
