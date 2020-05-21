using System;
using System.Collections.Generic;
//using System.Linq;


namespace binary_crossover
{
    class Program
    {
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

        private static string[] crossover(string[] testlist, int[] IndexArray)
        {
            string[] other = new string[0]; // temporary variable for storing the result from 'combine' method
            string[] resultlist = new string[0];  // initializing the array of strings to be returned
            for (int k = 0; k < IndexArray.Length; k++) // for each index in integer array
            {
                for (int i = 0; i < testlist.Length; i++) // just try all the combinations of strings using brute force
                {
                    for (int j = i; j < testlist.Length; j++)
                    {
                        if (i != j) // to avoid combining a string with itself
                        {
                            other = combine(testlist[i], testlist[j], IndexArray[k]); // temporary array that stores combinations
                            Array.Resize(ref resultlist, resultlist.Length + other.Length); // changing the size of the array for adding

                            // the array below keeps collecting the combinations, 2 combinations at a time
                            Array.Copy(other, 0, resultlist, resultlist.Length - other.Length, other.Length); // merging the two arrays
                        }
                    }
                }
            }// cllection is complete
            return resultlist; // returning the results
        }
        static void Main(string[] args)
        {
            int[] array = {5,10,15,20,25,30,35,40,45,50}; // array of crossover 10 index points 

            

            List<string> testlist = new List<string>(){
"00010000100001001000010000000110000100000001011101010",
"01000000010010000010100000000100100000100000110101100"
/* ,
"11000100000001101010100011000000100110000010001100001",
"00100100000001000100010000100000001000101000010101100",
"00010010000010000100001000100000100010000010010101010",
"01000100000000100100001001000001000001000010001001001",
"01000100000000110000000010000101000000011000010101010",
"00010100000001000010100000010000001000100100010111100",
"10000001000010000001000101000000010100000000110001010",
"10000001000010000010000011000010000000010010010101010"*/
};
            string[] list = testlist.ToArray();

                

            string[] result = crossover(list, array);
            for (int i = 0; i < result.Length; i++)
                Console.WriteLine(result[i] + " --> offspring " + (i + 1));


            Console.WriteLine("Hello World!");
        }
    }
}
