using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1); 
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums) // Method to find missing numbers
        {
            try
            {
                IList<int> missingNumbers = new List<int>(); // List of the missing numbers.

                // Edge case 1: Check if array is empty
                if (nums.Length == 0)
                {
                    return missingNumbers; // Return an empty list
                }

                // Edge case 2: Check if the array has duplicates
                bool[] present = new bool[nums.Length + 1]; // Create a boolean array to track which numbers are present

                // Mark the numbers as present
                foreach (int num in nums)
                {
                    if (num <= nums.Length) // Only consider numbers in the range 1 to n including n
                    {
                        present[num] = true; // Mark the number as present
                    }
                }

                // Find the missing numbers
                for (int k = 1; k <= nums.Length; k++)
                {
                    if (!present[k]) // If a number is missing (not marked as true in the `present` array)
                    {
                        missingNumbers.Add(k); // Add the missing number to the list
                    }
                }

                // Return the list of missing numbers
                return missingNumbers;
            }
            // Handle exceptions
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Input array is null: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums) // Method to sort the array by parity
        {
            try
            {
                // Edge case 1: Check if array is empty
                if (nums.Length == 0)
                {
                    throw new InvalidOperationException("Empty Input Array");
                }

                // Edge case 2: Check if the array has no odd or no even numbers
                bool allEven = true;
                bool allOdd = true;

                foreach (int num in nums)
                {
                    if (num % 2 == 0) allOdd = false;
                    else allEven = false;
                    if (!allEven && !allOdd) break; // Exit the loop if both conditions are met
                }

                if (allEven) throw new InvalidOperationException("All numbers are even.");
                if (allOdd) throw new InvalidOperationException("All numbers are odd.");

                // Position in Array: "begin" as start at the beginning and "end" as starts at the end
                int begin = 0;
                int end = nums.Length - 1;

                while (begin < end)
                {
                    // If the first number is even, move to the next number
                    if (nums[begin] % 2 == 0) begin++;
                    // If the last number is odd, move to the number before it
                    else if (nums[end] % 2 == 1) end--;
                    // If the number from begin is odd and the number from end is even, switch their place
                    else
                    {
                        int temp = nums[begin];
                        nums[begin] = nums[end];
                        nums[end] = temp;
                        begin++;
                        end--;
                    }
                }
                return nums;
            }
            // Handle exceptions
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target) // Method to find two numbers that add up to the target
        {
             try
                {
                    // Edge case 1: Check if array is empty
                    if (nums.Length == 0)
                    {
                        throw new InvalidOperationException("Empty Input Array");
                    }
                    // Edge case 2: Check if array contains only one number
                    if (nums.Length == 1)
                    {
                        throw new InvalidOperationException("No two sum solution");
                    }
                    // Declare Dictionary to store the indices of the numbers
                    Dictionary<int, int> numDict = new Dictionary<int, int>();

                    // Iterate through the array
                    for (int k = 0; k < nums.Length; k++)
                    {
                        int pairSum = target - nums[k]; // Calculate the pair sum

                        // Check if the pair sum exists in the dictionary
                        if (numDict.ContainsKey(pairSum))
                        {
                            return new int[] { numDict[pairSum], k }; // Return the indices of the pair sum and the current number
                        }

                        // Store the current number and its index in the dictionary
                        numDict[nums[k]] = k;
                    }
                // Edge case 3: If no two numbers add up to the target
                throw new InvalidOperationException("No two sum solution");
            }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                    throw;
                }
            }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums) // Method to find the maximum product of three numbers
        {
            try
            {
                // Edge case 1: If the array is empty
                if (nums.Length == 0)
                {
                    throw new InvalidOperationException("Empty Input Array");
                }
                // Edge case 2: If the array has less than three elements
                if (nums.Length < 3)
                {
                    throw new InvalidOperationException("Array is less than three elements");
                }
                // Sort the array in ascending order
                Array.Sort(nums);

                // Calculate the maximum product of three numbers
                int k = nums.Length;
                int maxProduct = nums[k - 1] * nums[k - 2] * nums[k - 3];

                // Return the maximum product
                return maxProduct;
            }
            // Handle exceptions
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw;
            }            
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
    {
                // Edge case 1: If the number is 0
                if (decimalNumber == 0)
                {
                    return "0";
                }
                // Edge case 2: If the number is negative
                if (decimalNumber < 0)
                {
                    throw new InvalidOperationException("Cannot convert negative numbers to binary.");
                }
                // Store the binary number
                string binary = string.Empty;

                // Convert the decimal number to binary
                // Calculate the remainder, add it to the binary and continue with the next decimal number until it becomes 0
                while (decimalNumber > 0)               
                {
                    int remainder = decimalNumber % 2;
                    binary = remainder + binary;
                    decimalNumber /= 2;
                }
                // Return the binary string
                return binary;
            }
            // Handle exceptions
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
    {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                // Edge case 1: If the array is empty
                if (nums.Length == 0)
                {
                    throw new InvalidOperationException("Empty Input Array");
                }
                // Edge case 2: if the array has only one number
                if (nums.Length == 1)
                {
                    return nums[0]; // Return the only number
                }
                // Set the pointers
                int begin = 0;
                int end = nums.Length - 1;

                // Binary search to find the minimum element
                while (begin < end)
                {
                    int mid = begin + (end - begin) / 2;

                   // If the middle number is bigger than the last number, the smallest number is in the right half
                    if (nums[mid] > nums[end])
                    {
                        begin = mid + 1;
                    }
                   // Otherwise, the minimum is in the left half
                    else
                    {
                        end = mid;
                    }
                }
                // The begin pointer will select to the smallest number
                return nums[begin];              
            }
            // Handle exceptions
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {               
                // Edge case 1: if x is a negative number
                if (x < 0)
                {
                    return false; // Negative numbers are not palindromes
                }
                // Edge case 2: if x is a single digit number
                if (x >= 0 && x < 10)
                {
                    return true; // Single digit numbers are palindromes
                }
                // Store the original number
                int original = x;
                int reversed = 0;

                // Reverse the number
                while (x > 0)
                {
                    int digit = x % 10;
                    reversed = reversed * 10 + digit;
                    x /= 10;
                }
                // Check if the original number is equal to the reversed number
                return original == reversed;
            }
            // Handle exceptions
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Edge case 1: If n is a negative number
                if (n < 0)
                {
                    throw new InvalidOperationException("Input cannot be a negative number");
                }

                // Edge case 2: If n is 0 or 1, return n because F(0) = 0 and F(1) = 1
                if (n == 0 || n == 1)
                {
                    return n;
                }

                // Set the first two numbers in the sequence
                int k = 0;
                int s = 1;

                // Calculate the Fibonacci number using a loop starting at n = 2
                for (int j = 2; j <= n; j++)
                {
                    int temp = k + s;
                    k = s;
                    s = temp;
                }

                // Return the nth Fibonacci number
                return s;
            }
            // Handle exceptions
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw;
            }
        }
    }
}
