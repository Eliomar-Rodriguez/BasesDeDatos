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
    public partial class verContador : Form
    {

        public static List<string> distritos = new List<string>();
        public static string id_distrito_actual;
        public verContador()
        {
            InitializeComponent();
        }

        private void verContador_Load(object sender, EventArgs e)
        {
            cargarDistritos();
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

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void cbDistritos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                id_distrito_actual = distritos[cbDistritos.SelectedIndex];
            }
            catch (Exception ex) { }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            // si hay espacios vacios

            if (txtTel.Text.Length != 9 & cbDistritos.SelectedIndex == -1 & cbValoracion.SelectedIndex == -1 & txtDirExacta.Text.Length == 0 & !rbContratado.Checked & !rbNoContratado.Checked & txtNombre.Text.Length == 0 & txtApell1.Text.Length == 0 & txtApell2.Text.Length == 0 & !radioH.Checked & !radioM.Checked & dtpFechaContrato.Value == null)
            {
                lblError.Visible = true;
                lblError.ForeColor = Color.Red;
            }
            else // si todo esta bien procede a insertar el cliente
            {
                char[] nombre = txtNombre.Text.ToCharArray(), apellido1 = txtApell1.Text.ToCharArray(), apellido2 = txtApell2.Text.ToCharArray(), telefono = txtTel.Text.ToCharArray();
                bool genero = true, estado = true;

                if (radioM.Checked)
                    genero = false;
                else if (radioH.Checked)
                    genero = true;
                if (rbContratado.Checked)
                    estado = true;
                else if (rbNoContratado.Checked)
                    estado = false;

                int idDistrito = -1;
                try
                {
                    idDistrito = int.Parse(id_distrito_actual);
                }
                catch (Exception ex) { }

                int valoracion = -1;

                try
                {
                    int.Parse(cbValoracion.SelectedItem.ToString());
                }
                catch (Exception ex) { }

                string dirExacta = txtDirExacta.Text;
                DateTime fechaContrato = dtpFechaContrato.Value;
                

                try
                {
                    NpgsqlConnection conn = new NpgsqlConnection();
                    conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                    conn.Open();

                    NpgsqlCommand command = new NpgsqlCommand("seleccionar_contadores", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    // creacion de variables que se enviaran por parametro en la consulta
                    NpgsqlParameter tel = new NpgsqlParameter("@telefono", NpgsqlDbType.Char, 9);
                    if (telefono.Length == 5)
                        tel.Value = DBNull.Value;
                    else
                        tel.Value = telefono;
                    command.Parameters.Add(tel);

                    NpgsqlParameter idE = new NpgsqlParameter("@id_empresa", NpgsqlDbType.Integer);
                    idE.Value = 1;
                    command.Parameters.Add(idE);

                    NpgsqlParameter idD = new NpgsqlParameter("@id_distrito", NpgsqlDbType.Integer);
                    if (idDistrito == -1)
                        idD.Value = DBNull.Value;
                    else
                        idD.Value = idDistrito;
                    command.Parameters.Add(idD);

                    NpgsqlParameter val = new NpgsqlParameter("@valoracion", NpgsqlDbType.Integer);
                    if (valoracion == -1)
                        val.Value = DBNull.Value;
                    else
                        val.Value = valoracion;
                    command.Parameters.Add(val);

                    NpgsqlParameter dir = new NpgsqlParameter("@dir_exacta", NpgsqlDbType.Varchar, 250);
                    if (dirExacta.Length == 0)
                        dir.Value = DBNull.Value;
                    else
                        dir.Value = dirExacta;
                    command.Parameters.Add(dir);

                    NpgsqlParameter es = new NpgsqlParameter("@estado", NpgsqlDbType.Boolean);
                    if (!rbContratado.Checked & !rbNoContratado.Checked)
                        es.Value = DBNull.Value;
                    else
                        es.Value = estado;
                    command.Parameters.Add(es);

                    NpgsqlParameter gen = new NpgsqlParameter("@genero", NpgsqlDbType.Boolean);
                    if (!radioH.Checked & !radioM.Checked)
                        gen.Value = DBNull.Value;
                    else
                        gen.Value = genero;
                    command.Parameters.Add(gen);

                    NpgsqlParameter name = new NpgsqlParameter("@nombre", NpgsqlDbType.Varchar, 50);
                    if (nombre.Length == 0)
                        name.Value = DBNull.Value;
                    else
                        name.Value = nombre;
                    command.Parameters.Add(name);

                    NpgsqlParameter apell1 = new NpgsqlParameter("@apellido1", NpgsqlDbType.Varchar, 50);
                    if (apellido1.Length == 0)
                        apell1.Value = DBNull.Value;
                    else
                        apell1.Value = apellido1;
                    command.Parameters.Add(apell1);

                    NpgsqlParameter apell2 = new NpgsqlParameter("@apellido2", NpgsqlDbType.Varchar, 50);
                    if (apellido2.Length == 0)
                        apell2.Value = DBNull.Value;
                    else
                        apell2.Value = apellido2;
                    command.Parameters.Add(apell2);

                    NpgsqlParameter fe = new NpgsqlParameter("@fecha_contrato", NpgsqlDbType.Date);
                    if (fechaContrato.ToShortDateString() == DateTime.Now.ToShortDateString())
                        fe.Value = DBNull.Value;
                    else
                        fe.Value = fechaContrato;
                    command.Parameters.Add(fe);



                    //limpiamos los renglones de la datagridview
                    vista.Rows.Clear();
                    //a la variable DataReader asignamos  el la variable de tipo SqlCommand
                    NpgsqlDataReader dr = command.ExecuteReader();

                    string generoT = "";
                    string estadoT = "";
                    //el ciclo while se ejecutará mientras lea registros en la tabla
                    while (dr.Read())
                    { 
                        if (bool.Parse(dr[5].ToString()))
                            estadoT = "Contratado";
                        else
                            estadoT = "Despedido";
                            
                        if (bool.Parse(dr[6].ToString()))
                            generoT = "Masculino";
                        else
                            generoT = "Femenino";  

                        vista.Rows.Add(dr[0].ToString(), getDistrito(int.Parse( dr[2].ToString())), dr[3].ToString(),dr[4].ToString(), estadoT, generoT, dr[7].ToString(),dr[8].ToString(), dr[9].ToString(), dr[10].ToString());

                        /*https://blogs.msmvps.com/peplluis/2009/02/10/establecer-una-vista-maestro-detalle-entre-dos-tablas/ */
                    }
                    //cierra la conexión
                    conn.Close();

                    txtTel.Clear();
                    txtNombre.Clear();
                    txtApell1.Clear();
                    txtApell2.Clear();
                    radioH.Checked = false;
                    radioM.Checked = false;
                    cbDistritos.SelectedIndex = -1;
                    cbValoracion.SelectedIndex = -1;
                    txtDirExacta.Clear();
                    rbContratado.Checked = false;
                    rbNoContratado.Checked = false;
                    dtpFechaContrato.Value = DateTime.Now;
                    
                }
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    // lblError.Text = "Ningun contador coincide con lo ingresado";
                    lblError.Text = ex.ToString();
                }
            }
        }
    }
}
