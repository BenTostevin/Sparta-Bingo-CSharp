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
            int bingoCardSize = 6;



            // Select numbers for your card - Start
            // Needs a clause to stop the user selecting the same number twice
            //for (int i = 0; i < bingoCard.Length; i++)
            //{

                //bool valid_number = false;
                //while (valid_number == false)
                //{
                //    Console.Write("Select your {0}th number: ", i + 1);
                //    int candidate = int.Parse(Console.ReadLine());

                //    // Check the number that the user chose has not already been chosen by them
                //    for (int j = 0; j < bingoCard.Length; j++)
                //    {
                //        if (bingoCard[j] != candidate)
                //        {
                //            Console.WriteLine("Not already chosen");
                //        }
                //    }


                //    if ((candidate <= number_of_balls) && (candidate > 0))
                //    {
                //        Console.WriteLine("OK");
                //        bingoCard[i] = candidate;
                //        break;
                //    }
                //    else
                //    {
                //        Console.WriteLine("Choose a valid number");
                //    }
                //}
 
            //}

            int[] bingoCard = new int[bingoCardSize];
            for (var i = 0; i < bingoCardSize; i++)
            {
                bool valid_number = false;
                while (valid_number == false)
                {

                    bool alreadyChosen = false;

                    Console.WriteLine("Select your {0}th number", i + 1);
                    int candidate = int.Parse(Console.ReadLine());

                    // Check number entered has been entered already
                    for (int j = 0; j < bingoCard.Length; j++)
                    {
                        Console.WriteLine("{0} - {1}", bingoCard[j], candidate);
                        if (bingoCard[j].Equals(candidate))
                        {
                            Console.WriteLine("alreadyChosen = true");
                            alreadyChosen = true;
                        }
                    }

                    Console.WriteLine(alreadyChosen);

                    if (candidate <= number_of_balls)
                    {
                        Console.WriteLine("condition 1 is true");
                    }
                    if (candidate > 0)
                    {
                        Console.WriteLine("condition 2 is true");
                    }
                    if (alreadyChosen == false)
                    {
                        Console.WriteLine("condition 3 is true");
                    }



                    // Check what the user entered is valid
                    if ((candidate <= number_of_balls) && (candidate > 0) && (alreadyChosen == false))
                    {
                        Console.WriteLine("Add");
                        bingoCard[i] = candidate;
                        valid_number = true;
                    }
                    else
                    {
                        Console.WriteLine("Not added");
                    }
                }
            }




            // Select numbers for your card - End

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

            // score - how many turns did it take you to get all of your numbers
            // score is tracked by using the for loop's counter below


            // This loop removes one number from the list array for each round
            for (int score = 0; score < rounds; score++)
            {
                // Randomly selects one of the remaining numbers
                Random rnd = new Random();
                int next_num_index = rnd.Next(0, remaining_numbers.Count);
                //int drawn_ball_number = remaining_numbers[next_num_index];


                Console.WriteLine("The {0}th number is {1}", score + 1, remaining_numbers[next_num_index]);

                chosen_nums.Add(remaining_numbers[next_num_index]);

                
                // Check number is on your card
                for (int j = 0; j < bingoCard.Length; j++)
                {
                    if (bingoCard[j].Equals(remaining_numbers[next_num_index]))
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