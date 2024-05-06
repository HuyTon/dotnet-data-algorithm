using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

public class ArrayProcessing
{
    // Starting from C# 3.0, LINQ methods like Concat are automatically available without explicitly importing System.Linq.
    // So, even though you've commented out using System.Linq;, the code still works because the LINQ methods are available by default. 
    // However, it's generally a good practice to include using System.Linq; for clarity and to make it clear that you are using LINQ methods in your code.
    public static void MergeWithLinq()
    {
        int[] array1 = [1, 2, 3, 4]; // C# 9.0 and later versions
        int[] array2 = { 4, 5, 6, 7, 8 }; // Older versions of C# must use curly braces {}

        int[] mergedArray1 = array1.Concat(array2).ToArray();

        // The spread operator, recently introduced to C# in version 12 as part of the .NET 8 update is a powerful feature borrowed from JavaScript.
        // The operator is represented by three dots (...) and serves multiple purposes such as cloning, merging, and expanding collections.
        int[] mergedArray2 = [.. array1, .. array2];

        Console.WriteLine("- Merge arrays with Linq -");
        Console.WriteLine(string.Join(", ", mergedArray1)); // 1, 2, 3, 4, 4, 5, 6, 7, 8
        Console.WriteLine(string.Join(", ", mergedArray2)); // 1, 2, 3, 4, 4, 5, 6, 7, 8
    }

    public static void MergeWithArrayCopy()
    {
        int[] array1 = { 1, 2, 3, 4, 5 };
        int[] array2 = { 6, 7, 8 };

        int[] mergedArray = new int[array1.Length + array2.Length];
        Array.Copy(array1, mergedArray, array1.Length);
        Array.Copy(array2, 0, mergedArray, array1.Length, array2.Length);

        Console.WriteLine("- Merge arrays with Array Copy -");
        Console.WriteLine(string.Join(", ", mergedArray));
    }

    /*
    You are given two integer arrays nums1 and nums 2, sorted in non-decreasing order, and two integers m and n, representing the number of elements in nums1 and nums 2 respectively.
    Merge nums1 and nums2 into a single array sorted in non-decreasing order.
    The final sorted array should not be returned by the function, but instead be stored inside the array nums 1. To accommodate this, nums 1 has a length of m + n, where the first m 
    elements denote the elements that should be merged, and the last n elements are set to and should be ignored. nums2 has a length of n.
    
    Example 1:
    - Input: nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3
    - Output: [1,2,2,3,5,6]
    - Explanation: The arrays we are merging are [1,2,3] and [2,5,6].
      The result of the merge is [1,2,2,3,5,6] with the underlined elements coming from nums1.
    
    Example 2:
    - Input: nums1 = [1], m = 1, nums2 = [], n = 0
    - Output: [1]
    - Explanation: The arrays we are merging are [1] and [].
      The result of the merge is [1].
    
    Example 3:
    - Input: nums1 = [0], m = 0, nums2 = [1], n = 1
    - Output: [1]
    - Explanation: The arrays we are merging are [] and [1].
      The result of the merge is [1].
      Note that because m = 0, there are no elements in nums1. The 0 is only there to ensure the merge result can fit in nums1.
    
    Constraints:
    - nums1.length == m + n
    - nums2.length == n
    - 0 <= m, n <= 200
    - 1 <= m + n <= 200
    - −10^9 <= nums1[i], nums2[j] <= 10^9
    */
    public static void MergeSortedArrays()
    {
        int[] nums1 = { 1, 2, 3, 0, 0, 0 };
        int[] nums2 = { 2, 5, 6 };
        int m = 3;
        int n = 3;
        int i = m - 1;
        int j = n - 1;
        int k = m + n - 1;

        while (i >= 0 && j >= 0)
        {
            if (nums1[i] > nums2[j])
            {
                nums1[k] = nums1[i];
                --i;
            }
            else
            {
                nums1[k] = nums2[j];
                --j;
            }
            k--;
        }

        // If there are remaining elements in nums2, copy them to nums1
        while (j >= 0)
        {
            nums1[k] = nums2[j];
            --j;
            --k;
        }

        Console.WriteLine("- Merge sorted arrays -");
        Console.WriteLine(string.Join(", ", nums1));
    }

    public static void RemoveDuplicatedItems()
    {
        int[] nums = { 1, 1, 2, 2, 3, 3, 3, 4, 4, 4, 4 };
        HashSet<int> set = new HashSet<int>(nums);
        int[] result = set.ToArray();

        Console.WriteLine("- Remove duplicated items -");
        Console.WriteLine(string.Join(", ", result));
    }

    public static void RemoveRepeatedNumbersWithLinq()
    {
        int[] numbers = { 1, 2, 2, 3, 4, 4, 5 };

        // Use LINQ's Distinct() method
        int[] uniqueNumbers = numbers.Distinct().ToArray();

        Console.WriteLine("Original array:");
        Console.WriteLine(string.Join(", ", numbers));

        Console.WriteLine("Array after removing duplicates:");
        Console.WriteLine(string.Join(", ", uniqueNumbers));
    }

    public static void RemoveDuplicatedItemsManually()
    {
        int[] nums = { 1, 1, 2, 2, 3, 3, 3, 4, 4, 4, 4 };
        HashSet<int> set = new HashSet<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (!set.Contains(nums[i]))
            {
                set.Add(nums[i]);
            }
        }

        int[] uniqueArray = new int[set.Count];
        set.CopyTo(uniqueArray);

        Console.WriteLine("- Remove duplicated items manually -");
        Console.WriteLine(string.Join(", ", uniqueArray));
    }

    public static void CountSubarrays()
    {
        int[] array = { 1, 2, 3, 4 };
        int count = 0;

        for (int start = 0; start < array.Length; start++)
        {
            for (int end = start; end < array.Length; end++)
            {
                count++;
                // Print the current subarray
                Console.Write("[ ");
                for (int i = start; i <= end; i++)
                {
                    Console.Write($"{array[i]} ");
                }
                Console.WriteLine("]");
            }
        }

        Console.WriteLine($"Total number of subarrays: {count}");
    }

    public static void CountSubarraysByFormula()
    {
        int[] nums = { 1, 2, 3, 4 };
        int n = nums.Length;

        // Calculate the total number of subarrays using the formula
        int totalCount = (n * (n - 1)) / 2;
        Console.WriteLine($"Total number of subarrays using the formula: {totalCount}");
    }

    public static void FindMedianOfSortedArrays()
    {
        int[] nums1 = { 1, 3 };
        int[] nums2 = { 2 };
        double median = 0;

        // Option 1: merge nums1 with nums2 with Linq
        int[] mergedArray1 = nums1.Concat(nums2).ToArray();

        // Option 2: merge nums1 with nums2 manually
        int totalLength = nums1.Length + nums2.Length;
        int[] mergedArray2 = new int[totalLength];

        int i = 0, j = 0, k = 0;
        while (i < nums1.Length && j < nums2.Length)
        {
            if (nums1[i] < nums2[j])
            {
                mergedArray2[k++] = nums1[i++];
            }
            else
            {
                mergedArray2[k++] = nums2[j++];
            }
        }

        while (i < nums1.Length)
        {
            mergedArray2[k++] = nums1[i++];
        }

        while (j < nums2.Length)
        {
            mergedArray2[k++] = nums2[j++];
        }

        if (totalLength % 2 == 0)
        {
            // If totalLength is even, return the average of the middle two elements
            int mid = totalLength / 2;
            median = (mergedArray2[mid - 1] + mergedArray2[mid + 2]) / 2.0;
        }
        else
        {
            // If totalLength is odd, return the middle element
            median = mergedArray2[totalLength / 2];
        }
        Console.WriteLine($"The median number of [{string.Join(" ,", nums1)}] and [{string.Join(" ,", nums2)}] is {median}");
    }

    public static void FindSecondHighest()
    {
        int[] array = { 5, 2, 8, 10, 3 };

        int max = int.MinValue;
        int secondMax = int.MinValue;

        foreach (int num in array)
        {
            if (num > max)
            {
                secondMax = max;
                max = num;
            }
            else if (num > secondMax && num != max)
            {
                secondMax = num;
            }
        }

        Console.WriteLine("- Find the second highest -");
        Console.WriteLine($"The highest and second highest numbers of [{string.Join(" ,", array)}] are {max}, {secondMax}");
    }

    public static void FindDuplicates()
    {
        int[] array1 = { 1, 2, 3, 4, 5 };
        int[] array2 = { 4, 5, 6, 7, 8 };

        HashSet<int> set = new HashSet<int>(array1);
        List<int> duplicates = new List<int>();

        foreach (int num in array2)
        {
            if (set.Contains(num))
            {
                duplicates.Add(num);
            }
        }

        Console.WriteLine("- Find duplicates between two arrays -");
        Console.WriteLine($"{string.Join(" ,", array1)} and {string.Join(" ,", array2)}");
        Console.WriteLine($"{string.Join(" ,", duplicates)}");
    }

    public static void FindMissingInteger(int[] nums)
    {
        int difference = nums[nums.Length - 1] - nums[nums.Length - 2];
        int step = difference;

        for (int i = nums.Length - 1; i > 0; i--)
        {
            step = nums[i] - nums[i - 1];
            if (step != difference)
            {
                int missingNumber = step > difference ? nums[i - 1] + step - difference : nums[i] + difference - step;
                Console.WriteLine($"Missing number of [{string.Join(" ,", nums)}] is {missingNumber}");
                break;
            }
        }

        if (step == difference) Console.WriteLine($"Missing number of [{string.Join(" ,", nums)}] is null");
    }

    public static void FindMissingIntegerOptimize(int[] nums)
    {
        int difference = (nums[nums.Length - 1] - nums[0]) / nums.Length;

        if (!int.TryParse(difference.ToString(), out _))
        {
            Console.WriteLine($"Missing number of [{string.Join(" ,", nums)}] is null");
            return;
        }

        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i + 1] - nums[i] != difference)
            {
                int missingNumber = nums[i] + difference;
                Console.WriteLine($"Missing number of [{string.Join(" ,", nums)}] is {missingNumber}");
                return;
            }
        }

        // If no missing integer found
        Console.WriteLine($"Missing number of [{string.Join(" ,", nums)}] is null");

    }

    public static void TestFindMissingInteger()
    {
        int[] array1 = { 1, 3, 5, 7, 9, 11, 13, 15, 19 }; // 17
        int[] array2 = { 1, 2, 3, 4, 5, 6, 8, 9, 10 }; // 7
        int[] array3 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; // null
        int[] array4 = { 1, 4, 7, 13, 16, 19 }; // 10

        Console.WriteLine("- Find Missing Integer -");

        FindMissingInteger(array1);
        FindMissingInteger(array2);
        FindMissingInteger(array3);
        FindMissingInteger(array4);
    }

    public static void TestFindMissingIntegerOptimize()
    {
        int[] array1 = { 1, 3, 5, 7, 9, 11, 13, 15, 19 }; // 17
        int[] array2 = { 1, 2, 3, 4, 5, 6, 8, 9, 10 }; // 7
        int[] array3 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; // null
        int[] array4 = { 1, 4, 7, 13, 16, 19 }; // 10

        Console.WriteLine("- Find Missing Integer Optimize -");

        FindMissingIntegerOptimize(array1);
        FindMissingIntegerOptimize(array2);
        FindMissingIntegerOptimize(array3);
        FindMissingIntegerOptimize(array4);
    }

    public static int HasNValues(int[] nums, int n)
    {
        HashSet<int> set = new HashSet<int>(nums);

        if (set.Count == n) return 1;
        else return 0;
    }

    public static int HasNValues2(int[] nums, int n)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();

        foreach (int num in nums)
        {
            map[num] = map.ContainsKey(num) ? map[num]++ : 1;
        }

        if (map.Keys.Count == n) return 1;
        else return 0;
    }

    public static void TestHasNValues()
    {
        int[] nums1 = { 1, 2, 2, 1 };
        int[] nums2 = { 1, 1, 1, 8, 1, 1, 1, 3, 3 };
        int[] nums3 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        Console.WriteLine("- HasNValues -");
        Console.WriteLine($"[{string.Join(" ,", nums1)}], {2} is {HasNValues(nums1, 2)}");
        Console.WriteLine($"[{string.Join(" ,", nums2)}], {3} is {HasNValues(nums2, 3)}");
        Console.WriteLine($"[{string.Join(" ,", nums3)}], {10} is {HasNValues(nums3, 10)}");
        Console.WriteLine($"[{string.Join(" ,", nums1)}], {3} is {HasNValues(nums1, 3)}");
        Console.WriteLine($"[{string.Join(" ,", nums2)}], {2} is {HasNValues(nums2, 2)}");
        Console.WriteLine($"[{string.Join(" ,", nums3)}], {20} is {HasNValues(nums3, 20)}");

        Console.WriteLine("- HasNValues2 -");
        Console.WriteLine($"[{string.Join(" ,", nums1)}], {2} is {HasNValues2(nums1, 2)}");
        Console.WriteLine($"[{string.Join(" ,", nums2)}], {3} is {HasNValues2(nums2, 3)}");
        Console.WriteLine($"[{string.Join(" ,", nums3)}], {10} is {HasNValues2(nums3, 10)}");
        Console.WriteLine($"[{string.Join(" ,", nums1)}], {3} is {HasNValues2(nums1, 3)}");
        Console.WriteLine($"[{string.Join(" ,", nums2)}], {2} is {HasNValues2(nums2, 2)}");
        Console.WriteLine($"[{string.Join(" ,", nums3)}], {20} is {HasNValues2(nums3, 20)}");
    }

    public static int EquivalentArrays(int[] nums1, int[] nums2)
    {
        if (nums1.Length == 0 && nums2.Length == 0) return 1;

        if ((nums1.Length == 0 && nums2.Length > 0) || (nums1.Length > 0 && nums2.Length == 0))
            return 0;

        bool isEquivalent = true;
        if (nums1.Length > nums2.Length)
        {
            foreach (int num in nums1)
            {
                if (!nums2.Contains(num))
                {
                    isEquivalent = false;
                    break;
                }
            }
        }
        else if (nums1.Length < nums2.Length)
        {
            foreach (int num in nums2)
            {
                if (!nums1.Contains(num))
                {
                    isEquivalent = false;
                    break;
                }
            }
        }
        else
        {
            foreach (int num in nums1)
            {
                if (!nums2.Contains(num))
                {
                    isEquivalent = false;
                    break;
                }
            }

            foreach (int num in nums2)
            {
                if (!nums1.Contains(num))
                {
                    isEquivalent = false;
                    break;
                }
            }
        }

        if (isEquivalent) return 1;
        else return 0;
    }

    public static void TestEquivalentArrays()
    {
        Console.WriteLine("- Test Equivalent Arrays -");

        int[] a1 = { 0, 1, 2 };
        int[] a2 = { 2, 0, 1 };
        Console.WriteLine($"Equivalent of [{string.Join(" ,", a1)}] and [{string.Join(" ,", a2)}] is {EquivalentArrays(a1, a2)}"); // Output: 1

        int[] a3 = { 0, 1, 2, 1 };
        int[] a4 = { 2, 0, 1 };
        Console.WriteLine($"Equivalent of [{string.Join(" ,", a3)}] and [{string.Join(" ,", a4)}] is {EquivalentArrays(a3, a4)}");  // Output: 1

        int[] a5 = { 2, 0, 1 };
        int[] a6 = { 0, 1, 2, 1 };
        Console.WriteLine($"Equivalent of [{string.Join(" ,", a5)}] and [{string.Join(" ,", a6)}] is {EquivalentArrays(a5, a6)}");  // Output: 1

        int[] a7 = { 0, 5, 5, 5, 1, 2, 1 };
        int[] a8 = { 5, 2, 0, 1 };
        Console.WriteLine($"Equivalent of [{string.Join(" ,", a7)}] and [{string.Join(" ,", a8)}] is {EquivalentArrays(a7, a8)}");  // Output: 1

        int[] a9 = { 5, 2, 0, 1 };
        int[] a10 = { 0, 5, 5, 5, 1, 2, 1 };
        Console.WriteLine($"Equivalent of [{string.Join(" ,", a9)}] and [{string.Join(" ,", a10)}] is {EquivalentArrays(a9, a10)}");  // Output: 1

        int[] a11 = { 0, 2, 1, 2 };
        int[] a12 = { 3, 1, 2, 0 };
        Console.WriteLine($"Equivalent of [{string.Join(" ,", a11)}] and [{string.Join(" ,", a12)}] is {EquivalentArrays(a11, a12)}");  // Output: 0

        int[] a13 = { 3, 1, 2, 0 };
        int[] a14 = { 0, 2, 1, 0 };
        Console.WriteLine($"Equivalent of [{string.Join(" ,", a13)}] and [{string.Join(" ,", a14)}] is {EquivalentArrays(a13, a14)}");  // Output: 0

        int[] a15 = { 1, 1, 1, 1, 1, 1 };
        int[] a16 = { 1, 1, 1, 1, 1, 2 };
        Console.WriteLine($"Equivalent of [{string.Join(" ,", a15)}] and [{string.Join(" ,", a16)}] is {EquivalentArrays(a15, a16)}");  // Output: 0

        int[] a17 = { };
        int[] a18 = { 3, 1, 1, 1, 1, 2 };
        Console.WriteLine($"Equivalent of [{string.Join(" ,", a17)}] and [{string.Join(" ,", a18)}] is {EquivalentArrays(a17, a18)}");  // Output: 0

        int[] a19 = { };
        int[] a20 = { };
        Console.WriteLine($"Equivalent of [{string.Join(" ,", a19)}] and [{string.Join(" ,", a20)}] is {EquivalentArrays(a19, a20)}"); // Ouput: 1

    }

    public static void FindMaxNumbers()
    {
        // If there is one max number return false.
        // If there are two max numbers return true.
        int[] a1 = { 1, 6, 4, 4, 3, 5, 6 }; // Output: true 
        int[] a2 = { 3, 4, 7, 2, 11, 32, 21 }; // Output: false

        int max = a1[0];
        int count = 0;
        foreach (int num in a1)
        {
            if (max < num)
            {
                max = num;
                count = 1; ;
            }
            else if (max == num)
            {
                count++;
            }
        }

        Console.WriteLine("- Find Max Numbers -");
        if (count > 1) Console.WriteLine("true");
        else Console.WriteLine("false");
    }

    public static bool OddEvenNumbers(int?[] a)
    {
        if (a == null || a.Length == 0 || a.Length == 2) return false;

        if (a[0] % 2 != 0 && a[a.Length - 1] % 2 != 0)
        {
            int i = 0;
            while (i + 3 < a.Length)
            {
                if (a[i + 1] % 2 == 0 && a[i + 2] % 2 == 0 && a[i + 3] % 2 != 0)
                {
                    i += 3;
                }
                else return false;
            }
            return true;
        }
        return false;
    }

    public static void TestOddEvenNumbers()
    {
        int?[] a1 = { 7, 2, 4, 11, 6, 8, 9 }; // Output: true
        int?[] a2 = { 7, 2, 4, 11, 6, 8, 10, 9 }; // Output: false
        int?[] a3 = { 7, 9 }; // Output: false;

        Console.WriteLine("- Test Odd Even Numbers -");
        Console.WriteLine($"[{string.Join(" ,", a1)}] is {OddEvenNumbers(a1)}");
        Console.WriteLine($"[{string.Join(" ,", a2)}] is {OddEvenNumbers(a2)}");
        Console.WriteLine($"[{string.Join(" ,", a3)}] is {OddEvenNumbers(a3)}");
    }
}