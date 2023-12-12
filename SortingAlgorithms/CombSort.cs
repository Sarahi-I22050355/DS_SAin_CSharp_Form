using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_SAinWFCSharp.SortingAlgorithms
{
    internal class CombSort
    {
        public void Sort(int[] arr)
        {
            int n = arr.Length;

            // Inicializar el tamaño del salto
            int gap = n;

            // Factor de reducción
            double shrink = 1.3;

            bool swapped;

            do
            {
                // Aplicar un salto mínimo de 1
                if (gap > 1)
                {
                    gap = (int)(gap / shrink);
                }

                swapped = false;

                // Realizar comparaciones y swaps
                for (int i = 0; i + gap < n; i++)
                {
                    if (arr[i] > arr[i + gap])
                    {
                        Swap(ref arr[i], ref arr[i + gap]);
                        swapped = true;
                    }
                }
            } while (gap > 1 || swapped);
        }
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }

}
