using System.Linq;
using System;

public static class MLinq
{

    public static void TestLinq()
    {
        int[] values = new int[] { 0, 1, 3, 12, 14, 56, 34, 22, 2 };

        var result = from v in values
                     where v < 22
                     orderby v descending //descending 指定排列顺序从大到小 不加则为从小到大
                     select v;

        foreach (var item in result)
        {
            Console.Write("{0} ", item);
        }
        Console.Read();
    }
}