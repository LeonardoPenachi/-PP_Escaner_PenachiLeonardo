using Entidades;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Libro libro = new Libro("44", "pepe",32, "pepe", "ewaad", 500);
            Libro libro2 = new Libro("Don", "hola", 25, "que tal", "sda", 1000);
            Libro libro3 = new Libro("44", "pepe", 23, "pepe", "ewaad", 500);
            Mapa mapa = new Mapa("pepe", "pepe", 23, "pepe", "ewaad", 10, 10);
            Escaner escanerLibro = new Escaner("sansonite", Escaner.TipoDoc.libro);
            bool comprobar;

            Console.WriteLine(libro.Estado);
            Console.WriteLine(libro2.Estado);
            Console.WriteLine(libro3.Estado);
            Console.WriteLine(mapa.Estado);
            Console.WriteLine("----------------------------------");
            comprobar = escanerLibro + libro;
            comprobar = escanerLibro + libro2;
            comprobar = escanerLibro + libro3;
            comprobar = escanerLibro + mapa;
            
            Console.WriteLine(libro.Estado);
            Console.WriteLine(libro2.Estado);
            Console.WriteLine(libro3.Estado);
            Console.WriteLine(mapa.Estado);
            Console.WriteLine("----------------------------------");

            foreach (Documento d in escanerLibro.ListaDocumentos)
            {
                Console.WriteLine(d.ToString());
            }
            int cantidad;
            int extension;
            string resumen;

            Informes.MostrarDistribuidos(escanerLibro, out cantidad, out extension, out resumen);
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"{cantidad},{extension},\n{resumen}");

        }
    }
}