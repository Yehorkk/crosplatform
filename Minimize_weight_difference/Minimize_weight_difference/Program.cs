using System;
using System.Collections;
using System.IO;

/*
 Вариант 58
    У Вас есть N камней с массами W1, W2 , … WN. Требуется разложить камни на 2 кучки так, 
    чтобы разница масс этих кучек была минимальной.
Входные данные
    В первой строке входного файла INPUT.TXT записано число N – количество камней (1 ≤ N ≤ 18). 
    Во второй строке через пробел перечислены массы камней W1, W2 , … WN (1 ≤ Wi ≤ 105).
Выходные данные
    В единственную строку выходного файла OUTPUT.TXT нужно вывести одно 
    неотрицательное целое число – минимально возможную разницу между массами 
    двух кучек.
Пример
	INPUT.TXT	
1)	5
2)  5 8 13 27 14	

    OUTPUT.TXT
    3
*/

class Program
{
    static void Main()
    {   
        //Reading file
        using (StreamReader reader = new StreamReader("INPUT.TXT"))
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
            using (StreamWriter writer = new StreamWriter("OUTPUT.TXT"))
            {
                writer.WriteLine(result);
            }
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

        //Supporting output
        /*
        for (int i = 1; i <= N; i++)
        {
            for (int j = 1; j <= halfWeight; j++)
            {
                Console.Write(arr[i, j] + " ");
            }
            Console.Write("\n");
        }
        Console.WriteLine(totalWeight);
        Console.WriteLine(minDifference);
        */

        //Result in the last ij cell
        return minDifference;
    }
}
