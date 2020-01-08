namespace ControlPrestamos.Formularios
{
    partial class formListaPrestamosIndices
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
            this.dgvPrestamosIndices = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ccodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cfecha_inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cfecha_final = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamosIndices)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPrestamosIndices
            // 
            this.dgvPrestamosIndices.AllowUserToAddRows = false;
            this.dgvPrestamosIndices.AllowUserToDeleteRows = false;
            this.dgvPrestamosIndices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPrestamosIndices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrestamosIndices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ccodigo,
            this.cfecha_inicio,
            this.cfecha_final,
            this.cnombre});
            this.dgvPrestamosIndices.Location = new System.Drawing.Point(12, 59);
            this.dgvPrestamosIndices.Name = "dgvPrestamosIndices";
            this.dgvPrestamosIndices.ReadOnly = true;
            this.dgvPrestamosIndices.RowHeadersVisible = false;
            this.dgvPrestamosIndices.Size = new System.Drawing.Size(578, 440);
            this.dgvPrestamosIndices.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "Prestamos Con Indices";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(164, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 41);
            this.button2.TabIndex = 2;
            this.button2.Text = "Prestamos Sin Indices";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ccodigo
            // 
            this.ccodigo.HeaderText = "Codigo";
            this.ccodigo.Name = "ccodigo";
            this.ccodigo.ReadOnly = true;
            // 
            // cfecha_inicio
            // 
            this.cfecha_inicio.HeaderText = "Fecha de Inicio";
            this.cfecha_inicio.Name = "cfecha_inicio";
            this.cfecha_inicio.ReadOnly = true;
            this.cfecha_inicio.Width = 120;
            // 
            // cfecha_final
            // 
            this.cfecha_final.HeaderText = "Fecha Final";
            this.cfecha_final.Name = "cfecha_final";
            this.cfecha_final.ReadOnly = true;
            // 
            // cnombre
            // 
            this.cnombre.HeaderText = "Cliente";
            this.cnombre.Name = "cnombre";
            this.cnombre.ReadOnly = true;
            this.cnombre.Width = 250;
            // 
            // formListaPrestamosIndices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 511);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvPrestamosIndices);
            this.Name = "formListaPrestamosIndices";
            this.Text = "formListaPrestamosIndices";
            this.Load += new System.EventHandler(this.formListaPrestamosIndices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamosIndices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPrestamosIndices;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cfecha_inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cfecha_final;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnombre;
    }
}