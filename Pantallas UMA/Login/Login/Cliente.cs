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
    public partial class Cliente : Form
    {
        Validacion v = new Validacion();

        public Cliente()
        {
            InitializeComponent();
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
            v.soloLetras(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form formulario = new Menu();
            formulario.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_IdCategoriaClien.Clear();
            txt_IdCliente.Clear();
            txt_NombreCliente.Clear();
            txt_TelefonoCliente.Clear();
            txt_CorreoCliente.Clear();
            txt_DireccionCliente.Clear();
            txt_RTNCliente.Clear();
            txt_IdentidadCliente.Clear();
        }
    }
}
