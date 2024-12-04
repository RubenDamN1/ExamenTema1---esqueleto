using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ExamenTema1
{
    public partial class FormularioJuegos : Form
    {
        public FormularioJuegos()
        {
            InitializeComponent();
        }

        private void btJuegos_Click(object sender, EventArgs e)
        {
            //Abrirá un OpenFileDialog
            openFileDialog1.ShowDialog(this);
            Console.WriteLine("en click");
            DialogResult respuesta;
            //OpenFileDialog ofd = new OpenFileDialog();
            List<DTOJuego> lJuegos = new List<DTOJuego>();

            try
            {                
                
                if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    Console.WriteLine("en if");

                    leerFichero(openFileDialog1.FileName, lJuegos);
                }

            }
            catch (Exception ex)
            {
            }
        }

        // Lee la lista de los artículos guardados en el fichero y mueve los datos a la lista
        private void leerFichero(string fichero, List<DTOJuego> lJuegos)
        {
            XmlDocument xDoc = new XmlDocument();
            DTOJuego regJuego;
            string titulo;
            Double dificultad, puntuacion, precio;

            // Cargo el xml
            xDoc.Load(fichero);

            // Obtenemos una selección de todos los nodos que contienen los registros
            XmlNodeList xmlListaJuegos = xDoc.SelectNodes("Articulos/RegArticulo");

            // Recorremos los subnodos de Articulo
            foreach (XmlElement juego in xmlListaJuegos)
            {
                // Obtenemos los atributos del elemento
                titulo = juego.SelectSingleNode("Titulo").InnerText;
                dificultad = Convert.ToDouble(juego.SelectSingleNode("Dificultad").InnerText);
                puntuacion = Convert.ToDouble(juego.SelectSingleNode("Puntuacion").InnerText);
                precio = Convert.ToDouble(juego.SelectSingleNode("Precio").InnerText);

                // Pasamos los datos a la lista
                regJuego = new DTOJuego(titulo, dificultad, puntuacion, precio);
                lJuegos.Add(regJuego);
            }
        }
    }
}
