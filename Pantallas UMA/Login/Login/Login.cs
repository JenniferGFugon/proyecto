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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            txtBox_Ususario.Clear();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            txtBox_Contrasena.Clear();
            txtBox_Contrasena.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form formulario = new Menu();
            formulario.Show();
            Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            this.Close();
           

        }
    }
}
