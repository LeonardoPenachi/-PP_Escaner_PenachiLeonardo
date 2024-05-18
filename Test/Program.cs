using Entidades;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Libro libro = new Libro("pepe","pepe",23,"pepe","ewaad",500);
            Console.WriteLine(libro.ToString());
        }
    }
}