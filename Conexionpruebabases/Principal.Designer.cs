namespace Conexionpruebabases
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consulta1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consulta2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consulta3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consulta4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porcentajeDeProductosVendidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertarProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertarVentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarContadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contadorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compraToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contadorToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedorToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.verInformacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.productoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.compraToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.contadorToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedorToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Palatino Linotype", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultasToolStripMenuItem,
            this.mantenimientosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(882, 28);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consulta1ToolStripMenuItem,
            this.consulta2ToolStripMenuItem,
            this.consulta3ToolStripMenuItem,
            this.consulta4ToolStripMenuItem,
            this.porcentajeDeProductosVendidosToolStripMenuItem});
            this.consultasToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(88, 26);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // consulta1ToolStripMenuItem
            // 
            this.consulta1ToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consulta1ToolStripMenuItem.Name = "consulta1ToolStripMenuItem";
            this.consulta1ToolStripMenuItem.Size = new System.Drawing.Size(417, 24);
            this.consulta1ToolStripMenuItem.Text = "Promedio compras mensual";
            this.consulta1ToolStripMenuItem.Click += new System.EventHandler(this.consulta1ToolStripMenuItem_Click);
            // 
            // consulta2ToolStripMenuItem
            // 
            this.consulta2ToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consulta2ToolStripMenuItem.Name = "consulta2ToolStripMenuItem";
            this.consulta2ToolStripMenuItem.Size = new System.Drawing.Size(417, 24);
            this.consulta2ToolStripMenuItem.Text = "Producto más comprado por un cliente";
            // 
            // consulta3ToolStripMenuItem
            // 
            this.consulta3ToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consulta3ToolStripMenuItem.Name = "consulta3ToolStripMenuItem";
            this.consulta3ToolStripMenuItem.Size = new System.Drawing.Size(417, 24);
            this.consulta3ToolStripMenuItem.Text = "Los mejores 3 clientes del último año";
            // 
            // consulta4ToolStripMenuItem
            // 
            this.consulta4ToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consulta4ToolStripMenuItem.Name = "consulta4ToolStripMenuItem";
            this.consulta4ToolStripMenuItem.Size = new System.Drawing.Size(417, 24);
            this.consulta4ToolStripMenuItem.Text = "Producto menos comprado";
            // 
            // porcentajeDeProductosVendidosToolStripMenuItem
            // 
            this.porcentajeDeProductosVendidosToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.porcentajeDeProductosVendidosToolStripMenuItem.Name = "porcentajeDeProductosVendidosToolStripMenuItem";
            this.porcentajeDeProductosVendidosToolStripMenuItem.Size = new System.Drawing.Size(417, 24);
            this.porcentajeDeProductosVendidosToolStripMenuItem.Text = "Porcentaje de productos vendidos de un proveedor";
            this.porcentajeDeProductosVendidosToolStripMenuItem.Click += new System.EventHandler(this.porcentajeDeProductosVendidosToolStripMenuItem_Click);
            // 
            // mantenimientosToolStripMenuItem
            // 
            this.mantenimientosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertarToolStripMenuItem,
            this.modificarToolStripMenuItem,
            this.borrarToolStripMenuItem,
            this.verInformacionToolStripMenuItem});
            this.mantenimientosToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mantenimientosToolStripMenuItem.Name = "mantenimientosToolStripMenuItem";
            this.mantenimientosToolStripMenuItem.Size = new System.Drawing.Size(132, 26);
            this.mantenimientosToolStripMenuItem.Text = "Mantenimientos";
            // 
            // insertarToolStripMenuItem
            // 
            this.insertarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertarClienteToolStripMenuItem,
            this.insertarProductoToolStripMenuItem,
            this.insertarVentaToolStripMenuItem,
            this.contadorToolStripMenuItem,
            this.proveedorToolStripMenuItem});
            this.insertarToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertarToolStripMenuItem.Name = "insertarToolStripMenuItem";
            this.insertarToolStripMenuItem.Size = new System.Drawing.Size(187, 24);
            this.insertarToolStripMenuItem.Text = "Insertar";
            // 
            // insertarClienteToolStripMenuItem
            // 
            this.insertarClienteToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertarClienteToolStripMenuItem.Name = "insertarClienteToolStripMenuItem";
            this.insertarClienteToolStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.insertarClienteToolStripMenuItem.Text = "Cliente";
            this.insertarClienteToolStripMenuItem.Click += new System.EventHandler(this.insertarClienteToolStripMenuItem_Click);
            // 
            // insertarProductoToolStripMenuItem
            // 
            this.insertarProductoToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertarProductoToolStripMenuItem.Name = "insertarProductoToolStripMenuItem";
            this.insertarProductoToolStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.insertarProductoToolStripMenuItem.Text = "Producto";
            this.insertarProductoToolStripMenuItem.Click += new System.EventHandler(this.insertarProductoToolStripMenuItem_Click);
            // 
            // insertarVentaToolStripMenuItem
            // 
            this.insertarVentaToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertarVentaToolStripMenuItem.Name = "insertarVentaToolStripMenuItem";
            this.insertarVentaToolStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.insertarVentaToolStripMenuItem.Text = "Compra";
            // 
            // contadorToolStripMenuItem
            // 
            this.contadorToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contadorToolStripMenuItem.Name = "contadorToolStripMenuItem";
            this.contadorToolStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.contadorToolStripMenuItem.Text = "Contador";
            // 
            // proveedorToolStripMenuItem
            // 
            this.proveedorToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proveedorToolStripMenuItem.Name = "proveedorToolStripMenuItem";
            this.proveedorToolStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.proveedorToolStripMenuItem.Text = "Proveedor";
            this.proveedorToolStripMenuItem.Click += new System.EventHandler(this.proveedorToolStripMenuItem_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificarClienteToolStripMenuItem,
            this.modificarContadorToolStripMenuItem,
            this.compraToolStripMenuItem,
            this.contadorToolStripMenuItem1,
            this.proveedorToolStripMenuItem1});
            this.modificarToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(187, 24);
            this.modificarToolStripMenuItem.Text = "Modificar";
            // 
            // modificarClienteToolStripMenuItem
            // 
            this.modificarClienteToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificarClienteToolStripMenuItem.Name = "modificarClienteToolStripMenuItem";
            this.modificarClienteToolStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.modificarClienteToolStripMenuItem.Text = "Cliente";
            this.modificarClienteToolStripMenuItem.Click += new System.EventHandler(this.modificarClienteToolStripMenuItem_Click);
            // 
            // modificarContadorToolStripMenuItem
            // 
            this.modificarContadorToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificarContadorToolStripMenuItem.Name = "modificarContadorToolStripMenuItem";
            this.modificarContadorToolStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.modificarContadorToolStripMenuItem.Text = "Producto";
            this.modificarContadorToolStripMenuItem.Click += new System.EventHandler(this.modificarContadorToolStripMenuItem_Click);
            // 
            // compraToolStripMenuItem
            // 
            this.compraToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compraToolStripMenuItem.Name = "compraToolStripMenuItem";
            this.compraToolStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.compraToolStripMenuItem.Text = "Compra";
            // 
            // contadorToolStripMenuItem1
            // 
            this.contadorToolStripMenuItem1.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contadorToolStripMenuItem1.Name = "contadorToolStripMenuItem1";
            this.contadorToolStripMenuItem1.Size = new System.Drawing.Size(146, 24);
            this.contadorToolStripMenuItem1.Text = "Contador";
            // 
            // proveedorToolStripMenuItem1
            // 
            this.proveedorToolStripMenuItem1.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proveedorToolStripMenuItem1.Name = "proveedorToolStripMenuItem1";
            this.proveedorToolStripMenuItem1.Size = new System.Drawing.Size(146, 24);
            this.proveedorToolStripMenuItem1.Text = "Proveedor";
            // 
            // borrarToolStripMenuItem
            // 
            this.borrarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clienteToolStripMenuItem,
            this.productoToolStripMenuItem,
            this.compraToolStripMenuItem1,
            this.contadorToolStripMenuItem2,
            this.proveedorToolStripMenuItem2});
            this.borrarToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.borrarToolStripMenuItem.Name = "borrarToolStripMenuItem";
            this.borrarToolStripMenuItem.Size = new System.Drawing.Size(187, 24);
            this.borrarToolStripMenuItem.Text = "Borrar";
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.clienteToolStripMenuItem.Text = "Cliente";
            this.clienteToolStripMenuItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // productoToolStripMenuItem
            // 
            this.productoToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productoToolStripMenuItem.Name = "productoToolStripMenuItem";
            this.productoToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.productoToolStripMenuItem.Text = "Producto";
            // 
            // compraToolStripMenuItem1
            // 
            this.compraToolStripMenuItem1.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compraToolStripMenuItem1.Name = "compraToolStripMenuItem1";
            this.compraToolStripMenuItem1.Size = new System.Drawing.Size(152, 24);
            this.compraToolStripMenuItem1.Text = "Compra";
            // 
            // contadorToolStripMenuItem2
            // 
            this.contadorToolStripMenuItem2.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contadorToolStripMenuItem2.Name = "contadorToolStripMenuItem2";
            this.contadorToolStripMenuItem2.Size = new System.Drawing.Size(152, 24);
            this.contadorToolStripMenuItem2.Text = "Contador";
            this.contadorToolStripMenuItem2.Click += new System.EventHandler(this.contadorToolStripMenuItem2_Click);
            // 
            // proveedorToolStripMenuItem2
            // 
            this.proveedorToolStripMenuItem2.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proveedorToolStripMenuItem2.Name = "proveedorToolStripMenuItem2";
            this.proveedorToolStripMenuItem2.Size = new System.Drawing.Size(152, 24);
            this.proveedorToolStripMenuItem2.Text = "Proveedor";
            this.proveedorToolStripMenuItem2.Click += new System.EventHandler(this.proveedorToolStripMenuItem2_Click);
            // 
            // verInformacionToolStripMenuItem
            // 
            this.verInformacionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clienteToolStripMenuItem1,
            this.productoToolStripMenuItem1,
            this.compraToolStripMenuItem2,
            this.contadorToolStripMenuItem3,
            this.proveedorToolStripMenuItem3});
            this.verInformacionToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verInformacionToolStripMenuItem.Name = "verInformacionToolStripMenuItem";
            this.verInformacionToolStripMenuItem.Size = new System.Drawing.Size(187, 24);
            this.verInformacionToolStripMenuItem.Text = "Ver informacion";
            // 
            // clienteToolStripMenuItem1
            // 
            this.clienteToolStripMenuItem1.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clienteToolStripMenuItem1.Name = "clienteToolStripMenuItem1";
            this.clienteToolStripMenuItem1.Size = new System.Drawing.Size(146, 24);
            this.clienteToolStripMenuItem1.Text = "Cliente";
            // 
            // productoToolStripMenuItem1
            // 
            this.productoToolStripMenuItem1.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productoToolStripMenuItem1.Name = "productoToolStripMenuItem1";
            this.productoToolStripMenuItem1.Size = new System.Drawing.Size(146, 24);
            this.productoToolStripMenuItem1.Text = "Producto";
            // 
            // compraToolStripMenuItem2
            // 
            this.compraToolStripMenuItem2.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compraToolStripMenuItem2.Name = "compraToolStripMenuItem2";
            this.compraToolStripMenuItem2.Size = new System.Drawing.Size(146, 24);
            this.compraToolStripMenuItem2.Text = "Compra";
            // 
            // contadorToolStripMenuItem3
            // 
            this.contadorToolStripMenuItem3.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contadorToolStripMenuItem3.Name = "contadorToolStripMenuItem3";
            this.contadorToolStripMenuItem3.Size = new System.Drawing.Size(146, 24);
            this.contadorToolStripMenuItem3.Text = "Contador";
            // 
            // proveedorToolStripMenuItem3
            // 
            this.proveedorToolStripMenuItem3.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proveedorToolStripMenuItem3.Name = "proveedorToolStripMenuItem3";
            this.proveedorToolStripMenuItem3.Size = new System.Drawing.Size(146, 24);
            this.proveedorToolStripMenuItem3.Text = "Proveedor";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(882, 414);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Principal";
            this.Text = "Menu Principal Mi K-fe";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consulta1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consulta2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consulta3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consulta4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mantenimientosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertarClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertarProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertarVentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarContadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verInformacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contadorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem proveedorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compraToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem contadorToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem proveedorToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem productoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem compraToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem contadorToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem proveedorToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem porcentajeDeProductosVendidosToolStripMenuItem;
    }
}

