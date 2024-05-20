using Entidades;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Libro libro = new Libro("44","pepe",23,"pepe","ewaad",500);
            Mapa mapa = new Mapa("pepe", "pepe", 23, "pepe", "ewaad",10,10);
            Console.WriteLine(libro.ToString());
            //Console.WriteLine(mapa.ToString());
            Console.WriteLine(libro.Estado);    
            libro.AvanzarEstado();
            Console.WriteLine(libro.Estado);
    
    }
}