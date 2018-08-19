using System;
namespace Bingo1
{
    class chosen
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
    }
}
