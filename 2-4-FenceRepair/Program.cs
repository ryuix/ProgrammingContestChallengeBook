using System.Diagnostics;
using CSharpStl;

namespace _2_4_FenceRepair
{
    internal class Program
    {
        static int n; // 切り出すべき板の数
        static int[] l; // 切り出した板の長さ

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
            var answer = 0;
            var que = new PriorityQueue<int>(false);

            for (int i = 0; i < l.Length; i++)
            {
                que.Push(l[i]);
            }

            while (que.Count > 1)
            {
                int l1, l2;
                l1 = que.Top;
                que.Pop();
                l2 = que.Top;
                que.Pop();

                answer += l1 + l2;
                que.Push(l1 + l2);
            }

            Console.WriteLine(answer);
        }

        private static void Input()
        {
            n = int.Parse(Console.ReadLine().Trim());
            l = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToArray();
        }
    }
}