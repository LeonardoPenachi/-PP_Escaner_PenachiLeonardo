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
            get => this.Locacion;
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
        public bool CambiarEstadoDocumento(Documento d)
        {
            return d.AvanzarEstado();
        }

        public Escaner(string marca,TipoDoc tipo)
        {
            this.listaDocumentos = new List<Documento>();
            this.marca = marca; 
            this.tipo = tipo;
            this.locacion = tipo == TipoDoc.mapa ? Departamento.mapoteca : Departamento.procesosTecnicos;
        }

        public static bool operator ==(Escaner e,Documento d)
        {
            bool bandera = false;
            foreach(Documento d2 in e.listaDocumentos)
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

        public static bool operator +(Escaner e,Documento d)
        {
            bool retorno = false;
            if(e != d)
            {
                e.listaDocumentos.Add(d);
                retorno = true;
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
