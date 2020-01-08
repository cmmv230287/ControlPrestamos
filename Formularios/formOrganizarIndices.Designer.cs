namespace ControlPrestamos.Formularios
{
    partial class formOrganizarIndices
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.dgvindices = new System.Windows.Forms.DataGridView();
            this.numindice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codindice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_cobrador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eliminarIndiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CBtrabajadores = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CHKinserccion = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TXTcodigo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvindices)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.dgvindices);
            this.groupBox1.Location = new System.Drawing.Point(5, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 336);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Indices Oreganizados";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(262, 15);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(64, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Reorganizar";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // dgvindices
            // 
            this.dgvindices.AllowUserToAddRows = false;
            this.dgvindices.AllowUserToDeleteRows = false;
            this.dgvindices.AllowUserToResizeRows = false;
            this.dgvindices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvindices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvindices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numindice,
            this.codindice,
            this.c_cobrador});
            this.dgvindices.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvindices.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvindices.Location = new System.Drawing.Point(6, 31);
            this.dgvindices.Name = "dgvindices";
            this.dgvindices.ReadOnly = true;
            this.dgvindices.RowHeadersVisible = false;
            this.dgvindices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvindices.Size = new System.Drawing.Size(320, 299);
            this.dgvindices.TabIndex = 0;
            this.dgvindices.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvindices_CellMouseClick);
            // 
            // numindice
            // 
            this.numindice.HeaderText = "Indice";
            this.numindice.Name = "numindice";
            this.numindice.ReadOnly = true;
            this.numindice.Width = 50;
            // 
            // codindice
            // 
            this.codindice.HeaderText = "Codigo de Prestamo";
            this.codindice.Name = "codindice";
            this.codindice.ReadOnly = true;
            this.codindice.Width = 130;
            // 
            // c_cobrador
            // 
            this.c_cobrador.HeaderText = "Cobrador";
            this.c_cobrador.Name = "c_cobrador";
            this.c_cobrador.ReadOnly = true;
            this.c_cobrador.Width = 150;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarIndiceToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 26);
            // 
            // eliminarIndiceToolStripMenuItem
            // 
            this.eliminarIndiceToolStripMenuItem.Name = "eliminarIndiceToolStripMenuItem";
            this.eliminarIndiceToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.eliminarIndiceToolStripMenuItem.Text = "Eliminar Indice";
            this.eliminarIndiceToolStripMenuItem.Click += new System.EventHandler(this.eliminarIndiceToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CBtrabajadores);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.CHKinserccion);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.TXTcodigo);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(5, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(333, 82);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Acciones Sobre Indices";
            // 
            // CBtrabajadores
            // 
            this.CBtrabajadores.FormattingEnabled = true;
            this.CBtrabajadores.Location = new System.Drawing.Point(57, 53);
            this.CBtrabajadores.Name = "CBtrabajadores";
            this.CBtrabajadores.Size = new System.Drawing.Size(171, 21);
            this.CBtrabajadores.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Cobrador:";
            // 
            // CHKinserccion
            // 
            this.CHKinserccion.AutoSize = true;
            this.CHKinserccion.Location = new System.Drawing.Point(110, 21);
            this.CHKinserccion.Name = "CHKinserccion";
            this.CHKinserccion.Size = new System.Drawing.Size(118, 17);
            this.CHKinserccion.TabIndex = 3;
            this.CHKinserccion.Text = "Inserccion Especial";
            this.CHKinserccion.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Codigo:";
            // 
            // TXTcodigo
            // 
            this.TXTcodigo.Location = new System.Drawing.Point(57, 19);
            this.TXTcodigo.Name = "TXTcodigo";
            this.TXTcodigo.Size = new System.Drawing.Size(47, 20);
            this.TXTcodigo.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(287, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = ">>>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // formOrganizarIndices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 440);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "formOrganizarIndices";
            this.Text = "OrganizarIndices";
            this.Load += new System.EventHandler(this.formOrganizarIndices_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvindices)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvindices;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TXTcodigo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox CHKinserccion;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem eliminarIndiceToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ComboBox CBtrabajadores;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn numindice;
        private System.Windows.Forms.DataGridViewTextBoxColumn codindice;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_cobrador;
    }
}