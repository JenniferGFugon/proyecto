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
    public partial class Venta : Form
    {
        Validacion v = new Validacion();
        private clase_venta ventas;
        private Clases.Lista_venta_y_detalle listaventa;
        private claConexion2 conexion;
        private int ultimaventa;
        private int producto;
        private decimal total;
        private string nombreCliente;
        private string categoriacliente;

        public Venta()
        {
            InitializeComponent();

            conexion = new claConexion2();
            ventas = new clase_venta();
            listaventa = new Clases.Lista_venta_y_detalle();
            conexion.Establecerconexion();
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
            v.soloLetras(e);
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

        private void button2_Click(object sender, EventArgs e)
        {
            /*txt_Estado.Clear();
            txtBox_IdVenta.Clear();
            txt_FechaHora.Clear();
            txt_IdCliente.Clear();
            txt_Total.Clear();*/
        }
        public void ajustarTamañoProducto()
        {
            this.dgvProducto.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvProducto.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        public void ajustarTamañodetalle()
        {
            this.dGVDetallada.Columns[0].Visible = false;
            this.dGVDetallada.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dGVDetallada.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dGVDetallada.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void CargarDatosproductos()
        {
            string sql = "";

            sql = String.Format("SELECT id_producto , nombre FROM uma.producto ;");

            DataTable t2 = listaventa.SQL(sql);
            dgvProducto.DataSource = null;
            dgvProducto.DataSource = t2;
            dgvProducto.Refresh();

            ultimaventa = Convert.ToInt32(conexion.consulta(string.Format("SELECT MAX(id_venta) from venta")).Rows[0][0].ToString());
            txtFactura.Text = Convert.ToString(ultimaventa);
            txtFactura.Enabled = false;
        }

        private void CargarListadetalle()
        {
            string sql = "";

            sql = String.Format("select detalle.id_detalle, producto.nombre, detalle.cantidad, detalle.subtotal FROM uma.detalle as detalle inner join uma.producto as producto on detalle.id_producto = producto.id_producto where id_venta='{0}'", txtFactura.Text);
            DataTable t2 = listaventa.SQL(sql);
            dGVDetallada.DataSource = null;
            dGVDetallada.DataSource = t2;
            dGVDetallada.Refresh();

            total = Convert.ToDecimal(conexion.consulta(string.Format("SELECT total FROM uma.venta where id_venta={0}", Convert.ToInt32(txtFactura.Text))).Rows[0][0].ToString());
            txtTotal.Text = Convert.ToString(total);
            txtTotal.Enabled = false;

        }

        private void Cargaridentidadcliente()
        {
            DataTable t1 = listaventa.SQL(String.Format("SELECT id_cliente, numero_identidad FROM uma.cliente ;"));
            txtCliente.DataSource = null;
            txtCliente.DataSource = t1;
            txtCliente.DisplayMember = "numero_identidad";
            txtCliente.ValueMember = "id_cliente";

        }
        private void Venta_Load(object sender, EventArgs e)
        {
            CargarDatosproductos();
            Cargaridentidadcliente();
            ajustarTamañoProducto();
            limpiar();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clase_venta ventas = new clase_venta();
            ventas.IdCliente = Convert.ToInt32(txtCliente.SelectedValue);

            if (ventas.guardarventa())
            {
                MessageBox.Show("comienze a agregar los productos");

                ultimaventa = Convert.ToInt32(conexion.consulta(string.Format("SELECT MAX(id_venta) from venta")).Rows[0][0].ToString());
                txtFactura.Text = Convert.ToString(ultimaventa);

                nombreCliente = Convert.ToString(conexion.consulta(string.Format("select cli.nombre_cliente, caci.nombre_categoria from uma.venta as venta inner join uma.cliente as cli on venta.id_cliente = cli.id_cliente inner join uma.categoria_cliente as caci on cli.id_categoria_cliente=caci.id_categoria_cliente where venta.id_venta = '{0}'", txtCliente.SelectedValue)).Rows[0][0].ToString());
                lblDatosCliente.Text = Convert.ToString(nombreCliente);
                categoriacliente = Convert.ToString(conexion.consulta(string.Format("select cli.nombre_cliente, caci.nombre_categoria from uma.venta as venta inner join uma.cliente as cli on venta.id_cliente = cli.id_cliente inner join uma.categoria_cliente as caci on cli.id_categoria_cliente=caci.id_categoria_cliente where venta.id_venta = '{0}'", txtCliente.SelectedValue)).Rows[0][1].ToString());
                lblcategoriacliente.Text = categoriacliente;
                txtFactura.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "")
            {
                MessageBox.Show("Ingrese la cantidad a vender");
                txtCantidad.Focus();
            }

            if (txtProducto.Text == "")
            {
                MessageBox.Show("selecione el producto");
                dgvProducto.Focus();
            }
            clase_venta ventas = new clase_venta();
            ventas.IdProducto = Convert.ToInt32(txtProducto.Text);
            ventas.IdVenta = Convert.ToInt32(txtFactura.Text);
            ventas.Cantidad = Convert.ToInt32(txtCantidad.Text);

            if (ventas.GuardarVentaDetalla())
            {
                MessageBox.Show("Producto Agregado");
                total = Convert.ToDecimal(conexion.consulta(string.Format("SELECT total FROM uma.venta where id_venta={0}", Convert.ToInt32(txtFactura.Text))).Rows[0][0].ToString());
                txtTotal.Text = Convert.ToString(total);
                txtTotal.Enabled = false;
                CargarListadetalle();
                ajustarTamañodetalle();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void dgvProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            producto = Convert.ToInt32(dgvProducto.CurrentRow.Cells[0].Value);
            txtProducto.Text = Convert.ToString(producto);
        }

        private void dGVDetallada_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCantidad.Text = dGVDetallada.CurrentRow.Cells[2].Value.ToString();
            txtiddetalle.Text = dGVDetallada.CurrentRow.Cells[0].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "")
            {
                MessageBox.Show("Ingrese la cantidad a vender");
                txtCantidad.Focus();
            }
            if (txtiddetalle.Text == "")
            {
                MessageBox.Show("selecione la venta a modificar");
                dGVDetallada.Focus();
            }

            if (txtProducto.Text == "")
            {
                MessageBox.Show("selecione el producto");
                dgvProducto.Focus();
            }

            clase_venta ventas = new clase_venta();
            ventas.Id_Detalle = Convert.ToInt32(txtiddetalle.Text);
            ventas.Cantidad = Convert.ToInt32(txtCantidad.Text);
            ventas.IdVenta = Convert.ToInt32(txtFactura.Text);
            ventas.IdProducto = Convert.ToInt32(txtProducto.Text);

            if (ventas.ModificarVentaDetallada())
            {
                MessageBox.Show("Producto Modificado");
                total = Convert.ToDecimal(conexion.consulta(string.Format("SELECT total FROM uma.venta where id_venta={0}", Convert.ToInt32(txtFactura.Text))).Rows[0][0].ToString());
                txtTotal.Text = Convert.ToString(total);
                txtTotal.Enabled = false;
                CargarListadetalle();
                ajustarTamañodetalle();

            }
            else
            {
                MessageBox.Show("ERROR EN GUARDAR \n verfique en que fallo");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (txtiddetalle.Text == "")
            {
                MessageBox.Show("selecione la venta a Eliminar");
                dGVDetallada.Focus();
            }
            clase_venta ventas = new clase_venta();
            ventas.Id_Detalle = Convert.ToInt32(txtiddetalle.Text);

            if (ventas.QuitarVentaDetallada())
            {
                MessageBox.Show("Producto quitado");
                total = Convert.ToDecimal(conexion.consulta(string.Format("SELECT total FROM uma.venta where id_venta={0}", Convert.ToInt32(txtFactura.Text))).Rows[0][0].ToString());
                txtTotal.Text = Convert.ToString(total);
                txtTotal.Enabled = false;
                CargarListadetalle();
                ajustarTamañodetalle();

            }
            else
            {
                MessageBox.Show("ERROR EN Eliminar \n verfique en que fallo");
            }
        }
        private void limpiar()
        {
            txtCantidad.Text = "";
            txtiddetalle.Text = "";
            txtProducto.Text = "";
            txtTotal.Text = "";
            lblDatosCliente.Text = "";
            lblcategoriacliente.Text="";
            txtTotal.Enabled = false;
            dGVDetallada.DataSource = null;

        }

        private void btn_LimpiarPantalla_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gracias por su compra");
            limpiar();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form formulario = new Menu();
            formulario.Show();
            Visible = false;
        }
    }
}
