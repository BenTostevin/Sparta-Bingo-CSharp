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
            int bingo_card_size = 6;

            int[] bingoCard = new int[bingo_card_size];

            // Select numbers for your card - Start
            // Needs a clause to stop the user selecting the same number twice
            for (int i = 0; i < bingoCard.Length; i++)
            {

                bool valid_number = false;
                while (valid_number == false)
                {
                    Console.Write("Select your {0}th number: ", i + 1);
                    int candidate = int.Parse(Console.ReadLine());

                    if ((candidate <= number_of_balls) && (candidate > 0))
                    {
                        Console.WriteLine("OK");
                        bingoCard[i] = candidate;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Choose a valid number");
                    }
                }
 
            }

            Console.WriteLine("You have selected the following numbers:");
            // Select numbers for your card - End




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

              
                // Check number is on your card
                for (int j = 0; j < bingoCard.Length; j++)
                {
                    if (bingoCard[j] > 50)
                    {
                        Console.WriteLine("Got that!");
                    }
                }    


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