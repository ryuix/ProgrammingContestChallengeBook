using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace _2_3_KnapsackProblem
{
    internal class Program
    {
        static int n; // 品物の個数
        static (int w, int v)[] items;
        static int W; // 最大重量

        static int[][] jag;

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
            items = new (int w, int v)[n];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Trim().Split(' ');
                items[i] = (int.Parse(line[0]), int.Parse(line[1]));
            }

            W = int.Parse(Console.ReadLine().Trim());
        }

        static void Solve()
        {
            jag = new int[n + 1][];
            for (int i = 0; i < n + 1; i++)
            {
                jag[i] = Enumerable.Repeat(-1, W + 1).ToArray();
            }
            DP(0, 0);
            Console.WriteLine(DP(0, W));
        }

        // n番目以降から選ぶ(n番目は存在しない)
        static int DP(int i, int j)
        {
            // 探索済み
            if (jag[i][j] >= 0)
            {
                return jag[i][j];
            }
            int result;

            if (i == n)
            {
                result = 0;
            }
            else if (j < items[i].w)
            {
                result = DP(i + 1, j);
            }
            else
            {
                result = Math.Max(DP(i + 1, j), DP(i + 1, j - items[i].w) + items[i].v);
            }
            //Console.WriteLine($"i:{i} j:{j} {result}");
            return jag[i][j] = result;
        }
    }
}