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
    public partial class Buscar_Clientes : Form
    {
         
        private Clases.cliente cliente;
        Validacion v = new Validacion();
        private Clases.clientelista clientes;
        public Buscar_Clientes()
        {
            InitializeComponent();
            cliente = new Clases.cliente();
            clientes = new Clases.clientelista();

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

        private void CargarDatos()
        {

        }

        
        private void Buscar_Clientes_Load(object sender, EventArgs e)
        {
           
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
