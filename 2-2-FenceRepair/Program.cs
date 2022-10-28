using System.Diagnostics;

namespace _2_2_FenceRepair
{
    internal class Program
    {
        static int n; // 切り出すべき板の数
        static int[] l; // 切り出した板の長さ

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
            l = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToArray();
        }

        static void Solve()
        {
            Array.Sort(l);
            int answer = 0;

            var depth = 0;
            var bit = n;

            while (bit > 0)
            {
                bit >>= 1;
                depth++;
            }
            var border = n - (1 << depth - 1);

            for (int i = 0; i < n; i++)
            {
                answer += l[i] * depth;
                if (i == border)
                {
                    depth--;
                }
            }
            Console.WriteLine(answer);
        }
    }
}