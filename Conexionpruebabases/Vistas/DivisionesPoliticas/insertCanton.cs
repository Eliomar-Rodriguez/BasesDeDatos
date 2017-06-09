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
    public partial class insertCanton : Form
    {
        public static List<string> provincias = new List<string>();
        public static string id_provincia_actual;
        public insertCanton()
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

        private void insertCanton_Load(object sender, EventArgs e)
        {
            cargarProvincias();
        }

        private bool verificarCanton(string nombre)
        {
            cbProvincias.Items.Clear();
            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * from cantones;", conn);

            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                if ((dr[2].ToString() == nombre) && (dr[1].ToString() == id_provincia_actual))
                {
                    return true;
                }
            }
                    
            conn.Close();
            return false;
        }

        private void cbProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                id_provincia_actual = provincias[cbProvincias.SelectedIndex];
            }
            catch (Exception ex) {}
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // si hay espacios vacios
            if (txtNombre.Text.Length == 0 | cbProvincias.SelectedIndex == -1)
            {
                lblError.BackColor = Color.Red;
                lblError.Visible = true;
            }
            else if (verificarCanton(txtNombre.Text))
            {
                lblError.Text = "Cantón ya existe";
                lblError.ForeColor = Color.Red;
                lblError.Visible = true;
            }
            else // si todo esta bien procede a insertar el cliente
            {
                string nombre = txtNombre.Text;
                int idProvincia = int.Parse(id_provincia_actual);
                try
                {
                    NpgsqlConnection conn = new NpgsqlConnection();
                    conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                    conn.Open();

                    NpgsqlCommand command = new NpgsqlCommand("insertar_canton", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    NpgsqlParameter idP = new NpgsqlParameter("@id_provincia", NpgsqlDbType.Integer);
                    idP.Value = idProvincia;
                    command.Parameters.Add(idP);

                    NpgsqlParameter name = new NpgsqlParameter("@nombre", NpgsqlDbType.Varchar, 50);
                    name.Value = nombre;
                    command.Parameters.Add(name);


                    command.ExecuteReader();

                    lblError.Text = "Listo! el cantón ha sido ingresado";
                    lblError.ForeColor = Color.Green;
                    lblError.Visible = true;

                    txtNombre.Clear();
                    cbProvincias.SelectedIndex = -1;
                    
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
            this.Dispose();
        }
    }
}
