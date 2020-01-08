using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlPrestamos.Clases.DB;
using ControlPrestamos.Clases.Presentacion;
using ControlPrestamos.Clases.Reglas;

namespace ControlPrestamos.Formularios
{
    public partial class formFrecPago : Form
    {
        public bool Guardar_Actualizar { get; set; }
        public formFrecPago()
        {
            InitializeComponent();
            Guardar_Actualizar = true;
        }

        private void formFrecPago_Load(object sender, EventArgs e)
        {
            cargar_grid();
        }

        private void cargar_grid()
        {
            ConexionDB con = new ConexionDB();
            con.llenar_DGV("SELECT decripcion, color, codigo FROM tfrecpago;", dgvtippag, con.getConexion());
            colorear();
        }
        private void colorear(){
            int i = 0;
            for (i = 0; i < dgvtippag.RowCount; i++)
            {
                int color = Convert.ToInt32(dgvtippag[1, i].Value);
                dgvtippag[1, i].Style.ForeColor = Color.FromArgb(color);
                dgvtippag[1, i].Style.BackColor = Color.FromArgb(color);
                dgvtippag[1, i].Style.SelectionForeColor = Color.FromArgb(color);
                dgvtippag[1, i].Style.SelectionBackColor = Color.FromArgb(color);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtcolor.BackColor = colorDialog1.Color;
                txtcolor.ForeColor = colorDialog1.Color;
                txtcolor.Text = Convert.ToString(colorDialog1.Color.ToArgb());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrecPago fre = new FrecPago();
            if (Guardar_Actualizar) 
            {
                fre.guardar_frecpag(txtdesc.Text, int.Parse(txtcolor.Text));
            }
            else
            {
                if (fre.actualizar_frecpag(txtdesc.Text, int.Parse(txtcolor.Text), int.Parse(txtcolor.Text)))
                {
                    MessageBox.Show("Registro Actualizado con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
            cargar_grid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("desea eliminar este registro?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.OK)
            {
                FrecPago fre = new FrecPago();
                fre.eliminar_frecpag(int.Parse(lblcodigo.Text));
                cargar_grid();
            }
        }

        private void dgvtippag_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {            
            lblcodigo.Text = dgvtippag[2, e.RowIndex].Value.ToString();
            txtdesc.Text = dgvtippag[0, e.RowIndex].Value.ToString();
            txtcolor.Text = dgvtippag[1, e.RowIndex].Value.ToString();
            txtcolor.BackColor = Color.FromArgb(int.Parse(txtcolor.Text));
            txtcolor.ForeColor = Color.FromArgb(int.Parse(txtcolor.Text));
            Guardar_Actualizar = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtcolor.Clear();
            txtdesc.Clear();
            lblcodigo.Text = "";
            Guardar_Actualizar = true;
        }
    }
}
