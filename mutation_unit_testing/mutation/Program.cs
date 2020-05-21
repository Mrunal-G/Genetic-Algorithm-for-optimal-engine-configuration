using System;
using System.Collections.Generic;
using System.Linq;
using cwklib2020;

namespace mutation
{
    class Program
    {
        public const string switch1 = "00100";

        public const string switch2 = "001";
        public const string switch3 = "010";
        public const string switch4 = "100";
        public List<string> Mutation1(List<string> testlist)
        {
            // Declaring a list of result strings
            List<string> resultlist = new List<string>();
            int index = 0;

            // Looping through the testlist
            foreach (string str in testlist)
            {
                // Getting the position from which characters have to be replaced
                //int pos = indexArray[index];
                int pos1 = 5;
                int pos2 = 10;
                int pos3 = 45;
                int last3pos = 50;


                /*
                *    Replacing the 5 characters and storing in a new string
                *   
                *   */

                // Replacing replacingString1 = "00100" in different positions
                string s1 = str.Substring(0, pos1) + switch1 + str.Substring(pos1 + 5);
                string s2 = str.Substring(0, pos2) + switch1 + str.Substring(pos2 + 5);
                
                // Engine Configuration parameters from 10 to 14 at index position 45 to 49 in chromosome string are mutated as follows using pos9   
                string s3 = str.Substring(0, pos3) + switch1 + str.Substring(pos3 + 5);

               
               
                // from index 50 Fuel Injection Timings parameter is encoded which only uses thre binary number sequences
                string s4 = str.Substring(0, last3pos) + switch2+ str.Substring(last3pos + 3); // to flip the last three chromosome characters to '001'
                string s5= str.Substring(0, last3pos) + switch3 + str.Substring(last3pos + 3); // to flip the last three chromosome characters to '010'
                string s6 = str.Substring(0, last3pos) + switch4 + str.Substring(last3pos + 3); // to flip the last three chromosome characters to '100'


                // Adding that replaced string to the resultlist
                resultlist.Add(s1);
                resultlist.Add(s2);
                resultlist.Add(s3);
                resultlist.Add(s4);
                resultlist.Add(s5);
                resultlist.Add(s6);
                
                index++;
            }

            return resultlist;
        }




        //********************************************************************************************************************************
        // RemoveIdenticalString function

        //********************************************************************************************************************************


        public static void RemoveIdenticalString(List<string> resultList, List<string> testlist)
        {
            foreach (string tStr in testlist)
                for (int i = 0; i < resultList.Count; i++)
                {
                    if (resultList[i] == tStr)
                        resultList.Remove(tStr);
                }
            Console.WriteLine("inside RemoveIdenticalString function");
        }


        //********************************************************************************************************************************

        static void Main(string[] args)
        {
            List<string> testlist = new List<string>(){
"00010000100001001000010000000110000100000001011101010",
"01000000010010000010100000000100100000100000110101100",
"11000100000001101010100011000000100110000010001100001"
};
            int[] indexArray = { 5, 10, 15, 20, 25, 30, 35, 40, 45 };

            // Displaying the inital list of strings - testlist
            Console.WriteLine("testlist: [");
            foreach (string str in testlist)
            {
                Console.WriteLine("\t" + str);
            }
            Console.WriteLine("]");


            Program mut = new Program();
            /*
            * Replacing the 5 characters in all strings based on indexArray
            * NOTE: substring that has to be modified is included in single quotes below for the purpose of demonstration
            * testlist[0] = "00010'00010'0001001000010000000110000100000001011101010"
            * indexArray[0] = 5
            * so, resultlist[0] = "00010'00100'0001001000010000000110000100000001011101010"
            * testlist[1] = "0100000001'00100'00010100000000100100000100000110101100"
            * indexArray[1] = 10
            * so, resultlist[1] = "0100000001'00100'00010100000000100100000100000110101100"
            */
            List<string> resultlist = mut.Mutation1(testlist);

            // Displaying the final list of strings - resultlist
            Console.WriteLine("resultlist: [");
            foreach (string str in resultlist)
            {
                Console.WriteLine("\t" + str);
            }
            Console.WriteLine("]");


            Console.WriteLine("Hello World! \n");

            //function to remove chromosomes strings in resultlist which are identical to OptimumPopulationlist
            RemoveIdenticalString(resultlist, testlist); //string is reference type, so resultList is updated on ReturnIdenticalString
            foreach (string mutatedstr in resultlist)
                Console.WriteLine(mutatedstr); //print all strings which are identical to testList;
        }
    }
}
