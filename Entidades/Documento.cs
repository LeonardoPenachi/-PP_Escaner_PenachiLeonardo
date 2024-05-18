﻿using System.Text;

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

        public Documento(string titulo,string autor,int anio,string numNormalizado,string barcode)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anio = anio;
            this.numNormalizado = numNormalizado;  
            this.barcode = barcode;
        }
        public bool AvanzarEstado()
        {
            bool retorno = true;

            return retorno;
        }

        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();
            datos.Append($"Titulo: {this.Titulo}");
            datos.AppendLine($"Autor: {this.Autor}");
            datos.AppendLine($"Año: {this.Anio}");
            datos.AppendLine($"Cód. de barras: {this.Barcode}");
            return datos.ToString();
        } 
        #endregion
    }
}