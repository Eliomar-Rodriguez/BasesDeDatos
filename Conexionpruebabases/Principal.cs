﻿using Npgsql;
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
using Conexionpruebabases.Vistas.Rifas;
using Conexionpruebabases.Vistas.Bienes;
using Conexionpruebabases.Vistas.Contadores;
using Conexionpruebabases.Vistas.Proveedores;
using Conexionpruebabases.Vistas.DivisionesPoliticas;
using Conexionpruebabases.Vistas.Empleados;

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
        
        private void insertarVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new insertCompra().Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Salir?\nVea que este sistema promete.", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void clienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new verCliente().Show();
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

        private void rifaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new insertRifas().Show();
        }

        private void rifaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new borrarRifa().Show();
        }

        private void rifaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new editRifa().Show();
        }

        private void bienesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new insertBienes().Show();
        }

        private void bienesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new borrarBienes().Show();
        }

        private void bienesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new editBienes().Show();
        }

        private void contadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new insertContador().Show();
        }

        private void contadorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new editContador().Show();
        }

        private void clienteRifaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new insertClienteRifa().Show();
        }

        private void provinciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new insertProvincia().Show();
        }

        private void cantónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new insertCanton().Show();
        }

        private void distritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new insertDistritos().Show();
        }
        
        private void provinciaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new borrarProvincia().Show();
        }

        private void cantónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new borrarCanton().Show();
        }

        private void distritoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new borrarDistrito().Show();
        }

        private void provinciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new editProvincia().Show();
        }

        private void cantónToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new editCanton().Show();
        }

        private void distritoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new editDistrito().Show();
        }
        private void proveedorToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new selectProveedor().Show();
        }

        private void clienteRifaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new insertClienteRifa().Show();
        }

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new insertEmpleado().Show();
        }

        private void empleadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new borrarEmpleado().Show();
        }

        private void empleadoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new editEmpleado().Show();
        }

        private void contadorToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new verContador().Show();
        }

        private void provinciaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new verProvincia().Show();
        }

        private void cantónToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new verCanton().Show();
        }

        private void distritoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new verDistrito().Show();
        }

        private void productoRifaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new insertProductoRifa().Show();
        }

        private void teléfonoProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new insertTelefonoProveedor().Show();
        }

        private void teléfonosProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new borrarTelefonoProveedor().Show();
        }

        private void teléfonoProveedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new editTelefonoProveedor().Show();
        }

        private void teléfonosProveedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new verTelefonosProveedores().Show();
        }
    }
}
