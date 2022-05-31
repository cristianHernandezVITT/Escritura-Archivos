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
            double Vt; //Ventas totales;
            double DsV;//Devoluciones sobre venta
            double DescV; //Descuento sobre venta
            double compras;
            double Gc;//Gasto de compra
            double DsC; //Devoluciones sobre compra
            double DescC; //Descuentos sobre compra
            double InventarioI; //Inventario inicial
            double InventarioF; //Inventario Final

            double Vn;//Ventas netas
            double Ct;//Compras totales
            double Cn;//Compras netas
            double CdV;//Costo de venta
            double TdM;//Total de mercancias tdm= compras netas + inventario final
            double Ub; //Utilidad bruta

            //Capturando venta
            Console.Write("Indica las ventas totales $");
            Vt = double.Parse(Console.ReadLine());
            Console.Write("Indica las devoluciones sobre la venta $");
            DsV = double.Parse(Console.ReadLine());
            Console.Write("Indica el descuento sobre la venta $");
            DescV = double.Parse(Console.ReadLine());
            Vn = Vt - (DsV + DescV);

            //Capturando compra
            Console.Write("Indica las compras $");
            compras = double.Parse(Console.ReadLine());
            Console.Write("Indica los gastos de compra $");
            Gc = double.Parse(Console.ReadLine());
            Ct = compras + Gc;

            //Capturando compras netas
            Console.Write("Indica las devoluciones sobre compras $");
            DsC = double.Parse(Console.ReadLine());
            Console.Write("Indica los descuentos sobre compra $");
            DescC = double.Parse(Console.ReadLine());
            Cn = Ct - (DescC + DsC);

            //Captura de utilidad bruta
            Console.Write("Indica el inventario inicial $");
            InventarioI = double.Parse(Console.ReadLine());
            Console.Write("Indica el inventario final $");
            InventarioF = double.Parse(Console.ReadLine());
            TdM = InventarioI + Cn;
            CdV = TdM - InventarioF;
            Ub = Vn - CdV;

            Console.Clear();
            StreamWriter sw = new StreamWriter("ejemplo.txt");
            
            sw.WriteLine("Ventas totales({0:C}) - (Devoluciones sobre ventas({1:C})+ descuento({2:C}))" +
                "\nLas ventas netas son:{3:C} ",Vt,DsV,DescV,Vn);
            sw.WriteLine("Compras({0:C}) + Gastos de compra({1:C})" +
                "\nLas compras totales son:{2:C} ",compras,Gc,Ct);
            sw.WriteLine("Compras totales({0:C}) -(Devoluciones sobre compra({1:C})+Descuento sobre compra({2:C}))" +
                "\nLas compras netas son:{3:C} ", Ct,DsC,DescC,Cn);
            sw.WriteLine("Inventario inicial({0:C}) + Compras netas({1:C})" +
                "\nEl total de mercancias es de:{2:C} ",InventarioI,Cn, TdM);
            sw.WriteLine("Total de mercancias({0:C})-Inventario Final({1:C})" +
                "\nEl costo de venta fue de:{2:C} ",TdM,InventarioF, CdV);
            sw.WriteLine("Ventas netas({0:C})-Costo de Venta({1:C})" +
                "\nLa utilidad bruta es de:{2:C} ",Vn,CdV, Ub);
            sw.Close();
            Console.WriteLine("Escribiendo en el archivo");
            Console.ReadLine();
        }
    }
}
