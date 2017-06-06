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

namespace Conexionpruebabases.Vistas.Bienes
{
    public partial class borrarBienes : Form
    {
        public static List<string> bienes = new List<string>();
        public static string codigo_bien_actual;
        public borrarBienes()
        {
            InitializeComponent();
        }

        private void borrarBienes_Load(object sender, EventArgs e)
        {
            cargarBienes();   
        }

        private void cargarBienes()
        {
            cbBienes.Items.Clear();
            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT codigo,nombre from bienes;", conn);

            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                bienes.Add(dr[0].ToString());
                cbBienes.Items.AddRange(new object[] { dr[1].ToString() });
            }
            conn.Close();
        }

        private void cbFechas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                codigo_bien_actual = bienes[cbBienes.SelectedIndex];
            }
            catch (Exception ex) { }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {// insertando todos los proveedores en el combo box
                NpgsqlConnection conn = new NpgsqlConnection();
                conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                conn.Open();

                NpgsqlCommand command = new NpgsqlCommand("SELECT nombre,descripcion,estado,cantidad from bienes where codigo='" + codigo_bien_actual + "';", conn);

                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    txtNombre.Text = dr[0].ToString();
                    txtDescripcion.Text = dr[1].ToString();
                    txtEstado.Text = dr[2].ToString();
                    txtCantidad.Text = dr[3].ToString();
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length == 0 | txtCantidad.Text.Length == 0  | txtEstado.Text.Length == 0 | txtDescripcion.Text.Length == 0)
            {
                lblError.Visible = true;
            }
            else
            {

                NpgsqlConnection conn = new NpgsqlConnection();
                conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                conn.Open();

                NpgsqlCommand command = new NpgsqlCommand("eliminar_bienes", conn);
                command.CommandType = CommandType.StoredProcedure;

                // creacion de variables que se enviaran por parametro en la consulta
                NpgsqlParameter id = new NpgsqlParameter("@codigo", NpgsqlDbType.Integer);
                id.Value = codigo_bien_actual;
                command.Parameters.Add(id);

                command.ExecuteReader();


                lblError.Visible = true;
                lblError.Text = "Listo! la rifa ha sido eliminada";
                lblError.ForeColor = Color.Green;

                txtDescripcion.Clear();
                txtEstado.Clear();
                txtCantidad.Clear();
                txtNombre.Clear();
                cbBienes.SelectedIndex = -1;
                cargarBienes();
                conn.Close();
            }
        }
    }
}
