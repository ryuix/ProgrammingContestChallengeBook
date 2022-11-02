using System.Diagnostics;

namespace _2_3_SubsetSumUnlimited
{
    internal class Program
    {
        static int n;
        static int[] a;
        static int[] m;
        static int K;

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

        private static void Input()
        {
            n = int.Parse(Console.ReadLine().Trim());
            a = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToArray();
            m = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToArray();
            K = int.Parse(Console.ReadLine().Trim());
        }

        private static void Solve()
        {
            var dp = Enumerable.Repeat(0, n + 1).Select(_ => Enumerable.Repeat(false, K + 1).ToArray()).ToArray();
            dp[0][0] = true;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= K; j++)
                {
                    for (int k = 0; k <= m[i] && k * a[i] <= j; k++)
                    {
                        dp[i + 1][j] |= dp[i][j - k * a[i]];
                    }
                }
            }
            Console.WriteLine(dp[n][K]);
        }

        private static void Solve2()
        {
            var dp = Enumerable.Repeat(0, n + 1).Select(_ => Enumerable.Repeat(-1, K + 1).ToArray()).ToArray();
            dp[0][0] = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= K; j++)
                {
                    if (dp[i][j] >= 0)
                    {
                        dp[i + 1][j] = m[i];
                    }
                    else if (j < a[i] || dp[i + 1][j - a[i]] <= 0)
                    {
                        dp[i + 1][j] = -1;
                    }
                    else
                    {
                        dp[i + 1][j] = dp[i + 1][j - a[i]] - 1;
                    }
                }
            }
            Console.WriteLine(dp[n][K]);
        }
    }
}