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

namespace Conexionpruebabases.Vistas.DivisionesPoliticas
{
    public partial class editProvincia : Form
    {
        public static List<string> provincias = new List<string>();
        public static string id_provincia_actual;
        public editProvincia()
        {
            InitializeComponent();
        }

        private void cargarProvincias()
        {
            cbProvincias.Items.Clear();
            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * from provincias;", conn);

            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                provincias.Add(dr[0].ToString());
                cbProvincias.Items.AddRange(new object[] { dr[1].ToString() });
            }
            conn.Close();
        }

        private void editProvincia_Load(object sender, EventArgs e)
        {
            cargarProvincias();
        }

        private void cbProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                id_provincia_actual = provincias[cbProvincias.SelectedIndex];
            }
            catch (Exception ex) { }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbProvincias.SelectedIndex == -1)
            {
                lblError.Visible = true;
                lblError.ForeColor = Color.Red;
            }
            else
            {
                // insertando todos los proveedores en el combo box
                NpgsqlConnection conn = new NpgsqlConnection();
                conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                conn.Open();

                NpgsqlCommand command = new NpgsqlCommand("SELECT nombre_provincia from provincias where id_provincia='" + id_provincia_actual + "';", conn);

                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    txtNombre.Text = dr[0].ToString();                    
                }
                conn.Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cbProvincias.SelectedIndex == -1)
            {
                lblError.BackColor = Color.Red;
                lblError.Visible = true;
            }
            else // si todo esta bien procede a insertar el cliente
            {
                int idProvincia = int.Parse(id_provincia_actual);
                string nombre = txtNombre.Text;
                try
                {
                    NpgsqlConnection conn = new NpgsqlConnection();
                    conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                    conn.Open();

                    NpgsqlCommand command = new NpgsqlCommand("modificar_provincias", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    NpgsqlParameter idP = new NpgsqlParameter("@id_provincia", NpgsqlDbType.Integer);
                    idP.Value = idProvincia;
                    command.Parameters.Add(idP);

                    NpgsqlParameter nom = new NpgsqlParameter("@nombre_provincia", NpgsqlDbType.Varchar,50);
                    nom.Value = nombre;
                    command.Parameters.Add(nom);

                    command.ExecuteReader();

                    lblError.Text = "Listo! la provincia se ha modificado";
                    lblError.ForeColor = Color.Green;
                    lblError.Visible = true;

                    cbProvincias.SelectedIndex = -1;
                    txtNombre.Clear();

                    conn.Close();
                }
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = ex.ToString(); ;
                }
            }
            cargarProvincias();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
