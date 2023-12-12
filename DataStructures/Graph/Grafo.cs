using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_SAinWFCSharp.DataStructures.Graph
{
    internal class Grafo
    {
        public List<Vertex> Vertices { get; }
        public List<Edge> Aristas { get; }

        public Grafo()
        {
            Vertices = new List<Vertex>();
            Aristas = new List<Edge>();
        }

        public void AgregarVertice(string nombre)
        {
            // Añadir un vértice a posiciones aleatorias en el PictureBox
            Random random = new Random();
            Vertex nuevoVertice = new Vertex(nombre, new Point(random.Next(0, 400), random.Next(0, 300)));
            Vertices.Add(nuevoVertice);
        }

        public void AgregarArista(string origen, string destino)
        {
            // Añadir una arista entre los vértices con los nombres dados
            Vertex verticeOrigen = Vertices.Find(v => v.Nombre == origen);
            Vertex verticeDestino = Vertices.Find(v => v.Nombre == destino);

            if (verticeOrigen != null && verticeDestino != null)
            {
                Aristas.Add(new Edge(verticeOrigen, verticeDestino));
            }
        }
    }

}
