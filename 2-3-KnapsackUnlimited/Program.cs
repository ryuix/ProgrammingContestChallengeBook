using System.Diagnostics;

namespace _2_3_KnapsackUnlimited
{
    internal class Program
    {
        static int n;
        static (int w, int v)[] items;
        static int W;

        static void Main(string[] args)
        {
            using var sr = new StreamReader("input.txt");
            Console.SetIn(sr);

            var sw = new Stopwatch();
            sw.Start();
            Input();
            //Solve();
            Solve2();
            sw.Stop();
            var ts = sw.Elapsed;

            Console.WriteLine($"{ts.Seconds}:{ts.Milliseconds}");

        }

        // 3Loop
        private static void Solve()
        {
            var dp = Enumerable.Repeat(0, n + 1).Select(_ => Enumerable.Repeat(0, W + 1).ToArray()).ToArray();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= W; j++)
                {
                    for (int k = 0; k * items[i].w <= j; k++)
                    {
                        dp[i + 1][j] = Math.Max(dp[i + 1][j], dp[i][j - k * items[i].w] + k * items[i].v);
                    }
                }
            }
            Console.WriteLine(dp[n][W]);
        }

        // 2Loop
        private static void Solve2()
        {
            var dp = Enumerable.Repeat(0, n + 1).Select(_ => Enumerable.Repeat(0, W + 1).ToArray()).ToArray();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= W; j++)
                {
                    if (j < items[i].w)
                    {
                        dp[i + 1][j] = dp[i][j];
                    }
                    else
                    {
                        dp[i + 1][j] = Math.Max(dp[i][j], dp[i + 1][j - items[i].w] + items[i].v);
                    }
                }
            }
            Console.WriteLine(dp[n][W]);
        }

        private static void Input()
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
    }
}