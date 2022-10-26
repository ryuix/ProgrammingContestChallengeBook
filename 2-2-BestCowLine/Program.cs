using System.Diagnostics;

namespace _2_2_BestCowLine
{
    internal class Program
    {
        // N文字の文字列Sが与えられN文字の文字列Tを作る
        static int n;
        static string? s;

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
            s = Console.ReadLine()?.Trim();
        }

        static void Solve()
        {
            int a = 0, b = n - 1;
            string t = string.Empty;

            while (a <= b)
            {
                var left = false;
                for (int i = 0; a + i <= b; i++)
                {
                    if (s[a + i] < s[b - i])
                    {
                        left = true;
                        break;
                    }
                    else if (s[a + i] > s[b - i])
                    {
                        left = false;
                        break;
                    }
                }
                if (left) 
                    t += s[a++];
                else 
                    t += s[b--];
            }
            Console.WriteLine(t);
        }
    }
}