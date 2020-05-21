using System;
using System.Collections.Generic;
using System.Linq;
using cwklib2020;

namespace EL3300_assignment_GA
{
    class Program
    {
        //********************************************************************************************************************************
        // Sorting top 5% chromosomees according to fitness grade function

        //********************************************************************************************************************************
        static List<string> Selection1(IEnumerable<string> testPopulationlist, IEnumerable<int> fitnesseslist)
        {
            int totalChromosomes = testPopulationlist.Count();
            int N = 5; // top N% 
            int Percent = (N * totalChromosomes) / 100;  // top N%

            //Fitness Grades attained by each chromosome string are sorted
            List<int> sortedfitnessGradesList = fitnesseslist.OrderByDescending(x => x).ToList();

            List<string> topChromosomesList = new List<string>();


            //Finding the top N% fitness grades in the list and corresponding chromosome strings who attained those top 10% fitness grades.
            for (int i = 0; i < Percent;)
            {
                //getting top element
                int grade = sortedfitnessGradesList[i];

                for (int j = 0; j < totalChromosomes; j++)
                {
                    //searching element in unsorted list
                    if (fitnesseslist.ElementAt(j) == grade)
                    {
                        //add chromosome string  based on index of fitness grade
                        topChromosomesList.Add(testPopulationlist.ElementAt(j));
                        i++;
                    }
                    //checking if we reached optimal x%
                    if (i >= Percent)
                        break;
                }
            }

            //print the name of the student attaining the highest grade in the console along with the highest grade obtained
            for (int i = 0; i < Percent;)
            {
                //getting top element
                string chromosomegenes = topChromosomesList[i];
                for (int j = 0; j < totalChromosomes; j++)
                {
                    //searching element in unsorted list
                    if (testPopulationlist.ElementAt(j) == chromosomegenes)
                    {
                        //Console.WriteLine("Chromosome : " + chromosomegenes + "\t\tFitness Score:" + fitnesseslist.ElementAt(j));
                        i++;
                    }
                    //checking if we reached optimal x%
                    if (i >= Percent)
                        break;
                }
            }
            //returning list of optimal x chromosome strings in a list.
            return topChromosomesList;


        } // end of sorting function




        //********************************************************************************************************************************
        // Sorting top 5% chromosomees according to fitness grade function inside generation loop 

        //********************************************************************************************************************************
        static List<string> Selection2(IEnumerable<string> Generationlist, IEnumerable<int> fitnesseslist1)
        {
            int totalChromosomes = Generationlist.Count();

            //POPULATION_SIZE = 1000  here totalchromosomes
            int Percent = (5 * totalChromosomes) / 100;  // top 5%

            //Fitness Grades attained by each chromosome string are sorted
            List<int> sortedfitnessGradesList = fitnesseslist1.OrderByDescending(x => x).ToList();

            List<string> topChromosomesList = new List<string>();


            //Finding the top 10% fitness grades in the list and corresponding chromosome strings who attained those top 10% fitness grades.
            for (int i = 0; i < Percent;)
            {
                //getting top element
                int grade = sortedfitnessGradesList[i];

                for (int j = 0; j < totalChromosomes; j++)
                {
                    //searching element in unsorted list
                    if (fitnesseslist1.ElementAt(j) == grade)
                    {
                        //add chromosome string  based on index of fitness grade
                        topChromosomesList.Add(Generationlist.ElementAt(j));
                        i++;
                    }
                    //checking if we reached optimal x%
                    if (i >= Percent)
                        break;
                }
            }

            //print the name of the student attaining the highest grade in the console along with the highest grade obtained
            for (int i = 0; i < Percent;)
            {
                //getting top element
                string chromosomegenes = topChromosomesList[i];
                for (int j = 0; j < totalChromosomes; j++)
                {
                    //searching element in unsorted list
                    if (Generationlist.ElementAt(j) == chromosomegenes)
                    {
                        //Console.WriteLine("Chromosome : " + chromosomegenes + "\t\tFitness Score:" + fitnesseslist1.ElementAt(j));
                        i++;
                    }
                    //checking if we reached optimal x%
                    if (i >= Percent)
                        break;
                }
            }
            //returning list of optimal x chromosome strings in a list.
            return topChromosomesList;


        } // end of sorting function

        //********************************************************************************************************************************
        // Crossover function
        //********************************************************************************************************************************
        private const int NUM_CHAR = 53;

        // this function returns the combination of two strings
        private static string[] combine(string str1, string str2, int index)
        {
            string[] result = { "", "" }; // initializing the array of strings to be returned
            string first, second;   // these strings are used for breaking and recombining the two strings

            // creating the first combination
            first = str1.Substring(0, index); // take the first part of the first string
            second = str2.Substring(index, str2.Length - index); // take the rest from the second one
            result[0] = first + second; // concatenate both parts


            // creating the second combination
            first = str2.Substring(0, index); // take the first part of the second string
            second = str1.Substring(index, str1.Length - index); // take the rest from the first string
            result[1] = first + second; // concatenate both parts
            return result; // return the resulting array of strings    
        }


        private static string[] crossover(string[] list, int[] IndexArray)
        {
            string[] temp = new string[0]; // temporary variable for storing the result from 'combine' method
            string[] resultArray = new string[0];  // initializing the array of strings to be returned
            for (int k = 0; k < IndexArray.Length; k++) // for each index in integer array
            {
                for (int i = 0; i < list.Length; i++) // try all the combinations of strings 
                {
                    for (int j = i; j < list.Length; j++)
                    {
                        if (i != j) // to avoid combining a string with itself
                        {
                            temp = combine(list[i], list[j], IndexArray[k]); // temporary array that stores combinations
                            Array.Resize(ref resultArray, resultArray.Length + temp.Length); // changing the size of the array for adding

                            // the array below keeps collecting the combinations, 2 combinations at a time
                            Array.Copy(temp, 0, resultArray, resultArray.Length - temp.Length, temp.Length); // merging the two arrays
                        }
                    }
                }
            }// collection is complete
            return resultArray; // returning the results
        }

        //*******************************************************************************************************************************
        //      Mutation function 1
        //*******************************************************************************************************************************
        public const string switch1 = "00100";
        public const string switch2 = "10000";
        public const string switch3 = "01000";
        public const string switch4 = "00010";
        public const string switch5 = "00001";

        public const string switch6 = "001";
        public const string switch7 = "010";
        public const string switch8 = "100";

        public const string switch9 = "00000";
        public const string switch10 = "11111";

        public List<string> Mutation(List<string> Generationlist)
        {
            // Declaring a list of result strings
            List<string> resultlist = new List<string>();
            int index = 0;



            // Looping through the list
            foreach (string str in Generationlist)
            {
                // Getting the position from which characters have to be replaced
                int pos1 = 5;
                int pos2 = 10;
                int pos3 = 15;
                int pos4 = 20;
                int pos5 = 25;
                int pos6 = 30;
                int pos7 = 35;
                int pos8 = 40;

                int pos9 = 45;

                int last3pos = 50;


                /*
                *    Replacing the 5 characters and storing in a new string 
                *   */

                // Replacing replacingString1 = "00100" in different positions
                string s1 = str.Substring(0, pos1) + switch1 + str.Substring(pos1 + 5);
                string s2 = str.Substring(0, pos2) + switch1 + str.Substring(pos2 + 5);
                string s3 = str.Substring(0, pos3) + switch1 + str.Substring(pos3 + 5);
                string s4 = str.Substring(0, pos4) + switch1 + str.Substring(pos4 + 5);
                string s5 = str.Substring(0, pos5) + switch1 + str.Substring(pos5 + 5);
                string s6 = str.Substring(0, pos6) + switch1 + str.Substring(pos6 + 5);
                string s7 = str.Substring(0, pos7) + switch1 + str.Substring(pos7 + 5);
                string s8 = str.Substring(0, pos8) + switch1 + str.Substring(pos8 + 5);

                // Engine Configuration parameters from 10 to 14 at index position 45 to 49 in chromosome string are mutated as follows using pos9   
                string s9 = str.Substring(0, pos9) + switch1 + str.Substring(pos9 + 5);

                // Replacing replacingString2 = "10000" in different positions
                string s10 = str.Substring(0, pos1) + switch2 + str.Substring(pos1 + 5);
                string s11 = str.Substring(0, pos2) + switch2 + str.Substring(pos2 + 5);
                string s12 = str.Substring(0, pos3) + switch2 + str.Substring(pos3 + 5);
                string s13 = str.Substring(0, pos4) + switch2 + str.Substring(pos4 + 5);
                string s14 = str.Substring(0, pos5) + switch2 + str.Substring(pos5 + 5);
                string s15 = str.Substring(0, pos6) + switch2 + str.Substring(pos6 + 5);
                string s16 = str.Substring(0, pos7) + switch2 + str.Substring(pos7 + 5);
                string s17 = str.Substring(0, pos8) + switch2 + str.Substring(pos8 + 5);
                string s18 = str.Substring(0, pos9) + switch2 + str.Substring(pos9 + 5);


                // Replacing replacingString3 = "01000" in different positions
                string s19 = str.Substring(0, pos1) + switch3 + str.Substring(pos1 + 5);
                string s20 = str.Substring(0, pos2) + switch3 + str.Substring(pos2 + 5);
                string s21 = str.Substring(0, pos3) + switch3 + str.Substring(pos3 + 5);
                string s22 = str.Substring(0, pos4) + switch3 + str.Substring(pos4 + 5);
                string s23 = str.Substring(0, pos5) + switch3 + str.Substring(pos5 + 5);
                string s24 = str.Substring(0, pos6) + switch3 + str.Substring(pos6 + 5);
                string s25 = str.Substring(0, pos7) + switch3 + str.Substring(pos7 + 5);
                string s26 = str.Substring(0, pos8) + switch3 + str.Substring(pos8 + 5);
                string s27 = str.Substring(0, pos9) + switch3 + str.Substring(pos9 + 5);

                // Replacing replacingString4 = "00010" in different positions
                string s28 = str.Substring(0, pos1) + switch4 + str.Substring(pos1 + 5);
                string s29 = str.Substring(0, pos2) + switch4 + str.Substring(pos2 + 5);
                string s30 = str.Substring(0, pos3) + switch4 + str.Substring(pos3 + 5);
                string s31 = str.Substring(0, pos4) + switch4 + str.Substring(pos4 + 5);
                string s32 = str.Substring(0, pos5) + switch4 + str.Substring(pos5 + 5);
                string s33 = str.Substring(0, pos6) + switch4 + str.Substring(pos6 + 5);
                string s34 = str.Substring(0, pos7) + switch4 + str.Substring(pos7 + 5);
                string s35 = str.Substring(0, pos8) + switch4 + str.Substring(pos8 + 5);
                string s36 = str.Substring(0, pos9) + switch4 + str.Substring(pos9 + 5);


                // Replacing replacingString5 = "00001" in different positions
                string s37 = str.Substring(0, pos1) + switch5 + str.Substring(pos1 + 5);
                string s38 = str.Substring(0, pos2) + switch5 + str.Substring(pos2 + 5);
                string s39 = str.Substring(0, pos3) + switch5 + str.Substring(pos3 + 5);
                string s40 = str.Substring(0, pos4) + switch5 + str.Substring(pos4 + 5);
                string s41 = str.Substring(0, pos5) + switch5 + str.Substring(pos5 + 5);
                string s42 = str.Substring(0, pos6) + switch5 + str.Substring(pos6 + 5);
                string s43 = str.Substring(0, pos7) + switch5 + str.Substring(pos7 + 5);
                string s44 = str.Substring(0, pos8) + switch5 + str.Substring(pos8 + 5);
                string s45 = str.Substring(0, pos9) + switch5 + str.Substring(pos9 + 5);



                // from index 50 Fuel Injection Timings parameter is encoded which only uses thre binary number sequences
                string s46 = str.Substring(0, last3pos) + switch6 + str.Substring(last3pos + 3); // to flip the last three chromosome characters to '001'
                string s47 = str.Substring(0, last3pos) + switch7 + str.Substring(last3pos + 3); // to flip the last three chromosome characters to '010'
                string s48 = str.Substring(0, last3pos) + switch8 + str.Substring(last3pos + 3); // to flip the last three chromosome characters to '100'


                // for 45 to 49 index
                string s49 = str.Substring(0, pos9) + switch9 + str.Substring(pos9 + 5);
                string s50 = str.Substring(0, pos9) + switch10 + str.Substring(pos9 + 5);

                // Adding that replaced string to the resultlist
                resultlist.Add(s1);
                resultlist.Add(s2);
                resultlist.Add(s3);
                resultlist.Add(s4);
                resultlist.Add(s5);
                resultlist.Add(s6);
                resultlist.Add(s7);
                resultlist.Add(s8);
                resultlist.Add(s9);
                resultlist.Add(s10);
                resultlist.Add(s11);
                resultlist.Add(s12);
                resultlist.Add(s13);
                resultlist.Add(s14);
                resultlist.Add(s15);
                resultlist.Add(s16);
                resultlist.Add(s17);
                resultlist.Add(s18);
                resultlist.Add(s19);
                resultlist.Add(s20);
                resultlist.Add(s21);
                resultlist.Add(s22);
                resultlist.Add(s23);
                resultlist.Add(s24);
                resultlist.Add(s25);
                resultlist.Add(s26);
                resultlist.Add(s27);
                resultlist.Add(s28);
                resultlist.Add(s29);
                resultlist.Add(s30);
                resultlist.Add(s31);
                resultlist.Add(s32);
                resultlist.Add(s33);
                resultlist.Add(s34);
                resultlist.Add(s35);
                resultlist.Add(s36);
                resultlist.Add(s37);
                resultlist.Add(s38);
                resultlist.Add(s39);
                resultlist.Add(s40);
                resultlist.Add(s41);
                resultlist.Add(s42);
                resultlist.Add(s43);
                resultlist.Add(s44);
                resultlist.Add(s45);
                resultlist.Add(s46);
                resultlist.Add(s47);
                resultlist.Add(s48);
                resultlist.Add(s49);
                resultlist.Add(s50);

                index++;
            }

            return resultlist;
        }


        //********************************************************************************************************************************
        // RemoveIdenticalString function

        //********************************************************************************************************************************


        public static void RemoveIdenticalString(List<string> resultList, List<string> Generationlist)
        {
            foreach (string tStr in Generationlist)
                for (int i = 0; i < resultList.Count; i++)
                {
                    if (resultList[i] == tStr)
                        resultList.Remove(tStr);
                }
            //Console.WriteLine("inside RemoveIdenticalString function");
        }


        //********************************************************************************************************************************

        static void Main(string[] args)
        {
            int POPULATION_SIZE = 1000;
            
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



            List<string> testPopulationlist = new List<string>();

            testPopulationlist.AddRange(chromosomeList);
      
            List<int> fitnesseslist = new List<int>(testPopulationlist.Count); // 100 is the constant population size

            // calculate fitness for test population.

            for (int i = 0; i < 1; ++i)  // this loop evaluates the fitness grade of the engine configurations chromosome string
            {
                
                FitFunc generationtest = new FitFunc();
                foreach (string chromosomeString in testPopulationlist)
                {
                    int gradeValue = generationtest.evalFunc(chromosomeString);
                    fitnesseslist.Add(gradeValue);
                }

            }


            List<string> topScorerList = Selection1(testPopulationlist, fitnesseslist);


            for (int i = 0; i < fitnesseslist.Count; i++)
            {
                if (testPopulationlist[i] == topScorerList[0])
                {
                    Console.WriteLine(topScorerList[0] + " scored the highest fitness grade of " + fitnesseslist[i]);
                    break;
                }
            }

            testPopulationlist = topScorerList;//now contain only the top 10% student names
                                               //Clear the contents of the gradeslist completely and keep only


            fitnesseslist.Clear(); // clear this list 

            List<string> runPopulationlist = new List<string>();
            List<string> OptimumPopulationlist = new List<string>();
            List<string> MutatePopulationlist = new List<string>();

            List<string> Generationlist = new List<string>();

            Generationlist.AddRange(testPopulationlist);

            int generation = 10;

            // continuously generate populations until number of iterations is met.
            for (int iter = 1; iter < generation; ++iter)
            {

   
                if (iter == generation) break;  // condition for breaking out of generation loop.

                while (Generationlist.Count <= POPULATION_SIZE)
                {

                    // crossover 

                    // Instantiating random number generator
                    var random1 = new Random();

                    //OptimumPopulationlist which will store randomly selected parent strings as per calculations for crossover
                    for (int c = 0; c < 10; c++) // random 10 chromosome strings (n = 10)
                    {
                        //generating a random index
                        int index1 = random1.Next(Generationlist.Count);
                        // adding the chromosome string present at randomly generated index in runPopulationlist to  OptimumPopulationlist
                        OptimumPopulationlist.Add(Generationlist[index1]);

                    }

                    //Console.Write("\n random 10 crossover parent strings: \n");
                    // loop to print the 9 random chromosome strings  in OptimumPopulationlist
                    //for (int i = 0; i < 10; i++)
                   // {
                   //     Console.WriteLine(OptimumPopulationlist[i]);
                    //}
                
                    int[] array = { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 }; // array of crossover index points

                    string[] list = OptimumPopulationlist.ToArray();

                    //Console.Write("\n crossover : \n");

                    string[] result = crossover(list, array);  // send to crossover function


                    //for (int i = 0; i < result.Length; i++)
                    //    Console.WriteLine(result[i] + " --> offspring " + (i + 1));

                    List<string> crossoverResultlist = new List<string>(result);


                    runPopulationlist.AddRange(crossoverResultlist);  //crossoverResultlist has 900 chromosomees for 10 randomly selected chromosome strings from OptimumPopulationlist (from top 5% of test Populationlist of 1000 population size)



                    // Mutation

                    Program p = new Program();
                    List<string> resultlist = p.Mutation(Generationlist); //  strings in resultlist from 1 randomly selected string // resultlist has 50 strings
                    //function to remove chromosomes strings in resultlist which are identical to OptimumPopulationlist
                    RemoveIdenticalString(resultlist, Generationlist); //string is reference type, so resultList is updated on ReturnIdenticalString


                    //MutatePopulationlist which will store randomly selected 50 mutated chromosome strings for 1000 population
                    for (int m = 0; m < 50; m++) // random 1 string from runPopulationlist so 1 x 50 combinations is 50 for mutation
                    {
                        //generating a random index
                        int index1 = random1.Next(resultlist.Count);
                        // adding the chromosome string present at randomly generated index in runPopulationlist to MutatePopulationlist
                        MutatePopulationlist.Add(resultlist[index1]);
                       // 50 strings generated from one randomly selectedstring

                    }
                    // loop to print the 50 random mutated chromosome strings  in MutatePopulationlist

                    //for (int i = 0; i < 50; i++)
                    //{
                   //     Console.WriteLine(MutatePopulationlist[i]);
                   // }


                    resultlist.Clear();

                    //********************************************************************************************************************

                    Generationlist.AddRange(MutatePopulationlist);

                    Generationlist.AddRange(runPopulationlist);
                  
                }

                List<int> fitnesseslist1 = new List<int>(Generationlist.Count); 

                // calculate fitness for test population.
                for (int i = 0; i < 1; ++i)  // this loop evaluates the fitness grade of the engine configurations chromosome string
                {
                    FitFunc generationtest1 = new FitFunc();
                    foreach (string chromosomeString in Generationlist)
                    {
                        int gradeValue1 = generationtest1.evalFunc(chromosomeString);
                        fitnesseslist1.Add(gradeValue1);
                    }

                }

                List<string> topScorerList1 = Selection2(Generationlist, fitnesseslist1);
                for (int i = 0; i < fitnesseslist1.Count; i++)
                {
                    if (Generationlist[i] == topScorerList1[0])
                    {
                        Console.WriteLine(topScorerList1[0] + " scored the highest fitness grade of " + fitnesseslist1[i] + " in generation:" + iter);
                        break;
                    }
                }

                Generationlist = topScorerList1;//now contain only the top N% chromosome strings.
                                                


                fitnesseslist1.Clear(); //Clear the contents of the fitnesseslist1 completely.
                runPopulationlist.Clear();
                MutatePopulationlist.Clear();

            }
            Console.WriteLine("Hello World!");
        }
    }
}
