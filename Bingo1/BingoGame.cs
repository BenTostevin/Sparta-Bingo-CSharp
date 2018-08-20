using System;
namespace Bingo1
{
    public class BingoGame
    {

        public int numberOfBalls;
        public int segmentSize;
        public int bingoCardRows;
        public int bingoCardCols;
        public int bingoCardSize;
        public int[,] bingoCard;

        public BingoGame(int _numberOfBalls, int _segmentSize, int _bingoCardRows, int _bingoCardCols)
        {
            numberOfBalls = _numberOfBalls;
            segmentSize = _segmentSize;
            bingoCardRows = _bingoCardRows;
            bingoCardCols = _bingoCardCols;

            bingoCardSize = _bingoCardRows * _bingoCardCols;
            bingoCard = new int[_bingoCardRows, _bingoCardCols];

        }

    }

}



