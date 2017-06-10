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
    public partial class insertEmpleado : Form
    {
        public static List<string> distritos = new List<string>();
        public static string id_distrito_actual;
        public insertEmpleado()
        {
            InitializeComponent();
        }

        private void insertEmpleado_Load(object sender, EventArgs e)
        {
            cargarDistritos();
        }

        private void cbDistritos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                id_distrito_actual = distritos[cbDistritos.SelectedIndex];
            }
            catch (Exception ex) { }
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
                string telefono = txtTelefono.Text, cedula = txtCedula.Text, dirExacta = txtDirExacta.Text;
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

                    NpgsqlCommand command = new NpgsqlCommand("insertar_empleado", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    // creacion de variables que se enviaran por parametro en la consulta
                    NpgsqlParameter tel = new NpgsqlParameter("@telefono", NpgsqlDbType.Char, 9);
                    tel.Value = telefono;
                    command.Parameters.Add(tel);

                    NpgsqlParameter ced = new NpgsqlParameter("@cedula", NpgsqlDbType.Char, 11);
                    ced.Value = cedula;
                    command.Parameters.Add(ced);

                    NpgsqlParameter idD = new NpgsqlParameter("@id_distrito", NpgsqlDbType.Integer);
                    idD.Value = idDistrito;
                    command.Parameters.Add(idD);

                    NpgsqlParameter dir = new NpgsqlParameter("@dir_exacta", NpgsqlDbType.Varchar,250);
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

                    lblError.Text = "Listo! el empleado ha sido agregado";
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

                    conn.Close();
                }
                catch (Exception ex)
                {
                    lblError.Visible = true;
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
