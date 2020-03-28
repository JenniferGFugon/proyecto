using System.Windows.Forms;

namespace Login
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }


        private void button4_Click(object sender, System.EventArgs e)
        {
            Form formulario = new Login();
            formulario.Show();
            Visible = false;
            this.Close();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            Form formulario = new Buscar();
            formulario.Show();
            Visible = false;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Form formulario = new Buscar_Productos();
            formulario.Show();
            Visible = false;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            Form formulario = new Venta();
            formulario.Show();
            Visible = false;
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            Form formulario = new Cliente();
            formulario.Show();
            Visible = false;
        }
    }       
}
