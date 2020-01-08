namespace ControlPrestamos.Formularios
{
    partial class formInformes
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
            this.LSTinformes = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.CBtrabajadores = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chcktodoscobra = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpinicio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpfinal = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LSTinformes
            // 
            this.LSTinformes.FormattingEnabled = true;
            this.LSTinformes.Location = new System.Drawing.Point(7, 16);
            this.LSTinformes.Name = "LSTinformes";
            this.LSTinformes.Size = new System.Drawing.Size(239, 95);
            this.LSTinformes.TabIndex = 0;
            this.LSTinformes.SelectedIndexChanged += new System.EventHandler(this.LSTinformes_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LSTinformes);
            this.groupBox1.Location = new System.Drawing.Point(8, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 120);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione el informe a abrir";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 46);
            this.button1.TabIndex = 2;
            this.button1.Text = "Imprimir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CBtrabajadores
            // 
            this.CBtrabajadores.FormattingEnabled = true;
            this.CBtrabajadores.Location = new System.Drawing.Point(339, 12);
            this.CBtrabajadores.Name = "CBtrabajadores";
            this.CBtrabajadores.Size = new System.Drawing.Size(181, 21);
            this.CBtrabajadores.TabIndex = 12;
            this.CBtrabajadores.Text = "<Seleccione Uno>";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(280, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Persona:";
            // 
            // chcktodoscobra
            // 
            this.chcktodoscobra.AutoSize = true;
            this.chcktodoscobra.Location = new System.Drawing.Point(121, 63);
            this.chcktodoscobra.Name = "chcktodoscobra";
            this.chcktodoscobra.Size = new System.Drawing.Size(128, 17);
            this.chcktodoscobra.TabIndex = 13;
            this.chcktodoscobra.Text = "Todos los cobradores";
            this.chcktodoscobra.UseVisualStyleBackColor = true;
            this.chcktodoscobra.CheckedChanged += new System.EventHandler(this.chcktodoscobra_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.chcktodoscobra);
            this.groupBox2.Controls.Add(this.dtpfinal);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtpinicio);
            this.groupBox2.Location = new System.Drawing.Point(267, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 91);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            // 
            // dtpinicio
            // 
            this.dtpinicio.Enabled = false;
            this.dtpinicio.Location = new System.Drawing.Point(47, 14);
            this.dtpinicio.Name = "dtpinicio";
            this.dtpinicio.Size = new System.Drawing.Size(200, 20);
            this.dtpinicio.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Desde:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Hasta:";
            // 
            // dtpfinal
            // 
            this.dtpfinal.Enabled = false;
            this.dtpfinal.Location = new System.Drawing.Point(47, 37);
            this.dtpfinal.Name = "dtpfinal";
            this.dtpfinal.Size = new System.Drawing.Size(200, 20);
            this.dtpfinal.TabIndex = 14;
            // 
            // formInformes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 185);
            this.Controls.Add(this.CBtrabajadores);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formInformes";
            this.Text = "formInformes";
            this.Load += new System.EventHandler(this.formInformes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LSTinformes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox CBtrabajadores;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chcktodoscobra;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpinicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpfinal;
    }
}