using Npgsql;
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
    public partial class porcProdVendProvee : Form
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;");
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        public static List<string> proveedores = new List<string>();
        public porcProdVendProvee()
        {
            InitializeComponent();
        }

        private void porcProdVendProvee_Load(object sender, EventArgs e)
        {
            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * from proveedores;", conn);

            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                proveedores.Add(dr[0].ToString());
                cmbEmpresa.Items.AddRange(new object[] { dr[1].ToString() });
            }
            conn.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            conn.Open();
            string sql = "select q.cedula_juridica,q.nombre, Cantidad_por_Tipo * 100 / Cantidad_de_productos as Porcentaje from tipos_productos tp inner join " 
                +"(select nombre,id_tipo,cedula_juridica, count(codigo_producto) as Cantidad_de_productos, count(id_tipo) as Cantidad_por_Tipo from productos where "
                +"cedula_juridica = '"+proveedores[cmbEmpresa.SelectedIndex]+ "' group by cedula_juridica,id_tipo, nombre) q on tp.id_tipo = q.id_tipo";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            vista.DataSource = dt;

            conn.Close();
        }
    }
}
