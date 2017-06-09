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
            // si hay espacios vacios
            if (txtTel.Text.Length != 9 & txtNombre.Text.Length == 0 & txtApell1.Text.Length == 0 & txtApell2.Text.Length == 0 & !radioH.Checked & !radioM.Checked)
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
                    if(telefono.Length == 5)
                        tel.Value = DBNull.Value;
                    else
                        tel.Value = telefono;
                    command.Parameters.Add(tel);
                    
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

                    NpgsqlParameter gen = new NpgsqlParameter("@genero", NpgsqlDbType.Boolean);
                    if(!radioH.Checked & !radioM.Checked)
                        gen.Value = DBNull.Value;
                    else
                        gen.Value = genero;
                    command.Parameters.Add(gen);
                    
                    //limpiamos los renglones de la datagridview
                    vista.Rows.Clear();
                    //a la variable DataReader asignamos  el la variable de tipo SqlCommand
                    NpgsqlDataReader dr = command.ExecuteReader();

                    bool gene = false;

                    //el ciclo while se ejecutará mientras lea registros en la tabla
                    while (dr.Read())
                    {
                        genero = bool.Parse(dr[4].ToString());
                        vista.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),dr[4].ToString());
                       
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
