using System;
using System.Collections.Generic;

public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        List<int> res = new List<int>();
        int l1i = 0;
        int l2i = 0;

        foreach (int i in select)
        {
            if (i == 1)
            {
                int iq = list1[l1i];
                res.Add(iq);
                l1i++;
            }
            else if (i == 2)
            {
                int iq = list2[l2i];
                res.Add(iq);
                l2i++;
            }
            // i got very close, i didnt know that you could add the ++ to inside the index selector
        }
        
        return res.ToArray();
    }
}

/*
problem 2

Come up with a plan (up to 10 minutes) on how to implement the integer version the
ListSelector() method. The function takes two arrays and a selector array. The two
arrays are combined together into a new array according to the selector array. The
selector array only contains 1's and 2's. A value of 1 means that you should select
the next number from the first array. A value of 2 means that you should select the
next number from the second array. For example, if array 1 is {1, 2, 3, 4} and if
array 2 is {10, 20, 30, 40} and if the selector array is {1, 1, 2, 2, 1, 1, 2, 2},
then the resulting array would be {1, 2, 10, 20, 3, 4, 30, 40}.
*/