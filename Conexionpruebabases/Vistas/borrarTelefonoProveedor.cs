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
    public partial class borrarTelefonoProveedor : Form
    {
        public static List<string> proveedores = new List<string>();
        public static string cedula_juridica_actual;
        public static List<string> telefonos = new List<string>();
        public static string telefono_actual;
        public borrarTelefonoProveedor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void cargarTelefonos()
        {
            cbTelefonos.Items.Clear();
            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT telefono from telefonos_proveedores where cedula_juridica = '"+cedula_juridica_actual+"';", conn);
          
            NpgsqlDataReader dr = command.ExecuteReader();
            
            while (dr.Read())
            {
                telefonos.Add(dr[0].ToString());
                cbTelefonos.Items.AddRange(new object[] { dr[0].ToString() });
            }
            conn.Close();
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

        private void cbProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cedula_juridica_actual = proveedores[cbProveedores.SelectedIndex];
                cargarTelefonos();
            }
            catch (Exception ex) { }
        }

        private void cbTelefonos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                telefono_actual = telefonos[cbTelefonos.SelectedIndex];
            }
            catch (Exception ex) { }
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {// insertando todos los proveedores en el combo box
                NpgsqlConnection conn = new NpgsqlConnection();
                conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                conn.Open();

                NpgsqlCommand command = new NpgsqlCommand("SELECT nombre, apellido1,apellido2 from proveedores where cedula_juridica='" + cedula_juridica_actual + "';", conn);

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
                /////////////////////////////////////////////////////////

                txtTel.Text = telefono_actual;

            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.ToString();
            }
        }

        private void borrarTelefonoProveedor_Load(object sender, EventArgs e)
        {
            cargarProveedores();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length == 0 | txtTel.Text.Length == 0)
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

                    NpgsqlCommand command = new NpgsqlCommand("eliminar_telefonos_proveedores", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    // creacion de variables que se enviaran por parametro en la consulta

                    NpgsqlParameter ced = new NpgsqlParameter("@cedula_juridica", NpgsqlDbType.Char, 12);
                    ced.Value = cedula_juridica_actual.ToCharArray();
                    command.Parameters.Add(ced);

                    NpgsqlParameter tel = new NpgsqlParameter("@telefono_proveedor", NpgsqlDbType.Char, 9);
                    tel.Value = telefono;
                    command.Parameters.Add(tel);


                    command.ExecuteReader();

                    lblError.Text = "Listo! el telefono se ha eliminado";
                    lblError.ForeColor = Color.Green;
                    lblError.Visible = true;

                    txtTel.Clear();
                    txtNombre.Clear();
                    cbProveedores.SelectedIndex = -1;
                    cbTelefonos.SelectedIndex = -1;
                    
                    conn.Close();
                }
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = ex.ToString();
                }
               cargarProveedores();
            }
        }
    }
}
