using MySql.Data.MySqlClient;
using System;
using System.Data;

class claConexion2
    {
        private MySqlConnection  conexion;
        //se necesitran estos para estabkecer la conexion
        private string BD;
        private string usuario;
        private string pass;
        private string servidor;
        //constructor
        public claConexion2()
        {
            conexion = new MySqlConnection();
            BD = "uma";
            usuario = "root";
            pass = "jj4107av";
            servidor = "127.0.0.1";
        

        }

        //constructor
        public Boolean Establecerconexion()
        {
            Boolean r = false;
        try
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
            conexion.ConnectionString = string.Format("Database = {0}; Server = {1} ; Uid = {2};Pwd = {3};SslMode = none ", BD, servidor, usuario, pass);
                conexion.Open();
                r = true;
            }
            catch (MySqlException e)
            {
                System.Windows.Forms.MessageBox.Show(string.Format("Error: {0}", e.ToString()));
                r = false;
            }
            return r;
        }

        public DataTable consulta(string sql)
        {
            Establecerconexion();
            DataTable t = new DataTable();
            MySqlCommand comando = conexion.CreateCommand();
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            comando.Connection = conexion;
            comando.CommandText = sql;
            adaptador.SelectCommand = comando;
            adaptador.Fill(t);
            return t;
        }
        public Boolean Ejecutar(string sql)
        {
            //Boolean r = false;

            Establecerconexion();
            MySqlCommand comando = conexion.CreateCommand();
            comando.Connection = conexion;
            comando.CommandText = sql;
            comando.ExecuteNonQuery();
            return true;
        }

    }

