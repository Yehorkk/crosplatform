namespace CL4
{
    public class Lab1
    {
        public static void Run(string inputFile, string outputFile)
        {
            using (StreamReader reader = new StreamReader(inputFile))
            {
                int N;
                if (!int.TryParse(reader.ReadLine(), out N))
                {
                    Console.WriteLine("Invalid input for N. Please enter an integer.");
                    return; // End program
                }

                string[] weightsInput = reader.ReadLine().Split();
                uint[] uweights = new uint[N];
                for (int i = 0; i < N; i++)
                {
                    if (!uint.TryParse(weightsInput[i], out uweights[i]))
                    {
                        Console.WriteLine($"Invalid input for W{i + 1}. Please enter an integer separated by spaces.");
                        return; // End program
                    }
                }

                int[] weights = uweights.Select(item => (int)item).ToArray();

                //Main calculation
                int result = MinimizeWeightDifference(N, weights);

                //Writing result
                using (StreamWriter writer = new StreamWriter(outputFile))
                {
                    writer.WriteLine(result);
                }
            }


            static int MinimizeWeightDifference(int N, int[] weights)
            {
                //totalWeight
                int totalWeight = 0;
                foreach (int weight in weights)
                {
                    totalWeight += weight;
                }

                int halfWeight = totalWeight / 2;

                // arr halfWeight
                int[,] arr = new int[N + 1, halfWeight + 1];

                // fill the supporting table    
                for (int i = 1; i <= N; i++)
                {
                    for (int j = 1; j <= halfWeight; j++)
                    {
                        if (weights[i - 1] <= j)
                        {
                            arr[i, j] = Math.Max(arr[i - 1, j], arr[i - 1, j - weights[i - 1]] + weights[i - 1]);
                        }
                        else
                        {
                            arr[i, j] = arr[i - 1, j];
                        }
                    }
                }
                //min differece
                int minDifference = totalWeight - 2 * arr[N, halfWeight];

                return minDifference;
            }
        }
    }

    public class Lab2
    {
        public static void Run(string inputFile, string outputFile)
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

    public class Lab3
    {
        public static void Run(string inputFile, string outputFile)
        {
            try
            {
                string[] lines = File.ReadAllLines(inputFile);

                if (lines.Length != 1)
                {
                    Console.WriteLine("Помилка: Невiрна кiлькiсть рядкiв.");
                    return;
                }

                string[] input = lines[0].Split();

                if (input.Length != 2)
                {
                    Console.WriteLine("Помилка: Невiрний формат вхiдних даних.");
                    return;
                }

                if (!int.TryParse(input[0], out int N) || !int.TryParse(input[1], out int M))
                {
                    Console.WriteLine("Помилка: Вхiднi данi мають бути цiлтми числами.");
                    return;
                }

                if (N <= 0 || M <= 0)
                {
                    Console.WriteLine("Помилка: Вхiднi данi мають бути цiлтми додатнiми числами.");
                    return;
                }


                int result = 0;

                if (M > N)
                {
                    int ad = M;
                    M = N;
                    N = ad;
                }
                if (N == 1)
                {
                    result = 4 * M;
                }
                else if (N % 2 == 0 && M % 2 == 0)
                {
                    result = 2 * (((N + 1) * M) + N);
                }
                else
                {
                    result = ((M + 1) * N) + ((N + 1) * M);
                    result += ((2 * (M - 1)) + (2 * (N - 1))) / 2;
                    if ((N * M) % 2 == 0)
                    {
                        result += 2;
                    }
                }

                File.WriteAllText(outputFile, result.ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
        }
    }
}