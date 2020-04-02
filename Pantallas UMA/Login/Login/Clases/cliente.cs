﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Data;


namespace Login.Clases
{
    class cliente
    {
        private int idCliente;
        private int categoria_cliente;
        private string nombre_cliente;
        private string telefono_cliente;
        private string correo_electronico;
        private string direccion;
        private string RTN;
        private string N_identidad;
        private claConexion2 Conexion2;
        private DataTable table;


        public  cliente()
            {

            idCliente = 0;
            categoria_cliente = 0;
            nombre_cliente = "";
            telefono_cliente = "";
            correo_electronico = "";
            direccion = "";
            RTN = "";
            N_identidad = "";
            Conexion2 = new claConexion2();


            }
            
        public DataTable Table
        {
            get { return table; }
        }

        public  int IdCliente
        {
            get { return idCliente;}
            set { idCliente = value; }
        }

        public int  Categoria_Cliente
        {
            get { return categoria_cliente; }
            set { categoria_cliente = value; }
        }

        public string Nombre_Cliente
        {
            get { return nombre_cliente; }
            set { nombre_cliente = value; }
        }

        public string TelefonoCliente
        {
            get { return telefono_cliente; }
            set { telefono_cliente = value; }
        }

        public string Coreo_electronico
        {
            get { return correo_electronico; }
            set { correo_electronico = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Rtn
        {
            get { return RTN; }
            set { RTN = value; }
        }

        public string N_Identidad
        {
            get { return N_identidad; }
            set { N_identidad = value; }
        }

        public Boolean GuardarCliente()
        {
            if(Conexion2.Ejecutar(string.Format("INSERT INTO cliente(id_categoria_cliente,nombre_cliente,numero_telefono,correo_electronico,direccion_cliente,RTN,numero_identidad)Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", Categoria_Cliente, Nombre_Cliente, TelefonoCliente, Coreo_electronico, Direccion, Rtn, N_Identidad)))
            {
                return true;
                
            }
            else
            {
                return false;
            }

        }

        public Boolean ModificarCliente()
        {
            if (Conexion2.Ejecutar(string.Format("UPDATE cliente SET id_categoria_cliente='{0}', nombre_cliente={1} , numero_telefono={2} , correo_electronico={3} , direccion_cliente={4}, RTN={5},numero_identidad={6}  WHERE id_cliente={7}", Categoria_Cliente, Nombre_Cliente, TelefonoCliente, Coreo_electronico, Direccion, Rtn, N_Identidad,idCliente)))
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        
        public Boolean BuscarCLiente(int id)
        {
            if (Conexion2.Ejecutar(string.Format("SELECT id_categoria_cliente, nombre_cliente, numero_telefono, correo_electronico, direccion_cliente, RTN, numero_identidad  habilitado FROM cliente where id_cliente={0}", id)))
            {
                if (table.Rows.Count > 0)
                {
                    Categoria_Cliente = Convert.ToInt32(table.Rows[0][1].ToString());
                    Nombre_Cliente = table.Rows[0][2].ToString();
                    TelefonoCliente = table.Rows[0][3].ToString();
                    Coreo_electronico = table.Rows[0][4].ToString();
                    Direccion = table.Rows[0][5].ToString();
                    Rtn = table.Rows[0][6].ToString();
                    N_Identidad = table.Rows[0][7].ToString();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

    }

}
    
