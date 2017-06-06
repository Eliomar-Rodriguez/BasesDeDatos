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

namespace Conexionpruebabases.Vistas.Rifas
{
    public partial class insertRifas : Form
    {
        public insertRifas()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text.Length == 0 | dtpFecha.Value == null)
            {
                lblError.Visible = true;
                return;
            }
            else
            {
                DateTime fecha = dtpFecha.Value;
                string descripcion = txtDescripcion.Text;
                try
                {
                    NpgsqlConnection conn = new NpgsqlConnection();
                    conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                    conn.Open();

                    NpgsqlCommand command = new NpgsqlCommand("insertar_rifa", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    // creacion de variables que se enviaran por parametro en la consulta
                    NpgsqlParameter fe = new NpgsqlParameter("@fecha", NpgsqlDbType.Date);
                    fe.Value = fecha;
                    command.Parameters.Add(fe);

                    NpgsqlParameter des = new NpgsqlParameter("@descripcion", NpgsqlDbType.Varchar,250);
                    des.Value = descripcion;
                    command.Parameters.Add(des);

                    dtpFecha.Value = DateTime.Now;
                    txtDescripcion.Clear();

                    command.ExecuteReader();

                    lblError.Visible = true;
                    lblError.Text = "Listo! la rifa ha sido agregada";
                    lblError.ForeColor = Color.Green;

                    conn.Close();
                }
                catch (Exception ex) { lblError.Visible = true; lblError.Text = ex.ToString(); }
            }
            
            
        }
    }
}
