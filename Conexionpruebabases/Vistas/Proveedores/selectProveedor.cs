using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conexionpruebabases.Vistas.Proveedores
{
    public partial class selectProveedor : Form
    {
        public static NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;");

        public static List<string> proveedores = new List<string>();
        public selectProveedor()
        {
            InitializeComponent();
        }

        private void selectProveedor_Load(object sender, EventArgs e)
        {
            cmbProveedor.Items.Clear();

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT cedula_juridica, nombre_empresa from proveedores;", conn);

            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                proveedores.Add(dr[0].ToString());
                cmbProveedor.Items.AddRange(new object[] { dr[1].ToString() });
            }
            conn.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.Dispose();            
        }

        private void cmbProveedor_SelectedValueChanged(object sender, EventArgs e)
        {
            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("select_proveedores", conn);
            command.CommandType = CommandType.StoredProcedure;

            // creacion de variables que se enviaran por parametro en la consulta
            NpgsqlParameter ced = new NpgsqlParameter("@cedula_juridica", NpgsqlDbType.Char, 12);
            ced.Value = proveedores[cmbProveedor.SelectedIndex];
            command.Parameters.Add(ced);

            NpgsqlParameter nE = new NpgsqlParameter("@nombre_empresa", NpgsqlDbType.Varchar, 50);
            nE.Value = DBNull.Value;
            command.Parameters.Add(nE);

            NpgsqlParameter val = new NpgsqlParameter("@valoracion", NpgsqlDbType.Integer);
            val.Value = DBNull.Value;
            command.Parameters.Add(val);

            NpgsqlParameter name = new NpgsqlParameter("@nombre", NpgsqlDbType.Varchar, 50);
            name.Value = DBNull.Value;
            command.Parameters.Add(name);

            NpgsqlParameter apell1 = new NpgsqlParameter("@apellido1", NpgsqlDbType.Varchar, 50);
            apell1.Value = DBNull.Value;
            command.Parameters.Add(apell1);

            NpgsqlParameter apell2 = new NpgsqlParameter("@apellido2", NpgsqlDbType.Varchar, 50);
            apell2.Value = DBNull.Value;
            command.Parameters.Add(apell2);

            NpgsqlParameter idDis = new NpgsqlParameter("@id_distrito", NpgsqlDbType.Integer);
            idDis.Value = DBNull.Value;
            command.Parameters.Add(idDis);

            NpgsqlParameter dir = new NpgsqlParameter("@direccion_exacta", NpgsqlDbType.Varchar, 250);
            dir.Value = DBNull.Value;
            command.Parameters.Add(dir);

            //a la variable DataReader asignamos  el la variable de tipo SqlCommand
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                txtCedulaJuridica.Text = dr[0].ToString();
                txtValoracion.Text = dr[2].ToString();
                txtNombre.Text = dr[3].ToString();
                txtApellido1.Text = dr[4].ToString();
                txtApellido2.Text = dr[5].ToString();

                txtDirExacta.Text = dr[7].ToString();
            }
            conn.Close();
            /*
            conn.Open();

            NpgsqlCommand command1 = new NpgsqlCommand("select nombre_distrito from distritos where id_distrito = " + dr[6] + ";", conn);

            NpgsqlDataReader dr1 = command1.ExecuteReader();
            while(dr1.Read())
                txtDistrito.Text = dr1[0].ToString();
            conn.Close();*/

            
        }
    }
}
