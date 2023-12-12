using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_SAinWFCSharp.SortingAlgorithms
{
    internal class SmoothSort
    {
        private int[] heap;

        public void Sort(int[] arr)
        {
            heap = arr;
            int n = arr.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                SiftDown(i, n - 1);
            }

            for (int i = n - 1; i > 0; i--)
            {
                Swap(0, i);
                SiftDown(0, i - 1);
            }
        }

        private void SiftDown(int root, int end)
        {
            int i = root;

            while (2 * i + 1 <= end)
            {
                int j = 2 * i + 1;

                if (j + 1 <= end && heap[j] < heap[j + 1])
                {
                    j++;
                }

                if (heap[i] >= heap[j])
                {
                    break;
                }

                Swap(i, j);
                i = j;
            }
        }

        private int LeftChild(int i, int k)
        {
            return i - Fibonacci(k - 1) + Fibonacci(k - 2);
        }

        private int Fibonacci(int n)
        {
            if (n <= 1)
                return n;

            int a = 0, b = 1;

            for (int i = 2; i <= n; i++)
            {
                int temp = a + b;
                a = b;
                b = temp;
            }

            return b;
        }

        private void Swap(int i, int j)
        {
            int temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }

}
