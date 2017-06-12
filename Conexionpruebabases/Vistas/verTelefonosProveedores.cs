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
    public partial class verTelefonosProveedores : Form
    {
        public static List<string> proveedores = new List<string>();
        public static string cedula_juridica_Actual;
        public verTelefonosProveedores()
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
                n = dr[1].ToString() +" "+ dr[2].ToString()+" " + dr[3].ToString();
                cbProveedores.Items.AddRange(new object[] { n });
                n = "";
            }
            conn.Close();
        }

        private string getNombreProveedor()
        {
            string n = "";
            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT cedula_juridica,nombre,apellido1,apellido2 from proveedores where cedula_juridica = '"+cedula_juridica_Actual+"' ;", conn);

            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                n = dr[1].ToString() + " " + dr[2].ToString() + " " + dr[3].ToString();
            }
            conn.Close();
            return n;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if(cbProveedores.SelectedIndex == -1)
            {
                lblError.Visible = true;
                lblError.ForeColor = Color.Red;
            }
            else
            {
                char[] cedulaJuridica = cedula_juridica_Actual.ToCharArray();

                try
                {
                    NpgsqlConnection conn = new NpgsqlConnection();
                    conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                    conn.Open();

                    NpgsqlCommand command = new NpgsqlCommand("seleccionar_telefonos_proveedores", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    // creacion de variables que se enviaran por parametro en la consulta
                    NpgsqlParameter ced = new NpgsqlParameter("@cedula_juridica", NpgsqlDbType.Char, 12);
                    if (cedulaJuridica.Length == 0)
                        ced.Value = DBNull.Value;
                    else
                        ced.Value = cedulaJuridica;
                    command.Parameters.Add(ced);


                    //limpiamos los renglones de la datagridview
                    vista.Rows.Clear();
                    //a la variable DataReader asignamos  el la variable de tipo SqlCommand
                    NpgsqlDataReader dr = command.ExecuteReader();

                    //el ciclo while se ejecutará mientras lea registros en la tabla
                    while (dr.Read())
                    {
                        vista.Rows.Add(dr[1].ToString(), getNombreProveedor());

                    }
                    //cierra la conexión
                    conn.Close();

                    cbProveedores.SelectedIndex = -1;

                }
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = ex.ToString();
                }
            }          
        }

        private void verTelefonosProveedores_Load(object sender, EventArgs e)
        {
            cargarProveedores();
        }

        private void cbProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cedula_juridica_Actual = proveedores[cbProveedores.SelectedIndex];
            }
            catch (Exception ex) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
