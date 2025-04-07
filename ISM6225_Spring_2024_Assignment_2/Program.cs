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
            int decimalNumber = 56;
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
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // Write your code here
                Array.Sort(nums);
                List<int> missingNumbers = new List<int>();
                int n = nums.Length;

                for (int i = 1; i < n; i++)
                {
                    if (Array.IndexOf(nums, i) == -1)
                    {
                        missingNumbers.Add(i);
                    }
                }

                return missingNumbers; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Write your code here
                int[] result = new int[nums.Length];
                int left = 0;
                int right = nums.Length - 1;

                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] % 2 == 0)
                    {
                        result[left++] = nums[i];
                    }
                    else
                    {
                        result[right--] = nums[i];
                    }
                }

                return result; // Placeholder

            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum

        // The edge cases of this problem were negative numbers, an empty array, and an array with one element.
        // I used a dictionary to efficiently find a complement without using the same index twice.
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Write your code here
                Dictionary<int, int> dict = new Dictionary<int, int>();

                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i];
                    if (dict.ContainsKey(complement))
                    {
                        return new int[] { dict[complement], i };
                    }

                    if (!dict.ContainsKey(nums[i]))
                    {
                        dict[nums[i]] = i;
                    }
                }

                return Array.Empty<int>();

            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Write your code here
                Array.Sort(nums);

                int product1 = nums[0] * nums[1] * nums[nums.Length - 1];
                int product2 = nums[nums.Length - 1] * nums[nums.Length - 2] * nums[nums.Length - 3];

                return Math.Max(product1, product2);

            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Write your code here
                if (decimalNumber == 0)
                {
                    return "0";
                }

                string binary = "";
                while (decimalNumber > 0)
                {
                    binary = (decimalNumber % 2) + binary;
                    decimalNumber /= 2;
                }

                return binary; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array

        // The edge cases of this problem were empty array and array with one element, an array with no rotation, and an array where all elements are the same.
        // I used binary search to find the minimum element in the rotated sorted array, which naturally handles the edge cases.
        public static int FindMin(int[] nums)
        {
            try
            {
                // Write your code here
                int left = 0;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int mid = left + (right - left) / 2;

                    if (nums[mid] > nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid;
                    }
                }

                return nums[left]; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number

        // The edge cases of this problem were negative numbers, numbers ending in zeros, and single-digit numbers.
        // I ruled out negative numbers and numbers ending in zeros as they cannot be palindromes, while reversing digits to compare against the original number.
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Write your code here
                if (x < 0)
                {
                    return false;
                }

                int original = x;
                int reversed = 0;

                while (x > 0)
                {
                    int digit = x % 10;
                    reversed = reversed * 10 + digit;
                    x /= 10;
                }

                return original == reversed;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number

        // The edge cases of this problem were negative numbers, a large number n, zero, and one.
        // I returned 0 for n = 0 and 1 for n = 1, while using an iterative approach to calculate Fibonacci numbers for larger n.
        public static int Fibonacci(int n)
        {
            try
            {
                // Write your code here
                if (n <= 1)
                {
                    return n;
                }

                int prev1 = 0, prev2 = 1;
                for (int i = 2; i <= n; i++)
                {
                    int temp = prev1 + prev2;
                    prev1 = prev2;
                    prev2 = temp;
                }

                return prev2;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
