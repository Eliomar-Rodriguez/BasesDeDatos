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

namespace Conexionpruebabases.Vistas
{
    public partial class borrarProveedor : Form
    {
        public borrarProveedor()
        {
            InitializeComponent();
        }
       
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {// insertando todos los proveedores en el combo box
                NpgsqlConnection conn = new NpgsqlConnection();
                conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                conn.Open();

                NpgsqlCommand command = new NpgsqlCommand("SELECT * from proveedores where cedula_juridica='" + txtCedulaJuridica.Text + "';", conn);

                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    txtCedulaJuridica.Text = dr[0].ToString();
                    txtNombreEmpresa.Text = dr[1].ToString();
                    txtValoracion.Text = dr[2].ToString();
                    txtNombre.Text = dr[3].ToString();
                    txtApellido1.Text = dr[4].ToString();
                    txtApellido2.Text = dr[5].ToString();
                    txtDirExacta.Text = dr[7].ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            new Principal().Show();
            this.Dispose();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection();
                conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                conn.Open();

                NpgsqlCommand command = new NpgsqlCommand("delete_proveedores", conn);
                command.CommandType = CommandType.StoredProcedure;

                // creacion de variables que se enviaran por parametro en la consulta
                NpgsqlParameter ced = new NpgsqlParameter("@cedula_juridica", NpgsqlDbType.Char, 12);
                ced.Value = txtCedulaJuridica.Text.ToCharArray();
                command.Parameters.Add(ced);

                command.ExecuteReader();


                lblError.Visible = true;
                lblError.Text = "Listo! el proveedor ha sido eliminado";
                lblError.ForeColor = Color.Green;

                txtCedulaJuridica.Clear();
                txtNombreEmpresa.Clear();
                txtNombre.Clear();
                txtValoracion.Clear();
                txtApellido1.Clear();
                txtApellido2.Clear();
                txtDirExacta.Clear();
                conn.Close();
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }
    }
}
