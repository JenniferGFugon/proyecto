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
    public partial class Listados : Form
    {
        public Listados()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form formulario = new Menu();
            formulario.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form formulario = new Listados_Ventas();
            formulario.Show();
            Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form formulario = new Listados_Clientes();
            formulario.Show();
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form formulario = new Listados_Productos();
            formulario.Show();
            Visible = false;
        }
    }
}
