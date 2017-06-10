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
    public partial class borrarDistrito : Form
    {
        public static List<string> provincias = new List<string>();
        public static string id_provincia_actual;
        public static List<string> cantones = new List<string>();
        public static string id_canton_actual;
        public static List<string> distritos = new List<string>();
        public static string id_distrito_actual;
        public borrarDistrito()
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

        private void cargarCantones()
        {
            cbCantones.Items.Clear();
            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * from cantones where id_provincia=" + id_provincia_actual + ";", conn);

            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                cantones.Add(dr[0].ToString());
                cbCantones.Items.AddRange(new object[] { dr[2].ToString() });
            }
            conn.Close();
        }

        private void cargarDistritos()
        {
            MessageBox.Show(id_canton_actual);
            cbDistritos.Items.Clear();
            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * from distritos where id_canton=" + id_canton_actual + ";", conn);

            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                distritos.Add(dr[0].ToString());
                cbDistritos.Items.AddRange(new object[] { dr[2].ToString() });
            }
            conn.Close();
        }

        private void borrarDistrito_Load(object sender, EventArgs e)
        {
            cargarProvincias();
        }

        private void cbProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                id_provincia_actual = provincias[cbProvincias.SelectedIndex];
                cargarCantones();
            }
            catch (Exception ex) { }
        }

        private void cbCantones_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                id_canton_actual = cantones[cbCantones.SelectedIndex];
                cargarDistritos();
            }
            catch (Exception ex) { }
        }

        private void cbDistritos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                id_distrito_actual = distritos[cbDistritos.SelectedIndex];
            }
            catch (Exception ex) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
