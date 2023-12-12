using DS_SAinWFCSharp.DataStructures.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DS_SAinWFCSharp.DataStructures.Lists
{
    internal class SimpleList<T>
    {
        private Node Head { get; set; }

        public SimpleList()
        {
            Clear();
        }

        public void Add(int data)
        {
            //Caso 0: Creamos un nuevo nodo
            Node NewNode = new Node(data);
            //Caso 1: Insertamso al inicio
            if (IsEmpty())
            {
                Head = NewNode;
                return;
            }
            //Caso 2: Impedimos datos repetidos
            if (Exist(NewNode.Data))
            {
                return;
            }
            //Caso 3: Insertamos el dato al inicio de la lista
            if (NewNode.Data < Head.Data)
            {
                NewNode.Next = Head;
                Head = NewNode;
                return;
            }
            //Caso 4: Recorremos la lista
            Node CurrentNode = Head;
            while (CurrentNode.Next != null && CurrentNode.Next.Data < NewNode.Data)
            {
                CurrentNode = CurrentNode.Next;
            }
            //Caso 5: Insertamos en X posicion o al final de la lista
            NewNode.Next = CurrentNode.Next;
            CurrentNode.Next = NewNode;
        }

        public void Delete(int data, System.Windows.Forms.TextBox textBox)
        {
            textBox.Text = string.Empty;
            //Caso 1: Si la lista esta vacia
            if (IsEmpty())
            {
                return;
            }
            //Caso 2: Si el dato esta al inicio
            if (Head.Data == data)
            {
                Head = Head.Next;
                textBox.Text = ($"- Data[{data}] Removed of the list");
                return;
            }
            //Caso 3: Recorremos la lista
            Node CurrentNode = Head;
            while (CurrentNode.Next != null && CurrentNode.Next.Data < data)
            {
                CurrentNode = CurrentNode.Next;
            }
            //Caso 4: Si el dato esta en X posicion
            if (CurrentNode.Next != null && CurrentNode.Next.Data == data)
            {
                CurrentNode.Next = CurrentNode.Next.Next;
                textBox.Text = ($"- Data[{data}] Removed of the list");
                return;
            }
            //Caso 5: No se encontro el dato
            textBox.Text = ($"- Data[{data}] Not found/removed of the list");
        }

        public void Search(int data, System.Windows.Forms.TextBox textBox)
        {
            textBox.Text = string.Empty;
            //Caso 1: Si la lista esta vacia
            if (IsEmpty())
            {
                return;
            }
            //Case 2: Si el dato esta al inicio
            if (Head.Data == data)
            {
                textBox.Text = ($"- Data[{data}] Exist in the list");
                return;
            }
            //Caso 3: Recorremos la lista
            Node CurrentNode = Head;
            while (CurrentNode.Next != null && CurrentNode.Next.Data <= data)
            {
                CurrentNode = CurrentNode.Next;
            }
            //Caso 4: Si el dato esta en X posicion
            if (CurrentNode.Data == data)
            {
                textBox.Text = ($"- Data[{data}] Exist in the list");
                return;
            }
            //Caso 5: No existe el dato
            textBox.Text = ($"- Data[{data}] Does not exist in the list");
        }

        public void Show(TextBox textBox)
        {
            textBox.Text = string.Empty;
            //Caso 1: Si la lista esta vacia
            if (IsEmpty())
            {
                textBox.Text = "Empty List";
                return;
            }
            //Caso 2: Recorremos la lista
            int i = 0;
            Node CurrentNode = Head;
            while (CurrentNode != null)
            {
                textBox.Text += $"- Node[{i}] and data: {CurrentNode.Data}\r\n";
                CurrentNode = CurrentNode.Next;
                i++;
            }
        }

        public bool Exist(int data)
        {

            //Caso 1: Si la lista esta vacia
            if (IsEmpty())
            {
                return false;
            }
            //Caso 2: Si el primer nodo contiene el dato
            if (Head.Data == data)
            {
                return true;
            }
            //Caso 3: Empezamos a recorrer la lista
            Node CurrentNode = Head;
            while (CurrentNode.Next != null && CurrentNode.Next.Data <= data)
            {
                CurrentNode = CurrentNode.Next;
            }
            //Caso 4: El dato existe en el ultimo elemento
            if (CurrentNode.Data == data)
            {
                return true;
            }
            //Caso 5: El dato no existe en la lista
            return false;
        }

        public bool IsEmpty()
        {
            return Head == null;
        }

        public void Clear()
        {
            Head = null;
        }
    }

}