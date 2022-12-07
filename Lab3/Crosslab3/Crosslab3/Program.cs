namespace Crosslab3;

public static class Program
{
    //private static readonly List<int>[] G = Enumerable.Repeat(new List<int>(), 30005).ToArray(); // Bug
    private static readonly List<int>[] G = InitializeWithDefaultInstances(30005);
    static readonly List<int> Ret = Enumerable.Repeat(0, 30005).ToList();
    static readonly List<bool> Used = Enumerable.Repeat(false, 30005).ToList();
    static int _last;
    static int _n;

    static List<int>[] InitializeWithDefaultInstances(int length) // Fix 
    {
        List<int>[] array = new List<int>[length];
        for (int i = 0; i < length; i++)
        {
            array[i] = new List<int>();
        }
        return array;
    }
    static void Dfs(int i)
    {
        Used[i] = true;
        foreach (var j in G[i])
        {
            if (!Used[j])
            {
                Dfs(j);
            }
        }
    }
    static void Solve(int i)
    {
        Dfs(i);
        if (Used[_last])
        {
            Console.Write(i);
            File.WriteAllText("output.txt", i.ToString());
            return;
        }
        Solve(Ret[i]);
    }

    internal static void Main()
    {
        List<int> input = new List<int>();
        // Console
        // while (Console.ReadLine() is { } line && line != "")
        // {
        //   string[] numbers = line.Split(" ");
        //   foreach (string i in numbers)
        //   {
        //     input.Add(int.Parse(i));
        //   }
        // }
        string[] lines = File.ReadAllLines("input.txt");
        foreach (var line in lines)
        {
            Console.WriteLine(line);
            foreach (var number in line.Split(" "))
            {
                input.Add(int.Parse(number));
            }
        }

        int iter = 0;
        _n = input[iter++];
        var first = input[iter++];
        _last = input[iter++];
        if (_last < first)
        {
            (_last, first) = (first, _last);
        }
        for (int i = 2; i <= _n; i++)
        {
            var tmp = input[iter++];
            G[tmp].Add(i);
            Ret[i] = tmp;
        }
        Solve(first);
    }
}