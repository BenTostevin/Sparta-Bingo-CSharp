using System;
using System.Linq;
using System.Collections;
namespace Bingo1
{
    class Program
    {


        static void Main(string[] args)
        {
            

            BingoGame bingoGame = new BingoGame(75);
            BingoCard bingoCard = new BingoCard(5, 5, 15);

            bingoGame.DrawBalls();

            bingoCard.confirmCard ();
        }
    }
}