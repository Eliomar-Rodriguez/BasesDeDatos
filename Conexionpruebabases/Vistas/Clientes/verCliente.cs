using System;
using Npgsql;
using NpgsqlTypes;
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
    public partial class verCliente : Form
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;");
        public verCliente()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //conn.Open();
            /*bool genero = false;
            char[] telefono = txtTel.Text.ToCharArray(), nombre = txtNombre.Text.ToCharArray(), apellido1 = txtApell1.Text.ToCharArray(), apellido2 = txtApell2.Text.ToCharArray();
            if (radioH.Checked)
                genero = true;
            else if (radioM.Checked)
                genero = false;*/
            // nombre, telefono, apellido1, apellido2, genero

            // si hay espacios vacios
            if (txtTel.Text.Length != 9 | txtNombre.Text.Length == 0 | txtApell1.Text.Length == 0 | txtApell2.Text.Length == 0 | (!radioH.Checked & !radioM.Checked))
            {
                lblError.Visible = true;
            }
            else // si todo esta bien procede a insertar el cliente
            {
                char[] nombre = txtNombre.Text.ToCharArray(), apellido1 = txtApell1.Text.ToCharArray(), apellido2 = txtApell2.Text.ToCharArray(), telefono = txtTel.Text.ToCharArray();
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

                    NpgsqlCommand command = new NpgsqlCommand("select_clientes", conn);
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
                    
                    //limpiamos los renglones de la datagridview
                    vista.Rows.Clear();
                    //a la variable DataReader asignamos  el la variable de tipo SqlCommand
                    NpgsqlDataReader dr = command.ExecuteReader();
                    //el ciclo while se ejecutará mientras lea registros en la tabla
                    while (dr.Read())
                    {
                        bool gene = false;
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

                    conn.Close();
                }
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = "Ningun cliente coincide con lo ingresado";
                }
            }






            /*NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            vista.DataSource = dt;

            conn.Close();*/
        }
    }
}
