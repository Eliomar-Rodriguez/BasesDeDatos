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

namespace Conexionpruebabases.Vistas.Empleados
{
    public partial class borrarEmpleado : Form
    {
        public static List<string> distritos = new List<string>();
        public static string id_distrito_actual;
        public static List<string> empleados = new List<string>();
        public static string id_empleado_actual;
        public borrarEmpleado()
        {
            InitializeComponent();
        }

        private void borrarEmpleado_Load(object sender, EventArgs e)
        {
            cargarDistritos();
            cargarEmpleados();
        }

        private void cargarDistritos()
        {
            cbDistritos.Items.Clear();
            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * from distritos", conn);

            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                distritos.Add(dr[0].ToString());
                cbDistritos.Items.AddRange(new object[] { dr[2].ToString() });
            }
            conn.Close();
        }

        private void cargarEmpleados()
        {
            cbEmpleados.Items.Clear();
            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT telefono,nombre,apellido1,apellido2 from empleados", conn);

            NpgsqlDataReader dr = command.ExecuteReader();
            string n = "";

            while (dr.Read())
            {
                empleados.Add(dr[0].ToString());
                n = dr[1].ToString() + " " + dr[2].ToString() + " " + dr[3].ToString();
                cbEmpleados.Items.AddRange(new object[] { n });
            }
            conn.Close();
        }

        private void cbDistritos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                id_distrito_actual = distritos[cbDistritos.SelectedIndex];
            }
            catch (Exception ex) { }
        }

        private void cbEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                id_empleado_actual = empleados[cbEmpleados.SelectedIndex];
                MessageBox.Show(id_distrito_actual);
            }
            catch (Exception ex) { }
        }

        private string getDistrito(int id)
        {
            string n = "";
            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT id_distrito,nombre_distrito from distritos;", conn);

            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                if (int.Parse(dr[0].ToString()) == id)
                    n = dr[1].ToString();
            }
            conn.Close();
            return n;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {// insertando todos los proveedores en el combo box
                NpgsqlConnection conn = new NpgsqlConnection();
                conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                conn.Open();

                NpgsqlCommand command = new NpgsqlCommand("SELECT * from empleados where telefono='" + id_empleado_actual + "';", conn);

                NpgsqlDataReader dr = command.ExecuteReader();
                bool genero;
                while (dr.Read())
                {
                    txtTelefono.Text = dr[0].ToString();
                    txtCedula.Text = dr[1].ToString();
                    cbDistritos.Text = getDistrito(int.Parse(dr[2].ToString()));
                    txtDirExacta.Text = dr[3].ToString();
                    dtpFechaNacimiento.Value = DateTime.Parse(dr[4].ToString());
                    genero = bool.Parse(dr[5].ToString());
                    if (genero) // true hombre{
                    {
                        radioH.Checked = true;
                        radioM.Checked = false;
                    }
                    else if (!genero)
                    {
                        radioM.Checked = true;
                        radioH.Checked = false;
                    }
                    txtNombre.Text = dr[6].ToString();
                    txtApellido1.Text = dr[7].ToString();
                    txtApellido2.Text = dr[8].ToString();
                    
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
            if (cbEmpleados.SelectedIndex == -1)
            {
                lblError.ForeColor = Color.Red;
                lblError.Visible = true;
            }
            else // si todo esta bien procede a insertar el cliente
            {
                char[] telefono = txtTelefono.Text.ToCharArray();
                try
                {
                    NpgsqlConnection conn = new NpgsqlConnection();
                    conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                    conn.Open();

                    NpgsqlCommand command = new NpgsqlCommand("borrar_empleado", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    NpgsqlParameter tel = new NpgsqlParameter("@telefono", NpgsqlDbType.Char,11);
                    tel.Value = telefono;
                    command.Parameters.Add(tel);

                    command.ExecuteReader();

                    lblError.Text = "Listo! el empleado ha sido eliminado";
                    lblError.ForeColor = Color.Green;
                    lblError.Visible = true;

                    txtTelefono.Clear();
                    txtCedula.Clear();
                    txtNombre.Clear();
                    txtApellido1.Clear();
                    txtApellido2.Clear();
                    txtDirExacta.Clear();
                    cbDistritos.SelectedIndex = -1;
                    radioH.Checked = false;
                    radioM.Checked = false;
                    dtpFechaNacimiento.Value = DateTime.Now;
                    cbEmpleados.SelectedIndex = -1;
                    cargarEmpleados();

                    conn.Close();
                }
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = ex.ToString(); ;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
