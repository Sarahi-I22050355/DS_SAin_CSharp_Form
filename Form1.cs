using System.Diagnostics;
using DS_SAinWFCSharp.DataStructures.Lists;
using DS_SAinWFCSharp.DataStructures.Graph;
using DS_SAinWFCSharp.SortingAlgorithms;
using DS_SAinWFCSharp.DataStructures.Nodes;
using DS_SAinWFCSharp.DataStructures;
using TreeNode = System.Windows.Forms.TreeNode;

namespace DS_SAinWFCSharp
{
    public partial class Form1 : Form
    {
        Random random;
        Auto auto;
        private MyStack<string> stringStack;
        readonly BinaryTree binaryTree;
        private Queue<string> cola;
        private LinkedList<string> bicola;
        private Grafo grafo;
        private SortedDictionary<int, Queue<string>> colaPrioridad;
        int[] array = { 9, 1, 8, 2, 7 };
        Stopwatch stopwatch;


        public Form1()
        {
            random = new Random();
            auto = new Auto();
            stringStack = new MyStack<string>();
            binaryTree = new BinaryTree();
            cola = new Queue<string>();
            bicola = new LinkedList<string>();
            grafo = new Grafo();
            colaPrioridad = new SortedDictionary<int, Queue<string>>();
            stopwatch = new Stopwatch();
            InitializeComponent();
        }

        private int[] ArrayReset(int[] arr)
        {
            arr[0] = 9;
            arr[1] = 1;
            arr[2] = 8;
            arr[3] = 2;
            arr[4] = 7;
            return arr;
        }

        #region Listas
        private async void button1_Click(object sender, EventArgs e)
        {
            SimpleList<int> Lista_Simple = new SimpleList<int>();
            auto.Auto_Add_SimpleList(Lista_Simple, random, textBox2, int.Parse(textBox1.Text));
            await Task.Delay(2000);
            auto.Auto_Delete_SimpleList(Lista_Simple, random, textBox2, int.Parse(textBox1.Text));
            await Task.Delay(2000);
            auto.Auto_Search_SimpleList(Lista_Simple, random, textBox2, int.Parse(textBox1.Text));
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            CircularList<int> Circular_List = new CircularList<int>();

            auto.Auto_Add_CircularList(Circular_List, random, textBox2, int.Parse(textBox1.Text));
            await Task.Delay(2000);
            auto.Auto_Delete_CircularList(Circular_List, random, textBox2, int.Parse(textBox1.Text));
            await Task.Delay(2000);
            auto.Auto_Search_CircularList(Circular_List, random, textBox2, int.Parse(textBox1.Text));
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            DoublyLinkedList<int> Doubly_List_Linked = new DoublyLinkedList<int>();
            auto.Auto_Add_DoublyListLinked(Doubly_List_Linked, random, textBox2, int.Parse(textBox1.Text));
            await Task.Delay(2000);
            auto.Auto_Delete_DoublyListLinked(Doubly_List_Linked, random, textBox2, int.Parse(textBox1.Text));
            await Task.Delay(2000);
            auto.Auto_Search_DoublyListLinked(Doubly_List_Linked, random, textBox2, int.Parse(textBox1.Text));
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            CircularDoublyLinkedList<int> Circular_Doubly_Linked_List = new CircularDoublyLinkedList<int>();
            auto.Auto_Add_CircularDoublyLinkedList(Circular_Doubly_Linked_List, random, textBox2, int.Parse(textBox1.Text));
            await Task.Delay(2000);
            auto.Auto_Delete_CircularDoublyLinkedList(Circular_Doubly_Linked_List, random, textBox2, int.Parse(textBox1.Text));
            await Task.Delay(2000);
            auto.Auto_Search_CircularDoublyLinkedList(Circular_Doubly_Linked_List, random, textBox2, int.Parse(textBox1.Text));
        }


        #endregion

        #region Pilas
        private void UpdateStackListBox()
        {
            StackListBox.Items.Clear();
            for (int i = stringStack.Count - 1; i >= 0; i--)
            {
                string item = stringStack[i];
                StackListBox.Items.Add(item);
            }
        }
        private void PushButton_Click(object sender, EventArgs e)
        {
            string item = InputTextBox.Text;
            stringStack.Push(item);
            UpdateStackListBox();
            InputTextBox.Clear();
        }

        private void PopButton_Click(object sender, EventArgs e)
        {
            try
            {
                string poppedItem = stringStack.Pop();
                MessageBox.Show("Elemento desapilado: " + poppedItem);
                UpdateStackListBox();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("La pila está vacía. No se pueden desapilar elementos.");
            }
        }

        private void PeekButton_Click(object sender, EventArgs e)
        {
            try
            {
                string topItem = stringStack.Peek();
                MessageBox.Show("Elemento en la cima de la pila: " + topItem);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("La pila está vacía. No hay elementos para ver.");
            }
        }
        #endregion

        #region Tree
        private void Add_BinaryTree_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(TexBox_Add_BinaryTree.Text, out var number))
            {
                MessageBox.Show("Only numbers in the 'numbers' box!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            binaryTree.Add(number);

            ToursOfTree();

            int Data = 0;
            try { Data = int.Parse(TexBox_Add_BinaryTree.Text); } catch { }

            binaryTree.Add(Data);

            Treeview(binaryTree.Root, null, TreeView.Nodes);

            TexBox_Add_BinaryTree.Clear();
            TexBox_Add_BinaryTree.Focus();
        }

        private void Delete_BinaryTree_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(TexBox_Delete_BinaryTree.Text, out var number))
            {
                MessageBox.Show("Only numbers in the 'numbers' box!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            binaryTree.Delete(number);
            ToursOfTree();

            TexBox_Delete_BinaryTree.Clear();
            TexBox_Delete_BinaryTree.Focus();
        }

        private void Search_BinaryTree_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(TexBox_Search_BinaryTree.Text, out var number))
            {
                MessageBox.Show("Only numbers in the 'numbers' box!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            binaryTree.Search(number);

            TexBox_Search_BinaryTree.Clear();
            TexBox_Search_BinaryTree.Focus();
        }
        public void Treeview(BinaryNode Tree, TreeNode parentNode, TreeNodeCollection nodes)
        {
            if (Tree != null)
            {
                var NewNode = new TreeNode(Tree.Data.ToString());
                if (parentNode != null)
                {
                    parentNode.Nodes.Add(NewNode);
                }
                else
                {
                    nodes.Add(NewNode);
                }
                Treeview(Tree.Left, NewNode, NewNode.Nodes);
                Treeview(Tree.Right, NewNode, NewNode.Nodes);
            }
        }

        public void ToursOfTree()
        {
            ListView_PreOrden.Items.Clear();
            foreach (int val in binaryTree.GetPreOrden())
            {
                ListView_PreOrden.Items.Add(val.ToString());
            }

            ListView_PostOrden.Items.Clear();
            foreach (int val in binaryTree.GetPostOrden())
            {
                ListView_PostOrden.Items.Add(val.ToString());
            }

            ListView_InOrden.Items.Clear();
            foreach (int val in binaryTree.GetInOrden())
            {
                ListView_InOrden.Items.Add(val.ToString());
            }
        }

        static void VisualizarArbol(Nodo Tree, TreeNode parentNode, TreeNodeCollection nodes)
        {
            if (Tree != null)
            {
                var NewNode = new TreeNode(Tree.Data.ToString());

                if (parentNode != null)
                {
                    parentNode.Nodes.Add(NewNode);
                }
                else
                {
                    nodes.Add(NewNode);
                }

                VisualizarArbol(Tree.Left, NewNode, NewNode.Nodes);
                VisualizarArbol(Tree.Right, NewNode, NewNode.Nodes);
            }
        }
        #endregion

        #region Queues
        private void btnEnqueue_Click(object sender, EventArgs e)
        {
            // Agregar un elemento a la cola
            string elemento = txtQueue.Text;
            cola.Enqueue(elemento);

            // Actualizar la lista de elementos en la cola
            ActualizarListaCola();
        }
        private void ActualizarListaCola()
        {
            // Mostrar la cola en el ListBox
            lstvQueue.Items.Clear();
            foreach (string elemento in cola)
            {
                lstvQueue.Items.Add(elemento);
            }
        }
        private void btnDequeue_Click(object sender, EventArgs e)
        {
            // Verificar si la cola no está vacía antes de intentar eliminar
            if (cola.Count > 0)
            {
                // Eliminar el elemento de la cola
                string elementoEliminado = cola.Dequeue();

                // Mostrar un mensaje con el elemento eliminado
                MessageBox.Show($"Se eliminó el elemento: {elementoEliminado}");

                // Actualizar la lista de elementos en la cola
                ActualizarListaCola();
            }
            else
            {
                MessageBox.Show("La cola está vacía. No se pueden eliminar elementos.");
            }
        }
        private void ActualizarListaBicola()
        {
            // Mostrar la bicola en el ListBox
            lstvDeque.Items.Clear();
            foreach (string elemento in bicola)
            {
                lstvDeque.Items.Add(elemento);
            }
        }
        private void btnEnqueueFirst_Click(object sender, EventArgs e)
        {
            // Agregar un elemento al inicio de la bicola
            string elemento = txtDeque.Text;
            bicola.AddFirst(elemento);

            // Actualizar la lista de elementos en la bicola
            ActualizarListaBicola();
        }
        private void btnEnqueueLast_Click(object sender, EventArgs e)
        {
            // Agregar un elemento al final de la bicola
            string elemento = txtDeque.Text;
            bicola.AddLast(elemento);

            // Actualizar la lista de elementos en la bicola
            ActualizarListaBicola();
        }

        private void btnDequeueFirst_Click(object sender, EventArgs e)
        {
            // Verificar si la bicola no está vacía antes de intentar eliminar al inicio
            if (bicola.Count > 0)
            {
                // Eliminar el elemento al inicio de la bicola
                string elementoEliminado = bicola.First.Value;
                bicola.RemoveFirst();

                // Mostrar un mensaje con el elemento eliminado
                MessageBox.Show($"Se eliminó el elemento al inicio: {elementoEliminado}");

                // Actualizar la lista de elementos en la bicola
                ActualizarListaBicola();
            }
            else
            {
                MessageBox.Show("La bicola está vacía. No se pueden eliminar elementos al inicio.");
            }
        }

        private void btnDequeueLast_Click(object sender, EventArgs e)
        {
            // Verificar si la bicola no está vacía antes de intentar eliminar al final
            if (bicola.Count > 0)
            {
                // Eliminar el elemento al final de la bicola
                string elementoEliminado = bicola.Last.Value;
                bicola.RemoveLast();

                // Mostrar un mensaje con el elemento eliminado
                MessageBox.Show($"Se eliminó el elemento al final: {elementoEliminado}");

                // Actualizar la lista de elementos en la bicola
                ActualizarListaBicola();
            }
            else
            {
                MessageBox.Show("La bicola está vacía. No se pueden eliminar elementos al final.");
            }
        }

        private void btnEnqueuePrior_Click(object sender, EventArgs e)
        {
            string elemento = txtPriorityQueue.Text;
            int prioridad;

            if (int.TryParse(txtPriorityQueue.Text, out prioridad))
            {
                if (!colaPrioridad.ContainsKey(prioridad))
                {
                    colaPrioridad[prioridad] = new Queue<string>();
                }

                colaPrioridad[prioridad].Enqueue(elemento);

                // Actualizar la lista de elementos en la cola de prioridad
                ActualizarListaColaPrioridad();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese una prioridad válida (número entero).");
            }
        }

        private void btnDequeuePiror_Click(object sender, EventArgs e)
        {
            // Verificar si la cola de prioridad no está vacía antes de intentar eliminar
            if (colaPrioridad.Count > 0)
            {
                // Encontrar la cola con la prioridad más baja
                var primeraCola = colaPrioridad.Keys.Min();
                var elementoEliminado = colaPrioridad[primeraCola].Dequeue();

                // Si la cola está vacía, eliminarla de la cola de prioridad
                if (colaPrioridad[primeraCola].Count == 0)
                {
                    colaPrioridad.Remove(primeraCola);
                }

                // Mostrar un mensaje con el elemento eliminado
                MessageBox.Show($"Se eliminó el elemento: {elementoEliminado}");

                // Actualizar la lista de elementos en la cola de prioridad
                ActualizarListaColaPrioridad();
            }
            else
            {
                MessageBox.Show("La cola de prioridad está vacía. No se pueden eliminar elementos.");
            }
        }
        private void ActualizarListaColaPrioridad()
        {
            // Mostrar la cola de prioridad en el ListBox
            lstvPriorityQueue.Items.Clear();
            foreach (var kvp in colaPrioridad)
            {
                foreach (var elemento in kvp.Value)
                {
                    lstvPriorityQueue.Items.Add($"{elemento} - Prioridad: {kvp.Key}");
                }
            }
        }


        #endregion

        #region Graphs
        private void btnAddVertex_Click(object sender, EventArgs e)
        {
            string vertice = txtVertex.Text;

            // Añadir vértice al grafo
            grafo.AgregarVertice(vertice);

            // Actualizar la visualización del grafo
            ActualizarVisualizacionGrafo();
        }

        private void btnAddEdge_Click(object sender, EventArgs e)
        {
            string origen = txtOrigin.Text;
            string destino = txtDestination.Text;

            // Añadir arista al grafo
            grafo.AgregarArista(origen, destino);

            // Actualizar la visualización del grafo
            ActualizarVisualizacionGrafo();
        }
        private void ActualizarVisualizacionGrafo()
        {
            // Crear una imagen para visualizar el grafo
            Bitmap imagenGrafo = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(imagenGrafo))
            {
                // Dibujar los vértices
                foreach (var vertice in grafo.Vertices)
                {
                    g.FillEllipse(Brushes.Blue, vertice.Valor.X, vertice.Valor.Y, 30, 30);
                    g.DrawString(vertice.Nombre, DefaultFont, Brushes.White, vertice.Valor.X + 8, vertice.Valor.Y + 8);
                }

                // Dibujar las aristas
                foreach (var arista in grafo.Aristas)
                {
                    g.DrawLine(Pens.Black, arista.Origen.Valor.X + 15, arista.Origen.Valor.Y + 15,
                                         arista.Destino.Valor.X + 15, arista.Destino.Valor.Y + 15);
                }
            }

            // Mostrar la imagen del grafo en el PictureBox
            pictureBox1.Image = imagenGrafo;
        }
        #endregion

        #region Bubble Sort
        public static void PrintArray(int[] array, TextBox txtBox)
        {
            txtBox.Text += ("[" + string.Join(", ", array) + "]\r\n");
        }
        public static void BubbleSort(int[] array, TextBox txtBox)
        {
            txtBox.Text = string.Empty;
            txtBox.Text += ("Arreglo inicial: ");
            PrintArray(array, txtBox);

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    // Comparar los elementos adyacentes y intercambiar si el elemento actual es menor que el siguiente
                    if (array[j] > array[j + 1])
                    {
                        // Intercambiar elementos
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;

                        // Mostrar el estado actual del arreglo
                        txtBox.Text += ("Intercambio - [" + string.Join(", ", array) + "]\r\n");
                    }
                }
            }
            txtBox.Text += ("Arreglo ordenado: ");
            PrintArray(array, txtBox);
        }

        #region Algorithms
        private void btnBubbleRandom_Click(object sender, EventArgs e)
        {
            txtBubble.Text = string.Empty;
            stopwatch.Restart();
            stopwatch.Start();
            BubbleSort(array, txtBubble);
            stopwatch.Stop();
            txtBubble.Text += ("Tiempo de ejecucion del metodo BubbleSort() = " + stopwatch.Elapsed);
            ArrayReset(array);
        }

        private void btnBinaryTree_Click(object sender, EventArgs e)
        {
            txtBinaryTree.Text = string.Empty;
            PrintArray(array, txtBinaryTree);
            BinaryTreeSort binaryTree = new BinaryTreeSort();
            stopwatch.Restart();
            stopwatch.Start();
            binaryTree.Sort(array);
            stopwatch.Stop();
            PrintArray(array, txtBinaryTree);
            txtBinaryTree.Text += ("Tiempo de ejecucion del Metodo Binary Tree Sort = " + stopwatch.Elapsed);
            ArrayReset(array);
        }

        private void btnBucket_Click(object sender, EventArgs e)
        {
            BucketSort bucketSort = new BucketSort();
            txtBucket.Text = string.Empty;
            stopwatch.Reset();
            txtBucket.Text += ("Arreglo inicial: ");
            PrintArray(array, txtBucket);
            stopwatch.Start();
            bucketSort.BucketSort_int(array, txtBucket);
            stopwatch.Stop();
            txtBucket.Text += ("Arreglo ordenado: ");
            PrintArray(array, txtBucket);
            txtBucket.Text += ("Tiempo de ejecucion del metodo BucketSort() = " + stopwatch.Elapsed);
            ArrayReset(array);
        }

        private void btnCocktail_Click(object sender, EventArgs e)
        {
            CocktailSort cocktailSort = new CocktailSort();
            txtCocktail.Text = string.Empty;
            stopwatch.Reset();
            txtCocktail.Text += ("Arreglo inicial: ");
            PrintArray(array, txtCocktail);
            stopwatch.Start();
            cocktailSort.cocktailSort(array);
            stopwatch.Stop();
            txtCocktail.Text += ("Arreglo ordenado: ");
            PrintArray(array, txtCocktail);
            txtCocktail.Text += ("Tiempo de ejecucion del metodo CocktailSort() = " + stopwatch.Elapsed);
            ArrayReset(array);
        }

        private void btnComb_Click(object sender, EventArgs e)
        {
            CombSort combSort = new CombSort();
            txtComb.Text = string.Empty;
            stopwatch.Reset();
            txtComb.Text += ("Arreglo inicial: ");
            PrintArray(array, txtComb);
            stopwatch.Start();
            combSort.Sort(array);
            stopwatch.Stop();
            txtComb.Text += ("Arreglo ordenado: ");
            PrintArray(array, txtComb);
            txtComb.Text += ("Tiempo de ejecucion del metodo CombSort() = " + stopwatch.Elapsed);
            ArrayReset(array);
        }

        private void btnCounting_Click(object sender, EventArgs e)
        {
            CountingSort countingSort = new CountingSort();
            txtCounting.Text = string.Empty;
            stopwatch.Reset();
            txtCounting.Text += ("Arreglo inicial: ");
            PrintArray(array, txtCounting);
            stopwatch.Start();
            countingSort.Sort(array);
            stopwatch.Stop();
            txtCounting.Text += ("Arreglo ordenado: ");
            PrintArray(array, txtCounting);
            txtCounting.Text += ("Tiempo de ejecucion del metodo CountingSort() = " + stopwatch.Elapsed);
            ArrayReset(array);
        }

        private void btnGnome_Click(object sender, EventArgs e)
        {
            GnomeSort gnomeSort = new GnomeSort();
            txtGnome.Text = string.Empty;
            stopwatch.Reset();
            txtGnome.Text += ("Arreglo inicial: ");
            PrintArray(array, txtGnome);
            stopwatch.Start();
            gnomeSort.Sort(array);
            stopwatch.Stop();
            txtGnome.Text += ("Arreglo ordenado: ");
            PrintArray(array, txtGnome);
            txtGnome.Text += ("Tiempo de ejecucion del metodo GnomeSort() = " + stopwatch.Elapsed);
            ArrayReset(array);
        }

        private void btnHeap_Click(object sender, EventArgs e)
        {
            HeapSort heapSort = new HeapSort();
            txtHeap.Text = string.Empty;
            stopwatch.Reset();
            txtHeap.Text += ("Arreglo inicial: ");
            PrintArray(array, txtHeap);
            stopwatch.Start();
            heapSort.Sort(array);
            stopwatch.Stop();
            txtHeap.Text += ("Arreglo ordenado: ");
            PrintArray(array, txtHeap);
            txtHeap.Text += ("Tiempo de ejecucion del metodo HeapSort() = " + stopwatch.Elapsed);
            ArrayReset(array);
        }

        private void btnInsertion_Click(object sender, EventArgs e)
        {
            InsertionSort insertionSort = new InsertionSort();
            txtInsertion.Text = string.Empty;
            stopwatch.Reset();
            txtInsertion.Text += ("Arreglo inicial: ");
            PrintArray(array, txtInsertion);
            stopwatch.Start();
            insertionSort.InsertionSortAlgorithm(array);
            stopwatch.Stop();
            txtInsertion.Text += ("Arreglo ordenado: ");
            PrintArray(array, txtInsertion);
            txtInsertion.Text += ("Tiempo de ejecucion del metodo InsertionSort() = " + stopwatch.Elapsed);
            ArrayReset(array);
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            MergeSort mergeSort = new MergeSort();
            txtMerge.Text = string.Empty;
            stopwatch.Reset();
            txtMerge.Text += ("Arreglo inicial: ");
            PrintArray(array, txtMerge);
            stopwatch.Start();
            mergeSort.MergeSortt(array);
            stopwatch.Stop();
            txtMerge.Text += ("Arreglo ordenado: ");
            PrintArray(array, txtMerge);
            txtMerge.Text += ("Tiempo de ejecucion del metodo MergeSort() = " + stopwatch.Elapsed);
            ArrayReset(array);
        }

        private void btnPigeon_Click(object sender, EventArgs e)
        {
            PigeonHole pigeonHole = new PigeonHole();
            txtPigeon.Text = string.Empty;
            stopwatch.Reset();
            txtPigeon.Text += ("Arreglo inicial: ");
            PrintArray(array, txtPigeon);
            stopwatch.Start();
            pigeonHole.PigeonholeSort(array);
            stopwatch.Stop();
            txtPigeon.Text += ("Arreglo ordenado: ");
            PrintArray(array, txtPigeon);
            txtPigeon.Text += ("Tiempo de ejecucion del metodo PigeonHoleSort() = " + stopwatch.Elapsed);
            ArrayReset(array);
        }

        private void btnQuick_Click(object sender, EventArgs e)
        {
            txtQuick.Text = string.Empty;
            QuickSort quickSort = new QuickSort();
            stopwatch.Reset();
            txtQuick.Text += ("Arreglo inicial: ");
            PrintArray(array, txtQuick);
            stopwatch.Start();
            quickSort.quicksort(ref array, 0, 4, txtQuick);
            stopwatch.Stop();
            txtQuick.Text += ("Arreglo ordenado: ");
            PrintArray(array, txtQuick);
            txtQuick.Text += ("Tiempo de ejecucion del metodo QuickSort() = " + stopwatch.Elapsed);
            ArrayReset(array);
        }

        private void btnRadix_Click(object sender, EventArgs e)
        {
            txtRadix.Text = string.Empty;
            RadixSort radixSort = new RadixSort();
            stopwatch.Reset();
            txtRadix.Text += ("Arreglo inicial: ");
            PrintArray(array, txtRadix);
            stopwatch.Start();
            radixSort.Sort(array);
            stopwatch.Stop();
            txtRadix.Text += ("Arreglo ordenado: ");
            PrintArray(array, txtRadix);
            txtRadix.Text += ("Tiempo de ejecucion del metodo RadixSort() = " + stopwatch.Elapsed);
            ArrayReset(array);
        }

        private void btnSelection_Click(object sender, EventArgs e)
        {
            txtSelection.Text = string.Empty;
            SelectionSort selection_Sort = new SelectionSort();
            stopwatch.Reset();
            txtSelection.Text += ("Arreglo inicial: ");
            PrintArray(array, txtSelection);
            stopwatch.Start();
            selection_Sort.Sort(array);
            stopwatch.Stop();
            txtSelection.Text += ("Arreglo ordenado: ");
            PrintArray(array, txtSelection);
            txtSelection.Text += ("Tiempo de ejecucion del metodo SelectionSort() = " + stopwatch.Elapsed);
            ArrayReset(array);
        }

        private void btnShell_Click(object sender, EventArgs e)
        {
            txtShell.Text = string.Empty;
            ShellSort shellSort = new ShellSort();
            txtShell.Text = string.Empty;
            stopwatch.Reset();
            txtShell.Text += ("Arreglo inicial: ");
            PrintArray(array, txtShell);
            stopwatch.Start();
            shellSort.Shell_Sort(array, txtShell);
            stopwatch.Stop();
            txtShell.Text += ("\r\nArreglo ordenado: ");
            PrintArray(array, txtShell);
            txtShell.Text += ("Tiempo de ejecucion del metodo ShellSort() = " + stopwatch.Elapsed);
            ArrayReset(array);
        }

        private void btnSmooth_Click(object sender, EventArgs e)
        {
            txtSmooth.Text = string.Empty;
            SmoothSort smoothSort = new SmoothSort();
            txtSmooth.Text = string.Empty;
            stopwatch.Reset();
            txtSmooth.Text += ("Arreglo inicial: ");
            PrintArray(array, txtSmooth);
            stopwatch.Start();
            smoothSort.Sort(array);
            stopwatch.Stop();
            txtSmooth.Text += ("Arreglo ordenado: ");
            PrintArray(array, txtSmooth);
            txtSmooth.Text += ("Tiempo de ejecucion del metodo SmoothSort() = " + stopwatch.Elapsed);
            ArrayReset(array);
        }
        #endregion

    }

}