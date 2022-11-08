using System.Collections;
using System.Diagnostics;

namespace _2_3_CombinationWithRepetition
{
    internal class Program
    {
        static int n, m, M;
        static int[] a;

        static void Main(string[] args)
        {
            using var sr = new StreamReader("input.txt");
            Console.SetIn(sr);

            var sw = new Stopwatch();
            sw.Start();
            Input();
            Solve();
            //Solve2();
            sw.Stop();
            var ts = sw.Elapsed;

            Console.WriteLine($"{ts.Seconds}:{ts.Milliseconds}");
        }

        private static void Solve()
        {
            // i番目までの品物からj個選ぶ組み合わせの総数
            var dp = Enumerable.Repeat(0, n + 1).Select(_ => Enumerable.Repeat(0, m + 1).ToArray()).ToArray();

            for (int i = 0; i <= n; i++)
            {
                dp[i][0] = 1;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (j - a[i] - 1 >= 0)
                    {
                        dp[i + 1][j] = dp[i + 1][j - 1] + dp[i][j] - dp[i][j - 1 - a[i]];
                    }
                    else
                    {
                        dp[i + 1][j] = dp[i + 1][j - 1] + dp[i][j];
                    }
                }
            }
            Console.WriteLine(dp[n][m] % M);
        }

        private static void Input()
        {
            n = int.Parse(Console.ReadLine().Trim());
            m = int.Parse(Console.ReadLine().Trim());
            a = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToArray();
            M = int.Parse(Console.ReadLine().Trim());
        }
    }
}