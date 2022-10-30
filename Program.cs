using System;
using System.Diagnostics.Metrics;
using System.IO;

public static class Rectangles
{
    
    internal static void Main()
    {
        
        long w;
        long h;
        w = long.Parse(Console.ReadLine());
        h = long.Parse(Console.ReadLine());
        long s = 0;
        for (long i = 1; i != w + 1; ++i)
        {
            for (long j = 1; j != h + 1; ++j)
            {
                s += i * j;
            }
        }
        Console.Write(s);
        
    }
    

}
