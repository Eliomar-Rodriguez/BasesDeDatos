namespace Conexionpruebabases.Vistas
{
    partial class insertProveedor
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
            this.button1 = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCedulaJuridica = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreEmpresa = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtApellido1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtApellido2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbDistrito = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDirExacta = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(155, 457);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 36);
            this.button1.TabIndex = 33;
            this.button1.Text = "Menú Principal";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(43, 379);
            this.lblError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(435, 22);
            this.lblError.TabIndex = 32;
            this.lblError.Text = "Error: Verifique que los espacios contengan datos validos.";
            this.lblError.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(117, 19);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(288, 32);
            this.label6.TabIndex = 31;
            this.label6.Text = "Inserción de Proveedores";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(189, 411);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(89, 36);
            this.btnGuardar.TabIndex = 30;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 22);
            this.label1.TabIndex = 34;
            this.label1.Text = "Cédula Jurídica";
            // 
            // txtCedulaJuridica
            // 
            this.txtCedulaJuridica.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCedulaJuridica.Location = new System.Drawing.Point(230, 82);
            this.txtCedulaJuridica.Margin = new System.Windows.Forms.Padding(2);
            this.txtCedulaJuridica.Mask = "3-000-000000";
            this.txtCedulaJuridica.Name = "txtCedulaJuridica";
            this.txtCedulaJuridica.Size = new System.Drawing.Size(206, 29);
            this.txtCedulaJuridica.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 118);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 22);
            this.label2.TabIndex = 36;
            this.label2.Text = "Nombre de la Empresa";
            // 
            // txtNombreEmpresa
            // 
            this.txtNombreEmpresa.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreEmpresa.Location = new System.Drawing.Point(230, 115);
            this.txtNombreEmpresa.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombreEmpresa.Name = "txtNombreEmpresa";
            this.txtNombreEmpresa.Size = new System.Drawing.Size(206, 29);
            this.txtNombreEmpresa.TabIndex = 37;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(230, 148);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(206, 29);
            this.txtNombre.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 151);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 22);
            this.label3.TabIndex = 38;
            this.label3.Text = "Nombre";
            // 
            // txtApellido1
            // 
            this.txtApellido1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido1.Location = new System.Drawing.Point(230, 181);
            this.txtApellido1.Margin = new System.Windows.Forms.Padding(2);
            this.txtApellido1.Name = "txtApellido1";
            this.txtApellido1.Size = new System.Drawing.Size(206, 29);
            this.txtApellido1.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(43, 184);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 22);
            this.label4.TabIndex = 40;
            this.label4.Text = "Apellido 1";
            // 
            // txtApellido2
            // 
            this.txtApellido2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido2.Location = new System.Drawing.Point(230, 214);
            this.txtApellido2.Margin = new System.Windows.Forms.Padding(2);
            this.txtApellido2.Name = "txtApellido2";
            this.txtApellido2.Size = new System.Drawing.Size(206, 29);
            this.txtApellido2.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(43, 217);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 22);
            this.label5.TabIndex = 42;
            this.label5.Text = "Apellido2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(43, 255);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 22);
            this.label7.TabIndex = 44;
            this.label7.Text = "Distrito";
            // 
            // cbDistrito
            // 
            this.cbDistrito.FormattingEnabled = true;
            this.cbDistrito.Location = new System.Drawing.Point(230, 258);
            this.cbDistrito.Name = "cbDistrito";
            this.cbDistrito.Size = new System.Drawing.Size(206, 21);
            this.cbDistrito.TabIndex = 45;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(43, 291);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 22);
            this.label8.TabIndex = 46;
            this.label8.Text = "Dirección Exacta";
            // 
            // txtDirExacta
            // 
            this.txtDirExacta.Location = new System.Drawing.Point(230, 294);
            this.txtDirExacta.Multiline = true;
            this.txtDirExacta.Name = "txtDirExacta";
            this.txtDirExacta.Size = new System.Drawing.Size(206, 82);
            this.txtDirExacta.TabIndex = 47;
            // 
            // insertProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(521, 497);
            this.Controls.Add(this.txtDirExacta);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbDistrito);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtApellido2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtApellido1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNombreEmpresa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCedulaJuridica);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnGuardar);
            this.Name = "insertProveedor";
            this.Load += new System.EventHandler(this.insertProveedor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtCedulaJuridica;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreEmpresa;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtApellido1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtApellido2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbDistrito;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDirExacta;
    }
}