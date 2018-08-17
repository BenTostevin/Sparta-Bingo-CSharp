using System;
using System.Collections;
namespace Bingo1
{
    class BingoGame
    {
        static void Main(string[] args)
        {

            int number_of_balls = 75;
            int[] bingoCard = new int[6];

            for (int i = 0; i < bingoCard.Length; i++)
            {
                Console.Write("Select your {0}th number. ", i+1);
                bingoCard[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("You have selected the following numbers:");

            for (int i = 0; i < bingoCard.Length; i++)
            {
                Console.WriteLine(bingoCard[i]);
            }    


            // Create array list of 1 to 75 START
            ArrayList remaining_numbers = new ArrayList();

            for (int i = 1; i < number_of_balls+1; i++)
            {
                remaining_numbers.Add(i);
            }
            // Create array list of 1 to 75 END


            // Uncomment this if you want to check that the numbers 1 to 100 are in the list array
            //for (int i = 0; i < remaining_numbers.Count; i++)
            //{
            //    Console.WriteLine(remaining_numbers[i]);
            //}


            // There will be 75 rounds - a round for each bingo ball
            int rounds = remaining_numbers.Count;


            ArrayList chosen_nums = new ArrayList();

            // This loop removes one number from the list array for each round
            for (int i = 0; i < rounds; i++)
            {
                // Randomly selects one of the remaining numbers
                Random rnd = new Random();
                int next_num_index = rnd.Next(0, remaining_numbers.Count);

                Console.WriteLine("The {0}th number is {1}", i + 1, remaining_numbers[next_num_index]);

                chosen_nums.Add(remaining_numbers[next_num_index]);


                // Removes the randomly selected number
                remaining_numbers.Remove(remaining_numbers[next_num_index]);

                //Console.WriteLine("Remaining numbers:");
                //for (int j = 0; j < remaining_numbers.Count; j++)
                //{
                //    Console.WriteLine(remaining_numbers[j]);
                //}

                Console.WriteLine("");
            }
        }
    }
}