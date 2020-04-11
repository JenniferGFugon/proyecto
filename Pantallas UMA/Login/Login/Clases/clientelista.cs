using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Login.Clases
{
     class clientelista
    {
        /*
        private List<cliente> clientes;
         private claConexion2 conexion;
        private DataTable tabla;

        public clientelista()
        {
            clientes = new List<cliente>();
            conexion = new claConexion2();
            tabla = new DataTable();
            Cargar_Datos();
        }
        public void Cargar_Datos()
        {
            conexion.Establecerconexion();
            tabla = conexion.consulta(string.Format("select cli.id_cliente, cat.nombre_categoria, cli.nombre_cliente, cli.numero_telefono, cli.correo_electronico, cli.direccion_cliente, cli.RTN, cli.numero_identidad  From cliente as cli inner join categoria_cliente as cat on cli.id_categoria_cliente = cat.id_categoria_cliente"));
            foreach (DataRow f in tabla.Rows)
            {
                cliente d = new cliente();
                d.IdCliente = f.Field<int>(0);
                d.NombreCategoria = f.Field<string>(1);
                d.Nombre_Cliente = f.Field<string>(2);
                d.TelefonoCliente = f.Field<string>(3);
                d.Coreo_electronico = f.Field<string>(4);
                d.Direccion = f.Field<string>(5);
                d.Rtn = f.Field<string>(6);
                d.N_Identidad = f.Field<string>(7);
                clientes.Add(d);
            }
        }
        public List<cliente> listaclientes
        {
            get
            {
                return listaclientes;
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
        */
    }

}
