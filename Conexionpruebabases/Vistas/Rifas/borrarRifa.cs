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

namespace Conexionpruebabases.Vistas.Rifas
{
    public partial class borrarRifa : Form
    {
        public static string id_rifa_actual;
        public static List<string> rifas = new List<string>();
        public borrarRifa()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {// insertando todos los proveedores en el combo box
                NpgsqlConnection conn = new NpgsqlConnection();
                conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                conn.Open();

                NpgsqlCommand command = new NpgsqlCommand("SELECT estado,fecha,descripcion from rifas where id_rifa='" + id_rifa_actual + "';", conn);

                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    if (dr[0].ToString().Equals("True"))
                        txtEstado.Text = "Realizada";
                    else
                        txtEstado.Text = "Pendiente";

                    dtpFecha.Value = DateTime.Parse(dr[1].ToString());
                    txtDescripcion.Text = dr[2].ToString();
                }
                if (dr.FieldCount == 0)
                {
                    lblError.Visible = true;
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.ToString();
            }
        }

        private void borrarRifa_Load(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * from rifas;", conn);

            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                rifas.Add(dr[0].ToString());
                cbFechas.Items.AddRange(new object[] { dr[2].ToString() });
            }
            conn.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cbFechas.SelectedIndex == -1 | txtEstado.Text.Length == 0 | txtDescripcion.Text.Length == 0)
            {
                lblError.Visible = true;
            }
            else
            {
                NpgsqlConnection conn = new NpgsqlConnection();
                conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                conn.Open();

                NpgsqlCommand command = new NpgsqlCommand("eliminar_rifa", conn);
                command.CommandType = CommandType.StoredProcedure;

                // creacion de variables que se enviaran por parametro en la consulta
                NpgsqlParameter id = new NpgsqlParameter("@id_rifa", NpgsqlDbType.Integer);
                id.Value = int.Parse(id_rifa_actual);
                command.Parameters.Add(id);

                NpgsqlParameter fe = new NpgsqlParameter("@fecha", NpgsqlDbType.Date);
                fe.Value = DateTime.Parse(cbFechas.SelectedItem.ToString());
                command.Parameters.Add(fe);

                command.ExecuteReader();


                lblError.Visible = true;
                lblError.Text = "Listo! la rifa ha sido eliminada";
                lblError.ForeColor = Color.Green;

                txtDescripcion.Clear();
                txtEstado.Clear();
                cbFechas.SelectedIndex = -1;
                dtpFecha.Value = DateTime.Now;
                conn.Close();
            }
            
        }

        private void cbFechas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                id_rifa_actual = rifas[cbFechas.SelectedIndex];
            }
            catch(Exception ex){}
        }
    }
}
