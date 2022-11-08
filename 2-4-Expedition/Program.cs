using System.Diagnostics;
using CSharpStl;

namespace _2_4_Expedition
{
    internal class Program
    {
        static int n, l, p;
        static int[] a, b;

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
            // 補給したくなった時に補給していたことにする
            var queue = new PriorityQueue<int>();

            int answer = 0, position = 0, tank = p;

            for (int i = 0; i <= n; i++)
            {
                int d = a[i] - position;

                while (tank - d < 0)
                {
                    if (queue.Count == 0)
                    {
                        Console.WriteLine(-1);
                        return;
                    }
                    tank += queue.Top;
                    queue.Pop();
                    answer++;
                }

                tank -= d;
                position = a[i];
                queue.Push(b[i]);
            }
            Console.WriteLine(answer);
        }

        private static void Input()
        {
            n = int.Parse(Console.ReadLine().Trim());
            l = int.Parse(Console.ReadLine().Trim());
            p = int.Parse(Console.ReadLine().Trim());
            a = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).Append(l).ToArray();
            b = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).Append(0).ToArray();
        }
    }
}