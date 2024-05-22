using System.Diagnostics;
using System.Text;

namespace Entidades
{
    public abstract class Documento
    {
        #region Atributos
        private int anio;
        private string autor;
        private string barcode;
        private Paso estado;
        private string numNormalizado;
        private string titulo;
        #endregion

        #region Enum
        public enum Paso
        {
            Inicio,
            Distribuido,
            EnEscaner,
            EnRevision,
            Terminado
        }
        #endregion

        #region Propiedades

        public int Anio
        {
            get => this.anio;
        }

        public string Autor
        {
            get => this.autor;
        }

        public string Barcode
        {
            get => this.barcode;
        }

        public Paso Estado
        {
            get => this.estado;
        }

        protected string NumNormalizado
        {
            get => this.numNormalizado;
        }

        public string Titulo
        {
            get => this.titulo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Inicializa los atributos con los valores pasados por parametro, al estado se lo inicializa como "Inicio".
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="autor"></param>
        /// <param name="anio"></param>
        /// <param name="numNormalizado"></param>
        /// <param name="barcode"></param>
        public Documento(string titulo,string autor,int anio,string numNormalizado,string barcode)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anio = anio;
            this.numNormalizado = numNormalizado;  
            this.barcode = barcode;
            this.estado = Paso.Inicio;
        }
        /// <summary>
        /// Este metodo hace avanzar un estado a un documento.
        /// </summary>
        /// <returns>Devuelve un valor booleano dependiendo de si pudo o no avanzar de estado</returns>
        public bool AvanzarEstado()
        {
            bool retorno = true;
            switch (this.Estado)
            {
                case Paso.Inicio:
                    this.estado = Paso.Distribuido;
                    break;
                case Paso.Distribuido:
                    this.estado = Paso.EnEscaner;
                    break;
                case Paso.EnEscaner:
                    this.estado = Paso.EnRevision;
                    break;
                case Paso.EnRevision:
                    this.estado = Paso.Terminado;
                    break;
                case Paso.Terminado:
                    retorno = false;    
                    break;
            }
            return retorno;
        }
        /// <summary>
        /// Crea un resumen del documento.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine($"Titulo: {this.Titulo}");
            datos.AppendLine($"Autor: {this.Autor}");
            datos.AppendLine($"Año: {this.Anio}");
            datos.Append($"Cód. de barras: {this.Barcode}");
            return datos.ToString();
        } 
        #endregion
    }
}