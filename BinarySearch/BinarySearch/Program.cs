using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> randomInts = new List<int>();
            Random rand = new Random();
            int index = 0;

            Console.WriteLine("Welcome to Binary Search!");
            Console.WriteLine("Time Complexity: O(log n)");

            randomInts = FillListWithRandomInts(rand);
            Console.WriteLine("Unsorted List: ");
            PrintPrettyList(randomInts);
            randomInts.Sort();
            Console.WriteLine("Sorted List: ");
            PrintPrettyList(randomInts);
            index = BinarySearch(randomInts);
            if (index >= 0)
            {
                Console.WriteLine("Number is at index " + index.ToString() + "\n");
            }
            else
            {
                Console.WriteLine("Number not found.\n");
            }
        }

        // Function does an iterative binary search on a list of ints to search for a provided number.
        // Function takes a list of ints as an argument.
        // Function returns the number's index if found, -1 otherwise.
        static int BinarySearch(List<int> numbers)
        {
            int index = -1;
            int term = 0;
            bool check = false;

            // Get numbther to search for...
            if (!check)
            {
                Console.Write("Enter search term (int): ");
                check = int.TryParse(Console.ReadLine(), out term);
                if (!check)
                {
                    Console.WriteLine("That's not a number, pal!");
                }
            }
            
            int start = 0; // Set initial start point of search.
            int end = numbers.Count - 1; // Set initial end point of search.

            // Keep going until either the number is found or the start overlaps the end.
            while (start < end)
            {
                int mid = (int)(start + end) / 2; // Find midpoint of list.

                // Number found.
                if (term == numbers[mid])
                {
                    return mid; // Return index of number in list.
                }
                // Number is less than the number at the midpoint of the array.
                else if (term < numbers[mid])
                {
                    end = mid - 1; // Readjust endpoint to search front half of the data.
                }
                // Number is greater than number at midpoint of array.
                else
                {
                    start = mid + 1; // Readjust start point to search back half of data.
                }
            }

            return index; // Number not found in search -> return -1.
        }

        static List<int> FillListWithRandomInts(Random rand)
        {
            List<int> tempList = new List<int>();
            bool check = false;
            int listSize = 0;

            if (!check)
            {
                Console.Write("Enter the number of ints in the list (minimum of 10): ");
                check = int.TryParse(Console.ReadLine(), out listSize);
                if (!check)
                {
                    Console.WriteLine("That's not a number, pal!");
                }
                if (check && listSize < 10)
                {
                    check = false;
                }
            }

            for (int i = 0; i < listSize; i++)
            {
                tempList.Add(rand.Next(1, 1001));
            }

            return tempList;
        }

        // Function prints a list of ints with 10 ints per row.
        // Function takes a list of int as an argument.
        // Function returns void.
        static void PrintPrettyList(List<int> nums)
        {
            // Loop through each number in the list.
            for (int i = 0, j = 0; i < nums.Count; i++)
            {
                string numString = nums[i].ToString();
                numString = numString.PadLeft(5); // Adds 5 leading spaces to each number to even out the column width.

                j++; // Counts the number of ints in a single row.

                // Puts 10 numbers in a row.
                if (j < 10)
                {
                    Console.Write(numString + " ");
                }
                // At the end of a row, reset the counter.
                else
                {
                    j = 0;
                    Console.WriteLine(numString);
                }
            }
        }
    }
}
