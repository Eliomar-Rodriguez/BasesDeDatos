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
    public partial class eliminar_tipo : Form
    {
        public static List<int> tiposProductos = new List<int>();
        public static NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;");

        public eliminar_tipo()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        
        private void eliminar_tipo_Load(object sender, EventArgs e)
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
            if (cmbTipoP.SelectedIndex != -1)
            {
                if (MessageBox.Show("Está seguro(@) de eliminar este tipo de producto", "Alerta de sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int id_tipo = tiposProductos[cmbTipoP.SelectedIndex];
                    try
                    {
                        conn.Open();

                        NpgsqlCommand command = new NpgsqlCommand("eliminar_tipos_productos", conn);
                        command.CommandType = CommandType.StoredProcedure;

                        // creacion de variables que se enviaran por parametro en la consulta
                        NpgsqlParameter tipo = new NpgsqlParameter("@id_tipo", NpgsqlDbType.Integer);
                        tipo.Value = id_tipo;
                        command.Parameters.Add(tipo);
                        cmbTipoP.SelectedIndex = -1;

                        command.ExecuteReader();

                        lblError.Visible = true;
                        lblError.Text = "Listo! el tipo de producto ha sido eliminado";
                        lblError.ForeColor = Color.Green;

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        lblError.Visible = true;
                    }
                }

            }
            else
            {
                MessageBox.Show("No selecionó ningún tipo de producto", "Alerta de sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
