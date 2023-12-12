using DS_SAinWFCSharp.DataStructures.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_SAinWFCSharp.DataStructures
{
    public class BinaryTree
    {
        public BinaryNode Root { get; set; }

        public BinaryTree()
        {
            Root = null;
        }


        public void PrintTree()
        {
            string treeGraph = GenerateTreeGraph();
            Console.WriteLine(treeGraph);
        }

        private string GenerateTreeGraph()
        {
            StringBuilder treeGraph = new StringBuilder();
            _GenerateTreeGraph(Root, "", true, treeGraph);
            return treeGraph.ToString();
        }

        private void _GenerateTreeGraph(BinaryNode node, string prefix, bool isLeft, StringBuilder treeGraph)
        {
            if (node != null)
            {
                treeGraph.Append(prefix);
                treeGraph.Append(isLeft ? "├── " : "└── ");
                treeGraph.AppendLine(node.Data.ToString());

                _GenerateTreeGraph(node.Left, prefix + (isLeft ? "│   " : "    "), true, treeGraph);
                _GenerateTreeGraph(node.Right, prefix + (isLeft ? "│   " : "    "), false, treeGraph);
            }
        }

        public void Add(int valor)
        {
            Root = _Add(Root, valor);
        }

        public void Delete(int valor)
        {
            Root = _Delete(Root, valor);
        }

        public bool Search(int valor)
        {
            return _Search(Root, valor);
        }

        public void PreOrden()
        {
            _PreOrden(Root);
            Console.WriteLine();
        }

        public void PostOrden()
        {
            _PostOrder(Root);
            Console.WriteLine();
        }

        public void InOrden()
        {
            _InOrder(Root);
            Console.WriteLine();
        }

        private BinaryNode _Add(BinaryNode nodo, int valor)
        {
            if (nodo == null)
            {
                return new BinaryNode(valor);
            }

            if (valor < nodo.Data)
            {
                nodo.Left = _Add(nodo.Left, valor);
            }
            else if (valor > nodo.Data)
            {
                nodo.Right = _Add(nodo.Right, valor);
            }
            return nodo;
        }

        private BinaryNode _Delete(BinaryNode nodo, int valor)
        {
            if (nodo == null)
            {
                return nodo;
            }
            if (valor < nodo.Data)
            {
                nodo.Left = _Delete(nodo.Left, valor);
            }
            else if (valor > nodo.Data)
            {
                nodo.Right = _Delete(nodo.Right, valor);
            }
            else
            {
                if (nodo.Left == null)
                {
                    return nodo.Right;
                }
                else if (nodo.Right == null)
                {
                    return nodo.Left;
                }
                nodo.Data = MinValue(nodo.Right);
                nodo.Right = _Delete(nodo.Right, nodo.Data);
            }
            return nodo;
        }

        private int MinValue(BinaryNode nodo)
        {
            int min = nodo.Data;
            while (nodo.Left != null)
            {
                min = nodo.Left.Data;
                nodo = nodo.Left;
            }
            return min;
        }

        private bool _Search(BinaryNode nodo, int valor)
        {
            if (nodo == null)
            {
                MessageBox.Show($"The value doesn't exist in the tree", "Doesn't exist", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (valor == nodo.Data)
            {
                MessageBox.Show($"The value exist in the list", "Founded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            if (valor < nodo.Data)
            {
                return _Search(nodo.Left, valor);
            }

            return _Search(nodo.Right, valor);
        }


        public List<int> GetPreOrden()
        {
            List<int> result = new List<int>();
            _GetPreOrden(Root, result);
            return result;
        }

        public List<int> GetPostOrden()
        {
            List<int> result = new List<int>();
            _GetPostOrden(Root, result);
            return result;
        }

        public List<int> GetInOrden()
        {
            List<int> result = new List<int>();
            _GetInOrden(Root, result);
            return result;
        }

        private void _GetPreOrden(BinaryNode node, List<int> result)
        {
            if (node != null)
            {
                result.Add(node.Data);
                _GetPreOrden(node.Left, result);
                _GetPreOrden(node.Right, result);
            }
        }

        private void _GetPostOrden(BinaryNode node, List<int> result)
        {
            if (node != null)
            {
                _GetPostOrden(node.Left, result);
                _GetPostOrden(node.Right, result);
                result.Add(node.Data);
            }
        }

        private void _GetInOrden(BinaryNode node, List<int> result)
        {
            if (node != null)
            {
                _GetInOrden(node.Left, result);
                result.Add(node.Data);
                _GetInOrden(node.Right, result);
            }
        }

        private void _PreOrden(BinaryNode Tree)
        {
            if (Tree != null)
            {
                Console.Write(Tree.Data + " ");
                _PreOrden(Tree.Left);
                _PreOrden(Tree.Right);
            }
        }

        private void _PostOrder(BinaryNode Tree)
        {
            if (Tree != null)
            {
                _PostOrder(Tree.Left);
                _PostOrder(Tree.Right);
                Console.Write(Tree.Data + " ");
            }
        }

        private void _InOrder(BinaryNode Tree)
        {
            if (Tree != null)
            {
                _InOrder(Tree.Left);
                Console.Write(Tree.Data + " ");
                _InOrder(Tree.Right);
            }
        }
    }
}
