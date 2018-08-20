using System;
namespace Bingo1
{
    public class BingoCard
    {
        public int rows;
        public int cols;
        public int bingoCardSize;
        public int segmentSize;
        public int[,] bingoCard;


        public BingoCard(int _rows, int _cols, int _segmentSize)
        {
            rows = _rows;
            cols = _cols;
            segmentSize = _segmentSize;


            bingoCardSize = _rows * _cols;
            bingoCard = new int[_rows, _cols];
            PopulateCard();

        }


        public void PopulateCard()
        {
            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    bool isValid = false;

                    while (isValid == false)
                    {

                        int nthNumber = (row * cols) + (col);
                        int lowerBound = this.createLowerBound(row, col);
                        int upperBound = this.createUpperBound(row, col);


                        Console.WriteLine("Select your {0}th number between {1} and {2}.", nthNumber + 1, lowerBound, upperBound);

                        int candidate = int.Parse(Console.ReadLine());


                        isValid = this.checkValid(candidate, upperBound, lowerBound);
                        if (isValid == true)
                        {
                            this.bingoCard[row, col] = candidate;
                        }
                    }
                }
            }
        }

        public bool checkValid(int candidate, int upperBound, int lowerBound)
        {
            if ((candidate <= upperBound) && (candidate >= lowerBound) && (bingoMethods.alreadyChosen(rows, cols, bingoCard, candidate) == false))
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

        public void confirmCard()
        {
            Console.WriteLine("You have selected the following numbers:");
            for (var i = 0; i < this.rows; i++)
            {
                for (var j = 0; j < this.cols; j++)
                {
                    Console.WriteLine(bingoCard[i, j]);
                }
            }
        }

        public int createUpperBound( int row, int col)
        {
            double nthNumber = (row * cols) + (col);

            double rowD = row;
            double colD = col;
            double rowsD = rows;

            return Convert.ToInt32((Math.Ceiling((nthNumber + 1) / rowsD)) * segmentSize);

        }

        public int createLowerBound( int row, int col)
        {
            double nthNumber = (row * cols) + (col);

            double rowD = row;
            double colD = col;
            double rowsD = rows;

            return Convert.ToInt32(((Math.Floor(nthNumber / rowsD)) * segmentSize) + 1);

        } 

    }
}