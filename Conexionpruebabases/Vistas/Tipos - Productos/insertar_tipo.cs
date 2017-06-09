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
    public partial class insertar_tipo : Form
    {

        public static NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Database=proyectoBases;Port=5432;User Id=postgres;Password=12345;");

        public insertar_tipo()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length != 0) //que no esté vacio el campo de texto
            {
                try
                {
                    char[] nombre = txtNombre.Text.ToCharArray();
                    
                    conn.Open();

                    NpgsqlCommand command = new NpgsqlCommand("insertar_tipos_productos", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    // creacion de variables que se enviaran por parametro en la consulta
                    NpgsqlParameter nombre_tipo = new NpgsqlParameter("@nombre", NpgsqlDbType.Varchar,50);
                    nombre_tipo.Value = nombre;
                    command.Parameters.Add(nombre_tipo);
                    txtNombre.Clear();
                   
                    command.ExecuteReader();

                    lblError.Visible = true;
                    lblError.Text = "Listo! el tipo de producto ha sido agregado";
                    lblError.ForeColor = Color.Green;

                    conn.Close();

                    
                }

                catch(Exception ex){
                    conn.Close();
                    lblError.Visible = true;

                }
            }
            else
            {
                lblError.Text = "No deben exsitir espacios vacíos";
            }
        }
    }
}
