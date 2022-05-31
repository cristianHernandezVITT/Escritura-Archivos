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
            //Si el archivo no existe creará el archivo
            //Si ya existe escribirá en él
            //True es para agregar y no para sobreescribir

            string[] lines = { 
                "Esta es la información de la primera linea", 
                "Esta es la segunda linea", 
                "Fin del texto" 
            };
            //Recorrer el arreglo
            foreach(string line in lines)
            {
                sw.WriteLine(line);//Esta linea escribe en el archivo
            }
            sw.Close();//Siempre se debe cerrar el archivo
            Console.WriteLine("Escribiendo en el archivo...");
            Console.ReadLine();
        }
    }
}
