namespace Entidades
{
    abstract class Documento
    {
        #region Atributos
        protected int anio;
        protected string autor;
        protected string barcode;
        protected Paso estado;
        protected string numNormalizado;
        protected string titulo;
        #endregion

        #region Enum
        protected enum Paso
        {
            Inicio,
            Distribuido,
            EnEscaner,
            EnRevision,
            Terminado
        }
        #endregion

        #region Propiedades

        protected int Anio
        {
            get => this.anio;
        }

        protected string Autor
        {
            get => this.autor;
        }

        protected string Barcode
        {
            get => this.barcode;
        }

        protected Paso Estado
        {
            get => this.estado;
        }

        protected string NumNormalizado
        {
            get => this.numNormalizado;
        }

        protected string Titulo
        {
            get => this.titulo;
        }
        #endregion

        #region Metodos

        protected Documento(string titulo,string autor,int anio,string numNormalizado,string barcode)
        {

        }
        protected bool AvanzarEstado()
        {
            bool retorno = true;

            return retorno;
        }

        protected override string ToString()
        {

        } 
        #endregion
    }
}