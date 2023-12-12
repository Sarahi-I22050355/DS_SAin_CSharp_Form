using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_SAinWFCSharp.SortingAlgorithms
{
    internal class QuickSort
    {
        private static Random _Random = new Random();
        private static int _Option, _ContainExchange, _ContainPartition, _ContainRecursive;
        private static void Swap(ref int IndexOnew, ref int IndexTwo)
        {
            int Temporary = IndexOnew;
            IndexOnew = IndexTwo;
            IndexTwo = Temporary;
        }

        private static int Partition(ref int[] Array, int FirstIndex, int LastIndex, TextBox textBox)
        {
            _ContainPartition++;
            int IndexPivot;
            switch (_Option)
            {
                case 1:
                    IndexPivot = FirstIndex;
                    break;

                case 2:
                    IndexPivot = (int)Math.Floor((double)(LastIndex + FirstIndex) / 2);
                    break;

                case 3:
                    IndexPivot = LastIndex;
                    break;

                default:
                    IndexPivot = _Random.Next(FirstIndex, LastIndex);
                    break;
            }
            Swap(ref Array[FirstIndex], ref Array[IndexPivot]);
            PrintSwap(ref Array, FirstIndex, IndexPivot, textBox);
            _ContainExchange++;
            int Pivot = Array[FirstIndex];
            int Left = FirstIndex + 1;
            int Right = LastIndex;
            while (true)
            {
                while (Left <= Right && Array[Left] <= Pivot)
                {
                    Left += 1;
                }
                while (Left <= Right && Array[Right] >= Pivot)
                {
                    Right -= 1;
                }
                if (Right < Left)
                {
                    break;
                }
                Swap(ref Array[Left], ref Array[Right]);
                PrintSwap(ref Array, Left, Right, textBox);
                _ContainExchange++;
                Left += 1;
                Right -= 1;
            }
            Swap(ref Array[FirstIndex], ref Array[Right]);
            PrintSwap(ref Array, FirstIndex, Right, textBox);
            _ContainExchange++;
            return Right;
        }
        private static void PrintSwap(ref int[] array, int Left, int Right, TextBox textBox)
        {
            textBox.Text += ("[ ");
            for (int i = 0; i < array.Length; i++)
            {
                if (Right == i && Left == i)
                {
                    textBox.Text += (array[i]);
                }
                else if (i == Left || i == Right)
                {
                    textBox.Text += (array[i]);
                }
                else
                {
                    textBox.Text += (array[i]);
                }
                if (i < array.Length - 1)
                {
                    textBox.Text += (", ");
                }
            }
            textBox.Text += (" ]\r\n");
        }

        public void quicksort(ref int[] Array, int FirstIndex, int LastIndex, TextBox textBox)
        {
            if (FirstIndex < LastIndex)
            {
                _ContainRecursive++;
                int IndexPivot = Partition(ref Array, FirstIndex, LastIndex, textBox);
                quicksort(ref Array, FirstIndex, IndexPivot - 1, textBox);
                quicksort(ref Array, IndexPivot + 1, LastIndex, textBox);
            }
        }
    }

}
