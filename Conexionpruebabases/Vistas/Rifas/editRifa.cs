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
    public partial class editRifa : Form
    {
        public static string id_rifa_actual;
        public static List<string> rifas = new List<string>();
        public editRifa()
        {
            InitializeComponent();
        }
        

        private void cargarRifas()
        {
            cbFechas.Items.Clear();
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
                        cbEstado.SelectedIndex = 0;
                    else
                        cbEstado.SelectedIndex = 1;

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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cbFechas.SelectedIndex == -1 | cbEstado.SelectedIndex == -1 | txtDescripcion.Text.Length == 0)
            {
                lblError.Visible = true;
            }
            else
            {
                bool estado;
                if (cbEstado.SelectedIndex == 0)
                    estado = true;
                else
                    estado = false;
                DateTime fecha = dtpFecha.Value;
                string descripcion = txtDescripcion.Text;


                NpgsqlConnection conn = new NpgsqlConnection();
                conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                conn.Open();

                NpgsqlCommand command = new NpgsqlCommand("modificar_rifa", conn);
                command.CommandType = CommandType.StoredProcedure;

                // creacion de variables que se enviaran por parametro en la consulta
                NpgsqlParameter id = new NpgsqlParameter("@id_rifa", NpgsqlDbType.Integer);
                id.Value = int.Parse(id_rifa_actual);
                command.Parameters.Add(id);

                NpgsqlParameter est = new NpgsqlParameter("@estado", NpgsqlDbType.Boolean);
                est.Value = estado;
                command.Parameters.Add(est);

                NpgsqlParameter fe = new NpgsqlParameter("@fecha", NpgsqlDbType.Date);
                fe.Value = fecha;
                command.Parameters.Add(fe);

                NpgsqlParameter des = new NpgsqlParameter("@descripcion", NpgsqlDbType.Varchar,250);
                des.Value = descripcion;
                command.Parameters.Add(des);

                command.ExecuteReader();


                lblError.Visible = true;
                lblError.Text = "Listo! la rifa ha sido actualizada";
                lblError.ForeColor = Color.Green;

                txtDescripcion.Clear();
                cbEstado.SelectedIndex = -1;
                cbFechas.SelectedIndex = -1;
                dtpFecha.Value = DateTime.Now;

                conn.Close();
            }
            cargarRifas();
        }

        private void cbFechas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                id_rifa_actual = rifas[cbFechas.SelectedIndex];
                MessageBox.Show(id_rifa_actual);
            }
            catch (Exception ex) { }
        }

        private void editRifa_Load(object sender, EventArgs e)
        {
            cargarRifas();
        }
    }
}
