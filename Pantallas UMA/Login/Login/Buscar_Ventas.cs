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
    public partial class Buscar_Ventas : Form
    {
        Validacion v = new Validacion();

        public Buscar_Ventas()
        {
            InitializeComponent();
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
    }
}
