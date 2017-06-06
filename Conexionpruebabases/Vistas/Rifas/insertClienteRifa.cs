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
    public partial class insertClienteRifa : Form
    {
        public static List<string> clientes = new List<string>();
        public static List<string> rifas = new List<string>();
        public static string telefono_cliente_actual;
        public static string id_rifa_actual;
        public insertClienteRifa()
        {
            InitializeComponent();
        }

        private void insertClienteRifa_Load(object sender, EventArgs e)
        {
            cargarClientes();
            cargarRifas();
        }

        private void cargarClientes()
        {
            cbClientes.Items.Clear();
            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT telefono,nombre, apellido1,apellido2 from clientes;", conn);

            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                string n = dr[1].ToString() + " " + dr[2].ToString() + " " + dr[3].ToString();
                clientes.Add(dr[0].ToString());
                cbClientes.Items.AddRange(new object[] { n });
            }
            conn.Close();
        }

        private void cargarRifas()
        {
            cbRifas.Items.Clear();
            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT id_rifa,fecha from rifas;", conn);

            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                rifas.Add(dr[0].ToString());
                cbRifas.Items.AddRange(new object[] { dr[1].ToString() });
            }
            conn.Close();
        }

        private void cbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                telefono_cliente_actual = clientes[cbClientes.SelectedIndex];
            }
            catch (Exception ex) { }
        }

        private void cbRifas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                id_rifa_actual = rifas[cbRifas.SelectedIndex];
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

                NpgsqlCommand command = new NpgsqlCommand("SELECT telefono,nombre from clientes where telefono='" + telefono_cliente_actual + "';", conn);

                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    txtTel.Text = dr[0].ToString();
                    txtNombre.Text = dr[1].ToString();
                }
                if (dr.FieldCount == 0)
                {
                    lblError.Visible = true;
                }
                conn.Close();

                NpgsqlConnection conn2 = new NpgsqlConnection();
                conn2.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                conn2.Open();

                NpgsqlCommand command2 = new NpgsqlCommand("SELECT fecha,descripcion from rifas where id_rifa='" + id_rifa_actual + "';", conn2);

                NpgsqlDataReader dr2 = command2.ExecuteReader();
                while (dr2.Read())
                {
                    dtpFecha.Value = DateTime.Parse(dr2[0].ToString());
                    txtDescripcion.Text = dr2[1].ToString();
                }
                if (dr2.FieldCount == 0)
                {
                    lblError.Visible = true;
                }
                conn2.Close();
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.ToString();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length == 0 | txtTel.Text.Length == 0 | dtpFecha.Value == null | txtDescripcion.Text.Length == 0)
            {
                lblError.Visible = true;
            }
            else // si todo esta bien procede a insertar el cliente
            {
                DateTime fecha = dtpFecha.Value;
                string descripcion = txtDescripcion.Text;
                char[] nombre = txtNombre.Text.ToCharArray(), telefono = txtTel.Text.ToCharArray();

                try
                {
                    NpgsqlConnection conn = new NpgsqlConnection();
                    conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                    conn.Open();

                    NpgsqlCommand command = new NpgsqlCommand("insertar_cliente_rifas", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    // creacion de variables que se enviaran por parametro en la consulta
                    NpgsqlParameter tel = new NpgsqlParameter("@telefono_cliente", NpgsqlDbType.Char, 9);
                    tel.Value = telefono;
                    command.Parameters.Add(tel);

                    NpgsqlParameter idR = new NpgsqlParameter("@id_rifa", NpgsqlDbType.Integer);
                    idR.Value = id_rifa_actual;
                    command.Parameters.Add(idR);

                    NpgsqlParameter gan = new NpgsqlParameter("@ganador", NpgsqlDbType.Boolean);
                    gan.Value = false;
                    command.Parameters.Add(gan);


                    command.ExecuteReader();

                    lblError.Text = "Listo! el Cliente agregado a la rifa";
                    lblError.ForeColor = Color.Green;
                    lblError.Visible = true;

                    txtTel.Clear();
                    txtNombre.Clear();
                    dtpFecha.Value = DateTime.Now;
                    txtDescripcion.Clear();


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
