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

namespace Conexionpruebabases.Vistas.Bienes
{
    public partial class insertBienes : Form
    {
        public insertBienes()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int n;
            if(txtNombre.Text.Length == 0 | txtDescripcion.Text.Length == 0 | txtCantidad.Text.Length == 0 | cbEstado.SelectedIndex == -1 | (int.TryParse(txtCantidad.ToString(),out n)))
            {
                lblError.Visible = true;
            }
            else
            {

                int estado = int.Parse(cbEstado.SelectedItem.ToString()), cantidad = int.Parse(txtCantidad.Text);
                string descripcion = txtDescripcion.Text, nombre = txtNombre.Text;

                NpgsqlConnection conn = new NpgsqlConnection();
                conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                conn.Open();

                NpgsqlCommand command = new NpgsqlCommand("insertar_bienes", conn);
                command.CommandType = CommandType.StoredProcedure;

                // creacion de variables que se enviaran por parametro en la consulta
                NpgsqlParameter id = new NpgsqlParameter("@id_empresa", NpgsqlDbType.Integer);
                id.Value = 1;
                command.Parameters.Add(id);

                NpgsqlParameter des = new NpgsqlParameter("@descripcion", NpgsqlDbType.Varchar, 250);
                des.Value = descripcion;
                command.Parameters.Add(des);

                NpgsqlParameter nomb = new NpgsqlParameter("@nombre", NpgsqlDbType.Varchar,50);
                nomb.Value = nombre;
                command.Parameters.Add(nomb);

                NpgsqlParameter est = new NpgsqlParameter("@estado", NpgsqlDbType.Integer);
                est.Value = estado;
                command.Parameters.Add(est);

                NpgsqlParameter cant = new NpgsqlParameter("@cantidad", NpgsqlDbType.Integer);
                cant.Value = cantidad;
                command.Parameters.Add(cant);
                
                command.ExecuteReader();


                lblError.Visible = true;
                lblError.Text = "Listo! el bien ha sido insertado";
                lblError.ForeColor = Color.Green;

                txtCantidad.Clear();
                txtDescripcion.Clear();
                txtNombre.Clear();
                cbEstado.SelectedIndex = -1;
                

                conn.Close();
            }
        }
    }
}
