using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conexionpruebabases.Vistas
{
    public partial class editCliente : Form
    {
        public editCliente()
        {
            InitializeComponent();
        }

        private void editCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // insertando todos los proveedores en el combo box
            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * from clientes where telefono='"+txtTel.Text+"';", conn);
            
            NpgsqlDataReader dr = command.ExecuteReader();
            bool genero;
            while (dr.Read())
            {
                txtTel.Text = dr[0].ToString();
                txtNombre.Text = dr[1].ToString();
                txtApell1.Text = dr[2].ToString();
                txtApell2.Text = dr[3].ToString();
                genero = bool.Parse(dr[4].ToString());
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
                    
            }
            conn.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // si hay espacios vacios
            if (txtTel.Text.Length != 9 | txtNombre.Text.Length == 0 | txtApell1.Text.Length == 0 | txtApell2.Text.Length == 0 | (!radioH.Checked & !radioM.Checked))
            {
                lblError.Visible = true;
            }
            else // si todo esta bien procede a insertar el cliente
            {
                string telefono = txtTel.Text;
                char[] nombre = txtNombre.Text.ToCharArray(), apellido1 = txtApell1.Text.ToCharArray(), apellido2 = txtApell2.Text.ToCharArray();
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

                    NpgsqlCommand command = new NpgsqlCommand("update_clientes", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    
                    // creacion de variables que se enviaran por parametro en la consulta
                    NpgsqlParameter tel = new NpgsqlParameter("@telefono", NpgsqlDbType.Char, 9);
                    tel.Value = telefono;
                    command.Parameters.Add(tel);

                    NpgsqlParameter name = new NpgsqlParameter("@nombre", NpgsqlDbType.Varchar, 50);
                    name.Value = nombre;
                    command.Parameters.Add(name);

                    NpgsqlParameter apell1 = new NpgsqlParameter("@apellido1", NpgsqlDbType.Varchar, 50);
                    apell1.Value = apellido1;
                    command.Parameters.Add(apell1);

                    NpgsqlParameter apell2 = new NpgsqlParameter("@apellido2", NpgsqlDbType.Varchar, 50);
                    apell2.Value = apellido2;
                    command.Parameters.Add(apell2);

                    NpgsqlParameter gen = new NpgsqlParameter("@genero", NpgsqlDbType.Boolean);
                    gen.Value = genero;
                    command.Parameters.Add(gen);
                                        
                    command.ExecuteReader();

                    
                    lblError.Visible = true;
                    lblError.Text = "Listo! el cliente ha sido modificado";
                    lblError.ForeColor = Color.Green;

                    txtTel.Clear();
                    txtNombre.Clear();
                    txtApell1.Clear();
                    txtApell2.Clear();
                    radioH.Checked = false;
                    radioM.Checked = false;
                        
                    conn.Close();
                }
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = ex.Message;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Principal().Show();
            this.Dispose();
        }
    }
}
