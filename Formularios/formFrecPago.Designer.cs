namespace ControlPrestamos.Formularios
{
    partial class formFrecPago
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
            this.dgvtippag = new System.Windows.Forms.DataGridView();
            this.c_descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtdesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtcolor = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lblcodigo = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtippag)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvtippag
            // 
            this.dgvtippag.AllowUserToAddRows = false;
            this.dgvtippag.AllowUserToDeleteRows = false;
            this.dgvtippag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvtippag.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_descripcion,
            this.c_color,
            this.c_codigo});
            this.dgvtippag.Location = new System.Drawing.Point(11, 123);
            this.dgvtippag.Name = "dgvtippag";
            this.dgvtippag.ReadOnly = true;
            this.dgvtippag.RowHeadersVisible = false;
            this.dgvtippag.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvtippag.Size = new System.Drawing.Size(400, 150);
            this.dgvtippag.TabIndex = 0;
            this.dgvtippag.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvtippag_CellMouseClick);
            // 
            // c_descripcion
            // 
            this.c_descripcion.HeaderText = "Descripcion";
            this.c_descripcion.Name = "c_descripcion";
            this.c_descripcion.ReadOnly = true;
            this.c_descripcion.Width = 250;
            // 
            // c_color
            // 
            this.c_color.HeaderText = "Color";
            this.c_color.Name = "c_color";
            this.c_color.ReadOnly = true;
            this.c_color.Width = 50;
            // 
            // c_codigo
            // 
            this.c_codigo.HeaderText = "codigo";
            this.c_codigo.Name = "c_codigo";
            this.c_codigo.ReadOnly = true;
            // 
            // txtdesc
            // 
            this.txtdesc.Location = new System.Drawing.Point(84, 23);
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.Size = new System.Drawing.Size(152, 20);
            this.txtdesc.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Descripcion:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(255, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Color:";
            // 
            // txtcolor
            // 
            this.txtcolor.Location = new System.Drawing.Point(84, 48);
            this.txtcolor.Name = "txtcolor";
            this.txtcolor.Size = new System.Drawing.Size(31, 20);
            this.txtcolor.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(336, 94);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Eliminar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(118, 51);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(63, 13);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Seleccionar";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lblcodigo
            // 
            this.lblcodigo.AutoSize = true;
            this.lblcodigo.Location = new System.Drawing.Point(12, 104);
            this.lblcodigo.Name = "lblcodigo";
            this.lblcodigo.Size = new System.Drawing.Size(13, 13);
            this.lblcodigo.TabIndex = 8;
            this.lblcodigo.Text = "0";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(174, 94);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Nuevo";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // formFrecPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 285);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lblcodigo);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtcolor);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtdesc);
            this.Controls.Add(this.dgvtippag);
            this.Name = "formFrecPago";
            this.Text = "formFrecPago";
            this.Load += new System.EventHandler(this.formFrecPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvtippag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvtippag;
        private System.Windows.Forms.TextBox txtdesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtcolor;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_color;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_codigo;
        private System.Windows.Forms.Label lblcodigo;
        private System.Windows.Forms.Button button3;
    }
}