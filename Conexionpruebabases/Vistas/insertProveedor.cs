using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;

namespace Conexionpruebabases.Vistas
{
    public partial class insertProveedor : Form
    {
        public static List<string> distritos = new List<string>();
        public insertProveedor()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //si hay espacios vacios
            if (cbDistrito.SelectedIndex == -1 | txtCedulaJuridica.Text.Length == 0 | txtNombreEmpresa.Text.Length == 0 | txtNombre.Text.Length == 0 | txtApellido1.Text.Length == 0 | txtApellido2.Text.Length == 0 | txtDirExacta.Text.Length == 0)
            {
                lblError.Visible = true;
            }
            else // si todo esta bien procede a insertar el cliente
            {
                char[] cedJurid = txtCedulaJuridica.Text.ToCharArray(), nombre = txtNombre.Text.ToCharArray(), apellido1 = txtApellido1.Text.ToCharArray(), apellido2 = txtApellido2.Text.ToCharArray(); ;
                string dirExacta = txtDirExacta.Text, nombreEmpresa = txtNombreEmpresa.Text;
                int idDistrito = int.Parse(distritos[cbDistrito.SelectedIndex]);


                try
                {
                    NpgsqlConnection conn = new NpgsqlConnection();
                    conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                    conn.Open();

                    NpgsqlCommand command = new NpgsqlCommand("insertar_proveedores", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    //    // creacion de variables que se enviaran por parametro en la consulta
                    NpgsqlParameter cedJ = new NpgsqlParameter("@cedula_juridica", NpgsqlDbType.Char,12);
                    cedJ.Value = cedJurid;
                    command.Parameters.Add(cedJ);

                    NpgsqlParameter nE = new NpgsqlParameter("@nombre_empresa", NpgsqlDbType.Varchar,50);
                    nE.Value = nombreEmpresa;
                    command.Parameters.Add(nE);

                    NpgsqlParameter nomb = new NpgsqlParameter("@nombre", NpgsqlDbType.Varchar, 50);
                    nomb.Value = nombre;
                    command.Parameters.Add(nomb);

                    NpgsqlParameter ap1 = new NpgsqlParameter("@apellido1", NpgsqlDbType.Varchar,50);
                    ap1.Value = apellido1;
                    command.Parameters.Add(ap1);

                    NpgsqlParameter ap2 = new NpgsqlParameter("@apellido2", NpgsqlDbType.Varchar,50);
                    ap2.Value = apellido2;
                    command.Parameters.Add(ap2);

                    NpgsqlParameter dis = new NpgsqlParameter("@id_distrito", NpgsqlDbType.Integer);
                    dis.Value = idDistrito;
                    command.Parameters.Add(dis);

                    NpgsqlParameter dir = new NpgsqlParameter("@dir_Exacta", NpgsqlDbType.Varchar, 250);
                    dir.Value = dirExacta;
                    command.Parameters.Add(dir);

                    txtCedulaJuridica.Clear();
                    txtNombreEmpresa.Clear();
                    txtNombre.Clear();
                    txtApellido1.Clear();
                    txtApellido2.Clear();
                    cbDistrito.SelectedIndex = -1;
                    txtDirExacta.Clear();

                    command.ExecuteReader();

                    lblError.Visible = true;
                    lblError.Text = "Listo! el producto ha sido agregado";
                    lblError.ForeColor = Color.Green;

                    conn.Close();
                }
                    catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = ex.Message;
                }
            }
        
        }

        private void insertProveedor_Load(object sender, EventArgs e)
        {
            // insertando todos los proveedores en el combo box
            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT id_distrito,nombre_distrito from distritos;", conn);

            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                distritos.Add(dr[0].ToString());
                cbDistrito.Items.AddRange(new object[] { dr[1].ToString() });
            }
            conn.Close();
        }
    }
}
