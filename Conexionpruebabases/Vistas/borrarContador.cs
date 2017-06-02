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
    public partial class borrarContador : Form
    {
        public borrarContador()
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

                NpgsqlCommand command = new NpgsqlCommand("SELECT telefono,valoracion,genero,nombre,apellido1,apellido2,fecha_contrato from contadores where telefono='" + txtTel.Text + "';", conn);

                NpgsqlDataReader dr = command.ExecuteReader();
                bool genero;
                while (dr.Read())
                {
                    txtTel.Text = dr[0].ToString();
                    txtValoracion.Text = dr[1].ToString();
                    txtNombre.Text = dr[3].ToString();
                    txtApell1.Text = dr[4].ToString();
                    txtApell2.Text = dr[5].ToString();
                    genero = bool.Parse(dr[2].ToString());
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
                    txtFechaC.Text = dr[6].ToString();
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
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection();
                conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                conn.Open();

                NpgsqlCommand command = new NpgsqlCommand("borrar_contadores", conn);
                command.CommandType = CommandType.StoredProcedure;

                // creacion de variables que se enviaran por parametro en la consulta
                NpgsqlParameter idEmp = new NpgsqlParameter("@telefono", NpgsqlDbType.Char, 9);
                idEmp.Value = txtTel.Text.ToCharArray();
                command.Parameters.Add(idEmp);
                
                command.ExecuteReader();


                lblError.Visible = true;
                lblError.Text = "Listo! el contador ha sido eliminado";
                lblError.ForeColor = Color.Green;

                txtTel.Clear();
                txtNombre.Clear();
                txtApell1.Clear();
                txtApell2.Clear();
                txtFechaC.Clear();
                txtValoracion.Clear();
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

        private void button1_Click(object sender, EventArgs e)
        {
            new Principal().Show();
            this.Dispose();
        }
    }
}
