using DS_SAinWFCSharp.DataStructures.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_SAinWFCSharp.SortingAlgorithms
{
    internal class BinaryTreeSort
    {
        private BinaryNode root;
        private int index = 0;
        public void Sort(int[] arr)
        {
            // Construir el árbol binario
            foreach (var value in arr)
            {
                root = Insert(root, value);
            }

            // Recorrer el árbol en orden para obtener los elementos ordenados
            InOrderTraversal(root, arr, ref index);
        }
        private BinaryNode Insert(BinaryNode node, int value)
        {
            if (node == null)
            {
                return new BinaryNode(value);
            }

            if (value < node.Data)
            {
                node.Left = Insert(node.Left, value);
            }
            else if (value > node.Data)
            {
                node.Right = Insert(node.Right, value);
            }

            return node;
        }
        private void InOrderTraversal(BinaryNode node, int[] arr, ref int index)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, arr, ref index);
                arr[index++] = node.Data;
                InOrderTraversal(node.Right, arr, ref index);
            }
        }
    }

}
