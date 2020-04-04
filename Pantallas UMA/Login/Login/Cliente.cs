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
            limpiar();
        }

        private void BtnGuardarCliente_Click(object sender, EventArgs e)
        {
            if (txt_IdCategoriaClien.Text == string.Empty || txt_NombreCliente.Text == string.Empty || txt_DireccionCliente.Text == string.Empty || txt_IdentidadCliente.Text == string.Empty )
            {
                MessageBox.Show("Error Algunos campos obligatirios esta vacios, porfavor verifique");
            }
            else
            {
                if (btnGuardarCliente.Text == "AGREGAR")
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
                else
                {
                    MessageBox.Show("Edicion Cancelada");

                }

                limpiar();
            }

            
        }

        private void limpiar()
        {
            txt_IdCliente.Text = "";
            txt_IdCategoriaClien.Text = "";
            txt_NombreCliente.Text = "";
            txt_TelefonoCliente.Text = "";
            txt_CorreoCliente.Text = "";
            txt_DireccionCliente.Text = "";
            txt_RTNCliente.Text = "";
            txt_IdentidadCliente.Text = "";
            btnGuardarCliente.Text = "AGREGAR";
            btnGuardarCliente.Enabled = true;
            txt_IdCliente.Enabled = true;
            txt_IdCliente.Focus();
        }

        private void BtnBuscarCLiente_Click(object sender, EventArgs e)
        {

        }

        private void BtnModificarCliente_Click(object sender, EventArgs e)
        {
            if (txt_IdCategoriaClien.Text == string.Empty || txt_NombreCliente.Text == string.Empty || txt_DireccionCliente.Text == string.Empty || txt_IdentidadCliente.Text == string.Empty)
            {
                MessageBox.Show("Error Algunos campos obligatirios esta vacios, porfavor verifique");
            }
            else
            {
                clientes.Categoria_Cliente = Convert.ToInt32(txt_IdCategoriaClien.Text);
                clientes.Nombre_Cliente = txt_NombreCliente.Text;
                clientes.TelefonoCliente = txt_TelefonoCliente.Text;
                clientes.Coreo_electronico = txt_CorreoCliente.Text;
                clientes.Direccion = txt_DireccionCliente.Text;

                if (clientes.ModificarCliente())
                {
                    MessageBox.Show("Registro actulizado correctamente", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo Actualizar los datos");
                }
                limpiar();
            }

           

        }

        private void buscar(int co)
        {
            if (clientes.BuscarCLiente(Convert.ToInt32(txt_IdCliente.Text)))
            {
                txt_IdCliente.Text = Convert.ToString(clientes.IdCliente);
                txt_IdCategoriaClien.Text = Convert.ToString(clientes.Categoria_Cliente);
                txt_NombreCliente.Text = clientes.Nombre_Cliente;
                txt_TelefonoCliente.Text = clientes.TelefonoCliente;
                txt_DireccionCliente.Text = clientes.Direccion;
                txt_CorreoCliente.Text = clientes.Coreo_electronico;
                txt_RTNCliente.Text = clientes.Rtn;
                txt_IdentidadCliente.Text = clientes.N_Identidad;
                txt_IdCliente.Enabled = false;
                txt_RTNCliente.Enabled = false;
                txt_IdentidadCliente.Enabled = false;
                btnGuardarCliente.Text = "Cancelar";
                btnModificarCliente.Enabled = true;
                
            }
            else
            {
                txt_IdCliente.Enabled = true;
                txt_RTNCliente.Enabled = true;
                txt_IdentidadCliente.Enabled = true;
                btnGuardarCliente.Text = "AGREGAR";
                btnModificarCliente.Enabled = false;
                btnModificarCliente.Visible = false;
            }
        }

        private void BtnBuscarCliente_Click_1(object sender, EventArgs e)
        {
            btnModificarCliente.Visible = true;
            buscar(Convert.ToInt32(txt_IdCliente.Text));
        }

        private void Cliente_Load(object sender, EventArgs e)
        {

        }
    }
}   
