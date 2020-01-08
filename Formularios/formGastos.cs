using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlPrestamos.Clases.Reglas;

namespace ControlPrestamos.Formularios
{
    public partial class formGastos : Form
    {
        public formGastos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.TXTvalor.TextLength > 0 || this.TXTpersona.TextLength > 0 || this.TXTconcepto.TextLength > 0)
            {
                Gasto gas = new Gasto(Convert.ToDouble(this.TXTvalor.Text), this.TXTpersona.Text, this.TXTconcepto.Text);
                if (gas.RegistrarGasto(DTPfechagasto.Value.ToShortDateString()))
                {
                    MessageBox.Show("Gasto insertado con exito", "informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.bttnguardar.Enabled = false;
                    this.bttnnuevo.Enabled = true;
                    groupBox1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Error al momento de insertar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Faltan datos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void formGastos_Load(object sender, EventArgs e)
        {
            ControlPrestamos.Clases.DB.ConexionDB con = new Clases.DB.ConexionDB();            
            string sql = "select cedula||' '||nombre from tpersonas";
            con.Llenar_Listbox(sql, LSTpersonas, con.getConexion());
            this.bttnguardar.Enabled = false;
            this.bttnnuevo.Enabled = true;
            groupBox1.Enabled = false;
            ControlPrestamos.Clases.Presentacion.DatosLogin.segnal = 1;
        }

        private void LSTpersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.TXTpersona.Text = LSTpersonas.Text;
        }

        private void bttnnuevo_Click(object sender, EventArgs e)
        {
            this.bttnguardar.Enabled = true;
            this.bttnnuevo.Enabled = false;
            groupBox1.Enabled = true;
            this.TXTconcepto.Clear();
            this.TXTpersona.Clear();
            this.TXTvalor.Clear();
        }

        private void formGastos_FormClosing(object sender, FormClosingEventArgs e)
        {
            ControlPrestamos.Clases.Presentacion.DatosLogin.segnal = 0;
        }
    }
}
