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

        public Venta()
        {
            InitializeComponent();
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
    }
}
