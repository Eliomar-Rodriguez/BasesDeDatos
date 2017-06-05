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
using Conexionpruebabases.Vistas;

namespace Conexionpruebabases
{
    public partial class Principal : Form
    {
        DataSet datos = new DataSet();
        public Principal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        // seleccionar con una funcion que retorna setof
        private void button1_Click(object sender, EventArgs e)
        {
        }
        

        private void rdbH_CheckedChanged(object sender, EventArgs e)
        {
            //rdbM.Checked = false;
        }

        private void rdbM_CheckedChanged(object sender, EventArgs e)
        {
            //rdbH.Checked = false;
        }

        private void insertarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new insertCliente().Show();
        }

        private void consulta1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = "Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;";

            conn.Open();

            //NpgsqlTransaction tran = conn.BeginTransaction();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * from proveedores;", conn);
            /*command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@cedula", NpgsqlDbType.Char, string.IsNullOrEmpty(null) ? (object)DBNull.Value : null);
            command.Parameters.AddWithValue("@nombreEmpresa", NpgsqlDbType.Varchar, string.IsNullOrEmpty(null) ? (object)DBNull.Value : null);
            command.Parameters.AddWithValue("@valoracion", NpgsqlDbType.Integer, string.IsNullOrEmpty(null) ? (object)DBNull.Value : null);
            command.Parameters.AddWithValue("@dueno", NpgsqlDbType.Varchar, string.IsNullOrEmpty(null) ? (object)DBNull.Value : null);
            command.Parameters.AddWithValue("@apellido1", NpgsqlDbType.Varchar, string.IsNullOrEmpty(null) ? (object)DBNull.Value : null);
            command.Parameters.AddWithValue("@apellido2", NpgsqlDbType.Varchar, string.IsNullOrEmpty(null) ? (object)DBNull.Value : null);
            command.Parameters.AddWithValue("@distrito", NpgsqlDbType.Integer, string.IsNullOrEmpty(null) ? (object)DBNull.Value : null);
            command.Parameters.AddWithValue("@dirExacta", NpgsqlDbType.Varchar, string.IsNullOrEmpty(null) ? (object)DBNull.Value : null);
            */
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
                Console.Write("{0}\t{1}\n", dr[0], dr[1]);

            conn.Close();
        }

        private void insertarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new insertProducto().Show();
        }

        private void modificarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new editCliente().Show();
        }

        private void modificarContadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new editProducto().Show();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new borrarCliente().Show();
        }

        private void contadorToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new borrarContador().Show();
        }

        private void porcentajeDeProductosVendidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new porcProdVendProvee().Show();
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new insertProveedor().Show();
        }

        private void proveedorToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new borrarProveedor().Show();
        }

        private void proveedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new editProveedor().Show();
        }
    }
}
