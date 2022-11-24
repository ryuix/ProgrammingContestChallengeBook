using CSharpStl;
using System.Diagnostics;

namespace _2_4_FoodChain
{
    internal class Program
    {
        static int n, k;
        static int[] T, X, Y;
        static UnionFindTree uft;

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

        static void Solve()
        {
            int answer = 0;

            for (int i = 0; i < k; i++)
            {
                int t = T[i];
                int x = X[i] - 1;
                int y = Y[i] - 1;

                // 番号が正しくない場合
                if (x < 0 || n <= x || y < 0 || n <= y)
                {
                    Console.WriteLine($"{x}:{y}");
                    answer++;
                    continue;
                }

                if (t == 1)
                {
                    // xとyが同じ種類になっていない
                    if (uft.IsSame(x, y + n) || uft.IsSame(x, y + 2 * n))
                    {
                        Console.WriteLine($"{x}:{y}");
                        answer++;
                    }
                    else
                    {
                        uft.Unite(x, y);
                        uft.Unite(x + n, y + n);
                        uft.Unite(x + n * 2, y + n * 2);
                    }
                }
                else
                {
                    // xがyを食べる関係になっていない:(A,A),(A,C)など
                    if (uft.IsSame(x, y) || uft.IsSame(x, y + 2 * n))
                    {
                        Console.WriteLine($"{x}:{y}");
                        answer++;
                    }
                    else
                    {
                        uft.Unite(x, y + n);
                        uft.Unite(x + n, y + 2 * n);
                        uft.Unite(x + n * 2, y);
                    }
                }
            }
            Console.WriteLine(answer);
        }

        static void Input()
        {
            var line = Console.ReadLine().Trim().Split(' ');
            n = int.Parse(line[0]);
            k = int.Parse(line[1]);

            uft = new UnionFindTree(n * 3);
            T = new int[k];
            X = new int[k];
            Y = new int[k];

            for (int i = 0; i < k; i++)
            {
                var line2 = Console.ReadLine().Trim().Split(' ');
                T[i] = int.Parse(line2[0]);
                X[i] = int.Parse(line2[1]);
                Y[i] = int.Parse(line2[2]);
            }
        }
    }
}