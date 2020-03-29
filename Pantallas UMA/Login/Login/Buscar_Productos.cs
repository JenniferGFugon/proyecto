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
        private claProducto Productos;
        private claseListaPRoductos pro;
        public Buscar_Productos()
        {
            InitializeComponent();
            conexion = new claConexion2();
            Productos = new claProducto();
            pro = new claseListaPRoductos();
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

        public void ajustarTamaño()
        {
            this.dgv_BuscarProducto.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this.dgv_BuscarProducto.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void Buscar_Productos_Load(object sender, EventArgs e)
        {
            CargarDatos();
            ajustarTamaño();
        }


        private void CargarDatos()
        {
            string sql = "";
           

            if (rbOtrosProductos.Checked)
            {
                sql = String.Format("SELECT id_producto , nombre FROM uma.producto where id_tipo_producto = 1 ;");
            }
            else if (rbRepuesto.Checked)
            {
                sql = String.Format("SELECT id_producto , nombre FROM uma.producto where id_tipo_producto = 2 ;");
            }
            else if (rbServicio.Checked)
            {
                sql = String.Format("SELECT id_producto , nombre FROM uma.producto where id_tipo_producto = 3 ;");
            }
            else
            {
                sql = String.Format("SELECT id_producto , nombre FROM uma.producto ;");
            }
            DataTable t2 = pro.SQL(sql);
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

        private void dgv_BuscarProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            /*
            Productos.IdProducto = Convert.ToInt32(dgv_BuscarProducto.CurrentRow.Cells[0].Value);
            Productos.Nombre = dgv_BuscarProducto.CurrentRow.Cells[1].Value.ToString();
            
            this.DialogResult = DialogResult.OK;*/
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = String.Format("SELECT id_producto , nombre FROM uma.producto where id_producto  like '%{0}%' or nombre like '%{0}%'", txtBuscar.Text);
            DataTable t2 = pro.SQL(sql);
            dgv_BuscarProducto.DataSource = null;
            dgv_BuscarProducto.DataSource = t2;
            dgv_BuscarProducto.Refresh();

        }

        private void rbRepuesto_CheckedChanged(object sender, EventArgs e)
        {
            CargarDatos();
            ajustarTamaño();
        }

        private void rbServicio_CheckedChanged(object sender, EventArgs e)
        {
            CargarDatos();
            ajustarTamaño();
        }

        private void rbOtrosProductos_CheckedChanged(object sender, EventArgs e)
        {
            CargarDatos();
            ajustarTamaño();
        }
    }
}
