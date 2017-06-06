namespace Conexionpruebabases.Vistas
{
    partial class insertCompra
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.MaskedTextBox();
            this.cmbEmpleado = new System.Windows.Forms.ComboBox();
            this.txtFechaCompra = new System.Windows.Forms.TextBox();
            this.listaProductos = new System.Windows.Forms.DataGridView();
            this.codigo_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio_unitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodProd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnPagar = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblProductos = new System.Windows.Forms.Label();
            this.cmbFechaRifa = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.listaProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1044, 633);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(209, 55);
            this.button1.TabIndex = 5;
            this.button1.Text = "Menú Principal";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(207, 247);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(636, 32);
            this.lblError.TabIndex = 28;
            this.lblError.Text = "Error: Verifique que los espacios contengan datos validos.";
            this.lblError.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(453, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(380, 49);
            this.label6.TabIndex = 27;
            this.label6.Text = "Inserción de Compras";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(692, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 32);
            this.label4.TabIndex = 22;
            this.label4.Text = "Fecha compra";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(524, 642);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 37);
            this.label3.TabIndex = 20;
            this.label3.Text = "Monto total";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 32);
            this.label2.TabIndex = 18;
            this.label2.Text = "Empleado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(350, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 32);
            this.label1.TabIndex = 16;
            this.label1.Text = "Teléfono cliente";
            // 
            // txtTel
            // 
            this.txtTel.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTel.Location = new System.Drawing.Point(356, 88);
            this.txtTel.Mask = "0000-0000";
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(307, 40);
            this.txtTel.TabIndex = 1;
            // 
            // cmbEmpleado
            // 
            this.cmbEmpleado.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpleado.FormattingEnabled = true;
            this.cmbEmpleado.Location = new System.Drawing.Point(14, 88);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(307, 40);
            this.cmbEmpleado.TabIndex = 0;
            // 
            // txtFechaCompra
            // 
            this.txtFechaCompra.Enabled = false;
            this.txtFechaCompra.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaCompra.Location = new System.Drawing.Point(698, 88);
            this.txtFechaCompra.Name = "txtFechaCompra";
            this.txtFechaCompra.Size = new System.Drawing.Size(307, 40);
            this.txtFechaCompra.TabIndex = 3;
            // 
            // listaProductos
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.listaProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.listaProductos.BackgroundColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listaProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.listaProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo_producto,
            this.Nombre1,
            this.Cantidad,
            this.precio_unitario,
            this.Total});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listaProductos.DefaultCellStyle = dataGridViewCellStyle3;
            this.listaProductos.Location = new System.Drawing.Point(16, 292);
            this.listaProductos.Name = "listaProductos";
            this.listaProductos.RowTemplate.Height = 28;
            this.listaProductos.Size = new System.Drawing.Size(1237, 335);
            this.listaProductos.TabIndex = 29;
            // 
            // codigo_producto
            // 
            this.codigo_producto.HeaderText = "Codigo Producto";
            this.codigo_producto.Name = "codigo_producto";
            // 
            // Nombre1
            // 
            this.Nombre1.HeaderText = "Nombre";
            this.Nombre1.Name = "Nombre1";
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // precio_unitario
            // 
            this.precio_unitario.HeaderText = "Precio Unitario";
            this.precio_unitario.Name = "precio_unitario";
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(668, 204);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(307, 40);
            this.txtCantidad.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(550, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 32);
            this.label5.TabIndex = 31;
            this.label5.Text = "Cantidad";
            // 
            // txtCodProd
            // 
            this.txtCodProd.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodProd.Location = new System.Drawing.Point(213, 204);
            this.txtCodProd.Name = "txtCodProd";
            this.txtCodProd.Size = new System.Drawing.Size(307, 40);
            this.txtCodProd.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(193, 32);
            this.label7.TabIndex = 33;
            this.label7.Text = "Codigo Producto";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(1029, 189);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(134, 55);
            this.btnAdd.TabIndex = 34;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnPagar
            // 
            this.btnPagar.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.Location = new System.Drawing.Point(903, 633);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(115, 55);
            this.btnPagar.TabIndex = 35;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Palatino Linotype", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Chocolate;
            this.lblTotal.Location = new System.Drawing.Point(722, 637);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(36, 44);
            this.lblTotal.TabIndex = 36;
            this.lblTotal.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Palatino Linotype", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Chocolate;
            this.label9.Location = new System.Drawing.Point(689, 635);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 44);
            this.label9.TabIndex = 37;
            this.label9.Text = "¢";
            // 
            // lblProductos
            // 
            this.lblProductos.AutoSize = true;
            this.lblProductos.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductos.ForeColor = System.Drawing.Color.Red;
            this.lblProductos.Location = new System.Drawing.Point(12, 644);
            this.lblProductos.Name = "lblProductos";
            this.lblProductos.Size = new System.Drawing.Size(506, 32);
            this.lblProductos.TabIndex = 38;
            this.lblProductos.Text = "Error: Debe de agregar al menos un producto.";
            this.lblProductos.Visible = false;
            // 
            // cmbFechaRifa
            // 
            this.cmbFechaRifa.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFechaRifa.FormattingEnabled = true;
            this.cmbFechaRifa.Location = new System.Drawing.Point(668, 137);
            this.cmbFechaRifa.Name = "cmbFechaRifa";
            this.cmbFechaRifa.Size = new System.Drawing.Size(307, 40);
            this.cmbFechaRifa.TabIndex = 39;
            this.cmbFechaRifa.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(329, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(309, 32);
            this.label8.TabIndex = 40;
            this.label8.Text = "Seleccione la fecha de la rifa";
            this.label8.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(19, 139);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(284, 36);
            this.checkBox1.TabIndex = 42;
            this.checkBox1.Text = "Agregar cliente a la rifa";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // insertCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1325, 737);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.cmbFechaRifa);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblProductos);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtCodProd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listaProductos);
            this.Controls.Add(this.txtFechaCompra);
            this.Controls.Add(this.cmbEmpleado);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTel);
            this.Name = "insertCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.insertCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listaProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtTel;
        private System.Windows.Forms.ComboBox cmbEmpleado;
        private System.Windows.Forms.TextBox txtFechaCompra;
        private System.Windows.Forms.DataGridView listaProductos;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodProd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio_unitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.ComboBox cmbFechaRifa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}