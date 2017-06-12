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
    public partial class insertTelefonoProveedor : Form
    {
        public static List<string> proveedores = new List<string>();
        public static string id_proveedor_actual;
        public insertTelefonoProveedor()
        {
            InitializeComponent();
        }

        private void cargarProveedores()
        {
            cbProveedores.Items.Clear();
            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT cedula_juridica,nombre,apellido1,apellido2 from proveedores;", conn);

            NpgsqlDataReader dr = command.ExecuteReader();
            string n;
            while (dr.Read())
            {
                proveedores.Add(dr[0].ToString());
                n = dr[1].ToString() + " " + dr[2].ToString() + " " + dr[3].ToString();
                cbProveedores.Items.AddRange(new object[] { n });
                n = "";
            }
            conn.Close();
        }

        private void insertTelefonoProveedor_Load(object sender, EventArgs e)
        {
            cargarProveedores();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {// insertando todos los proveedores en el combo box
                NpgsqlConnection conn = new NpgsqlConnection();
                conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                conn.Open();

                NpgsqlCommand command = new NpgsqlCommand("SELECT nombre, apellido1,apellido2 from proveedores where cedula_juridica='" + id_proveedor_actual + "';", conn);

                NpgsqlDataReader dr = command.ExecuteReader();
                string n;
                while (dr.Read())
                {                    
                    n = dr[0].ToString() + " " + dr[1].ToString() + " " + dr[2].ToString();
                    txtNombre.Text = n;
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

        private void cbProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                id_proveedor_actual = proveedores[cbProveedores.SelectedIndex];
            }
            catch (Exception ex) { }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length == 0 | txtTel.Text.Length == 0 )
            {
                lblError.Visible = true;
            }
            else // si todo esta bien procede a insertar el cliente
            {
                char[] nombre = txtNombre.Text.ToCharArray(), telefono = txtTel.Text.ToCharArray();

                try
                {
                    NpgsqlConnection conn = new NpgsqlConnection();
                    conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                    conn.Open();

                    NpgsqlCommand command = new NpgsqlCommand("insertar_telefonos_proveedores", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    // creacion de variables que se enviaran por parametro en la consulta

                    NpgsqlParameter ced = new NpgsqlParameter("@cedula_juridica", NpgsqlDbType.Char,12);
                    ced.Value = id_proveedor_actual.ToCharArray();
                    command.Parameters.Add(ced);

                    NpgsqlParameter tel = new NpgsqlParameter("@telefono_proveedor", NpgsqlDbType.Char, 9);
                    tel.Value = telefono;
                    command.Parameters.Add(tel);

                   
                    command.ExecuteReader();

                    lblError.Text = "Listo! el telefono agregado para el proveedor";
                    lblError.ForeColor = Color.Green;
                    lblError.Visible = true;

                    txtTel.Clear();
                    txtNombre.Clear();
                    cbProveedores.SelectedIndex = -1;

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
