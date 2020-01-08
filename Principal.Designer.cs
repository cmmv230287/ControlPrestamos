namespace ControlPrestamos
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.procesosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarPrestamosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirInformesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarGastosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarPersonasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elimiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.organizarIndicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDePagoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoCuotasPorDiasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 620);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(888, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = global::ControlPrestamos.Properties.Resources.User;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(69, 17);
            this.toolStripStatusLabel1.Text = "Usuario: ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.procesosToolStripMenuItem,
            this.herramientasToolStripMenuItem,
            this.configuracionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(888, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Image = global::ControlPrestamos.Properties.Resources.btn_Cancel;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // procesosToolStripMenuItem
            // 
            this.procesosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarPrestamosToolStripMenuItem,
            this.imprimirInformesToolStripMenuItem,
            this.registrarGastosToolStripMenuItem,
            this.registrarPersonasToolStripMenuItem,
            this.listadoCuotasPorDiasToolStripMenuItem});
            this.procesosToolStripMenuItem.Name = "procesosToolStripMenuItem";
            this.procesosToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.procesosToolStripMenuItem.Text = "Procesos";
            // 
            // administrarPrestamosToolStripMenuItem
            // 
            this.administrarPrestamosToolStripMenuItem.Image = global::ControlPrestamos.Properties.Resources.Money_128x128;
            this.administrarPrestamosToolStripMenuItem.Name = "administrarPrestamosToolStripMenuItem";
            this.administrarPrestamosToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.administrarPrestamosToolStripMenuItem.Text = "Administrar Prestamos";
            this.administrarPrestamosToolStripMenuItem.Click += new System.EventHandler(this.administrarPrestamosToolStripMenuItem_Click);
            // 
            // imprimirInformesToolStripMenuItem
            // 
            this.imprimirInformesToolStripMenuItem.Image = global::ControlPrestamos.Properties.Resources.Report1;
            this.imprimirInformesToolStripMenuItem.Name = "imprimirInformesToolStripMenuItem";
            this.imprimirInformesToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.imprimirInformesToolStripMenuItem.Text = "Imprimir Informes";
            this.imprimirInformesToolStripMenuItem.Click += new System.EventHandler(this.imprimirInformesToolStripMenuItem_Click);
            // 
            // registrarGastosToolStripMenuItem
            // 
            this.registrarGastosToolStripMenuItem.Name = "registrarGastosToolStripMenuItem";
            this.registrarGastosToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.registrarGastosToolStripMenuItem.Text = "Registrar Gastos";
            this.registrarGastosToolStripMenuItem.Click += new System.EventHandler(this.registrarGastosToolStripMenuItem_Click);
            // 
            // registrarPersonasToolStripMenuItem
            // 
            this.registrarPersonasToolStripMenuItem.Name = "registrarPersonasToolStripMenuItem";
            this.registrarPersonasToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.registrarPersonasToolStripMenuItem.Text = "Registrar Personas";
            this.registrarPersonasToolStripMenuItem.Click += new System.EventHandler(this.registrarPersonasToolStripMenuItem_Click);
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.elimiToolStripMenuItem,
            this.importarClientesToolStripMenuItem,
            this.organizarIndicesToolStripMenuItem});
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // elimiToolStripMenuItem
            // 
            this.elimiToolStripMenuItem.Image = global::ControlPrestamos.Properties.Resources.canda16_xp;
            this.elimiToolStripMenuItem.Name = "elimiToolStripMenuItem";
            this.elimiToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.elimiToolStripMenuItem.Text = "Eliminacion Segura";
            this.elimiToolStripMenuItem.Click += new System.EventHandler(this.elimiToolStripMenuItem_Click);
            // 
            // importarClientesToolStripMenuItem
            // 
            this.importarClientesToolStripMenuItem.Image = global::ControlPrestamos.Properties.Resources.btn_databases_bg;
            this.importarClientesToolStripMenuItem.Name = "importarClientesToolStripMenuItem";
            this.importarClientesToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.importarClientesToolStripMenuItem.Text = "Importar Clientes";
            this.importarClientesToolStripMenuItem.Visible = false;
            this.importarClientesToolStripMenuItem.Click += new System.EventHandler(this.importarClientesToolStripMenuItem_Click);
            // 
            // organizarIndicesToolStripMenuItem
            // 
            this.organizarIndicesToolStripMenuItem.Image = global::ControlPrestamos.Properties.Resources.EditReplace1;
            this.organizarIndicesToolStripMenuItem.Name = "organizarIndicesToolStripMenuItem";
            this.organizarIndicesToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.organizarIndicesToolStripMenuItem.Text = "Organizar Indices";
            this.organizarIndicesToolStripMenuItem.Click += new System.EventHandler(this.organizarIndicesToolStripMenuItem_Click);
            // 
            // configuracionToolStripMenuItem
            // 
            this.configuracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tiposDePagoToolStripMenuItem,
            this.cuentaToolStripMenuItem});
            this.configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
            this.configuracionToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.configuracionToolStripMenuItem.Text = "Configuracion";
            this.configuracionToolStripMenuItem.Click += new System.EventHandler(this.configuracionToolStripMenuItem_Click);
            // 
            // tiposDePagoToolStripMenuItem
            // 
            this.tiposDePagoToolStripMenuItem.Name = "tiposDePagoToolStripMenuItem";
            this.tiposDePagoToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.tiposDePagoToolStripMenuItem.Text = "Tipos de Pago";
            this.tiposDePagoToolStripMenuItem.Click += new System.EventHandler(this.tiposDePagoToolStripMenuItem_Click);
            // 
            // cuentaToolStripMenuItem
            // 
            this.cuentaToolStripMenuItem.Name = "cuentaToolStripMenuItem";
            this.cuentaToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.cuentaToolStripMenuItem.Text = "Acceso";
            this.cuentaToolStripMenuItem.Click += new System.EventHandler(this.cuentaToolStripMenuItem_Click);
            // 
            // listadoCuotasPorDiasToolStripMenuItem
            // 
            this.listadoCuotasPorDiasToolStripMenuItem.Name = "listadoCuotasPorDiasToolStripMenuItem";
            this.listadoCuotasPorDiasToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.listadoCuotasPorDiasToolStripMenuItem.Text = "Listado Cuotas por Dias";
            this.listadoCuotasPorDiasToolStripMenuItem.Click += new System.EventHandler(this.listadoCuotasPorDiasToolStripMenuItem_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(888, 642);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.Text = "Control de Prestamos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Principal_FormClosing_1);
            this.Load += new System.EventHandler(this.Principal_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem procesosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarPrestamosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirInformesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem elimiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem organizarIndicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarGastosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarPersonasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDePagoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoCuotasPorDiasToolStripMenuItem;
    }
}

