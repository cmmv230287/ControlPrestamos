namespace ControlPrestamos.Formularios
{
    partial class formGastos
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TXTpersona = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TXTconcepto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TXTvalor = new System.Windows.Forms.TextBox();
            this.LSTpersonas = new System.Windows.Forms.ListBox();
            this.bttnguardar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bttnnuevo = new System.Windows.Forms.Button();
            this.DTPfechagasto = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TXTpersona);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TXTconcepto);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TXTvalor);
            this.groupBox1.Location = new System.Drawing.Point(12, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 210);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del gasto";
            // 
            // TXTpersona
            // 
            this.TXTpersona.BackColor = System.Drawing.SystemColors.Window;
            this.TXTpersona.Location = new System.Drawing.Point(91, 55);
            this.TXTpersona.Name = "TXTpersona";
            this.TXTpersona.ReadOnly = true;
            this.TXTpersona.Size = new System.Drawing.Size(143, 20);
            this.TXTpersona.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cargar a:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Concepto:";
            // 
            // TXTconcepto
            // 
            this.TXTconcepto.Location = new System.Drawing.Point(91, 98);
            this.TXTconcepto.Multiline = true;
            this.TXTconcepto.Name = "TXTconcepto";
            this.TXTconcepto.Size = new System.Drawing.Size(227, 97);
            this.TXTconcepto.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Valor del Gasto:";
            // 
            // TXTvalor
            // 
            this.TXTvalor.Location = new System.Drawing.Point(91, 19);
            this.TXTvalor.Name = "TXTvalor";
            this.TXTvalor.Size = new System.Drawing.Size(113, 20);
            this.TXTvalor.TabIndex = 0;
            // 
            // LSTpersonas
            // 
            this.LSTpersonas.FormattingEnabled = true;
            this.LSTpersonas.Location = new System.Drawing.Point(350, 81);
            this.LSTpersonas.Name = "LSTpersonas";
            this.LSTpersonas.Size = new System.Drawing.Size(206, 199);
            this.LSTpersonas.TabIndex = 1;
            this.LSTpersonas.SelectedIndexChanged += new System.EventHandler(this.LSTpersonas_SelectedIndexChanged);
            // 
            // bttnguardar
            // 
            this.bttnguardar.Image = global::ControlPrestamos.Properties.Resources.FileSave;
            this.bttnguardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bttnguardar.Location = new System.Drawing.Point(5, 9);
            this.bttnguardar.Name = "bttnguardar";
            this.bttnguardar.Size = new System.Drawing.Size(56, 44);
            this.bttnguardar.TabIndex = 2;
            this.bttnguardar.Text = "Guardar";
            this.bttnguardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bttnguardar.UseVisualStyleBackColor = true;
            this.bttnguardar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(348, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Lista de Personas";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bttnnuevo);
            this.groupBox2.Controls.Add(this.bttnguardar);
            this.groupBox2.Location = new System.Drawing.Point(12, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(332, 56);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // bttnnuevo
            // 
            this.bttnnuevo.Image = global::ControlPrestamos.Properties.Resources.FileNew;
            this.bttnnuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bttnnuevo.Location = new System.Drawing.Point(67, 9);
            this.bttnnuevo.Name = "bttnnuevo";
            this.bttnnuevo.Size = new System.Drawing.Size(56, 44);
            this.bttnnuevo.TabIndex = 2;
            this.bttnnuevo.Text = "Nuevo";
            this.bttnnuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bttnnuevo.UseVisualStyleBackColor = true;
            this.bttnnuevo.Click += new System.EventHandler(this.bttnnuevo_Click);
            // 
            // DTPfechagasto
            // 
            this.DTPfechagasto.Location = new System.Drawing.Point(356, 15);
            this.DTPfechagasto.Name = "DTPfechagasto";
            this.DTPfechagasto.Size = new System.Drawing.Size(200, 20);
            this.DTPfechagasto.TabIndex = 5;
            // 
            // formGastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 293);
            this.Controls.Add(this.DTPfechagasto);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LSTpersonas);
            this.Name = "formGastos";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formGastos_FormClosing);
            this.Load += new System.EventHandler(this.formGastos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TXTpersona;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TXTconcepto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TXTvalor;
        private System.Windows.Forms.ListBox LSTpersonas;
        private System.Windows.Forms.Button bttnguardar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bttnnuevo;
        private System.Windows.Forms.DateTimePicker DTPfechagasto;
    }
}