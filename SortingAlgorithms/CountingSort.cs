using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_SAinWFCSharp.SortingAlgorithms
{
    internal class CountingSort
    {
        public void Sort(int[] arr)
        {
            int n = arr.Length;

            // Encontrar el rango del arreglo
            int max = FindMax(arr);

            // Crear un arreglo de conteo y un arreglo resultado
            int[] count = new int[max + 1];
            int[] output = new int[n];

            // Inicializar el arreglo de conteo
            for (int i = 0; i <= max; i++)
            {
                count[i] = 0;
            }

            // Contar la frecuencia de cada elemento
            for (int i = 0; i < n; i++)
            {
                count[arr[i]]++;
            }

            // Actualizar el arreglo de conteo para contener las posiciones reales
            for (int i = 1; i <= max; i++)
            {
                count[i] += count[i - 1];
            }

            // Construir el arreglo de salida
            for (int i = n - 1; i >= 0; i--)
            {
                output[count[arr[i]] - 1] = arr[i];
                count[arr[i]]--;
            }

            // Copiar el arreglo de salida de vuelta al arreglo original
            for (int i = 0; i < n; i++)
            {
                arr[i] = output[i];
            }
        }

        private static int FindMax(int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max;
        }
    }
}
