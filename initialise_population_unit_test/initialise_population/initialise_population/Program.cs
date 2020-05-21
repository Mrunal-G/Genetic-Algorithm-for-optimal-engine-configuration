using System;
using System.Collections.Generic;
using System.Linq;


namespace initialise_population
{
    class Program
    {
        static void Main(string[] args)
        {
            int POPULATION_SIZE = 10;

            List<string> chromosomeList = new List<string>();

            var rand = new Random();
            for (int n = 0; n < POPULATION_SIZE; n++) // here 10 is the population size
            {
                Random random = new Random(); //create a random object
                List<int> list1 = new List<int>(); //create a list for parameter 1    
                List<int> list2 = new List<int>(); //create a list for parameter 2 
                List<int> list3 = new List<int>(); //create a list for parameter 3 
                List<int> list4 = new List<int>(); //create a list for parameter 4
                List<int> list5 = new List<int>();  //create a list for parameter 5 
                List<int> list6 = new List<int>();  //create a list for parameter 6 
                List<int> list7 = new List<int>();  //create a list for parameter 7 
                List<int> list8 = new List<int>();  //create a list for parameter 8 
                List<int> list9 = new List<int>();  //create a list for parameter 9 

                List<int> list10 = new List<int>(); //created a list10  correct for 10 - 14 parameters (5 elements)

                List<int> list11 = new List<int>(); //create a list 11    for 15th parameter (without only 1 rest 0)


                // Adding elements to List
                list1.Add(0);
                list1.Add(0);
                list1.Add(0);
                list1.Add(0);
                list1.Add(0);
                list1[random.Next() % 5] = 1; // changing one 0 to 1 at random position


                list2.Add(0);
                list2.Add(0);
                list2.Add(0);
                list2.Add(0);
                list2.Add(0);
                list2[random.Next() % 5] = 1; // changing one 0 to 1 at random position


                list3.Add(0);
                list3.Add(0);
                list3.Add(0);
                list3.Add(0);
                list3.Add(0);
                list3[random.Next() % 5] = 1; // changing one 0 to 1 at random position

                list4.Add(0);
                list4.Add(0);
                list4.Add(0);
                list4.Add(0);
                list4.Add(0);
                list4[random.Next() % 5] = 1; // changing one 0 to 1 at random position

                list5.Add(0);
                list5.Add(0);
                list5.Add(0);
                list5.Add(0);
                list5.Add(0);
                list5[random.Next() % 5] = 1; // changing one 0 to 1 at random position

                list6.Add(0);
                list6.Add(0);
                list6.Add(0);
                list6.Add(0);
                list6.Add(0);
                list6[random.Next() % 5] = 1; // changing one 0 to 1 at random position

                list7.Add(0);
                list7.Add(0);
                list7.Add(0);
                list7.Add(0);
                list7.Add(0);
                list7[random.Next() % 5] = 1; // changing one 0 to 1 at random position

                list8.Add(0);
                list8.Add(0);
                list8.Add(0);
                list8.Add(0);
                list8.Add(0);
                list8[random.Next() % 5] = 1; // changing one 0 to 1 at random position

                list9.Add(0);
                list9.Add(0);
                list9.Add(0);
                list9.Add(0);
                list9.Add(0);
                list9[random.Next() % 5] = 1; // changing one 0 to 1 at random position


                for (int i = 0; i < 5; i++) //loop 5 times
                {
                    int r = random.Next(0, 2); //genearte random number 0 or 1
                    list10.Add(r); //add the random number to list10
                }


                list11.Add(0);
                list11.Add(0);
                list11.Add(0);
                list11[random.Next() % 3] = 1; // changing one 0 to 1 at random position



                List<int> Individualslist = list1.Concat(list2).Concat(list3).Concat(list4).Concat(list5).Concat(list6).Concat(list7).Concat(list8).Concat(list9).Concat(list10).Concat(list11).ToList();



                var chromosome = string.Join("", Individualslist);  // concatenated chromosomeList is in List<int> data type and needs to be converted to string and this string needs to be stored in "chromosome"
                chromosomeList.Add(chromosome);


            } // of "for loop" of initialising Population


            // printing the population
            for (int i = 0; i < POPULATION_SIZE; i++)
            {
                Console.WriteLine(chromosomeList[i]);
            }
            Console.WriteLine("Hello World!");
        }
    }
}
