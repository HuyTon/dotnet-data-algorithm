using System;
using System.Collections.Generic;
using System.Diagnostics;

public class StringProcessing
{
    public static void ReverseString()
    {
        string str = "This is a string!";
        char[] chars = str.ToCharArray();
        char[] result = new char[chars.Length];

        for (int i = 0; i < chars.Length; i++)
        {
            result[i] = chars[chars.Length - i - 1];
        }

        // Convert char array back to string
        string revertedString = new string(result);

        Console.WriteLine("- Reverse String -");
        Console.WriteLine(revertedString);
    }

    public static void CountVowels()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        string str = "This is a string!".ToLower();
        char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
        int count = 0;

        foreach (char c in str)
        {
            if (vowels.Contains(c))
            {
                count++;
            }
        }

        stopwatch.Stop();

        Console.WriteLine("- Count Vowels -");
        Console.WriteLine($"Count vowels of string: {str} is {count}");
        Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");
    }

    public static void CountVowelsOptimize()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        string str = "This is a string!".ToLower();
        HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
        int count = 0;

        foreach (char c in str)
        {
            if (vowels.Contains(c))
            {
                count++;
            }
        }

        stopwatch.Stop();

        Console.WriteLine("- Count Vowels Optimize -");
        Console.WriteLine($"Count vowels of string: {str} is {count}");
        Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");
    }

    public static char MostOccurringLetter(string input)
    {
        Dictionary<char, int> map = new Dictionary<char, int>();

        foreach (char c in input)
        {
            if (Char.IsLetter(c))
            {
                Char lowercaseChar = Char.ToLower(c);
                if (map.ContainsKey(lowercaseChar))
                {
                    map[lowercaseChar]++;
                }
                else
                {
                    map[lowercaseChar] = 1; // Or map.Add(lowercaseChar, 1);
                }
            }
        }

        KeyValuePair<char, int> mostOccurringItem = map.Aggregate((x, y) => x.Value > y.Value ? x : y);

        return mostOccurringItem.Key;
    }
}