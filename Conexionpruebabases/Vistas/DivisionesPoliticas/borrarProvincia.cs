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
    
    public partial class borrarProvincia : Form
    {
        public static List<string> provincias = new List<string>();
        public static string id_provincia_actual;

        public borrarProvincia()
        {
            InitializeComponent();
        }

        private void borrarProvincia_Load(object sender, EventArgs e)
        {
                cargarProvincias();
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cbProvincias.SelectedIndex == -1)
            {
                lblError.BackColor = Color.Red;
                lblError.Visible = true;
            }
            else // si todo esta bien procede a insertar el cliente
            {
                int idProvincia = int.Parse(id_provincia_actual);
                try
                {
                    NpgsqlConnection conn = new NpgsqlConnection();
                    conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                    conn.Open();

                    NpgsqlCommand command = new NpgsqlCommand("borrar_provincias", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    NpgsqlParameter idP = new NpgsqlParameter("@id_provincia", NpgsqlDbType.Integer);
                    idP.Value = idProvincia;
                    command.Parameters.Add(idP);

                    command.ExecuteReader();

                    lblError.Text = "Listo! la provincia se ha eliminado";
                    lblError.ForeColor = Color.Green;
                    lblError.Visible = true;
                    
                    cbProvincias.SelectedIndex = -1;

                    conn.Close();
                }
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = ex.ToString(); ;
                }
            }
        }

        private void cbProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                id_provincia_actual = provincias[cbProvincias.SelectedIndex];
            }
            catch (Exception ex) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
