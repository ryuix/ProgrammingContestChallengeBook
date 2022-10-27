using System.Diagnostics;

namespace _2_2_SarumansArmy
{
    internal class Program
    {
        static int n;
        static int r;
        static int[] x;

        static void Main(string[] args)
        {
            using var sr = new StreamReader("input.txt");
            Console.SetIn(sr);

            var sw = new Stopwatch();
            sw.Start();
            Input();
            Solve();
            sw.Stop();
            var ts = sw.Elapsed;

            Console.WriteLine($"{ts.Seconds}:{ts.Milliseconds}");
        }

        static void Input()
        {
            n = int.Parse(Console.ReadLine().Trim());
            r = int.Parse(Console.ReadLine().Trim());
            x = Console.ReadLine().Trim().Split(' ').Select(s => int.Parse(s)).ToArray();
        }

        static void Solve()
        {
            Array.Sort(x);
            (int i, int answer) = (0, 0);

            while (i < n)
            {
                int s = x[i++];

                while (i < n && x[i] <= s + r)
                {
                    i++;
                }
                int p = x[i - 1];
                while (i < n && x[i] < p + r)
                {
                    i++;
                }
                answer++;
            }
            Console.WriteLine(answer);
        }
    }
}