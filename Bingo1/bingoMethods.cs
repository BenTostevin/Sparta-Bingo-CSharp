using System;
namespace Bingo1
{
    class bingoMethods
    {
        public static bool alreadyChosen(int rows, int cols, int[,] bingoCard, int candidate)
        {
            bool checkChosen = false;
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
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
