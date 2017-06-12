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
    public partial class insertProductoRifa : Form
    {
        public static List<string> productos = new List<string>();
        public static List<string> rifas = new List<string>();
        public static string id_producto_actual;
        public static string id_rifa_actual;
        public insertProductoRifa()
        {
            InitializeComponent();
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

        private void cargarProductos()
        {
            cbProductos.Items.Clear();
            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT codigo_producto,nombre from productos;", conn);

            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                productos.Add(dr[0].ToString());
                cbProductos.Items.AddRange(new object[] { dr[1].ToString() });
            }
            conn.Close();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {// insertando todos los proveedores en el combo box
                NpgsqlConnection conn = new NpgsqlConnection();
                conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                conn.Open();

                NpgsqlCommand command = new NpgsqlCommand("SELECT nombre,precio_unitario from productos where codigo_producto='" + id_producto_actual + "';", conn);

                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    txtNombre.Text = dr[0].ToString();
                    txtPrecio.Text = dr[1].ToString();
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

        private void insertProductoRifa_Load(object sender, EventArgs e)
        {
            cargarProductos();
            cargarRifas();
        }

        private void cbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                id_producto_actual = productos[cbProductos.SelectedIndex];
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length == 0 | txtPrecio.Text.Length == 0 | dtpFecha.Value == null | txtDescripcion.Text.Length == 0)
            {
                lblError.Visible = true;
            }
            else // si todo esta bien procede a insertar el cliente
            {
                DateTime fecha = dtpFecha.Value;
                string descripcion = txtDescripcion.Text;
                char[] nombre = txtNombre.Text.ToCharArray();
                int precio = int.Parse(txtPrecio.Text);

                try
                {
                    NpgsqlConnection conn = new NpgsqlConnection();
                    conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                    conn.Open();

                    NpgsqlCommand command = new NpgsqlCommand("insertar_productos_rifas", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    // creacion de variables que se enviaran por parametro en la consulta
                    NpgsqlParameter idR = new NpgsqlParameter("@id_rifa", NpgsqlDbType.Integer);
                    idR.Value = id_rifa_actual;
                    command.Parameters.Add(idR);

                    NpgsqlParameter cp = new NpgsqlParameter("@codigo_producto", NpgsqlDbType.Integer);
                    cp.Value = int.Parse(id_producto_actual);
                    command.Parameters.Add(cp);

                    command.ExecuteReader();

                    lblError.Text = "Listo! el prodcto se ha agregado a la rifa";
                    lblError.ForeColor = Color.Green;
                    lblError.Visible = true;

                    txtPrecio.Clear();
                    txtNombre.Clear();
                    dtpFecha.Value = DateTime.Now;
                    txtDescripcion.Clear();
                    cbRifas.SelectedIndex = -1;
                    cbProductos.SelectedIndex = -1;

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
