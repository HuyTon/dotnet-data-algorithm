public class Arithmetic
{
    public static void SwapVariables()
    {
        // Swap 2 variables without using a 3rd variable
        int a = 5;
        int b = 10;

        a = a + b;
        b = a - b;
        a = a - b;

        Console.WriteLine("- Swap two variables -");
        Console.WriteLine($"a = {a}, b = {b}");
    }

    public static void SwapVariablesUseBitwiseXOR()
    {
        // Swap 2 variables without using a 3rd variable
        int a = 5;
        int b = 10;

        a = a ^ b;
        b = a ^ b;
        a = a ^ b;

        Console.WriteLine("- Swap two variables with bitwise XOR operation -");
        Console.WriteLine($"a = {a}, b = {b}");
    }

    public static void FibonacciSeries()
    {
        int n = 10;
        Console.WriteLine($"Fibonacci Series of {n}:");

        for (int i = 0; i < n; i++)
        {
            Console.Write(Fibonacci(i) + " ");
        }
    }

    public static int Fibonacci(int n)
    {
        if (n <= 1) return n;

        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    public static bool IsPrime(int number)
    {
        if (number <= 1) return false; // 0 and 1 are not prime numbers

        // Check for divisibility by numbers from 2 to the square root of the number       
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false; // If the number is divisible by any number in this range, it's not prime
        }

        return true; // If the number is not divisible by any number in this range, it's prime
    }

    public static int BinarySearch(int[] array, int target)
    {
        int start = 0;
        int end = array.Length - 1;

        while (start <= end)
        {
            int mid = (start + end) / 2;
            if (array[mid] == target) return mid;

            if (array[mid] < target)
            {
                start = mid + 1;
            }
            else if (array[mid] > target)
            {
                end = mid - 1;
            }
        }

        return -1;
    }

    private static List<int> MergeSort(List<int> a1, List<int> a2)
    {
        List<int> sorted = new List<int>();

        while (a1.Count > 0 && a2.Count > 0)
        {
            if (a1[0] < a2[0])
            {
                sorted.Add(a1[0]);
                a1.RemoveAt(0);
            }
            else
            {
                sorted.Add(a2[0]);
                a2.RemoveAt(0);
            }
        }

        sorted.AddRange(a1);
        sorted.AddRange(a2);

        return sorted;
    }

    private static List<int> MergeSort(List<int> a)
    {
        if (a.Count <= 1) return a;

        int mid = a.Count / 2;

        List<int> left = MergeSort(a.GetRange(0, mid));
        List<int> right = MergeSort(a.GetRange(mid, a.Count - mid));

        return MergeSort(left, right);
    }

    public static void MergeSort()
    {
        int[] unsortedArr = { 31, 27, 28, 42, 13, 8, 11, 30, 17, 41, 15, 43, 1, 36, 9, 16, 20, 35, 48, 37, 7, 26, 34, 21, 22, 6, 29, 32, 49, 10, 12, 19, 24, 38, 5, 14, 44, 40, 3, 50, 46, 25, 18, 33, 47, 4, 45, 39, 23, 2 };
        List<int> a = new List<int>(unsortedArr);

        List<int> mergedSort = MergeSort(a);

        Console.WriteLine("- Merge Sort -");
        Console.WriteLine($"Merge sort of [{string.Join(" ,", unsortedArr)}] is [{string.Join(" ,", mergedSort)}]");
    }

    public static void FizzBuzz(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                // If the number is divisible by both 3 and 5, we print "FizzBuzz".
                Console.WriteLine("FizzBuzz");
            }
            else if (i % 3 == 0)
            {
                // If the number is divisible by 3, we print "Fizz".
                Console.WriteLine("Fizz");
            }
            else if (i % 5 == 0)
            {
                // If the number is divisible by 5, we print "Buzz".
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(i);
            }
        }
    }

    /// <summary>
    /// Given a list of number, find all its prime factor and use those prime factor to flip the blubs. 
    /// A factor that is a prime number.
    /// In other words: any of the prime numbers that can be multiplied to give the original number.
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    static List<int> FindPrimeFactors(int number)
    {
        List<int> primeFactors = new List<int>();

        // Find all 2 factors first
        while (number % 2 == 0) // 10 % 2 | 9 % 2
        {
            primeFactors.Add(2); // primeFactors = [2]
            number /= 2; // number = 10 /2 = 5
        }

        // Find other prime factors
        for (int i = 3; i <= Math.Sqrt(number); i += 2)
        {
            while (number % i == 0) // 9 % 3 = 0
            {
                primeFactors.Add(i); // primeFactors = [3]
                number /= i; // 9 / 3 = 3
            }
        }

        if (number > 2) // 5 > 2
        {
            primeFactors.Add(number); // primeFactors = [2, 5] | [3, 3]
        }

        return primeFactors;
    }
}