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
                MessageBox.Show("Producto Guardado");
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
         public void limpiarPantallaPro()
        {
            txt_IDProducto.Text = "";
            txt_NombreProducto.Text = "";
            txt_MarcaProducto.Text = "";
            txt_PrecioVentaProducto.Text = "";
            txt_PrecioCompraProducto.Text = "";
            txt_CantidadProducto.Text = "";
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
    }
}
