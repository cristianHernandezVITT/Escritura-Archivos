using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EscrituraArchivos
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter("ejemplo.txt",true);
            string linea;
            Console.Write("Escribe un nombre ");
            linea = Console.ReadLine();
            sw.WriteLine(linea);
            sw.Close();
            Console.WriteLine("Escribiendo en el archivo");
            Console.ReadLine();
        }
    }
}
