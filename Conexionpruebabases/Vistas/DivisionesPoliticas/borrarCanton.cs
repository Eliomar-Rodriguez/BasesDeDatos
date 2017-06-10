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
    public partial class borrarCanton : Form
    {
        public static List<string> provincias = new List<string>();
        public static string id_provincia_actual;
        public static List<string> cantones = new List<string>();
        public static string id_canton_actual;
        public borrarCanton()
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


        private void borrarCanton_Load(object sender, EventArgs e)
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
            }
            catch (Exception ex) { }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cbProvincias.SelectedIndex == -1 | cbCantones.SelectedIndex == -1)
            {
                lblError.ForeColor = Color.Red;
                lblError.Visible = true;
            }
            else // si todo esta bien procede a insertar el cliente
            {
                int idCanton = int.Parse(id_canton_actual);
                try
                {
                    NpgsqlConnection conn = new NpgsqlConnection();
                    conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                    conn.Open();

                    NpgsqlCommand command = new NpgsqlCommand("eliminar_canton", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    NpgsqlParameter idC = new NpgsqlParameter("@id_canton", NpgsqlDbType.Integer);
                    idC.Value = idCanton;
                    command.Parameters.Add(idC);

                    command.ExecuteReader();

                    lblError.Text = "Listo! el distrito ha sido ingresado";
                    lblError.ForeColor = Color.Green;
                    lblError.Visible = true;
                    
                    cbProvincias.SelectedIndex = -1;
                    cbCantones.SelectedIndex = -1;
                    cargarProvincias();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = ex.ToString(); ;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
