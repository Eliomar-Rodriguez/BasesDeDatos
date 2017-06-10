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
    public partial class insertCompra : Form
    {
        public static int montoTotal = 0;
        public static List<string> empleados = new List<string>();
        public static List<int> rifas = new List<int>();
        public static NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;");
        public insertCompra()
        {
            InitializeComponent();
        }

        private void insertCompra_Load(object sender, EventArgs e)
        {
            DateTime fechaHoy = DateTime.Now.Date;
            txtFechaCompra.Text = fechaHoy.ToString("d");
            
            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT telefono,nombre,apellido1,apellido2 from empleados;", conn);

            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                empleados.Add(dr[0].ToString());
                cmbEmpleado.Items.AddRange(new object[] { dr[1].ToString() + " " + dr[2].ToString() + " " + dr[3].ToString() });
            }
            conn.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                
                int cantidad = 0;

                if (txtCantidad.Text.Length == 0 | txtCodProd.Text.Length == 0)
                {
                    lblError.Text = "Debe ingresar una cantidad de productos a agregar";
                    lblError.Visible = true;
                    return;
                }
                else
                {
                    if (int.Parse(txtCantidad.Text)>0)
                    {
                        bool resp = int.TryParse(txtCantidad.Text, out cantidad);
                        if (!resp)
                        {
                            lblError.Text = "No se permite el ingreso de letras";
                            lblError.Visible = true;
                        }
                    }
                    else
                    {
                        lblError.Text = "Debe ingresar una cantidad de productos mayor a 0";
                        lblError.Visible = true;
                        return;
                    }
                }
                conn.Open();
                NpgsqlCommand command = new NpgsqlCommand("SELECT nombre, precio_unitario,stock from productos where codigo_producto = " + txtCodProd.Text + ";", conn);

                NpgsqlDataReader dr = command.ExecuteReader();

                //listaProductos.Columns.Add();
                while (dr.Read())
                {
                    listaProductos.Rows.Add(txtCodProd.Text, dr[0], txtCantidad.Text, dr[1], cantidad * int.Parse(dr[1].ToString()));
                    montoTotal = montoTotal + cantidad * int.Parse(dr[1].ToString());
                    lblTotal.Text = montoTotal.ToString();
                }
                lblError.Visible = false;
                conn.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error, producto no existe";
                lblError.Visible = true;
                conn.Close();
            }
            txtCantidad.Clear();
            txtCodProd.Clear();

        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            
            // si hay espacios vacios
            if (txtFechaCompra.Text.Length == 0 | cmbEmpleado.SelectedIndex == -1 | lblTotal.Text == "0")
            {
                lblError.Visible = true;
            }
            else // si todo esta bien procede a insertar el cliente
            {
                char[] telClien = txtTel.Text.ToCharArray(), telEmple = empleados[cmbEmpleado.SelectedIndex].ToCharArray();
                int monto = int.Parse(lblTotal.Text);
                string fecha = txtFechaCompra.Text;
                int codigoCompra = 0;
                int nextVal = 0;
                try
                {
                    conn.Open();
                    NpgsqlCommand ultComp = new NpgsqlCommand("select nextval('compras_codigo_seq');", conn);
                    nextVal = int.Parse(ultComp.ExecuteScalar().ToString());
                    //codigoCompra= int.Parse(dr[0].ToString());

                    conn.Close();

                    conn.Open();
                    NpgsqlCommand setVal = new NpgsqlCommand("select setval('compras_codigo_seq',"+(nextVal-1)+");", conn);
                    setVal.ExecuteScalar();
                    //codigoCompra= int.Parse(dr[0].ToString());

                    conn.Close();

                    conn.Open();

                    NpgsqlCommand command = new NpgsqlCommand("insertar_compras", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    // creacion de variables que se enviaran por parametro en la consulta
                    NpgsqlParameter telEmplea = new NpgsqlParameter("@telefonoEmpleado", NpgsqlDbType.Char, 9);
                    telEmplea.Value = telEmple;
                    command.Parameters.Add(telEmplea);

                    NpgsqlParameter telCli = new NpgsqlParameter("@telefonoCliente", NpgsqlDbType.Char, 9);
                    if (txtTel.Text.Length!=9)
                        telCli.Value = DBNull.Value;
                    else
                        telCli.Value = telClien;

                    command.Parameters.Add(telCli);
                    
                    
                    NpgsqlParameter total = new NpgsqlParameter("@monto", NpgsqlDbType.Integer);
                    total.Value = montoTotal;
                    command.Parameters.Add(total);

                    NpgsqlParameter fec = new NpgsqlParameter("@fecha", NpgsqlDbType.Date);
                    fec.Value = fecha;
                    command.Parameters.Add(fec);

                    command.ExecuteReader();
                    conn.Close();



                    /*- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

                   

                    /*- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

                    for (int i = 0; i < listaProductos.RowCount-1; i++)
                    {
                        NpgsqlCommand command2 = new NpgsqlCommand("insertar_productos_compras", conn);
                        command2.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        // creacion de variables que se enviaran por parametro en la consulta
                        NpgsqlParameter codPro = new NpgsqlParameter("@codigoProducto", NpgsqlDbType.Integer);
                        codPro.Value = int.Parse(listaProductos.Rows[i].Cells[0].Value.ToString());
                        command2.Parameters.Add(codPro);
                        
                        NpgsqlParameter codCompr = new NpgsqlParameter("@codigoCompra", NpgsqlDbType.Integer);
                        codCompr.Value = nextVal; //int.Parse(txtCodProd.Text);
                        command2.Parameters.Add(codCompr);

                        NpgsqlParameter totalP = new NpgsqlParameter("@total", NpgsqlDbType.Integer);
                        totalP.Value = int.Parse(listaProductos.Rows[i].Cells[4].Value.ToString());
                        command2.Parameters.Add(totalP);

                        NpgsqlParameter cantComp = new NpgsqlParameter("@cantComprada", NpgsqlDbType.Integer);
                        cantComp.Value = int.Parse(listaProductos.Rows[i].Cells[2].Value.ToString());
                        command2.Parameters.Add(cantComp);

                        NpgsqlParameter precUni = new NpgsqlParameter("@precioUnitario", NpgsqlDbType.Integer);
                        precUni.Value = int.Parse(listaProductos.Rows[i].Cells[3].Value.ToString());
                        command2.Parameters.Add(precUni);

                        command2.ExecuteReader();
                        conn.Close();
                    }
                    /*- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
                    if (txtTel.Text.Length != 9)
                    {
                        lblError.Text = "Debe insertar el número de un cliente existente.";
                        lblError.Visible = true;
                    }
                    else
                    {
                        NpgsqlCommand command2 = new NpgsqlCommand("insertar_cliente_rifas", conn);
                        command2.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        // creacion de variables que se enviaran por parametro en la consulta
                        NpgsqlParameter telClie = new NpgsqlParameter("@telefonoCliente", NpgsqlDbType.Char,9);
                        telClie.Value = txtTel.Text.ToCharArray();
                        command2.Parameters.Add(telClie);

                        NpgsqlParameter idRifa = new NpgsqlParameter("@idRifa", NpgsqlDbType.Integer);
                        idRifa.Value = rifas[cmbFechaRifa.SelectedIndex];
                        command2.Parameters.Add(idRifa);

                        NpgsqlParameter ganador = new NpgsqlParameter("@ganador", NpgsqlDbType.Boolean);
                        ganador.Value = false;
                        command2.Parameters.Add(ganador);
                        
                        command2.ExecuteReader();
                        conn.Close();
                    }


                    /*- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

                    lblProductos.Text = "Listo! la compra ha sido registrada";
                    lblProductos.ForeColor = Color.Green;
                    lblProductos.Visible = true;

                    cmbEmpleado.SelectedIndex = -1;
                    txtFechaCompra.Clear();
                    txtTel.Clear();
                }
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = "Error al ingresar la compra";
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            label8.Visible = true;
            cmbFechaRifa.Visible = true;

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("select id_rifa,fecha from rifas where estado = false;", conn);

            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                rifas.Add(int.Parse(dr[0].ToString()));
                DateTime fecha = DateTime.Parse(dr[1].ToString());
                cmbFechaRifa.Items.AddRange(new object[] { fecha.ToString("d") });
            }
            conn.Close();
        }
    }
}
