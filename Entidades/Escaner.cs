using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Escaner
    {
        #region Atributos
        private List<Documento> listaDocumentos;
        private Departamento locacion;
        private string marca;
        private TipoDoc tipo;
        #endregion

        #region Propiedades
        public List<Documento> ListaDocumentos
        {
            get => this.listaDocumentos;
        }
        public Departamento Locacion
        {
            get => this.locacion;
        }
        public string Marca
        {
            get => this.marca;
        }
        public TipoDoc Tipo
        {
            get=> this.tipo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Cambia el estado del documento.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool CambiarEstadoDocumento(Documento d)
        {
            return d.AvanzarEstado();
        }
        /// <summary>
        /// Inicializa los atributos con los valores pasados por parametro.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="tipo"></param>
        public Escaner(string marca,TipoDoc tipo)
        {
            this.listaDocumentos = new List<Documento>();
            this.marca = marca; 
            this.tipo = tipo;
            this.locacion = tipo == TipoDoc.mapa ? Departamento.mapoteca : Departamento.procesosTecnicos;
        }
        /// <summary>
        /// Busca en el escaner si existe un documento igual al pasado por parametro.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool operator ==(Escaner e,Documento d)
        {
            bool bandera = false;
            foreach(Documento d2 in e.ListaDocumentos)
            {
                if(d.GetType() == typeof(Libro) && d2.GetType() == typeof(Libro))
                {
                    if ((Libro)d == (Libro)d2)
                    {
                        bandera = true;
                        break;
                    }
                }
                else
                {
                    if(d.GetType() == typeof(Mapa) && d2.GetType() == typeof(Mapa))
                    {
                        if((Mapa)d == (Mapa)d2)
                        {
                            bandera = true;
                            break;
                        }
                    }

                }
            }
           return bandera;
        } 

        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e == d);
        }
        /// <summary>
        /// En caso de que no haya un documento igual y que este sea del tipo del escaner, lo agregara.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool operator +(Escaner e,Documento d)
        {
            bool retorno = false;
            if (d.GetType() == typeof(Libro) && e.Tipo == TipoDoc.libro || d.GetType() == typeof(Mapa) && e.Tipo == TipoDoc.mapa)
            {
                if (d.Estado == Documento.Paso.Inicio) 
                {
                    if (e != d)
                    {
                        CambiarEstadoDocumento(d);
                        e.listaDocumentos.Add(d);
                        retorno = true;
                    }
                }
            }
            return retorno;
        }
        #endregion

        #region Enum
        public enum Departamento
        {
            nulo,
            mapoteca,
            procesosTecnicos
        }
        public enum TipoDoc
        {
            libro,
            mapa
        }
        #endregion
    }
}
