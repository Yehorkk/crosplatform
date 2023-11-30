using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4Classes
{
    public class Lab2
    {
        public void Run(string inputFile, string outputFile)
        {
            try
            {
                using (StreamReader reader = new StreamReader(inputFile))
                using (StreamWriter writer = new StreamWriter(outputFile))
                {
                    // Ввод елей
                    int M = int.Parse(reader.ReadLine());

                    if (M <= 0)
                    {
                        Console.WriteLine("Ошибка: M должно быть положительным числом.");
                        return;
                    }

                    int[][] varieties = new int[M][];
                    for (int i = 0; i < M; i++)
                    {
                        string[] values = reader.ReadLine().Split();
                        if (values.Length != 2 || !int.TryParse(values[0], out int W) || !int.TryParse(values[1], out int E))
                        {
                            Console.WriteLine($"Ошибка в строке {i + 2}: Некорректные данные для сорта ели.");
                            return;
                        }
                        varieties[i] = new int[] { W, E };
                    }

                    // Ввод клумб
                    int N = int.Parse(reader.ReadLine());

                    if (N <= 0)
                    {
                        Console.WriteLine("Ошибка: N должно быть положительным числом.");
                        return;
                    }

                    int[] flowerbeds = new int[N];
                    string[] flowerbedValues = reader.ReadLine().Split();

                    if (flowerbedValues.Length != N)
                    {
                        Console.WriteLine("Ошибка: Количество координат клумб должно быть равно N.");
                        return;
                    }

                    for (int i = 0; i < N; i++)
                    {
                        if (!int.TryParse(flowerbedValues[i], out flowerbeds[i]))
                        {
                            Console.WriteLine($"Ошибка в строке {i + M + 3}: Некорректные данные для клумбы.");
                            return;
                        }
                    }

                    int[][] dp = new int[M][];
                    for (int i = 0; i < M; i++)
                    {
                        dp[i] = new int[N];
                    }

                    for (int i = 0; i < M; i++)
                    {
                        dp[i][0] = 1;
                    }

                    // Перебор всех возможных вариантов
                    for (int i = 1; i < N; i++) // Перебираем клумбы
                    {
                        for (int j = 0; j < M; j++) // Перебираем ели
                        {
                            for (int i0 = 0; i0 < i; i0++) // Доп перебор клумб
                            {
                                for (int j0 = 0; j0 < M; j0++) // Доп перебор елей
                                {
                                    if (flowerbeds[i0] + varieties[j0][1] <= flowerbeds[i] && // условие проверяет, не будет ли тень от ели j0 перекрывать клумбу i, если посадить ее в клумбу i0.
                                        flowerbeds[i] - varieties[j][0] >= flowerbeds[i0])    // условие проверяет, не будет ли тень от ели j перекрывать клумбу i0, если посадить ее в клумбу i.
                                    {
                                        dp[j][i] = Math.Max(dp[j][i], dp[j0][i0] + 1);
                                    }
                                }
                            }
                        }
                    }

                    int ans = 0;

                    for (int i = 0; i < M; i++)
                    {
                        ans = Math.Max(ans, dp[i][N - 1]);
                    }

                    writer.WriteLine(ans);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
