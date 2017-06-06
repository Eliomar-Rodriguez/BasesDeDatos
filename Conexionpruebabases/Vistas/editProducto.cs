using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conexionpruebabases.Vistas
{
    public partial class editProducto : Form
    {
        public static List<string> proveedores = new List<string>();
        public static List<int> tiposProductos = new List<int>();
        public editProducto()
        {
            InitializeComponent();
        }

        private void editProducto_Load(object sender, EventArgs e)
        {
            // insertando todos los proveedores en el combo box
            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * from proveedores;", conn);

            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                proveedores.Add(dr[0].ToString());
                cmbEmpresa.Items.AddRange(new object[] { dr[1].ToString() });
            }
            conn.Close();
            // insertando todos los tipos de productos en el combo box
            conn.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("SELECT * from tipos_productos;", conn);

            NpgsqlDataReader dr1 = command1.ExecuteReader();
            int idTipo;
            while (dr1.Read())
            {
                idTipo = 0;
                bool res = int.TryParse(dr1[0].ToString(), out idTipo);
                if (res)
                    tiposProductos.Add(idTipo);
                cmbTipoP.Items.AddRange(new object[] { dr1[1].ToString() });
            }
            conn.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text.Length != 0 & cmbEmpresa.SelectedIndex != -1)
            {
                try
                {
                    char[] nombre = txtNombre.Text.ToCharArray();
                    NpgsqlConnection conn = new NpgsqlConnection();
                    conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                    conn.Open();

                    NpgsqlCommand command = new NpgsqlCommand("seleccionar_productos", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    // creacion de variables que se enviaran por parametro en la consulta
                    command.Parameters.AddWithValue("@codigoP", NpgsqlDbType.Integer, string.IsNullOrEmpty(null) ? (object)DBNull.Value : null);
                    command.Parameters.AddWithValue("@idEmp", NpgsqlDbType.Integer, string.IsNullOrEmpty(null) ? (object)DBNull.Value : null);
                    command.Parameters.AddWithValue("@tipo", NpgsqlDbType.Integer, string.IsNullOrEmpty(null) ? (object)DBNull.Value : null);
                    
                    NpgsqlParameter tP = new NpgsqlParameter("@cedJur", NpgsqlDbType.Char, 12);
                    tP.Value = proveedores[cmbEmpresa.SelectedIndex];
                    command.Parameters.Add(tP);

                    NpgsqlParameter nomb = new NpgsqlParameter("@nombre", NpgsqlDbType.Varchar, 50);
                    nomb.Value = nombre;
                    command.Parameters.Add(nomb);

                    command.Parameters.AddWithValue("@precio", NpgsqlDbType.Money, string.IsNullOrEmpty(null) ? (object)DBNull.Value : null);
                    command.Parameters.AddWithValue("@stock", NpgsqlDbType.Integer, string.IsNullOrEmpty(null) ? (object)DBNull.Value : null);
                    

                    NpgsqlDataReader dr1 = command.ExecuteReader();
                    int tipo;
                    while (dr1.Read())
                    {
                        if (int.TryParse(dr1[2].ToString(), out tipo))
                        {
                            cmbTipoP.SelectedIndex = tipo - 1;
                        }
                        else
                        {
                            lblError.Text = "Datos invalidos.";
                            lblError.Visible = true;
                        }

                        txtPrecio.Text = dr1[5].ToString();
                        txtStock.Text = dr1[6].ToString();
                    }

                    lblError.Visible = true;
                    lblError.Text = "Listo! el producto ha sido agregado";
                    lblError.ForeColor = Color.Green;

                    cmbTipoP.SelectedIndex = -1;
                    cmbEmpresa.SelectedIndex = -1;
                    txtNombre.Clear();
                    txtPrecio.Clear();
                    txtStock.Clear();

                    conn.Close();
                }
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = ex.Message;
                }
            }
            else
                lblError.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Principal().Show();
            this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
