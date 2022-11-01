using System.Diagnostics;

namespace _2_3_KnapsackProblem2
{
    internal class Program
    {
        static int n;
        static int[] w, v;
        static int W;

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

        private static void Solve()
        {
            var maxV = v.Sum();

            // dp[i+1][j] i番目までの品物から価値の総和がjとなるように選んだ時の、重さの総和の最小値
            var dp = Enumerable.Repeat(0, n + 1).Select(_ => Enumerable.Repeat(0, maxV + 1).ToArray()).ToArray();
            for (int i = 1; i <= maxV; i++)
            {
                dp[0][i] = (int)(1e+9 + 1);
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= maxV; j++)
                {
                    if (j < v[i])
                    {
                        dp[i + 1][j] = dp[i][j];
                    }
                    else
                    {
                        dp[i + 1][j] = Math.Min(dp[i][j], dp[i][j - v[i]] + w[i]);
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join(' ', dp[i]));
            }

            var result = 0;
            for (int i = 0; i <= maxV; i++)
            {
                if (dp[n][i] <= W) result = i;
            }

            Console.WriteLine(result);

        }

        private static void Input()
        {
            n = int.Parse(Console.ReadLine().Trim());
            w = new int[n];
            v = new int[n];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Trim().Split(' ');
                (w[i], v[i]) = (int.Parse(line[0]), int.Parse(line[1]));
            }

            W = int.Parse(Console.ReadLine().Trim());
        }
    }
}