namespace ControlPrestamos.Formularios
{
    partial class formLimpiar
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TBprestamos = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TXTfechafin = new System.Windows.Forms.TextBox();
            this.TXTfechaini = new System.Windows.Forms.TextBox();
            this.TXTsaldo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TXTvalorcuota = new System.Windows.Forms.TextBox();
            this.TXTnumcuotas = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TXTtotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TXTporcent = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TXTvalor = new System.Windows.Forms.TextBox();
            this.LBLcodigo = new System.Windows.Forms.Label();
            this.TBclientes = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label14 = new System.Windows.Forms.Label();
            this.TXTcedula = new System.Windows.Forms.TextBox();
            this.TXTnombre = new System.Windows.Forms.TextBox();
            this.TXTdireccion = new System.Windows.Forms.TextBox();
            this.TXTbarrio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TXTtelefono = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.TXTbuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TBprestamos.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.TBclientes.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(431, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::ControlPrestamos.Properties.Resources.btn_Cancel;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(116, 22);
            this.toolStripButton1.Text = "Eliminar Registro";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TBprestamos);
            this.tabControl1.Controls.Add(this.TBclientes);
            this.tabControl1.Location = new System.Drawing.Point(12, 78);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(411, 334);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseClick);
            // 
            // TBprestamos
            // 
            this.TBprestamos.Controls.Add(this.groupBox3);
            this.TBprestamos.Controls.Add(this.LBLcodigo);
            this.TBprestamos.Location = new System.Drawing.Point(4, 22);
            this.TBprestamos.Name = "TBprestamos";
            this.TBprestamos.Padding = new System.Windows.Forms.Padding(3);
            this.TBprestamos.Size = new System.Drawing.Size(403, 308);
            this.TBprestamos.TabIndex = 0;
            this.TBprestamos.Text = "Prestamos";
            this.TBprestamos.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TXTfechafin);
            this.groupBox3.Controls.Add(this.TXTfechaini);
            this.groupBox3.Controls.Add(this.TXTsaldo);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.TXTvalorcuota);
            this.groupBox3.Controls.Add(this.TXTnumcuotas);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.TXTtotal);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.TXTporcent);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.TXTvalor);
            this.groupBox3.Location = new System.Drawing.Point(6, 34);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(392, 177);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos del Prestamo";
            // 
            // TXTfechafin
            // 
            this.TXTfechafin.Location = new System.Drawing.Point(281, 126);
            this.TXTfechafin.Name = "TXTfechafin";
            this.TXTfechafin.Size = new System.Drawing.Size(100, 20);
            this.TXTfechafin.TabIndex = 13;
            // 
            // TXTfechaini
            // 
            this.TXTfechaini.Location = new System.Drawing.Point(80, 126);
            this.TXTfechaini.Name = "TXTfechaini";
            this.TXTfechaini.Size = new System.Drawing.Size(100, 20);
            this.TXTfechaini.TabIndex = 13;
            // 
            // TXTsaldo
            // 
            this.TXTsaldo.BackColor = System.Drawing.SystemColors.Window;
            this.TXTsaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTsaldo.ForeColor = System.Drawing.Color.Maroon;
            this.TXTsaldo.Location = new System.Drawing.Point(301, 77);
            this.TXTsaldo.Name = "TXTsaldo";
            this.TXTsaldo.ReadOnly = true;
            this.TXTsaldo.Size = new System.Drawing.Size(80, 20);
            this.TXTsaldo.TabIndex = 12;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(258, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 13);
            this.label15.TabIndex = 11;
            this.label15.Text = "Saldo:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(205, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Valor de la Cuota:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(197, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Numero de Cuotas:";
            // 
            // TXTvalorcuota
            // 
            this.TXTvalorcuota.BackColor = System.Drawing.SystemColors.Window;
            this.TXTvalorcuota.Location = new System.Drawing.Point(301, 48);
            this.TXTvalorcuota.Name = "TXTvalorcuota";
            this.TXTvalorcuota.ReadOnly = true;
            this.TXTvalorcuota.Size = new System.Drawing.Size(80, 20);
            this.TXTvalorcuota.TabIndex = 8;
            // 
            // TXTnumcuotas
            // 
            this.TXTnumcuotas.BackColor = System.Drawing.SystemColors.Window;
            this.TXTnumcuotas.Location = new System.Drawing.Point(301, 22);
            this.TXTnumcuotas.Name = "TXTnumcuotas";
            this.TXTnumcuotas.ReadOnly = true;
            this.TXTnumcuotas.Size = new System.Drawing.Size(40, 20);
            this.TXTnumcuotas.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Fecha Inicial:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(210, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Fecha Final:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Total:";
            // 
            // TXTtotal
            // 
            this.TXTtotal.BackColor = System.Drawing.SystemColors.Window;
            this.TXTtotal.Location = new System.Drawing.Point(80, 74);
            this.TXTtotal.Name = "TXTtotal";
            this.TXTtotal.ReadOnly = true;
            this.TXTtotal.Size = new System.Drawing.Size(97, 20);
            this.TXTtotal.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Porcentaje:";
            // 
            // TXTporcent
            // 
            this.TXTporcent.BackColor = System.Drawing.SystemColors.Window;
            this.TXTporcent.Location = new System.Drawing.Point(80, 48);
            this.TXTporcent.Name = "TXTporcent";
            this.TXTporcent.ReadOnly = true;
            this.TXTporcent.Size = new System.Drawing.Size(39, 20);
            this.TXTporcent.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Valor:";
            // 
            // TXTvalor
            // 
            this.TXTvalor.BackColor = System.Drawing.SystemColors.Window;
            this.TXTvalor.Location = new System.Drawing.Point(80, 22);
            this.TXTvalor.Name = "TXTvalor";
            this.TXTvalor.ReadOnly = true;
            this.TXTvalor.Size = new System.Drawing.Size(97, 20);
            this.TXTvalor.TabIndex = 0;
            // 
            // LBLcodigo
            // 
            this.LBLcodigo.AutoSize = true;
            this.LBLcodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLcodigo.ForeColor = System.Drawing.Color.Maroon;
            this.LBLcodigo.Location = new System.Drawing.Point(338, 9);
            this.LBLcodigo.Name = "LBLcodigo";
            this.LBLcodigo.Size = new System.Drawing.Size(60, 25);
            this.LBLcodigo.TabIndex = 7;
            this.LBLcodigo.Text = "0000";
            // 
            // TBclientes
            // 
            this.TBclientes.Controls.Add(this.groupBox2);
            this.TBclientes.Location = new System.Drawing.Point(4, 22);
            this.TBclientes.Name = "TBclientes";
            this.TBclientes.Padding = new System.Windows.Forms.Padding(3);
            this.TBclientes.Size = new System.Drawing.Size(403, 308);
            this.TBclientes.TabIndex = 1;
            this.TBclientes.Text = "Clientes";
            this.TBclientes.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.TXTcedula);
            this.groupBox2.Controls.Add(this.TXTnombre);
            this.groupBox2.Controls.Add(this.TXTdireccion);
            this.groupBox2.Controls.Add(this.TXTbarrio);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.TXTtelefono);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(6, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(391, 257);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del Cliente";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(286, 139);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(72, 108);
            this.listBox1.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(219, 138);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "Prestamos:";
            // 
            // TXTcedula
            // 
            this.TXTcedula.BackColor = System.Drawing.SystemColors.Window;
            this.TXTcedula.Location = new System.Drawing.Point(79, 53);
            this.TXTcedula.Name = "TXTcedula";
            this.TXTcedula.ReadOnly = true;
            this.TXTcedula.Size = new System.Drawing.Size(100, 20);
            this.TXTcedula.TabIndex = 0;
            // 
            // TXTnombre
            // 
            this.TXTnombre.BackColor = System.Drawing.SystemColors.Window;
            this.TXTnombre.Location = new System.Drawing.Point(79, 27);
            this.TXTnombre.Name = "TXTnombre";
            this.TXTnombre.ReadOnly = true;
            this.TXTnombre.Size = new System.Drawing.Size(227, 20);
            this.TXTnombre.TabIndex = 0;
            // 
            // TXTdireccion
            // 
            this.TXTdireccion.BackColor = System.Drawing.SystemColors.Window;
            this.TXTdireccion.Location = new System.Drawing.Point(79, 79);
            this.TXTdireccion.Name = "TXTdireccion";
            this.TXTdireccion.ReadOnly = true;
            this.TXTdireccion.Size = new System.Drawing.Size(277, 20);
            this.TXTdireccion.TabIndex = 0;
            // 
            // TXTbarrio
            // 
            this.TXTbarrio.BackColor = System.Drawing.SystemColors.Window;
            this.TXTbarrio.Location = new System.Drawing.Point(79, 105);
            this.TXTbarrio.Name = "TXTbarrio";
            this.TXTbarrio.ReadOnly = true;
            this.TXTbarrio.Size = new System.Drawing.Size(227, 20);
            this.TXTbarrio.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Telefono:";
            // 
            // TXTtelefono
            // 
            this.TXTtelefono.BackColor = System.Drawing.SystemColors.Window;
            this.TXTtelefono.Location = new System.Drawing.Point(79, 131);
            this.TXTtelefono.Name = "TXTtelefono";
            this.TXTtelefono.ReadOnly = true;
            this.TXTtelefono.Size = new System.Drawing.Size(100, 20);
            this.TXTtelefono.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Barrio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Direccion:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Cedula:";
            // 
            // TXTbuscar
            // 
            this.TXTbuscar.Location = new System.Drawing.Point(111, 12);
            this.TXTbuscar.Name = "TXTbuscar";
            this.TXTbuscar.Size = new System.Drawing.Size(100, 20);
            this.TXTbuscar.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Codigo de Prestamo:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TXTbuscar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 37);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Image = global::ControlPrestamos.Properties.Resources.FilePreview;
            this.button1.Location = new System.Drawing.Point(212, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 23);
            this.button1.TabIndex = 9;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(337, 462);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Salir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // formLimpiar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 497);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.Name = "formLimpiar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eliminacion Segura";
            this.Load += new System.EventHandler(this.formLimpiar_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.TBprestamos.ResumeLayout(false);
            this.TBprestamos.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.TBclientes.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TBprestamos;
        private System.Windows.Forms.TabPage TBclientes;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TXTsaldo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TXTvalorcuota;
        private System.Windows.Forms.TextBox TXTnumcuotas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TXTtotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TXTporcent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TXTvalor;
        private System.Windows.Forms.Label LBLcodigo;
        private System.Windows.Forms.TextBox TXTfechafin;
        private System.Windows.Forms.TextBox TXTfechaini;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox TXTbuscar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TXTcedula;
        private System.Windows.Forms.TextBox TXTnombre;
        private System.Windows.Forms.TextBox TXTdireccion;
        private System.Windows.Forms.TextBox TXTbarrio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TXTtelefono;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button button1;
    }
}