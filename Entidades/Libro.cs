using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro : Documento
    {
        #region Atributos
        private int numPaginas;
        #endregion

        #region Propiedades
        public string ISBN { get => base.NumNormalizado;}
        public int NumPaginas { get => this.numPaginas; }
        #endregion

        #region Metodos
        /// <summary>
        /// Inicializa los atributos con los valores pasados por parametro.
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="autor"></param>
        /// <param name="anio"></param>
        /// <param name="numNormalizado"></param>
        /// <param name="barcode"></param>
        /// <param name="numPaginas"></param>
        public Libro(string titulo, string autor, int anio, string numNormalizado, string barcode, int numPaginas) : base(titulo, autor, anio, numNormalizado, barcode)
        {
            this.numPaginas = numPaginas;
        }
        /// <summary>
        /// Devuelve un resumen de los datos del libro.
        /// </summary>
        /// <returns>Devuelve un string.</returns>
        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();
            string[] strings;
            int contador = 0;
            strings = base.ToString().Split('\n');
            foreach (string s in strings)
            {
                if (contador == 3)
                {
                    datos.AppendLine($"ISBN: {this.ISBN}");
                }
                datos.AppendLine(s);
                contador++;
            }
            datos.AppendLine($"Número de páginas: {this.NumPaginas}.");
            return datos.ToString();
        }
        /// <summary>
        /// Con dos libros compara su barcode,ISBN,titulo y autor para saber si son iguales.
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns>Devuelve un valor booleano</returns>
        public static bool operator ==(Libro l1, Libro l2) 
        {
            bool retorno = false;
            if (l1.Barcode == l2.Barcode || l1.ISBN == l2.ISBN || l1.Titulo == l2.Titulo && l1.Autor == l2.Autor)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Libro l1, Libro l2) {  return !(l1 == l2); }
        #endregion
    }
}
