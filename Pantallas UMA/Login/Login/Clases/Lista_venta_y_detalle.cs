using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Login.Clases
{
    class Lista_venta_y_detalle
    {
        private List<clase_venta> ventas;
        private claConexion2 conexion;
        private DataTable tabla;

        public Lista_venta_y_detalle()
        {
            ventas = new List<clase_venta>();
            conexion = new claConexion2();
            tabla = new DataTable();
        }
        public List<clase_venta> Lista_Venta
        {
            get
            {
                return Lista_Venta;
            }
        }

        public DataTable Tabla
        {
            get { return tabla; }
        }
        public DataTable SQL(string sql)
        {

            DataTable t = conexion.consulta(sql);
            return t;
        }
    }
}
