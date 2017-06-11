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
    public partial class editEmpleado : Form
    {
        public static List<string> distritos = new List<string>();
        public static string id_distrito_actual;
        public static List<string> empleados = new List<string>();
        public static string id_empleado_actual;
        public editEmpleado()
        {
            InitializeComponent();
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

        private void editEmpleado_Load(object sender, EventArgs e)
        {
            cargarDistritos();
            cargarEmpleados();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // si hay espacios vacios
            if (txtTelefono.Text.Length != 9 | txtCedula.Text.Length != 11 | dtpFechaNacimiento.Value == null | txtNombre.Text.Length == 0 | txtApellido1.Text.Length == 0 | txtApellido2.Text.Length == 0 | (!radioH.Checked & !radioM.Checked) | cbDistritos.SelectedIndex == -1 | txtDirExacta.Text.Length == 0)
            {
                lblError.Visible = true;
                lblError.ForeColor = Color.Red;
            }
            else // si todo esta bien procede a insertar el cliente
            {
                string nuevoTelefono = txtTelefono.Text, cedula = txtCedula.Text, dirExacta = txtDirExacta.Text, telefono = id_empleado_actual;
                char[] nombre = txtNombre.Text.ToCharArray(), apellido1 = txtApellido1.Text.ToCharArray(), apellido2 = txtApellido2.Text.ToCharArray();
                DateTime fechaNacimiento = dtpFechaNacimiento.Value;
                int idDistrito = int.Parse(id_distrito_actual);
                bool genero = true;

                if (radioM.Checked)
                    genero = false;
                else if (radioH.Checked)
                    genero = true;

                try
                {
                    NpgsqlConnection conn = new NpgsqlConnection();
                    conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                    conn.Open();

                    NpgsqlCommand command = new NpgsqlCommand("modificar_empleado", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    // creacion de variables que se enviaran por parametro en la consulta
                    NpgsqlParameter tel = new NpgsqlParameter("@telefono", NpgsqlDbType.Char, 9);
                    tel.Value = telefono;
                    command.Parameters.Add(tel);

                    NpgsqlParameter nTel = new NpgsqlParameter("@telefono", NpgsqlDbType.Char, 9);
                    nTel.Value = nuevoTelefono;
                    command.Parameters.Add(nTel);

                    NpgsqlParameter ced = new NpgsqlParameter("@cedula", NpgsqlDbType.Char, 11);
                    ced.Value = cedula;
                    command.Parameters.Add(ced);

                    NpgsqlParameter idD = new NpgsqlParameter("@id_distrito", NpgsqlDbType.Integer);
                    idD.Value = idDistrito;
                    command.Parameters.Add(idD);

                    NpgsqlParameter dir = new NpgsqlParameter("@dir_exacta", NpgsqlDbType.Varchar, 250);
                    dir.Value = dirExacta;
                    command.Parameters.Add(dir);

                    NpgsqlParameter fe = new NpgsqlParameter("@fecha_nacimiento", NpgsqlDbType.Date);
                    fe.Value = fechaNacimiento;
                    command.Parameters.Add(fe);

                    NpgsqlParameter ge = new NpgsqlParameter("@genero", NpgsqlDbType.Boolean);
                    ge.Value = genero;
                    command.Parameters.Add(ge);

                    NpgsqlParameter name = new NpgsqlParameter("@nombre", NpgsqlDbType.Varchar, 50);
                    name.Value = nombre;
                    command.Parameters.Add(name);

                    NpgsqlParameter apell1 = new NpgsqlParameter("@apellido1", NpgsqlDbType.Varchar, 50);
                    apell1.Value = apellido1;
                    command.Parameters.Add(apell1);

                    NpgsqlParameter apell2 = new NpgsqlParameter("@apellido2", NpgsqlDbType.Varchar, 50);
                    apell2.Value = apellido2;
                    command.Parameters.Add(apell2);
                                        
                    command.ExecuteReader();

                    lblError.Text = "Listo! el empleado ha sido actualizado";
                    lblError.ForeColor = Color.Green;
                    lblError.Visible = true;

                    txtTelefono.Clear();
                    txtCedula.Clear();
                    txtNombre.Clear();
                    txtApellido1.Clear();
                    txtApellido2.Clear();
                    txtDirExacta.Clear();
                    cbDistritos.SelectedIndex = -1;
                    cbEmpleados.SelectedIndex = -1;
                    radioH.Checked = false;
                    radioM.Checked = false;
                    dtpFechaNacimiento.Value = DateTime.Now;

                    conn.Close();
                    cargarEmpleados();
                }
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = ex.ToString();
                }
            }
        }
    }
}
