using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
             //Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            //int[] nums1 = { 1, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            //int[] nums2 = { 0, 1, 2 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            //int[] nums3 = { 3, 2, 4 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4};
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 10;
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
            //List to store missing numbers
            List<int> missingnumbers = new List<int>();
            //Input array to HashSet which stores only unique values
            HashSet<int> numSet = new HashSet<int>(nums);
            try
            {
                //Edge case -Check if the input array is empty or null

                if (nums.Length == 0 || nums.Length == null)
                {
                    return missingnumbers;
                    Console.WriteLine("Invalid input.");
                }
                for (int i = 1; i <= nums.Length; i++)
                {
                    if (!numSet.Contains(i))
                    {
                        missingnumbers.Add(i);
                    }
                }

                return missingnumbers; 
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
                //Edge case: Check if the input array is null
                if (nums == null)
                {
                    Console.WriteLine("Input array is null");
                    return nums;
                }
                //Edge case: Check if the input array is empty
                if (nums.Length == 0)
                {
                    Console.WriteLine("Input array is empty");
                    return nums;
                }
                
                int odd = 0;
                for(int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] % 2 == 0)
                    {
                        int temp = nums[odd];
                        nums[odd] = nums[i];
                        nums[i] = temp;
                        odd++;
                    }
                }
                return nums; 
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum

        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                //Edge case -Check if the input array is null
                if (nums == null)
                {
                    Console.WriteLine("Input array is null.");
                    return new int[0];
                }
                //Edge case -Check if the input array is empty or has only one element
                if ( nums.Length<2)
                {
                    Console.WriteLine("Input array does not have enough elements.");
                    return new int[0];
                }
                for (int i=0;i<= nums.Length - 1; i++)
                {
                    for (int j = i + 1; j <= nums.Length - 1; j++)
                    {
                        if (nums[i] + nums[j] == target)
                        {
                            return new int[] { i, j };
                        }
                    }
                }
                return new int[] {}; 
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
                //Edge case -Check if the input array is null
                if (nums == null)
                {
                    Console.WriteLine("Input array is null.");
                    return 0;
                }
                //Edge case -Check if the input array is empty or has less than three elements
                if (nums.Length < 3)
                {
                    Console.WriteLine("Input array is empty or has less than three elements.");
                    return 0;
                }
                Array.Sort(nums);
                int n = nums.Length;
                // Calculate the maximum product of three numbers
                int product1 = nums[n - 1] * nums[n - 2] * nums[n - 3];
                //If the array has negative numbers, calculate the product of two smallest and one largest number
                int product2 = nums[0] * nums[1] * nums[n - 1];
                // Compare the two products and return the maximum
                if (product1 > product2)
                {
                    return product1;
                }
                else
                {
                    return product2;
                }
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
                //Edge case -Check if the input number is negative
                if (decimalNumber < 0)
                {
                    Console.WriteLine("Input number is negative.");
                    return "";
                }
                if (decimalNumber == 0)
                {
                    return "0";
                }
                // Initialize an empty string to store the binary representation
                string binary = "";

                while (decimalNumber > 0)
                {
                    int r = decimalNumber % 2;
                    // Add the remainder to the binary string
                    binary = r + binary;
                    decimalNumber /= 2;
                }      
                return binary; 
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                // Edge Case : null array
                if (nums == null|| nums.Length == 0)
                {
                    Console.WriteLine("Input array is null or empty");
                    return int.MinValue;
                }
                int left = 0;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int mid = left + (right - left) / 2;

                    if (nums[mid] > nums[right])
                    {
                        // Minimum is in the right half
                        left = mid + 1;
                    }
                    else
                    {
                        // Minimum is at mid or in the left half
                        right = mid;
                    }
                }

                return nums[left];          
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            int temp = 0;
            int result = 0;
            int target = x;
            try
            {
                //Edge case -Check if the input number is negative
                if (x < 0)
                    return false;
                //Edge case -Check if the input number is less than 10. Single digit numbers are palindromes
                if (x>=0 && x<10)
                    return true;
                while (x > 0)
                {
                    temp = x % 10;
                    result = result*10 + temp;
                    x = x / 10;
                }
                return result == target; 

            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            //Edge case: Check valid range
            if (n < 0 || n>30)
            {
                Console.WriteLine("Input out of valid range (0 to 30)");
                return -1;
            }
            // Edge case: Check if the input number is 0 or 1
            if (n == 0) return 0;
            if (n == 1) return 1;

            int a = 0;
            int b = 1;
            int temp = 0;
            try
            {
                for(int i = 2; i <=n; i++)
                {
                    temp = a+b;
                    a = b;
                    b = temp;
                }

                return b; 
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
