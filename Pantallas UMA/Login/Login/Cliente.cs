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
    public partial class Cliente : Form
    {
        Validacion v = new Validacion();
        private claConexion2 c;

        private cliente clientes;


        public Cliente()
        {
            InitializeComponent();
            clientes = new cliente();
            c = new claConexion2();
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

        private void BtnGuardarCliente_Click(object sender, EventArgs e)
        {
            cliente cliente = new cliente();
            cliente.Categoria_Cliente = Convert.ToInt32(txt_IdCategoriaClien.Text);
            cliente.Nombre_Cliente = Convert.ToString(txt_NombreCliente.Text);
            cliente.TelefonoCliente = Convert.ToString(txt_TelefonoCliente.Text);
            cliente.Coreo_electronico = Convert.ToString(txt_CorreoCliente.Text);
            cliente.Direccion = Convert.ToString(txt_DireccionCliente.Text);
            cliente.Rtn = Convert.ToString(txt_RTNCliente.Text);
            cliente.N_Identidad = Convert.ToString(txt_IdentidadCliente.Text);


            if (cliente.GuardarCliente())
            {
                MessageBox.Show("Cliente guardado exitosamente");
            }
            else
            {
                MessageBox.Show("Error el cliente no a sido agregado");
            }


        }

        private void BtnBuscarCLiente_Click(object sender, EventArgs e)
        {
            cliente cliente = new cliente();
            if (Convert.ToInt32(txt_IdCliente.Text) == Convert.ToInt32(cliente.IdCliente))
            {
                txt_IdCategoriaClien.Text = Convert.ToString(cliente.Categoria_Cliente);
                txt_TelefonoCliente.Text = Convert.ToString(txt_NombreCliente.Text);
                txt_TelefonoCliente.Text = Convert.ToString(cliente.TelefonoCliente);
                txt_CorreoCliente.Text = Convert.ToString(cliente.Coreo_electronico);
                txt_DireccionCliente.Text = Convert.ToString(cliente.Direccion);
                txt_RTNCliente.Text = Convert.ToString(cliente.Rtn);
                txt_IdentidadCliente.Text = Convert.ToString(cliente.N_Identidad);
            }
            else
            {
                MessageBox.Show("No se encontro datos del cliente");
            }


        }

        private void BtnModificarCliente_Click(object sender, EventArgs e)
        {
            

            cliente cliente = new cliente();
            if(Convert.ToInt32(txt_IdCliente.Text) == Convert.ToInt32(cliente.IdCliente))
            {
                cliente.Categoria_Cliente = Convert.ToInt32(txt_IdCategoriaClien.Text);
                cliente.Nombre_Cliente = Convert.ToString(txt_NombreCliente.Text);
                cliente.TelefonoCliente = Convert.ToString(txt_TelefonoCliente.Text);
                cliente.Coreo_electronico = Convert.ToString(txt_CorreoCliente.Text);
                cliente.Direccion = Convert.ToString(txt_DireccionCliente.Text);
                cliente.Rtn = Convert.ToString(txt_RTNCliente.Text);
                cliente.N_Identidad = Convert.ToString(txt_IdentidadCliente.Text);


                if (cliente.ModificarCliente())
                {
                    MessageBox.Show("Cliente Modificado Exitosamente");
                }
                else
                {
                    MessageBox.Show("Error el cliente no a sido modificado");
                }
            }


        }


    }
}
