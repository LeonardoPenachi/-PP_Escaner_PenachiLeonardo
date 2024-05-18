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
        { get => this.ancho * this.alto;}
        #endregion

        #region Metodos
        public Mapa(string titulo, string autor, int anio, string numNormalizado, string barcode,int ancho,int alto) : base(titulo,autor, anio, numNormalizado, barcode)
        {
           this.ancho = ancho;
           this.alto = alto;
        }

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

        public override string ToString()
        {
            StringBuilder texto = new StringBuilder();
            texto.Append(base.ToString());
            texto.AppendLine($"\nSuperficie: {this.Ancho} * {this.Alto} = {this.Superficie} cm2.");
            return texto.ToString();
        }

         
        #endregion
    }
}
