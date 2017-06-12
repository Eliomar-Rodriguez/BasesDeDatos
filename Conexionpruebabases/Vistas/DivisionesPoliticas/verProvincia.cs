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
    public partial class verProvincia : Form
    {
        public verProvincia()
        {
            InitializeComponent();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            // si hay espacios vacios
            
            if (txtId.Text.Length == 0 & txtNombre.Text.Length == 0)
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
                int id = -1;
                try
                {
                    id = int.Parse(txtId.Text);
                }
                catch (Exception ex) { }
                try
                {
                    NpgsqlConnection conn = new NpgsqlConnection();
                    conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                    conn.Open();

                    NpgsqlCommand command = new NpgsqlCommand("seleccionar_provincia", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    // creacion de variables que se enviaran por parametro en la consulta
                    NpgsqlParameter idP = new NpgsqlParameter("@id_provincia", NpgsqlDbType.Integer);
                    if (id == -1)
                        idP.Value = DBNull.Value;
                    else
                        idP.Value = id;
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

                        vista.Rows.Add(dr[0].ToString(), dr[1].ToString());

                        /*https://blogs.msmvps.com/peplluis/2009/02/10/establecer-una-vista-maestro-detalle-entre-dos-tablas/ */
                    }
                    //cierra la conexión
                    conn.Close();

                    txtId.Clear();
                    txtNombre.Clear();
                    

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
