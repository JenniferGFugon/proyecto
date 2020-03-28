using Login.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Buscar_Productos : Form
    {
        Validacion v = new Validacion();
        claConexion2 conexion;
        private claseListaPRoductos BuscarProductos;
        public Buscar_Productos()
        {
            InitializeComponent();
            conexion = new claConexion2();
            BuscarProductos = new claseListaPRoductos();
            conexion.Establecerconexion();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form formulario = new Buscar();
            formulario.Show();
            Visible = false;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }
       

        private void Buscar_Productos_Load(object sender, EventArgs e)
        {
            DataTable t2 = BuscarProductos.SQL(String.Format("SELECT id_producto , nombre FROM uma.producto;"));
            
        }
        private void CargarDatos(string sql)
        {
            DataTable t2 = BuscarProductos.SQL(String.Format("SELECT id_producto , nombre FROM uma.producto;"));
            dgv_BuscarProducto.DataSource = null;
            dgv_BuscarProducto.DataSource = t2;

            dgv_BuscarProducto.Refresh();
        }
        private void btn_Gestionar_Click_1(object sender, EventArgs e)
        {
            Form formulario = new Producto();
            formulario.Show();
            Visible = false;
        }
    }
}
