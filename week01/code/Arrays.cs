using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // starting at one going to length+1, multiply number by i where i is the current itterator between 1 and length+1
        // add the resulting multiple to a list, then at the end of the loop, return the array of said list
        List<double> res = new List<double>();
        double iq;
        for (int i = 1; i < length+1; i++)
        {
            iq = number * i;
            res.Add(iq);
        }

        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        return res.ToArray(); // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // in list data, from position 0 to n where n is amount-1, clone said data as l1, and from n+1 to length of data-1, clone said data as l2
        // in the above rules, the input data is equal to l1l2 at first. with l1 and l2 cloned, their order is reversed and data is reset so that data is l2l1

        // the above did not work. here is a new approach.
        // the list data is copied and the original is cleared. in the original, items from index amount to the end are then added from the clone to the original, and then from the beginning to the index amount they are added from the clone

        // the above also did not work. heres another new approach.
        // data is copied to a new array then cleared. for i in the length of data, insert to the new data array[(i-amount) % length of data]

        // the above did not work but it is closer to the right track
        // the new approach is copy data to new array, clear data, and for length of old data, insert to data old[i-amount+length]

        // the above didnt work going back to the previous one but modified?
        // copy data clear data, for length data insert copy[i - amount % length + length % length]

        int[] grug = data.ToArray();
        data.Clear();

        for (int i = 0; i < grug.Length; i++)
        {
            int iq1 = i - amount;
            int iq = ((iq1 % grug.Length) + grug.Length) % grug.Length;
            // Console.WriteLine(iq);
            data.Add(grug[iq]);
        }
        // int[] grug = data.ToArray();
        // data.Clear();

        // for (int i = 0; i < grug.Length; i++)
        // {
        //     int iq = i - amount + grug.Length;
        //     // Console.WriteLine(iq);
        //     data.Add(grug[iq]);
        // }
        // int[] grug = data.ToArray();
        // data.Clear();

        // for (int i = 0; i < grug.Length; i++)
        // {
        //     int iq = (((i % amount) + amount) % amount) % grug.Length;
        //     Console.WriteLine(iq);
        //     data.Add(grug[iq]);
        // }
        // Console.WriteLine(data[0]);
        // Console.WriteLine(data[amount]);
        // Console.WriteLine("thiswasasctiomphte");
        // int[] cwar = data.ToArray();
        // data.Clear();

        // for (int i = amount; i < cwar.Length; i++)
        // {
        //     data.Add(cwar[i]);
        // }
        // for (int i = 0; i < amount; i++)
        // {
        //     data.Add(cwar[i]);
        // }
        // Console.WriteLine(data[0]);

        // List<int> l1 = new List<int>();
        // List<int> l2 = new List<int>();

        // int dc = data.Count;

        // for (int i = 0; i < amount; i++)
        // {
        //     l1.Add(data[i]);
        // }
        // for (int i = amount; i < dc; i++)
        // {
        //     l2.Add(data[i]);
        // }
        // l2.Concat(l1);
        // data = l2;

        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
    }
}
