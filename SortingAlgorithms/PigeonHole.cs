using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_SAinWFCSharp.SortingAlgorithms
{
    internal class PigeonHole
    {
        public void PigeonholeSort(int[] arr)
        {
            int min = arr[0];
            int max = arr[0];
            int range, i, j, index;

            for (int a = 1; a < arr.Length; a++)
            {
                if (arr[a] > max)
                    max = arr[a];
                if (arr[a] < min)
                    min = arr[a];
            }

            range = max - min + 1;
            int[] pigeonholes = new int[range];

            for (i = 0; i < arr.Length; i++)
                pigeonholes[i] = 0;

            for (i = 0; i < arr.Length; i++)
                pigeonholes[arr[i] - min]++;

            index = 0;

            for (j = 0; j < range; j++)
                while (pigeonholes[j]-- > 0)
                    arr[index++] = j + min;
        }
    }
}
