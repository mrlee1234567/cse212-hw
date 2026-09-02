using System;
using System.Collections.Generic;

public static class Divisors {
    /// <summary>
    /// Entry point for the Divisors class
    /// </summary>
    public static void Run() {
        List<int> list = FindDivisors(80);
        Console.WriteLine("<List>{" + string.Join(", ", list) + "}"); // <List>{1, 2, 4, 5, 8, 10, 16, 20, 40}
        List<int> list1 = FindDivisors(79);
        Console.WriteLine("<List>{" + string.Join(", ", list1) + "}"); // <List>{1}
    }

    /// <summary>
    /// Create a list of all divisors for a number including 1
    /// and excluding the number itself. Modulo will be used
    /// to test divisibility.
    /// </summary>
    /// <param name="number">The number to find the divisor</param>
    /// <returns>List of divisors</returns>
    private static List<int> FindDivisors(int number) {
        List<int> results = new();
        // TODO problem 1
        for (int i = 1; i < number; i++)
        {
            double iq = number / i;
            int iqr = number / i;
            if (iq == iqr)
            {
                results.Add(i);
                // there was a method to the madness... this isnt a me c# problem, i always forget mod is a thing, its almost never taught in school
            }
        }
        return results;
    }
}

/*
problem 1:
The method should create and return a list of divisors of the number provided into the
method. The list should include the value 1 but should not include the actual number.
If the number was 12, then the resulting list would be {1, 2, 3, 4, 6}. If the number was
17, then the resulting list would be just {1} because 17 is a prime number. When
implementing the method, use a for loop, an if statement, and call Add.
*/