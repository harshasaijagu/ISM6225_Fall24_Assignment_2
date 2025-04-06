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
            IList<int> missingNumbers = Question1.MissingNumbers.FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = Question2.SortArray.SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = Question3.TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = Question4.MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = Question5.DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = Question6.FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = Question7.IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Question8.Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }
    }

    // Question 1: Find Missing Numbers in Array
public static class Question1
    {
        public static class MissingNumbers
        {
            public static IList<int> FindMissingNumbers(int[] nums)
            {
                var resultList = new List<int>(); // To hold missing values
                var numberSet = new HashSet<int>(nums); // Fast lookup for existing numbers
                for (int i = 1; i <= nums.Length; i++)
                {
                    if (!numberSet.Contains(i))
                    {
                        resultList.Add(i);
                    }
                }
                return resultList;
            }
        }
    }

    // Question 2: Sort Array by Parity
public static class Question2
    {
        public static class SortArray
        {
            public static int[] SortArrayByParity(int[] nums)
            {
                int start = 0, end = nums.Length - 1;
                while (start < end)
                {
                    if (nums[start] % 2 > nums[end] % 2)
                    {
                        int temp = nums[start];
                        nums[start] = nums[end];
                        nums[end] = temp;
                    }
                    if (nums[start] % 2 == 0) start++;
                    if (nums[end] % 2 == 1) end--;
                }
                return nums;
            }
        }
    }

    // Question 3: Two Sum
public static class Question3
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            var seen = new Dictionary<int, int>(); // Map to store seen numbers and their indices
            for (int i = 0; i < nums.Length; i++)
            {
                int required = target - nums[i];
                if (seen.ContainsKey(required))
                {
                    return new int[] { seen[required], i };
                }
                seen[nums[i]] = i;
            }
            return new int[0];
        }
    }

    // Question 4: Find Maximum Product of Three Numbers
public static class Question4
    {
        public static int MaximumProduct(int[] nums)
        {
            Array.Sort(nums);
            int len = nums.Length;
            return Math.Max(nums[0] * nums[1] * nums[len - 1], nums[len - 1] * nums[len - 2] * nums[len - 3]);
        }
    }

    // Question 5: Decimal to Binary Conversion
public static class Question5
    {
        public static string DecimalToBinary(int decimalNumber)
        {
            if (decimalNumber == 0) return "0";
            var binaryStack = new Stack<int>();
            while (decimalNumber > 0)
            {
                binaryStack.Push(decimalNumber % 2);
                decimalNumber /= 2;
            }
            return string.Join("", binaryStack);
        }
    }

    // Question 6: Find Minimum in Rotated Sorted Array
public static class Question6
    {
        public static int FindMin(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
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
            return nums[left];
        }
    }

    // Question 7: Palindrome Number
public static class Question7
    {
        public static bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            int original = x, reversed = 0;
            while (x > 0)
            {
                reversed = reversed * 10 + x % 10;
                x /= 10;
            }
            return original == reversed;
        }
    }

    // Question 8: Fibonacci Number
public static class Question8
    {
        public static int Fibonacci(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            int first = 0, second = 1;
            for (int i = 2; i <= n; i++)
            {
                int sum = first + second;
                first = second;
                second = sum;
            }
            return second;
        }
    }
}
