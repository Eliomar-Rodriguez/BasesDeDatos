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
    public partial class verCanton : Form
    {

        public static List<string> provincias = new List<string>();
        public static string id_provincia_actual = "";
        public verCanton()
        {
            InitializeComponent();
        }

        private void cbProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                id_provincia_actual = provincias[cbProvincias.SelectedIndex];
            }
            catch (Exception ex) { }
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

        private void verCanton_Load(object sender, EventArgs e)
        {
            cargarProvincias();
        }

        private string getProvincia(int id)
        {
            string n = "";
            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT id_provincia,nombre_provincia from provincias;", conn);

            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                if (int.Parse(dr[0].ToString()) == id)
                    n = dr[1].ToString();
            }
            conn.Close();
            return n;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            // si hay espacios vacios

            if (txtId.Text.Length == 0 & txtNombre.Text.Length == 0 & cbProvincias.SelectedIndex == -1)
            {
                lblError.Visible = true;
                lblError.ForeColor = Color.Red;
            }
            int n;
            if ((txtId.Text.Length != 0) && (!int.TryParse(txtId.Text, out n)))
            {
                lblError.Visible = true;
                lblError.Text = "Id no numérico";
                lblError.ForeColor = Color.Red;
            }
            else // si todo esta bien procede a insertar el cliente
            {
                char[] nombre = txtNombre.Text.ToCharArray();
                int idCanton = -1;
                try
                {
                    idCanton = int.Parse(txtId.Text);
                }
                catch (Exception ex) { }
                try
                {
                    NpgsqlConnection conn = new NpgsqlConnection();
                    conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                    conn.Open();

                    NpgsqlCommand command = new NpgsqlCommand("seleccionar_cantones", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    // creacion de variables que se enviaran por parametro en la consulta
                    NpgsqlParameter idC = new NpgsqlParameter("@id_Canton", NpgsqlDbType.Integer);
                    if (idCanton == -1)
                        idC.Value = DBNull.Value;
                    else
                        idC.Value = idCanton;
                    command.Parameters.Add(idC);

                    
                    NpgsqlParameter idP = new NpgsqlParameter("@id_provincia", NpgsqlDbType.Integer);
                    if (id_provincia_actual == "")
                        idP.Value = DBNull.Value;
                    else
                        idP.Value = int.Parse(id_provincia_actual);
                    command.Parameters.Add(idP);

                    NpgsqlParameter name = new NpgsqlParameter("@nombre", NpgsqlDbType.Varchar, 50);
                    if (nombre.Length == 0)
                        name.Value = DBNull.Value;
                    else
                        name.Value = nombre;
                    command.Parameters.Add(name);

                    //limpiamos los renglones de la datagridview
                    vista.Rows.Clear();
                    //a la variable DataReader asignamos  el la variable de tipo SqlCommand
                    NpgsqlDataReader dr = command.ExecuteReader();

                    //el ciclo while se ejecutará mientras lea registros en la tabla
                    while (dr.Read())
                    {
                        vista.Rows.Add(dr[0].ToString(),getProvincia(int.Parse(dr[1].ToString())),dr[2].ToString());
                    }
                    //cierra la conexión
                    conn.Close();

                    txtId.Clear();
                    txtNombre.Clear();
                    cbProvincias.SelectedIndex = -1;

                }
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    // lblError.Text = "Ningun contador coincide con lo ingresado";
                    lblError.Text = ex.ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
