using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Data;


namespace Login
{
    class clase_venta
    {
        private int id_venta;
        private int id_cliente;
        private string estado;
        private int id_producto;
        private int id_detalle;
        private int cantidad;
        private decimal precio;
        private decimal isv;
        private decimal descuento;
        private decimal subtotal;
        private DateTime dateTime;
        private claConexion2 conexion;
        private DataTable tabla;
        private MySqlException error;

        //constructores
        public clase_venta()
        {
            id_venta = 0;
            id_cliente = 0;
            id_producto = 0;
            id_detalle = 0;
            cantidad = 0;
            estado = "";
            precio = 0;
            isv = 0;
            descuento = 0;
            subtotal = 0;
            dateTime = DateTime.Now;
            conexion = new claConexion2();
        }
        public DataTable Tabla
        {
            get { return tabla; }
        }

        public int Id_Detalle
        {
            get
            {
                return id_detalle;
            }
            set
            {
                id_detalle = value;
            }
        }
        public int IdVenta
        {
            get
            {
                return id_venta;
            }
            set
            {
                id_venta = value;
            }
        }

        public int IdCliente
        {
            get
            {
                return id_cliente;
            }
            set
            {
                id_cliente = value;
            }
        }

        public int IdProducto
        {
            get
            {
                return id_producto;
            }
            set
            {
                id_producto = value;
            }
        }

        public decimal Subtotal
        {
            get
            {
                return subtotal;
            }
            set
            {
                subtotal = value;
            }
        }
        public int Cantidad
        {
            get
            {
                return cantidad;
            }
            set
            {
                cantidad = value;
            }
        }
        public decimal Precio
        {
            get
            {
                return precio;
            }
            set
            {
                precio = value;
            }
        }
        public decimal ISV
        {
            get
            {
                return isv;
            }
            set
            {
                isv = value;
            }
        }
        public decimal Descuento
        {
            get
            {
                return descuento;
            }
            set
            {
                descuento = value;
            }
        }
        public DateTime DateTime
        {
            get
            {
                return dateTime;
            }
            set
            {
                dateTime = value;
            }
        }

        public Boolean guardarventa()
        {
            if (conexion.Ejecutar(string.Format("call uma.guardar_venta('{0}')", IdCliente)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public Boolean GuardarVentaDetalla()
        {
            if (conexion.Ejecutar(string.Format("call uma.guardar_venta_detalla('{0}', '{1}', '{2}');", id_venta, id_producto, cantidad)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean ModificarVentaDetallada()
        {
            if (conexion.Ejecutar(string.Format("call uma.modificar_venta_detalle('{0}', '{1}', '{2}', '{3}');", id_detalle, cantidad, id_venta, id_producto)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean QuitarVentaDetallada()
        {
            if (conexion.Ejecutar(string.Format("call uma.eliminar_venta_detalle('{0}')", id_detalle)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}