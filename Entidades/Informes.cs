using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Informes
    {
        #region Metodos
        public static void MostrarDistribuidos(Escaner e,out int extension , out int cantidad,out string resumen)
        {
             MostrarDocumentosPorEstado(e,Documento.Paso.Distribuido,out extension,out cantidad, out resumen);
        }

        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnEscaner, out extension, out cantidad, out resumen);
        }

        public static void MostrarEnRevision(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnRevision, out extension, out cantidad, out resumen);
        }

        public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.Terminado, out extension, out cantidad, out resumen);
        }

        private static void MostrarDocumentosPorEstado(Escaner e, Documento.Paso estado, out int extension, out int cantidad, out string resumen)
        {
            extension = 0;
            cantidad = 0;
            StringBuilder texto = new StringBuilder();

            foreach(Documento d in e.ListaDocumentos)
            {
                if(d.Estado == estado)
                {
                    if(e.Tipo == Escaner.TipoDoc.libro)
                    {
                        Libro libro = (Libro)d;
                        extension += libro.NumPaginas;
                        cantidad += 1;
                    }
                    else
                    {
                        if(e.Tipo == Escaner.TipoDoc.mapa)
                        {
                            Mapa mapa = (Mapa)d;
                            extension += mapa.Superficie;
                            cantidad += 1;
                        }
                    }
                }
            }
            texto.AppendLine($"Tipo: {e.Tipo}");
            texto.AppendLine($"Cantidad escaneado: {cantidad}");
            texto.AppendLine($"{(e.Tipo == Escaner.TipoDoc.libro ? "Paginas totales" : "Superficie total")}:{extension}");
            resumen = texto.ToString();
        } 


        #endregion
    }
}
