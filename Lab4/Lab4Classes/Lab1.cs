using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4Classes
{
    public class Lab1
    {
        public void Run(string inputFile, string outputFile)
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
}
