using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTema1
{
    internal class DTOJuego
    {
        string titulo;
        double dificultad, puntuacion, precio;

        public DTOJuego(string titulo, double dificultad, double puntuacion, double precio)
        {
            this.titulo = titulo;
            this.dificultad = dificultad;
            this.puntuacion = puntuacion;
            this.precio = precio;
        }
    }
}
