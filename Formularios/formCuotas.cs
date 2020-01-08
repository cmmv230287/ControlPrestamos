using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlPrestamos.Clases.Reglas;
using ControlPrestamos.Clases.Presentacion;
namespace ControlPrestamos.Formularios
{
    public partial class formCuotas : Form
    {
        private Mensajes msg = new Mensajes();
        private string cedulacobrador = "";
        public formCuotas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CBtrabajadores.Text != "<Seleccione uno>" && CBtrabajadores.Text.Length > 0)
            {
                this.RegistrarCuota();
                ReestablecerCampos();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Cobrador", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void ReestablecerCampos()
        {
            TXTabono.Clear();
            TXTcodigo.Clear();
        }
        //GUARDA LA CUOTA ACTUAL
        private void RegistrarCuota()
        {
            double abono = Convert.ToDouble(TXTabono.Text);
            Cuota objCuota = new Cuota(abono, TXTcodigo.Text, DTPfecha.Value.ToShortDateString(), cedulacobrador, int.Parse(DTPfecha.Value.DayOfWeek.ToString("d")));
            
            if (objCuota.verificarExistencia(TXTcodigo.Text, DTPfecha.Value.ToShortDateString()) == 0)
            {
                if (objCuota.InsertarCuota())
                {
                    msg.Getmensaje(TipoError.INSERCCION_POSITIVA);
                    //this.Close();
                }
                else
                {
                    msg.Getmensaje(TipoError.INSERCCION_NEGATIVA);
                }
            }
            else
            {
                MessageBox.Show("Ya existe una cuota con la fecha: " + DTPfecha.Value.ToShortDateString() + " y con el codigo: " + TXTcodigo.Text, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formCuotas_Load(object sender, EventArgs e)
        {
            //ControlPrestamos.Clases.DB.ConexionDB con = new Clases.DB.ConexionDB();
            //string sql = "select cedula||' '||nombre from tpersonas";
            //con.Llenar_Listbox(sql, CBtrabajadores , con.getConexion());
            datos.LlenardgvTrabajadores(CBtrabajadores);
        }

        private void CBtrabajadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            int aux = CBtrabajadores.Text.IndexOf(' ');
            cedulacobrador = CBtrabajadores.Text.Substring(0,aux);
        }
    }
}