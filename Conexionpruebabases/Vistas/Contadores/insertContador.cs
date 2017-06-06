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

namespace Conexionpruebabases.Vistas.Contadores
{
    public partial class insertContador : Form
    {

        public static List<string> distritos = new List<string>();
        public insertContador()
        {
            InitializeComponent();
        }

        private void insertContador_Load(object sender, EventArgs e)
        {
            cargarDistritos();
        }

        private void cargarDistritos()
        {
            cbDistritos.Items.Clear();
            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT id_distrito,nombre_distrito from distritos;", conn);

            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                distritos.Add(dr[0].ToString());
                cbDistritos.Items.AddRange(new object[] { dr[1].ToString() });
            }
            conn.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length == 0 | txtApell1.Text.Length == 0 | txtApell2.Text.Length == 0 | txtTel.Text.Length == 0 | cbDistritos.SelectedIndex == -1 | dtpFecha.Value == null | (!(rbContratado.Checked) && !(rbNoContratado.Checked)) | (!(radioM.Checked) && !(radioH.Checked)) | txtDirExacta.Text.Length == 0)
            {
                lblError.Visible = true;
            }
            else // si todo esta bien procede a insertar el cliente
            {
                DateTime fecha = dtpFecha.Value;
                string dirExacta = txtDirExacta.Text;
                char[] nombre = txtNombre.Text.ToCharArray(), apellido1 = txtApell1.Text.ToCharArray(), apellido2 = txtApell2.Text.ToCharArray(), telefono = txtTel.Text.ToCharArray();
                bool genero = true;
                bool estado = true;
                int distrito = int.Parse(distritos[cbDistritos.SelectedIndex]);
                if (radioH.Checked)
                    genero = true;
                else if (radioM.Checked)
                    genero = false;
                if (rbContratado.Checked)
                    estado = true;
                else if (rbNoContratado.Checked)
                    estado = false;

                try
                {
                    NpgsqlConnection conn = new NpgsqlConnection();
                    conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                    conn.Open();

                    NpgsqlCommand command = new NpgsqlCommand("insertar_contadores", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    // creacion de variables que se enviaran por parametro en la consulta
                    NpgsqlParameter tel = new NpgsqlParameter("@telefono", NpgsqlDbType.Char, 9);
                    tel.Value = telefono;
                    command.Parameters.Add(tel);

                    NpgsqlParameter idE = new NpgsqlParameter("@id_empresa", NpgsqlDbType.Integer);
                    idE.Value = 1;
                    command.Parameters.Add(idE);

                    NpgsqlParameter dis = new NpgsqlParameter("@id_distrito", NpgsqlDbType.Integer);
                    dis.Value = distrito;
                    command.Parameters.Add(dis);

                    NpgsqlParameter dir = new NpgsqlParameter("@dir_exacta", NpgsqlDbType.Varchar, 250);
                    dir.Value = dirExacta;
                    command.Parameters.Add(dir);

                    NpgsqlParameter est = new NpgsqlParameter("@estado", NpgsqlDbType.Boolean);
                    est.Value = estado;
                    command.Parameters.Add(est);

                    NpgsqlParameter gen = new NpgsqlParameter("@genero", NpgsqlDbType.Boolean);
                    gen.Value = genero;
                    command.Parameters.Add(gen);

                    NpgsqlParameter nom = new NpgsqlParameter("@nombre", NpgsqlDbType.Varchar, 50);
                    nom.Value = nombre;
                    command.Parameters.Add(nom);

                    NpgsqlParameter apell1 = new NpgsqlParameter("@apellido1", NpgsqlDbType.Varchar, 50);
                    apell1.Value = apellido1;
                    command.Parameters.Add(apell1);

                    NpgsqlParameter apell2 = new NpgsqlParameter("@apellido2", NpgsqlDbType.Varchar, 50);
                    apell2.Value = apellido2;
                    command.Parameters.Add(apell2);

                    NpgsqlParameter fe = new NpgsqlParameter("@fecha", NpgsqlDbType.Date);
                    fe.Value = fecha;
                    command.Parameters.Add(fe);


                    command.ExecuteReader();

                    lblError.Text = "Listo! el Contador ha sido insertado";
                    lblError.ForeColor = Color.Green;
                    lblError.Visible = true;

                    txtTel.Clear();
                    txtNombre.Clear();
                    txtDirExacta.Clear();
                    txtApell2.Clear();
                    txtApell1.Clear();
                    dtpFecha.Value = DateTime.Now;
                    rbContratado.Checked = false;
                    rbNoContratado.Checked = false;
                    radioH.Checked = false;
                    radioM.Checked = false;
                    cbDistritos.SelectedIndex = -1;

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
