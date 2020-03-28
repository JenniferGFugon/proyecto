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

       
       

        private void btn_Ingresar_Click_1(object sender, EventArgs e)
        {
            claProducto producto = new claProducto();
            producto.Nombre = txt_NombreProducto.Text;
            producto.Marca = txt_MarcaProducto.Text;
            producto.Precio_compra = Convert.ToDecimal(txt_PrecioCompraProducto.Text);
            producto.Precio_venta = Convert.ToDecimal(txt_PrecioVentaProducto.Text);
            producto.Existencia = Convert.ToInt32(txt_CantidadProducto.Text);
            if (producto.GuardarProductoGeneral())
            {
                MessageBox.Show("Producto Guardado");

            }
            else
            {
                MessageBox.Show("Error");
            }
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
        }

      

        private void btn_LimpiarPantalla_Click(object sender, EventArgs e)
        {
            txt_IDProducto.Clear();
            txt_NombreProducto.Clear();
            txt_MarcaProducto.Clear();
            txt_PrecioVentaProducto.Clear();
            txt_CantidadProducto.Clear();
            txt_PrecioCompraProducto.Clear();
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
    }
}
