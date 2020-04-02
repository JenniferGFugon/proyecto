using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Login.Clases
{
    class lista_Ventas
    {
        private List<venta> VentaDetallada;
        private claConexion2 conexion2;
        private DataTable tabla;

        public lista_Ventas()
        {
            VentaDetallada = new List<venta>();
            conexion2 = new claConexion2();
            tabla = new DataTable();
            Cargar_Datos();
        }
        public void Cargar_Datos()
        {
            tabla = conexion2.consulta(string.Format("SELECT "));
            foreach (DataRow f in tabla.Rows)
            {
                venta d = new venta();
                d.Precio = f.Field<decimal>(0);
                d.Cantidad = f.Field<int>(1);
                d.Subtotal = f.Field<decimal>(2);
            }
        }
    }
}
