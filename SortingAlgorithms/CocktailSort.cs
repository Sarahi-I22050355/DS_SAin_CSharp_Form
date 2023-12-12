using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_SAinWFCSharp.SortingAlgorithms
{
    internal class CocktailSort
    {
        public void cocktailSort(int[] arr)
        {
            int n = arr.Length;
            bool swapped = true;
            int start = 0;
            int end = n - 1;
            while (swapped)
            {
                // Move from left to right
                swapped = false;
                for (int i = start; i < end; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(arr, i, i + 1);
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }
                end--;
                // Move from right to left
                swapped = false;
                for (int i = end - 1; i >= start; i--)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(arr, i, i + 1);
                        swapped = true;
                    }
                }
                start++;
            }
        }
        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }

}
