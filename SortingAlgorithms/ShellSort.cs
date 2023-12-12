using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_SAinWFCSharp.SortingAlgorithms
{
    internal class ShellSort
    {
        private void PrintArray(int[] array, TextBox textBox)
        {
            foreach (var num in array)
            {
                textBox.Text += (num + " ");
            }
            textBox.Text += "\r\n";
        }
        public void Shell_Sort(int[] array, TextBox textBox)
        {
            // se obtiene la longitud del array
            int n = array.Length;
            // se obtiene el tamaño de espacio entre elementos
            int gap = n / 2;

            textBox.Text += ("\nStart of the Shell Sort Algorithm:\r\n");

            // Mientras el espacio entre elementos sea mayor que 0
            while (gap > 0)
            {
                textBox.Text += ($"\nCurrent Gap: {gap}\r\n");

                // Aplicar el algoritmo de inserción para cada "subarray" con el tamaño de gap
                for (int i = gap; i < n; i++)
                {
                    // Guardar el valor actual del elemento en una variable temporal
                    int temp = array[i];
                    int j = i;

                    textBox.Text += ($"\nCompare {temp} to elements of the subarray:\r\n");

                    // Realizar la inserción
                    while (j >= gap && array[j - gap] > temp)
                    {
                        // Desplazar elementos hacia la derecha hasta encontrar la posición correcta
                        array[j] = array[j - gap];
                        j -= gap;

                        PrintArray(array, textBox);
                    }

                    // Colocar el valor temporal en la posición correcta en el subarray
                    array[j] = temp;
                    textBox.Text += ($"Insrt {temp} int the subarray {j} position:\r\n");
                    PrintArray(array, textBox);
                }

                // Reducir el espacio entre elementos a la mitad en cada iteración
                gap /= 2;
            }

            textBox.Text += ("\nEnd of Shell Sort Algorithm:");
        }
    }
}