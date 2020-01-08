using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlPrestamos.Clases.Reglas;
using ControlPrestamos.Clases.DB;
namespace ControlPrestamos.Formularios
{
    public partial class formPersona : Form
    {
        Persona per = null;
        string cedulaActual = null;
        bool nuevo = true;
        public formPersona()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nuevo)
            {                
                guardarPersona();
            }
            else
            {
                actualizarPersona();
            }
            this.cargarPersonas("");
        }

        private void guardarPersona()
        {
            per = new Persona(txtcedula.Text, txtnombre.Text, Convert.ToInt16(datos.getSubstringSpacio(cbtipo.Text, ' ')));
            if (txtcedula.TextLength > 0 && txtnombre.TextLength > 0 && cbtipo.Text.Length > 0)
            {
                if (per.verificarexistencia(txtcedula.Text) == false)
                {
                    if (per.registrarPersona())
                    {
                        MessageBox.Show("Persona Guardada con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Problemas al guardar a la Persona", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("la cedula de esta persona ya existe ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void actualizarPersona()
        {
            per = new Persona();
            if (txtcedula.TextLength > 0 && txtnombre.TextLength > 0 && cbtipo.Text.Length > 0)
            {
                if (per.actualizarPersona(txtcedula.Text, txtnombre.Text, Convert.ToInt16(datos.getSubstringSpacio(cbtipo.Text, ' ')), cedulaActual))
                {
                    MessageBox.Show("Persona actualizada con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Problemas al actualizar a la Persona", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void eliminarPersona()
        {
            per = new Persona();
            if (MessageBox.Show("Esta seguro de eliminar a " + txtnombre.Text + " ?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes )
            {
                if (per.eliminarPersona(txtcedula.Text))
                {
                    MessageBox.Show("Persona eliminada con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Problemas al eliminar a la Persona", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cargarPersonas(string filtrocedula)
        {
            ConexionDB con = new ConexionDB();
            string sql = "SELECT  nombre, cedula, tipo FROM tpersonas WHERE cedula like '" + filtrocedula + "%'";
            string sql2 = "SELECT codigo||' '||descripccion FROM ttipoper;";
            con.llenar_DGV(sql, dgvpersonas, con.getConexion());
            con.Llenar_Listbox(sql2, cbtipo,con.getConexion());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            eliminarPersona();
            this.cargarPersonas("");
        }

        private void formPersona_Load(object sender, EventArgs e)
        {
            cargarPersonas("");
        }

        private void dgvpersonas_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            per = new Persona();
            int fila = dgvpersonas.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            string cedaux = Convert.ToString(dgvpersonas["c_cedula", fila].Value);
            Persona per2 = per.getPersona(cedaux);
            txtcedula.Text  = per2.Cedula;
            txtnombre.Text = per2.Nombre;
            cbtipo.Text = Convert.ToString(per2.Tipo) + " " + new ConexionDB().getDataSelect_SQL2("select get_descripciontipoper(" + per2.Tipo + ")");
            this.nuevo = false;
            this.cedulaActual = txtcedula.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.nuevo = true;
            txtcedula.Clear();
            txtnombre.Clear();
            cargarPersonas("");
        }

        private void cbtipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
