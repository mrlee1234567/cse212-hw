
using System;
using System.Collections.Generic;

class D
{
    static void Main()
    {
        int[] d = R(5);//r=random 1-7, d=[r,r,r,r,r]
        Array.Sort(d);
        Console.WriteLine("Values: " + string.Join(", ", d));
        int s = C(d);//s=int of 0, 10, 20, 30, 40, but when d is [2,2,3,3,3]
        Console.WriteLine("Total: " + s);
    }
    //because R contains a Random that is called several times, the final value of s is an int of either 0, 10, 20, 30, or 40
    // therefore, this code returns said numbers based on an initial seed
    //when d is [2,2,3,3,3], the result is most likely 10, because the foreach loop breaks when 10 is added to s

    static int[] R(int n)//n=5
    {
        Random r = new Random();
        int[] d = new int[n];//array len 5
        for (int i = 0; i < n; i++)
        {
            d[i] = r.Next(1, 7);
        }
        return d;//[r,r,r,r,r]
    }

    static int C(int[] d)//d=[r,r,r,r,r] or [2,2,3,3,3]
    {
        int s = 0;
        Dictionary<int, int> c = new Dictionary<int, int>();//c={}
        foreach (int x in d)
        {
            if (c.ContainsKey(x))
            {
                c[x]++;
            }
            else
            {
                c[x] = 1;
            }//{2:2,3:3}
        }
        foreach (int v in c.Values)
        {
            switch (v)
            {
                case 2:
                    s += 10;
                    break;
                case 3:
                    s += 20;
                    break;
                case 4:
                    s += 30;
                    break;
                case 5:
                    s += 40;
                    break;
            }
        }
        return s;//s=int of 0, 10, 20, 30, 40, but under constraitns, it will rpbably be 10
    }
}

