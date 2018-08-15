using System;
using System.Collections;
namespace Bingo1
{
    class Program
    {
        
        static void Main(string[] args)
        {

  

           

            // Create array list of 1 to 100 START
            ArrayList remaining_numbers = new ArrayList();

            for (int i = 1; i < 101; i++)
            {
                remaining_numbers.Add(i);
            }

            for (int i = 0; i < remaining_numbers.Count; i++)
            {
                Console.WriteLine(remaining_numbers[i]);
            }
            // Create array list of 1 to 100 END





            //remaining_numbers.Remove(random_number);




            int rounds = remaining_numbers.Count;

            for (int i = 0; i < rounds; i++)
            {
                Random rnd = new Random();
                int next_num_index = rnd.Next(0, remaining_numbers.Count);

                //Console.WriteLine("The index of the {0}th number is {1}", i, next_num_index);
                //int bingo_number = remaining_numbers[next_num_index];
                //Console.WriteLine("The value of index {0} is {1}", next_num_index, remaining_numbers[next_num_index]);

                Console.WriteLine("The {0}th number is {1}", i+1, remaining_numbers[next_num_index]);
                remaining_numbers.Remove(remaining_numbers[next_num_index]);



                Console.WriteLine("Remaining numbers:");
                for (int j = 0; j < remaining_numbers.Count; j++)
                {
                    Console.WriteLine(remaining_numbers[j]);
                }   

                Console.WriteLine("");

            }






        }
    }
}
