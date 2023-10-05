using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string[] lines = File.ReadAllLines("INPUT.TXT");

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

            File.WriteAllText("OUTPUT.TXT", result.ToString());

        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }
    }
}
