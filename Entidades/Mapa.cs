using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mapa : Documento
    {
        #region Atributos
        private int alto;
        private int ancho;
        #endregion

        #region Propiedades
        public int Alto
        {get => this.alto;}
        public int Ancho
        { get => this.ancho;}
        public int Superficie
        { get => this.alto * this.Ancho;}
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
        /// <param name="ancho"></param>
        /// <param name="alto"></param>
        public Mapa(string titulo, string autor, int anio, string numNormalizado, string barcode,int ancho,int alto) : base(titulo,autor, anio, numNormalizado, barcode)
        {
           this.ancho = ancho;
           this.alto = alto;
        }
        /// <summary>
        /// Con dos mapas compara su barcode,titulo,autor,año y superficie, para saber si son el mismo.
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns>Devuelve un valor booleano.</returns>
        public static bool operator ==(Mapa m1, Mapa m2) 
        {
            bool retorno = false;
            if(m1.Barcode == m2.Barcode || m1.Titulo == m2.Titulo && m1.Autor == m2.Autor && m1.Anio == m2.Anio && m1.Superficie == m2.Superficie)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Mapa m1, Mapa m2) {  return !(m1 == m2);}

        /// <summary>
        /// Devuelve un resumen con los datos del mapa.
        /// </summary>
        /// <returns>Devuelve un string.</returns>
        public override string ToString()
        {
            StringBuilder texto = new StringBuilder();
            texto.Append(base.ToString());
            texto.AppendLine($"\nSuperficie: {this.Alto} * {this.Ancho} = {this.Superficie} cm2.");
            return texto.ToString();
        }

         
        #endregion
    }
}
