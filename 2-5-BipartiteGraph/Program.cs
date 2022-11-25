using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace _2_5_BipartiteGraph
{
    internal class Program
    {
        static int v, e; // 頂点と辺
        static int[][] graph; // 隣接行列
        static int[] color; //頂点の色

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
            for (int i = 0; i < v; i++)
            {
                if (color[i] == 0)
                {
                    if (!Dfs(i, 1))
                    {
                        Console.WriteLine("No");
                        return;
                    }
                }
            }
            Console.WriteLine("Yes");
        }

        private static bool Dfs(int v, int c)
        {
            color[v] = c;
            for (int i = 0; i < graph[v].Length; i++)
            {
                if (graph[v][i] == 1)
                {
                    // 隣接している頂点が同じ色ならfalse
                    if (color[i] == c) return false;
                    // 隣接している頂点がまだ塗られていないなら-cで塗る
                    if (color[i] == 0 && !Dfs(i, -c)) return false;
                }
            }
            return true;
        }

        private static void Input()
        {
            v = int.Parse(Console.ReadLine().Trim());
            e = int.Parse(Console.ReadLine().Trim());
            color = new int[v];

            graph = Enumerable.Repeat(0, v).Select(x => Enumerable.Repeat(0, v).ToArray()).ToArray();

            for (int i = 0; i < e; i++)
            {
                var line = Console.ReadLine().Trim().Split(' ');
                int s = int.Parse(line[0]);
                int t = int.Parse(line[1]);
                graph[s][t] = 1;
                graph[t][s] = 1;
            }
        }
    }
}