using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace DS_SAinWFCSharp.DataStructures.Lists
{
    internal class Auto
    {
        public void Auto_Add_SimpleList(SimpleList<int> lista, Random R, System.Windows.Forms.TextBox textBox, int numDatos)
        {
            for (int i = 0; i < numDatos; i++)
            {
                lista.Add(R.Next(25));
            }
            lista.Show(textBox);
        }

        public void Auto_Delete_SimpleList(SimpleList<int> lista, Random R, System.Windows.Forms.TextBox textBox, int numDatos)
        {
            for (int i = 0; i < numDatos; i++)
            {
                lista.Delete(R.Next(25), textBox);
            }
        }

        public void Auto_Search_SimpleList(SimpleList<int> lista, Random R, System.Windows.Forms.TextBox textBox, int numDatos)
        {
            for (int i = 0; i < numDatos; i++)
            {
                lista.Search(R.Next(25), textBox);
            }
        }

        public void Auto_Add_CircularList(CircularList<int> lista, Random R, System.Windows.Forms.TextBox textBox, int numDatos)
        {
            textBox.Text = string.Empty;
            for (int i = 0; i < numDatos; i++)
            {
                lista.Add(R.Next(25));
            }
            lista.Show(textBox);
        }

        public void Auto_Delete_CircularList(CircularList<int> lista, Random R, System.Windows.Forms.TextBox textBox, int numDatos)
        {
            for (int i = 0; i < numDatos; i++)
            {
                lista.Delete(R.Next(25), textBox);
            }
        }

        public void Auto_Search_CircularList(CircularList<int> lista, Random R, System.Windows.Forms.TextBox textBox, int numDatos)
        {
            for (int i = 0; i < numDatos; i++)
            {
                lista.Search(R.Next(25), textBox);
            }
        }

        public void Auto_Add_DoublyListLinked(DoublyLinkedList<int> lista, Random R, System.Windows.Forms.TextBox textBox, int numDatos)
        {
            for (int i = 0; i < numDatos; i++)
            {
                lista.Add(R.Next(25));
            }
            lista.Show(textBox);
        }

        public void Auto_Delete_DoublyListLinked(DoublyLinkedList<int> lista, Random R, System.Windows.Forms.TextBox textBox, int numDatos)
        {

            for (int i = 0; i < numDatos; i++)
            {
                lista.Delete(R.Next(25), textBox);
            }
        }

        public void Auto_Search_DoublyListLinked(DoublyLinkedList<int> lista, Random R, System.Windows.Forms.TextBox textBox, int numDatos)
        {

            for (int i = 0; i < numDatos; i++)
            {
                lista.Search(R.Next(25), textBox);
            }
        }

        public void Auto_Add_CircularDoublyLinkedList(CircularDoublyLinkedList<int> lista, Random R, System.Windows.Forms.TextBox textBox, int numDatos)
        {

            for (int i = 0; i < numDatos; i++)
            {
                lista.Add(R.Next(25));
            }
            lista.Show(textBox);
        }

        public void Auto_Delete_CircularDoublyLinkedList(CircularDoublyLinkedList<int> lista, Random R, System.Windows.Forms.TextBox textBox, int numDatos)
        {

            for (int i = 0; i < numDatos; i++)
            {
                lista.Delete(R.Next(25), textBox);
            }
        }

        public void Auto_Search_CircularDoublyLinkedList(CircularDoublyLinkedList<int> lista, Random R, System.Windows.Forms.TextBox textBox, int numDatos)
        {

            for (int i = 0; i < numDatos; i++)
            {
                lista.Search(R.Next(25), textBox);
            }
        }
    }

}
