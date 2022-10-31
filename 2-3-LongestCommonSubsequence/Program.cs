using System.Diagnostics;

namespace _2_3_LongestCommonSubsequence
{
    internal class Program
    {
        static int n;
        static int m;
        static string s;
        static string t;

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
            m = int.Parse(Console.ReadLine().Trim());
            s = Console.ReadLine().Trim();
            t = Console.ReadLine().Trim();
        }

        static void Solve()
        {
            var dp = Enumerable.Repeat(0, n + 1).Select(_ => Enumerable.Repeat(0, m + 1).ToArray()).ToArray();

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (s[i - 1] == t[j - 1])
                    {
                        dp[i][j] = dp[i - 1][j - 1] + 1;
                    }
                    else
                    {
                        dp[i][j] = Math.Max(dp[i][j - 1], dp[i - 1][j]);
                    }
                }
            }
            for (int i = 0; i <= n; i++)
            {
                Console.WriteLine(String.Join(' ', dp[i]));
            }

            Console.WriteLine(dp[n][m]);
        }
    }
}