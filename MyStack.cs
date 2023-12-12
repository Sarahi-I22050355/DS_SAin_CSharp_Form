using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_SAinWFCSharp
{
    internal class MyStack<T>
    {
        private List<T> stackList;

        public MyStack()
        {
            stackList = new List<T>();
        }



        public void Push(T item)
        {
            stackList.Add(item);
        }

        public T Pop()
        {
            if (stackList.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            int lastIndex = stackList.Count - 1;
            T poppedItem = stackList[lastIndex];
            stackList.RemoveAt(lastIndex);

            return poppedItem;
        }

        public T Peek()
        {
            if (stackList.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            return stackList[stackList.Count - 1];
        }

        public int Count
        {
            get { return stackList.Count; }
        }
        public T this[int index]
        {
            get { return stackList[index]; }
        }
    }
}