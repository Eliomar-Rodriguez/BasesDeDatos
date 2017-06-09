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

namespace Conexionpruebabases.Vistas.tipos_productos
{
    public partial class modificar_tipo : Form
    {
        public static List<int> tiposProductos = new List<int>();
        public static NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;");

        public modificar_tipo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void modificar_tipo_Load(object sender, EventArgs e)
        {
            conn.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("SELECT * from tipos_productos;", conn);

            NpgsqlDataReader dr1 = command1.ExecuteReader();
            int idTipo;
            while (dr1.Read())
            {
                idTipo = 0;
                bool res = int.TryParse(dr1[0].ToString(), out idTipo); //conversion del id_tipo a integer
                if (res)
                    tiposProductos.Add(idTipo);
                cmbTipoP.Items.AddRange(new object[] { dr1[1].ToString() }); //agregar el tipo de producto ak combo box
            }
            conn.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length !=0 ||cmbTipoP.SelectedIndex ==-1)
            {
                try
                {
                    char[]nuevo_nombre = txtNombre.Text.ToCharArray();
                    int id = tiposProductos[cmbTipoP.SelectedIndex];
                    conn.Open();
                    NpgsqlCommand command = new NpgsqlCommand("modificar_tipos_productos", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    // creacion de variables que se enviaran por parametro en la consulta

                    NpgsqlParameter id_tipo = new NpgsqlParameter("@id", NpgsqlDbType.Integer);
                    id_tipo.Value = id;
                    command.Parameters.Add(id_tipo);

                    NpgsqlParameter tipo = new NpgsqlParameter("@nuevo_nombre", NpgsqlDbType.Varchar, 50);
                    tipo.Value = nuevo_nombre;
                    command.Parameters.Add(tipo);

                    lblError.Visible = true;
                    lblError.Text = "Listo! el tipo de producto ha sido agregado";
                    lblError.ForeColor = Color.Green;
                    txtNombre.Clear();
                    cmbTipoP.SelectedIndex = -1;
                    command.ExecuteReader();
                    conn.Close();
                }
                catch (Exception ex)
                {
                   conn.Close();
                   lblError.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Error en los datos", "Alerta de sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}
