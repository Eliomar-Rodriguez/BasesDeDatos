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
    public partial class editProveedor : Form
    {
        public static List<string> distritos = new List<string>();
        public editProveedor()
        {
            InitializeComponent();
        }

        private void editProveedor_Load(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * from distritos;", conn);

            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                distritos.Add(dr[0].ToString());
                cbDistritos.Items.AddRange(new object[] { dr[2].ToString() });
            }
            conn.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * from proveedores where cedula_juridica='" + txtCedulaJuridica.Text + "';", conn);

            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                txtCedulaJuridica.Text = dr[0].ToString();
                txtNombreEmpresa.Text = dr[1].ToString();
                txtValoracion.Text = dr[2].ToString();
                txtNombre.Text = dr[3].ToString();
                txtApellido1.Text = dr[4].ToString();
                txtApellido2.Text = dr[5].ToString();
                txtDirExacta.Text = dr[7].ToString();
            }           

            conn.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // si hay espacios vacios
            if (txtCedulaJuridica.Text.Length ==0 | txtNombreEmpresa.Text.Length == 0 | txtValoracion.Text.Length == 0 | txtNombre.Text.Length == 0 | txtApellido1.Text.Length == 0 | txtApellido2.Text.Length == 0 | cbDistritos.SelectedIndex == -1 | txtDirExacta.Text.Length == 0 )
            {
                lblError.Visible = true;
            }
            else // si todo esta bien procede a insertar el cliente
            {
                string  dirExacta = txtDirExacta.Text, nombreEmpresa = txtNombreEmpresa.Text;
                char[] cedulaJuridica = txtCedulaJuridica.Text.ToCharArray(), nombre = txtNombre.Text.ToCharArray(), apellido1 = txtApellido1.Text.ToCharArray(), apellido2 = txtApellido2.Text.ToCharArray();
                int valoracion = int.Parse(txtValoracion.Text), idDistrito = int.Parse(distritos[cbDistritos.SelectedIndex]);

                try
                {
                    NpgsqlConnection conn = new NpgsqlConnection();
                    conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                    conn.Open();

                    NpgsqlCommand command = new NpgsqlCommand("update_proveedores", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    // creacion de variables que se enviaran por parametro en la consulta
                    NpgsqlParameter ced = new NpgsqlParameter("@cedula_juridica", NpgsqlDbType.Char, 12);
                    ced.Value = cedulaJuridica;
                    command.Parameters.Add(ced);

                    NpgsqlParameter nE = new NpgsqlParameter("@nombre_empresa", NpgsqlDbType.Varchar,50);
                    nE.Value = nombreEmpresa;
                    command.Parameters.Add(nE);

                    NpgsqlParameter val = new NpgsqlParameter("@valoracion", NpgsqlDbType.Integer);
                    val.Value = valoracion;
                    command.Parameters.Add(val);

                    NpgsqlParameter name = new NpgsqlParameter("@nombre", NpgsqlDbType.Varchar, 50);
                    name.Value = nombre;
                    command.Parameters.Add(name);

                    NpgsqlParameter apell1 = new NpgsqlParameter("@apellido1", NpgsqlDbType.Varchar, 50);
                    apell1.Value = apellido1;
                    command.Parameters.Add(apell1);

                    NpgsqlParameter apell2 = new NpgsqlParameter("@apellido2", NpgsqlDbType.Varchar, 50);
                    apell2.Value = apellido2;
                    command.Parameters.Add(apell2);

                    NpgsqlParameter idDis = new NpgsqlParameter("@id_distrito", NpgsqlDbType.Integer);
                    idDis.Value = idDistrito;
                    command.Parameters.Add(idDis);

                    NpgsqlParameter dir = new NpgsqlParameter("@direccion_exacta", NpgsqlDbType.Varchar,250);
                    dir.Value = dirExacta;
                    command.Parameters.Add(dir);

                    command.ExecuteReader();

                    lblError.Text = "Listo! el Proveedor ha sido actualizado";
                    lblError.ForeColor = Color.Green;
                    lblError.Visible = true;

                    txtCedulaJuridica.Clear();
                    txtNombreEmpresa.Clear();
                    txtValoracion.Clear();
                    txtNombre.Clear();
                    txtApellido1.Clear();
                    txtApellido2.Clear();
                    txtDirExacta.Clear();
                    cbDistritos.SelectedIndex = -1;

                    conn.Close();
                }
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = ex.ToString(); ;
                }
            }
        }
    }
}
