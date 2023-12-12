using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_SAinWFCSharp.SortingAlgorithms
{
    internal class BucketSort
    {
        private static Random _rand = new Random();

        static void PrintBucketState(List<int>[] buckets, TextBox txtBox)
        {
            txtBox.Text += ("Current state of buckets: \r\n");
            for (int i = 0; i < buckets.Length; i++)
            {
                txtBox.Text += ($"Bucket {i}: ");
                foreach (var item in buckets[i])
                {
                    txtBox.Text += ($"{item} ");
                }
                txtBox.Text += "\r\n";
            }
            txtBox.Text += "\r\n";
        }

        public void BucketSort_int(int[] array, TextBox txtBox)
        {
            // Encuentra el valor máximo en el array
            int maxVal = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxVal)
                    maxVal = array[i];
            }
            // Crea una lista de buckets vacíos
            List<int>[] buckets = new List<int>[maxVal + 1];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new List<int>();
            }

            // Distribuye los elementos en los buckets
            for (int i = 0; i < array.Length; i++)
            {
                buckets[array[i]].Add(array[i]);
            }
            PrintBucketState(buckets, txtBox);

            // Ordena cada cubo individualmente
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i].Sort();
            }
            PrintBucketState(buckets, txtBox);

            // Concatena los elementos ordenados de cada cubo
            int index = 0;
            for (int i = 0; i < buckets.Length; i++)
            {
                foreach (var item in buckets[i])
                {
                    array[index++] = item;
                }
            }
        }
    }
}
