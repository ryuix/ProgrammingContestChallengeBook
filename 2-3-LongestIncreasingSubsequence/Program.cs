using System.Diagnostics;

namespace _2_3_LongestIncreasingSubsequence
{
    internal class Program
    {
        static int n;
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
            // 最後がa[i]であるような最長の増加部分列の長さ
            var dp = new int[n];

            for (int i = 0; i < n; i++)
            {
                dp[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (a[j] < a[i])
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
            Console.WriteLine(dp.Max());
        }

        private static void Solve2()
        {
            // 長さがi+1であるような増加部分列における最終要素の最小値
            var dp = Enumerable.Repeat(10000000, n).ToArray();
            for (int i = 0; i < n; i++)
            {
                var v = lowerBound(dp, a[i]);
                if (dp[v] > a[i])
                {
                    dp[v] = a[i];
                }

            }
            Console.WriteLine(dp.Count(x => x < 10000000));

            int lowerBound(int[] array, int value)
            {
                var l = 0;
                var r = array.Length - 1;
                while (l <= r)
                {
                    var mid = l + (r - 1) / 2;
                    var res = array[mid].CompareTo(value);
                    if (res == -1) l = mid + 1;
                    else r = mid - 1;
                }
                return l;
            }
        }

        private static void Input()
        {
            n = int.Parse(Console.ReadLine().Trim());
            a = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToArray();
        }
    }
}