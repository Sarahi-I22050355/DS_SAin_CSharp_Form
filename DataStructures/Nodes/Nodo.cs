using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_SAinWFCSharp.DataStructures.Nodes
{
    class Nodo
    {
        public Nodo Left { get; set; }
        public Nodo Right { get; set; }
        public Nodo Next { get; set; }
        public int Data { get; set; }

        public Nodo(int Data)
        {
            this.Data = Data;
            Left = null;
            Right = null;
        }
    }
}
