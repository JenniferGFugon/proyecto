using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;

namespace Login.Clases
{
    class claProducto
    {
        private int id_producto;
        private int id_tipo_producto;
        private int id_categoria_producto;
        private Bitmap imagen;
        private decimal precio_venta;
        private decimal precio_compra;
        private string nombre;
        private string marca;
        private int existencia;
        private string modelo;
        private int año;
        private string fabricante;
        private claConexion2 conexion;
        private DataTable tabla;
        //constructores
        public claProducto()
        {

            id_producto = 0;
            id_tipo_producto = 0;
            id_categoria_producto = 0;
            imagen = null;
            precio_venta = 0;
            precio_compra = 0;
            nombre = "";
            marca = "";
            existencia = 0;
            modelo = "";
            año = DateTime.Today.Year;
            fabricante = "";
            conexion = new claConexion2();

        
        }

        public claProducto(Image im, decimal pv,string nom,string mar,int ex)
        {
            id_producto = 0;
            id_tipo_producto = 0;
            id_categoria_producto = 0;
            //imagen = im;
            precio_venta = 0;
            conexion = new claConexion2();
            
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
        public int Id_Tipo_Producto
        {
            get
            {
                return id_tipo_producto;
            }
            set
            {
                id_tipo_producto = value;
            }
        }
        public int Id_Categoria_Producto
        {
            get
            {
                return id_categoria_producto;
            }
            set
            {
                id_categoria_producto = value;
            }
        }

        public Bitmap Imagen
        {
            get
            {
                return imagen;
            }
            set
            {
                imagen = value;
            }
        }

        public decimal Precio_venta
        {
            get
            {
                return precio_venta;
            }
            set
            {
                precio_venta = value;
            }
        }


        public decimal Precio_compra
        {
            get
            {
                return precio_compra;
            }
            set
            {
                precio_compra = value;
            }
        }
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        public string Marca
        {
            get
            {
                return marca;
            }
            set
            {
                marca = value;
            }
        }

        public int Existencia
        {
            get
            {
                return existencia;
            }
            set
            {
                existencia = value;
            }
        }
        public string Modelo
        {
            get
            {
                return modelo;
            }
            set
            {
                modelo = value;
            }
        }

        public int Año
        {
            get
            {
                return año;
            }
            set
            {
               año= value;
            }
        }

        public string Fabricante
        {
            get
            {
                return fabricante;
            }
            set
            {
                fabricante = value;
            }
        }
        public DataTable Tabla
        {
            get { return tabla; }
        }
        /*
        public Boolean BuscaridProducto(int id)
        {
            Boolean r = false;
            DataTable t = conexion.Tabla(string.Format("SELECT id_producto,id_tipo_producto,imagen,precio_venta  FROM uma.producto where id_producto= {0};", id));
            if (t.Rows.Count > 0)
            {
                id_producto = Convert.ToInt32(t.Rows[0][0].ToString());
                id_tipo_producto = Convert.ToInt32(t.Rows[0][1].ToString());
                //imagen =  t.Rows[0][2].GetType(ToolboxBitmapAttribute);
                precio_venta = Convert.ToDecimal(t.Rows[0][3].ToString());

                //CargarProductos();
                r = true;
            }
            return r;
        }*/


        /*
        private void CargarProductos()
        {

            conexion.Establecerconexion();
            tabla = conexion.consulta(string.Format("SELECT id_producto ,id_tipo_producto, nombre ,precio_venta FROM uma.producto;"));
            foreach (DataRow f in tabla.Rows)
            {
                //claProducto p = new claProducto();
                IdProducto = f.Field<int>(0);
                Id_Tipo_Producto = f.Field<int>(1);
                Nombre = f.Field<string>(2);
                Precio_venta = f.Field<Decimal>(3);
               
            }

        }*/

        public Boolean GuardarProductoGeneral()

        {
            Boolean r = false;
           
            r = conexion.Ejecutar(string.Format("INSERT INTO producto_general (id_tipo_producto,precio_compra,nombre,marca,existencia,precio_venta) values({0},{1},'{2}','{3}','{4}',{5});", 1,precio_compra,nombre,marca,existencia,precio_venta));

            return r;
        }
        
        public Boolean GuardarRepuesto()

        {
            Boolean r = false;

            r = conexion.Ejecutar(string.Format("INSERT INTO repuesto (id_tipo_producto,id_categoria_producto,nombre,marca,modelo,año,fabricante,precio_compra,precio_venta,existencia) values({0},{1},'{2}','{3}','{4}',{5},'{6}',{7},{8},{9});", 2,id_categoria_producto, nombre,marca,modelo,año,fabricante,precio_compra,precio_venta,existencia ));

            return r;
        }

        public Boolean GuardarServicio()

        {
            Boolean r = false;

            r = conexion.Ejecutar(string.Format("insert into servicio (id_tipo_producto,nombre,precio) values({0},'{1}',{2});", 3, nombre,precio_venta));

            return r;
        }

        public Boolean ModificarProductoGeneral()
        {
            Boolean r = false;

            r = conexion.Ejecutar(string.Format("UPDATE producto_general SET nombre = '{0}' ,marca = '{1}' ,precio_venta = {2} ,precio_compra = {3} ,existencia ={4}  where id_producto_general = {5};",Nombre,Marca,Precio_venta,Precio_compra,Existencia,IdProducto));
                
            return r;
        }

        public Boolean EliminarProductoGeneral()
        {
            Boolean r = false;

            r = conexion.Ejecutar(string.Format(" DELETE  from producto_general where id_producto_general = {0} ; ",IdProducto));

            return r;
        }
    }
}
    

