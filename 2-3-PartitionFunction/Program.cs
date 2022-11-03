using System.Diagnostics;

namespace _2_3_PartitionFunction
{
    internal class Program
    {
        static int n, m, M;

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
            var dp = Enumerable.Repeat(0, m + 1).Select(_ => Enumerable.Repeat(0, n + 1).ToArray()).ToArray();
            dp[0][0] = 1;

            for (int i = 1; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (j - i >= 0)
                    {
                        dp[i][j] = dp[i - 1][j] + dp[i][j - i];
                    }
                    else
                    {
                        dp[i][j] = dp[i - 1][j];
                    }
                }
            }
            Console.WriteLine(dp[m][n] % M);
        }

        private static void Input()
        {
            n = int.Parse(Console.ReadLine().Trim());
            m = int.Parse(Console.ReadLine().Trim());
            M = int.Parse(Console.ReadLine().Trim());
        }
    }
}