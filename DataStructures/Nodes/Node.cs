using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_SAinWFCSharp.DataStructures.Nodes
{
    internal class Node
    {
        public Node Next { get; set; }
        public int Data { get; set; }

        public Node(int d)
        {
            Data = d;
            Next = null;
        }
    }

}
