using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_SAinWFCSharp.DataStructures.Nodes
{
    public class BinaryNode
    {
        public int Data;
        public BinaryNode Left, Right;

        public BinaryNode(int value)
        {
            Data = value;
            Left = Right = null;
        }
    }
}
