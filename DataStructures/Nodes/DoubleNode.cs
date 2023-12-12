using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_SAinWFCSharp.DataStructures.Nodes
{
    internal class DoubleNode
    {
        public DoubleNode Back { get; set; }
        public DoubleNode Next { get; set; }
        public int Data { get; set; }

        public DoubleNode(int data)
        {
            Data = data;
            Next = null;
            Back = null;
        }
    }

}
