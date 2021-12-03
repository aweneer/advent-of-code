using System;
using System.IO;
using System.Collections.Generic;

namespace day_03
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            Console.WriteLine(FirstPuzzle(input, input[0].Length));
            Console.WriteLine(SecondPuzzle(input, input[0].Length));
        }

        public static int FirstPuzzle(string[] input, int binaryWordLength)
        {
            string gamma = "";
            string epsilon = "";
            int zero = 0;
            int one = 0;

            for (int i = 0; i < binaryWordLength; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j][i] == '1') { one++; } else { zero++; }
                }
                if (one > zero) { gamma += "1"; epsilon += "0"; } else { gamma += "0"; epsilon += "1"; };
                one = 0; zero = 0;
            }
            return BinaryToDecimal(gamma) * BinaryToDecimal(epsilon);
        }

        public static int SecondPuzzle(string[] input, int binaryWordLength)
        {
            string oxygen = "";
            string carbon = "";
            string[] fewerInput = input;
            List<string> ones = new List<string>();
            List<string> zeroes = new List<string>();
            for (int i = 0; i < binaryWordLength; i++)
            {
                // Extra binaries
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j][i] == '1') { ones.Add(input[j]); } else { zeroes.Add(input[j]); }
                }
                if (ones.Count >= zeroes.Count) { input = ones.ToArray(); }
                else { input = zeroes.ToArray(); }

                if (input.Length == 1) { oxygen = input[0]; }
                ones.Clear();
                zeroes.Clear();

                // Fewer binaries
                for (int j = 0; j < fewerInput.Length; j++)
                {
                    if (fewerInput[j][i] == '1') { ones.Add(fewerInput[j]); } else { zeroes.Add(fewerInput[j]); }
                }
                if (ones.Count >= zeroes.Count) { fewerInput = zeroes.ToArray(); }
                else { fewerInput = ones.ToArray(); }
                if (fewerInput.Length == 1) { carbon = fewerInput[0]; }
                ones.Clear();
                zeroes.Clear();
            }
            return BinaryToDecimal(oxygen) * BinaryToDecimal(carbon);
        }

        public static int BinaryToDecimal(string binary)
        {
            int dec = 0;
            double j = Convert.ToDouble(binary.Length-1);
            for (int i = 0; i < binary.Length; i++)
            {
                dec += int.Parse(binary[i].ToString()) * Convert.ToInt32(Math.Pow(2.0, j--));
            }
            return dec;
        }
    }
}
