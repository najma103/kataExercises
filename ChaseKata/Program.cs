using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaseKata
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    //create initial array
                    string[] initialArray = new string[2];
                    initialArray = line.Split(';');
                    //split 
                    string[] sNumbers = new string[initialArray[0].Length];
                    sNumbers = initialArray[0].Split(',');

                    int k = Convert.ToInt32(initialArray[1]);
                    string[] returnArray = new string[sNumbers.Length];

                    returnArray = ReverseElements(sNumbers, k);
                    Console.WriteLine(line);
                    Console.WriteLine(String.Join(", ", returnArray));
                }
        }

        /*Programming Challenge Description:
        Given a list of numbers and a positive integer k, reverse the elements of the list, 
        k items at a time.If the number of elements is not a multiple of k, 
        then the remaining items in the end should be left as is.
        Input:
        Your program should read lines from standard input.Each line contains a list of numbers and the number k,
        separated by a semicolon. The list of numbers are comma delimited.
        1,2,3,4,5;2
        Output:
            Print out the new comma separated list of numbers obtained after reversing.*/
        public static string[] ReverseElements(string[] strArray, int k)
        {
            string[] newArray = new string[strArray.Length];
            int reminder = strArray.Length % k;
            int temp = k-1;
            int arrLen = strArray.Length;
            for(int x = 0; x < strArray.Length; x++)
            {
                newArray[x] = strArray[x];
            }

            if(arrLen % k == 0)
            {
                for(int i = 0; i < strArray.Length; i= i + 2)
                {
                    newArray[i] = strArray[temp];
                    newArray[temp] = strArray[i];
                    temp = temp + k; ;
                }
            }
            else
            {
                //Stack<string> nums = new Stack<string>();
                //int reminder = arrLen % k;
                //for(int i = 0; i < arrLen; i++)
                //{
                //    nums.Push(strArray[i]);
                //}
                //for(int j = reminder; j >= 0; j--)
                //{
                //    nums.Pop();
                //}
                //string[] anotherArray = new string[nums.Count];
                //anotherArray = nums.ToArray();
                //newArray = anotherArray;

                for (int i = 0; i < strArray.Length - reminder; i = i + 2)
                {
                    newArray[i] = strArray[temp];
                    newArray[temp] = strArray[i];
                    temp = temp + k; ;
                }
            }
            
            return newArray;
            
        }
    }
}
