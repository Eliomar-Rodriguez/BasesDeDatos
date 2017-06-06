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
    public partial class insertProducto : Form
    {
        public static List<string> proveedores = new List<string>();
        public static List<int> tiposProductos = new List<int>();
        public insertProducto()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
             //si hay espacios vacios
            if (cmbTipoP.SelectedIndex == -1 | cmbEmpresa.SelectedIndex == -1 | txtNombre.Text.Length == 0 | txtPrecio.Text.Length == 0 | txtStock.Text.Length == 0)
            {
                lblError.Visible = true;
            }
            else // si todo esta bien procede a insertar el cliente
            {
                char[] cedJurid = proveedores[cmbEmpresa.SelectedIndex].ToCharArray(), nombre = txtNombre.Text.ToCharArray();
                int stock = 0, precio = 0, tipoP = tiposProductos[cmbTipoP.SelectedIndex];
                bool stock1 = int.TryParse(txtStock.Text,out stock);
                bool precio1 = int.TryParse(txtPrecio.Text,out precio);

                if (!stock1 | !precio1)
                {
                    lblError.Visible = true;
                    return;
                }

                try
                {
                    
                    NpgsqlConnection conn = new NpgsqlConnection();
                    conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

                    conn.Open();

                    NpgsqlCommand command = new NpgsqlCommand("insertar_productos", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    // creacion de variables que se enviaran por parametro en la consulta
                    NpgsqlParameter idEmp = new NpgsqlParameter("@idEmpresa", NpgsqlDbType.Integer);
                    idEmp.Value = 1;
                    command.Parameters.Add(idEmp);

                    NpgsqlParameter tP = new NpgsqlParameter("@tipProd", NpgsqlDbType.Integer);
                    tP.Value = tipoP;
                    command.Parameters.Add(tP);

                    NpgsqlParameter cedJud = new NpgsqlParameter("@cedJuridica", NpgsqlDbType.Char, 12);
                    cedJud.Value = cedJurid;
                    command.Parameters.Add(cedJud);

                    NpgsqlParameter nomb = new NpgsqlParameter("@nombre", NpgsqlDbType.Varchar, 50);
                    nomb.Value = nombre;
                    command.Parameters.Add(nomb);

                    NpgsqlParameter prec = new NpgsqlParameter("@precio", NpgsqlDbType.Integer);
                    prec.Value = precio;
                    command.Parameters.Add(prec);

                    NpgsqlParameter stck = new NpgsqlParameter("@stock", NpgsqlDbType.Integer);
                    stck.Value = stock;
                    command.Parameters.Add(stck);

                    cmbTipoP.SelectedIndex = -1;
                    cmbEmpresa.SelectedIndex = -1;
                    txtNombre.Clear();
                    txtPrecio.Clear();
                    txtStock.Clear();

                    command.ExecuteReader();

                    lblError.Visible = true;
                    lblError.Text = "Listo! el producto ha sido agregado";
                    lblError.ForeColor = Color.Green;
                    
                    conn.Close();
                }
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = ex.Message;
                }
            }
        }

        private void insertProducto_Load(object sender, EventArgs e)
        {
            // insertando todos los proveedores en el combo box
            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * from proveedores;", conn);
            
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                proveedores.Add(dr[0].ToString());
                cmbEmpresa.Items.AddRange(new object[] { dr[1].ToString()});
            }
            conn.Close();
            // insertando todos los tipos de productos en el combo box
            conn.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("SELECT * from tipos_productos;", conn);

            NpgsqlDataReader dr1 = command1.ExecuteReader();
            int idTipo;
            while (dr1.Read())
            {
                idTipo = 0;
                bool res = int.TryParse(dr1[0].ToString(), out idTipo);
                if (res)
                    tiposProductos.Add(idTipo);
                cmbTipoP.Items.AddRange(new object[] { dr1[1].ToString() });
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
