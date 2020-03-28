using System;

namespace Login
{
    public class clase_venta
    {
        public int id_venta { get; set; }
        public int id_cliente { get; set; }
        public int id_producto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal isv { get; set; }
        public decimal descuento { get; set; }
        public DateTime hora { get; set; }
        public DateTime fecha { get; set; }

        public clase_venta() { }
        public clase_venta(int id_venta, int id_cliente, int id_producto, int cantida, decimal precio, decimal isv, decimal descuento, DateTime hora, DateTime fecha)
        {
            this.id_venta = id_venta;
            this.id_cliente = id_cliente;
            this.id_producto = id_producto;
            this.cantidad = cantida;
            this.precio = precio;
            this.isv = isv;
            this.descuento = descuento;
            this.hora = hora;
            this.fecha = fecha;

        }


        /*
        public static int agregar(clase_venta add)
        {
            int retorno = 0;
            MysqlCommand comando = new MysqlCommand(string.Format("Insert into Venta(id_venta,id_cliente,id_producto,cantidad,isv,descuento,hora,fecha)valuest('{0}''{1}''{2}''{3}''{4}''{5}''{6}''{7}')",add.id_venta,add.id_cliente,add.id_producto,add.cantidad,add.isv,add.descuento,add.hora,add.fecha)conexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static int modificar(clase_venta add)
        {
            int retorno = 0;
            MysqlCommand comando = new MysqlCommand(string.Format("Insert into Venta(id_venta,id_cliente,id_producto,cantidad,isv,descuento,hora,fecha)valuest('{0}''{1}''{2}''{3}''{4}''{5}''{6}''{7}')", add.id_venta, add.id_cliente, add.id_producto, add.cantidad, add.isv, add.descuento, add.hora, add.fecha)conexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static int eliminar(clase_venta add)
        {
            int retorno = 0;
            MysqlCommand comando = new MysqlCommand(string.Format("Delete into Venta(id_venta,id_cliente,id_producto,cantidad,isv,descuento,hora,fecha)valuest('{0}''{1}''{2}''{3}''{4}''{5}''{6}''{7}')", add.id_venta, add.id_cliente, add.id_producto, add.cantidad, add.isv, add.descuento, add.hora, add.fecha)conexion.obtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }*/




    }

}
