using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login.Clases;
using MySql.Data.MySqlClient;

namespace Login
{
    public partial class Producto : Form
    {
        Validacion v = new Validacion();
        private claConexion2 c;

        private claseListaPRoductos  productos;


        public Producto()

        {

            
            InitializeComponent();
            c = new claConexion2();
            productos = new claseListaPRoductos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form formulario = new Menu();
            formulario.Show();
            Visible = false;
        }



        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

       
       
        public void GuardarProductoGeneral()
        {
            txt_IDProducto.Enabled = true;
            btnbuscar.Enabled = true;
            claProducto producto = new claProducto();
            producto.Nombre = txt_NombreProducto.Text;
            producto.Marca = txt_MarcaProducto.Text;
            producto.Precio_compra = Convert.ToDecimal(txt_PrecioCompraProducto.Text);
            producto.Precio_venta = Convert.ToDecimal(txt_PrecioVentaProducto.Text);
            producto.Existencia = Convert.ToInt32(txt_CantidadProducto.Text);
            if (producto.GuardarProductoGeneral())
            {
               
                limpiarPantallaPro();
                MessageBox.Show("Producto Guardado");
                

            }
            else
            {
                MessageBox.Show("Error");
            }
        }
        private void btn_Ingresar_Click_1(object sender, EventArgs e)
        {
            GuardarProductoGeneral();
        }

        private void btn_guardar_repuesto_Click(object sender, EventArgs e)
        {
            claProducto repuesto = new claProducto();
            repuesto.Id_Categoria_Producto = Convert.ToInt32(cmbCategorias.SelectedValue);
            repuesto.Nombre = txt_NombreRepuesto.Text;
            repuesto.Marca = txt_MarcaRepuesto.Text;
            repuesto.Modelo = txt_ModeloRepuesto.Text;
            repuesto.Año = Convert.ToInt32(txt_Anio.Text);
            repuesto.Fabricante = txt_Fabricante.Text;
            repuesto.Precio_compra = Convert.ToDecimal(txt_PrecioCompraRepuesto.Text);
            repuesto.Precio_venta = Convert.ToDecimal(txt_PrecioVentaRepuesto.Text);
            repuesto.Existencia = Convert.ToInt32(txt_CantidadRepuesto.Text);
            if (repuesto.GuardarRepuesto ())
            {
                MessageBox.Show("Producto Guardado");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void Producto_Load_1(object sender, EventArgs e)
        {
            DataTable t1 = productos.SQL(String.Format("SELECT id_categoria_producto, nombre_categoria FROM uma.categoria_producto ;"));
            cmbCategorias.DataSource = null;
            cmbCategorias.DataSource = t1;
            cmbCategorias.DisplayMember = "nombre_categoria";
            cmbCategorias.ValueMember = "id_categoria_producto";
            btn_LimpiarPantallaP.Visible = true;
            

        }

      

        private void btn_LimpiarPantalla_Click(object sender, EventArgs e)
        {
           
            if (btn_LimpiarPantallaP.Text == "Cancelar")
            {
                limpiarPantallaPro();
                btn_Ingresar.Visible = true;
                btn_LimpiarPantallaP.Location = new Point(460, 290);
                btn_LimpiarPantallaP.Text = "Limpiar Pantalla";

            }
            else
            {
                limpiarPantallaPro();
            }
            
        }

        private void IngresarServicio_Click(object sender, EventArgs e)
        {
            claProducto servicio = new claProducto();
            servicio.Nombre = txt_NombreServicio.Text;
        
            servicio.Precio_venta = Convert.ToDecimal(txt_PrecioServicio.Text);
           
            if (servicio.GuardarServicio())
            {
                MessageBox.Show("Servicio Guardado");
                limpiarPantallaServicio();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void cmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_guardar_repuesto_Click_1(object sender, EventArgs e)
        {
            claProducto repuesto = new claProducto();
            repuesto.Nombre = txt_NombreRepuesto.Text;
            repuesto.Id_Categoria_Producto = Convert.ToInt32( cmbCategorias.SelectedValue);
            repuesto.Marca = txt_MarcaRepuesto.Text;
            repuesto.Modelo = txt_ModeloRepuesto.Text;
            repuesto.Año = Convert.ToInt32( txt_Anio.Text);
            repuesto.Fabricante = txt_Fabricante.Text;
            repuesto.Precio_venta = Convert.ToDecimal(txt_PrecioVentaRepuesto .Text);
            repuesto.Precio_compra = Convert.ToDecimal(txt_PrecioCompraRepuesto.Text);
            repuesto.Existencia = Convert.ToInt32(txt_CantidadRepuesto.Text);


            if (repuesto.GuardarRepuesto())
            {
                MessageBox.Show("Producto Guardado");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            btn_Ingresar.Visible = false;
            btn_Ingresar.Visible = true;
            //btnCancelar.Visible = true;
            btn_Eliminar.Visible = true;
            //btnCancelar.Visible = true;
            btn_LimpiarPantallaP.Visible = true;
            txt_IDProducto.Visible = true;
            btn_LimpiarPantallaP.Location = new Point(460, 290);
            btn_LimpiarPantallaP.Text = "Limpiar Pantalla";
            claProducto producto = new claProducto();
            producto.IdProducto = Convert.ToInt32( txt_IDProducto.Text);
            producto.Nombre = txt_NombreProducto.Text;
            producto.Marca = txt_MarcaProducto.Text;
            producto.Precio_venta = Convert.ToDecimal(txt_PrecioVentaProducto.Text);
            producto.Precio_compra = Convert.ToDecimal(txt_PrecioCompraProducto.Text);
            producto.Existencia = Convert.ToInt32(txt_CantidadProducto.Text);


            if (producto.ModificarProductoGeneral())
            {
                MessageBox.Show("Producto Modificado","Confirmacion",MessageBoxButtons.OK);
                limpiarPantallaPro();
                btn_Ingresar.Visible = true;
                
            }
            else
            {
                MessageBox.Show("Error");
            }

        }

      
       
        public void llenarProductoGeneral()
        {
          
            
                DataTable t1 = productos.SQL(String.Format("SELECT  nombre , marca,precio_venta , precio_compra , existencia FROM producto_general where id_producto_general = {0} ; ", txt_IDProducto.Text));
               if(t1.Rows.Count != 0)
                 {
                txt_NombreProducto.Text = t1.Rows[0]["nombre"].ToString();
                txt_MarcaProducto.Text = t1.Rows[0]["marca"].ToString();
                txt_PrecioVentaProducto.Text = t1.Rows[0]["precio_venta"].ToString();
                txt_PrecioCompraProducto.Text = t1.Rows[0]["precio_compra"].ToString();
                txt_CantidadProducto.Text = t1.Rows[0]["existencia"].ToString();
                btn_LimpiarPantallaP.Visible = true;
            }
               else
            {
                MessageBox.Show("El producto no existe");
                btn_LimpiarPantallaP.Text = "Limpiar Pantalla";
                btn_Ingresar.Visible = true;
                btn_LimpiarPantallaP.Location = new Point(460, 290);
            }
                    
   

        }

        public void llenarRepuesto()
        {
            DataTable t1 = productos.SQL(String.Format("SELECT id_categoria_producto, nombre  , marca , año  ,fabricante  , modelo ,precio_compra  , precio_venta  , existencia from repuesto   where id_repuesto = {0} ; ", txt_IDrepuesto.Text));
            if (t1.Rows.Count != 0)
            {
                cmbCategorias.DisplayMember = t1.Rows[0]["id_categoria_producto"].ToString();
                txt_NombreRepuesto.Text = t1.Rows[0]["nombre"].ToString();
                txt_MarcaRepuesto.Text = t1.Rows[0]["marca"].ToString();
                txt_Anio.Text = t1.Rows[0]["año"].ToString();
                txt_Fabricante.Text = t1.Rows[0]["fabricante"].ToString();
                txt_ModeloRepuesto.Text = t1.Rows[0]["modelo"].ToString();
                txt_PrecioCompraRepuesto.Text = t1.Rows[0]["precio_compra"].ToString();
                txt_PrecioVentaRepuesto.Text = t1.Rows[0]["precio_venta"].ToString();           
                txt_CantidadRepuesto.Text = t1.Rows[0]["existencia"].ToString();
                btn_limpiar_pantalla_repuesto.Visible = true;
            }
            else
            {
                MessageBox.Show("El producto no existe");
                btn_limpiar_pantalla_repuesto.Text = "Limpiar Pantalla";
                btn_guardar_repuesto.Visible = true;
                btn_limpiar_pantalla_repuesto.Location = new Point(460, 290);
            }



        }

        public void llenarServicio()
        {
            DataTable t1 = productos.SQL(String.Format("SELECT  nombre , precio from servicio   where id_servicio = {0} ; ", txt_IdServicio.Text));
            if (t1.Rows.Count != 0)
            {
               
                txt_NombreServicio.Text = t1.Rows[0]["nombre"].ToString();
                txt_PrecioServicio.Text = t1.Rows[0]["precio"].ToString();
                btn_limpiar_pantalla_servicio.Visible = true;
            }
            else
            {
                MessageBox.Show("El producto no existe");
                btn_limpiar_pantalla_servicio.Text = "Limpiar Pantalla";
                IngresarServicio.Visible = true;
                btn_limpiar_pantalla_servicio.Location = new Point(460, 290);
            }



        }

        public void limpiarPantallaPro()
        {
            txt_IDProducto.Text = "";
            txt_NombreProducto.Text = "";
            txt_MarcaProducto.Text = "";
            txt_PrecioVentaProducto.Text = "";
            txt_PrecioCompraProducto.Text = "";
            txt_CantidadProducto.Text = "";
        }
        public void limpiarPantallaRepuesto()
            
        {
            txt_IDrepuesto.Text = "";
            txt_NombreRepuesto.Text = "";
            txt_MarcaRepuesto.Text = "";
            txt_Anio.Text = "";
            txt_Fabricante.Text = "";
            txt_ModeloRepuesto.Text = "";
            txt_PrecioCompraRepuesto.Text = "";
            txt_PrecioVentaRepuesto.Text = "";
            txt_CantidadRepuesto.Text = "";
        }

        public void limpiarPantallaServicio()

        {
            txt_IdServicio.Text = "";
            txt_NombreServicio.Text = "";
            txt_PrecioServicio.Text = "";
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            btn_Ingresar.Visible = false;
            btn_LimpiarPantallaP.Text = "Cancelar";
            btn_LimpiarPantallaP.Location = new Point(460, 56);

            if (txt_IDProducto.Text != "")
            {
                llenarProductoGeneral();
            }
            else
            {
                MessageBox.Show("Ingrese el producto a buscar");
            }        
          
           
           
            
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if(txt_IDProducto.Text == "" )
            {
                MessageBox.Show("Ingrese producto a eliminar");
            }
            else
            {
                claProducto producto = new claProducto();
                producto.IdProducto = Convert.ToInt32(txt_IDProducto.Text);
         

                if (producto.EliminarProductoGeneral())
                {
                    MessageBox.Show("Producto Eliminado", "Confirmacion", MessageBoxButtons.OK);
                    limpiarPantallaPro();
                    btn_Ingresar.Visible = true;

                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void txt_NombreProducto_TextChanged(object sender, EventArgs e)
        {
            if(txt_NombreProducto.Text != "")
            {
                txt_IDProducto.Enabled = false;
                btnbuscar.Enabled = false;
            }
            else
            {
                txt_IDProducto.Enabled = true;
                btnbuscar.Enabled =true;
            }
        }

        private void btn_moficicar_repuesto_Click(object sender, EventArgs e)
        {
            btn_guardar_repuesto.Visible = false;
            btn_guardar_repuesto.Visible = true;
            //btnCancelar.Visible = true;
            btn_eliminar_repuesto.Visible = true;
            //btnCancelar.Visible = true;
            btn_limpiar_pantalla_repuesto.Visible = true;
            txt_IDrepuesto.Visible = true;
            btn_limpiar_pantalla_repuesto.Location = new Point(460, 290);
            btn_limpiar_pantalla_repuesto.Text = "Limpiar Pantalla";
            claProducto producto = new claProducto();
            producto.Id_Categoria_Producto = Convert.ToInt32(cmbCategorias.SelectedIndex);
            producto.IdProducto = Convert.ToInt32(txt_IDrepuesto.Text);
            producto.Nombre = txt_NombreRepuesto.Text;
            producto.Marca = txt_MarcaRepuesto.Text;
            producto.Año =  Convert.ToInt32( txt_Anio.Text);
            producto.Fabricante = txt_Fabricante.Text;
            producto.Modelo = txt_ModeloRepuesto.Text;
            producto.Precio_venta = Convert.ToDecimal(txt_PrecioVentaRepuesto.Text);
            producto.Precio_compra = Convert.ToDecimal(txt_PrecioVentaRepuesto.Text);
            producto.Existencia = Convert.ToInt32(txt_CantidadRepuesto.Text);


            if (producto.ModificarRepuesto())
            {
                MessageBox.Show("Producto Modificado", "Confirmacion", MessageBoxButtons.OK);
                limpiarPantallaRepuesto();
                btn_guardar_repuesto.Visible = true;

            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void txt_IDrepuesto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_IDProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_BuscarRepuesto_Click(object sender, EventArgs e)
        {
            btn_guardar_repuesto.Visible = false;
            btn_limpiar_pantalla_repuesto.Text = "Cancelar";
            btn_limpiar_pantalla_repuesto.Location = new Point(460, 56);

            if (txt_IDrepuesto.Text != "")
            {
                llenarRepuesto();
            }
            else
            {
                MessageBox.Show("Ingrese el producto a buscar");
                btn_guardar_repuesto.Visible = true;
                btn_limpiar_pantalla_repuesto.Text = "Limpiar Pantalla";
                btn_limpiar_pantalla_repuesto.Location = new Point(469, 62);
            }
        }

        private void txt_NombreRepuesto_TextChanged(object sender, EventArgs e)
        {
            if (txt_NombreRepuesto.Text != "")
            {
                txt_IDrepuesto.Enabled = false;
                btn_BuscarRepuesto.Enabled = false;
            }
            else
            {
                txt_IDrepuesto.Enabled = true;
                btn_BuscarRepuesto.Enabled = true;
            }
        }

        private void btn_eliminar_repuesto_Click(object sender, EventArgs e)
        {
            if (txt_IDrepuesto.Text == "")
            {
                MessageBox.Show("Ingrese producto a eliminar");
            }
            else
            {
                claProducto producto = new claProducto();
                producto.IdProducto = Convert.ToInt32(txt_IDrepuesto.Text);


                if (producto.EliminarRepuesto())
                {
                    MessageBox.Show("Producto Eliminado", "Confirmacion", MessageBoxButtons.OK);
                    limpiarPantallaRepuesto();
                    btn_guardar_repuesto.Visible = true;

                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void btn_modificar_servicio_Click(object sender, EventArgs e)
        {
            IngresarServicio.Visible = false;
            IngresarServicio.Visible = true;
            btn_Eliminar_servicio.Visible = true;
            btn_Eliminar_servicio.Visible = true;
            txt_IdServicio.Visible = true;
            btn_limpiar_pantalla_servicio.Location = new Point(460, 290);
            btn_limpiar_pantalla_servicio.Text = "Limpiar Pantalla";
            claProducto producto = new claProducto();
            producto.IdProducto = Convert.ToInt32(txt_IdServicio.Text);
            producto.Nombre = txt_NombreServicio.Text;
            producto.Precio_venta = Convert.ToDecimal(txt_PrecioServicio.Text);

            if (producto.ModificarServicio())
            {
                MessageBox.Show("Producto Modificado", "Confirmacion", MessageBoxButtons.OK);
                limpiarPantallaServicio();
                IngresarServicio.Visible = true;

            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btn_BuscarServicio_Click(object sender, EventArgs e)
        {
            IngresarServicio.Visible = false;
            btn_limpiar_pantalla_servicio.Text = "Cancelar";
            btn_limpiar_pantalla_servicio.Location = new Point(460, 56);

            if (txt_IdServicio.Text != "")
            {
                llenarServicio();
            }
            else
            {
                MessageBox.Show("Ingrese el servicio a buscar");
                IngresarServicio.Visible = true;
                btn_limpiar_pantalla_servicio.Text = "Limpiar Pantalla";
                btn_limpiar_pantalla_servicio.Location = new Point(469, 62);
            }
        }

        private void btn_limpiar_pantalla_repuesto_Click(object sender, EventArgs e)
        {
            limpiarPantallaRepuesto();
        }

        private void btn_limpiar_pantalla_servicio_Click(object sender, EventArgs e)
        {
            limpiarPantallaServicio();

        }

        private void btn_Eliminar_servicio_Click(object sender, EventArgs e)
        {
            if (txt_IdServicio.Text == "")
            {
                MessageBox.Show("Ingrese servicio a eliminar");
            }
            else
            {
                claProducto producto = new claProducto();
                producto.IdProducto = Convert.ToInt32(txt_IdServicio.Text);


                if (producto.EliminarServicio())
                {
                    MessageBox.Show("Servicio Eliminado", "Confirmacion", MessageBoxButtons.OK);
                    limpiarPantallaServicio();
                    IngresarServicio.Visible = true;

                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void txt_NombreServicio_TextChanged(object sender, EventArgs e)
        {
            if (txt_NombreServicio.Text != "")
            {
                txt_IdServicio.Enabled = false;
                btn_BuscarServicio.Enabled = false;
            }
            else
            {
                txt_IdServicio.Enabled = true;
                btn_BuscarServicio.Enabled = true;
            }
        }
    }
}

