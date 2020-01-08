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
    public partial class formConfig : Form
    {
        public string usuario = "";
        public string passw = "";
        public formConfig()
        {
            InitializeComponent();
        }

        private void formConfig_Load(object sender, EventArgs e)
        {
            
        }

        private bool verificarPassword()
        {
            bool res = false;
            if (TXTpassw.Text == TXTrepetirpassw.Text)
            {
                res = true;
            }
            return res;
        }

        private void CambiarContras()
        {
            Usuario usu = new Usuario();
            if (verificarPassword())
            {
                if (usu.CambiarPassword(this.passw, TXTpassw.Text, this.usuario))
                {
                    MessageBox.Show("Contraseña cambiada con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al cambiar la contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Las contraseña no coinciden", "Mensaje de Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void TXTrepetirpassw_TextChanged(object sender, EventArgs e)
        {
            if (TXTrepetirpassw.Text == TXTpassw.Text)
            {
                pictureBox2.Image = ControlPrestamos.Properties.Resources._ok;
            }
            else
            {
                pictureBox2.Image = ControlPrestamos.Properties.Resources.button_cancel_16n;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.CambiarContras();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}