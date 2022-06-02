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
        class Registro
        {
            private double Vt; //Ventas totales;
            private double DsV;//Devoluciones sobre venta
            private double DescV; //Descuento sobre venta
            private double compras;
            private double Gc;//Gasto de compra
            private double DsC; //Devoluciones sobre compra
            private double DescC; //Descuentos sobre compra
            private double InventarioI; //Inventario inicial
            private double InventarioF; //Inventario Final
            public Registro(double Vt, double DsV, double DescV, double compras, double Gc, double DsC, double DescC, double InventarioI, double InventarioF)
            {
                this.Vt = Vt;
                this.DsV = DsV;
                this.DescV = DescV;
                this.compras = compras;
                this.Gc = Gc;
                this.DsC = DsC;
                this.DescC = DescC;
                this.InventarioI = InventarioI;
                this.InventarioF = InventarioF;
            }
            public double Vn()
            {
                return Vt - (DsV + DescV);
            }
            public double Cn(double Ct)
            {
                return Ct-(DsC + DescC);
            }
            public double Ct()
            {
                return compras + Gc;
            }
            public double TdM(double Cn)
            {
                return InventarioI + Cn;
            }
            public double CdV(double TdM)
            {
                return TdM - InventarioF;
            }
            public double Ub(double Vn, double Cdv)
            {
                return Vn - Cdv;
            }
            public void Imprimir(double Vn, double Ct, double Cn, double TdM, double CdV, double Ub)
            {
                Console.WriteLine("Ventas totales({0:C}) - (Devoluciones sobre ventas({1:C})+ descuento({2:C}))" +
                "\nLas ventas netas son:{3:C} ", Vt, DsV, DescV, Vn);
                Console.WriteLine("Compras({0:C}) + Gastos de compra({1:C})" +
                    "\nLas compras totales son:{2:C} ", compras, Gc, Ct);
                Console.WriteLine("Compras totales({0:C}) -(Devoluciones sobre compra({1:C})+Descuento sobre compra({2:C}))" +
                    "\nLas compras netas son:{3:C} ", Ct, DsC, DescC, Cn);
                Console.WriteLine("Inventario inicial({0:C}) + Compras netas({1:C})" +
                    "\nEl total de mercancias es de:{2:C} ", InventarioI, Cn, TdM);
                Console.WriteLine("Total de mercancias({0:C})-Inventario Final({1:C})" +
                    "\nEl costo de venta fue de:{2:C} ", TdM, InventarioF, CdV);
                Console.WriteLine("Ventas netas({0:C})-Costo de Venta({1:C})" +
                    "\nLa utilidad bruta es de:{2:C} ", Vn, CdV, Ub);
            }

        }

        static void Main(string[] args)
        {
            double Vt = 0.0;  //Ventas totales;
            double DsV = 0.0;//Devoluciones sobre venta
            double DescV = 0.0; //Descuento sobre venta
            double compras = 0.0;
            double Gc = 0.0;//Gasto de compra
            double DsC = 0.0; //Devoluciones sobre compra
            double DescC = 0.0; //Descuentos sobre compra
            double InventarioI = 0.0; //Inventario inicial
            double InventarioF = 0.0; //Inventario Final

            double Vn = 0.0;//Ventas netas
            double Ct = 0.0;//Compras totales
            double Cn = 0.0;//Compras netas
            double CdV = 0.0;//Costo de venta
            double TdM = 0.0;//Total de mercancias tdm= compras netas + inventario final
            double Ub = 0.0; //Utilidad bruta
            try
            {
                //Capturando venta
                Console.Write("Indica las ventas totales $");
                Vt = double.Parse(Console.ReadLine());
                Console.Write("Indica las devoluciones sobre la venta $");
                DsV = double.Parse(Console.ReadLine());
                Console.Write("Indica el descuento sobre la venta $");
                DescV = double.Parse(Console.ReadLine());


                //Capturando compra
                Console.Write("Indica las compras $");
                compras = double.Parse(Console.ReadLine());
                Console.Write("Indica los gastos de compra $");
                Gc = double.Parse(Console.ReadLine());


                //Capturando compras netas
                Console.Write("Indica las devoluciones sobre compras $");
                DsC = double.Parse(Console.ReadLine());
                Console.Write("Indica los descuentos sobre compra $");
                DescC = double.Parse(Console.ReadLine());


                //Captura de utilidad bruta
                Console.Write("Indica el inventario inicial $");
                InventarioI = double.Parse(Console.ReadLine());
                Console.Write("Indica el inventario final $");
                InventarioF = double.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Solo usa números");
                Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            //Creación del objeto
            Registro registro = new Registro(Vt, DsV, DescV, compras, Gc, DsC, DescC, InventarioI, InventarioF);
           
            //Llamadas al objeto
            Vn = registro.Vn();
            Ct = registro.Ct();
            Cn = registro.Cn(Ct);
            TdM = registro.TdM(Cn);
            CdV = registro.CdV(TdM);
            Ub = registro.Ub(Vn,CdV);

            Console.Clear();
            registro.Imprimir(Vn, Ct, Cn, TdM, CdV, Ub);
            Console.ReadLine();

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
