using System;

class JaggedArray
{
    static void Main()
    {
        int[][] data = new int[4][];
        data[0] = new int[] { 1, 2, 3 };
        data[1] = new int[] { 10, 20 };
        data[2] = new int[] { 7, 8, 9, 10 };
        data[3] = new int[] { 6, 4, 6, 8 };

        for (int i = 0; i < data.Length; i++)
        {
            Console.Write("Row " + i + ": ");
            foreach (var v in data[i]) Console.Write(v + " ");
            Console.WriteLine();
        }
    }
}