using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Login.Clases
{
    class claseListaPRoductos
    {
        private List<claProducto> productos;
        private claConexion2 conexion;
        private DataTable tabla;

        public claseListaPRoductos()
        {
            productos = new List<claProducto>();
            conexion = new claConexion2();
            tabla = new DataTable();
            //Cargar_Datos();
        }
        /*
        public void Cargar_Datos()
        {
            conexion.Establecerconexion();
            tabla = conexion.consulta(string.Format("SELECT id_producto ,id_tipo_producto, nombre ,precio_venta FROM uma.producto;"));
            foreach (DataRow f in tabla.Rows)
            {
                claProducto p = new claProducto();
                p.IdProducto = f.Field<int>(0);
                //p.Id_Tipo_Producto = f.Field<int>(1);
                p.Nombre = f.Field<string>(1);
                //p.Precio_venta = f.Field<Decimal>(3);
                productos.Add(p);
            }
        }*/
        public List<claProducto> ListaProductos
        {
            get
            {
                return ListaProductos;
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
