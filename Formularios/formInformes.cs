using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlPrestamos.Clases.Presentacion;
using ControlPrestamos.Clases.DB;
namespace ControlPrestamos.Formularios
{
    public partial class formInformes : Form
    {
        Informes objInformes = new Informes();
        public formInformes()
        {
            InitializeComponent();
        }

        private void formInformes_Load(object sender, EventArgs e)
        {
            ConexionDB con = new ConexionDB(); 
            this.CargarInformes();
            datos.LlenardgvTrabajadores(CBtrabajadores);
            //string sql = "select cedula||' '||nombre from tpersonas";
            //con.Llenar_Listbox(sql, LSTpersonas, con.getConexion());
        }
        /// <summary>
        /// Carga los nombres de los informes del archivo access en un ListBox (LSTinformes)
        /// </summary>
        private void CargarInformes()
        {
            List<string> lista = new List<string>();
            lista = objInformes.GetInformes();
            for (int i = 0; i < lista.Count; i++)
            {
                LSTinformes.Items.Add(lista[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConexionDB con = new ConexionDB();
            string cedcobrador = "";
            string empleado = "";

            if (!chcktodoscobra.Checked)
            {
                cedcobrador = CBtrabajadores.Text.Substring(0, CBtrabajadores.Text.IndexOf(' ')); ;
            }

            string sql = "";
            //string sql2 = "";

            if (LSTinformes.SelectedIndex == 0)
            {
                sql = "CREATE OR REPLACE VIEW cobros_diarios AS ";
                sql = sql + "SELECT tprestamo.codigo, tcliente.nombre, tcliente.telefono, tcuotas.fecha, tcuotas.abono, tprestamo.fecha_inicio, tprestamo.fecha_final, tprestamo.valor, tprestamo.total, tprestamo.saldo, tindice.num_indice, get_descripcion_corta_frecpago(codigo_frecpag) ";
                sql = sql + "FROM tprestamo, tcliente, tcuotas, tindice ";
                sql = sql + "WHERE tprestamo.codigo::text = tindice.codigo_prestamo::text AND tcliente.cedula::text = tprestamo.cedula_cliente::text AND tcuotas.codigo_prestamo::text = tprestamo.codigo::text AND tcuotas.numero = maximo_numero(tprestamo.codigo::text)  AND ";
                sql = sql + "tindice.cobrador like '" + cedcobrador + "%' ";
                sql = sql + "ORDER BY tindice.num_indice; ";
            }
            else if (LSTinformes.SelectedIndex == 1)
            {
                //empleado = LSTpersonas.Text.Substring(0, LSTpersonas.Text.IndexOf(' '));
                string fechaini = string.Format("{0:yyyy-MM-dd}", dtpinicio.Value);
                string fechafin = string.Format("{0:yyyy-MM-dd}", dtpfinal.Value);
                sql = "CREATE OR REPLACE VIEW vista_gastos AS ";
                sql += "SELECT tpersonas.cedula, tpersonas.nombre, tgastos.valorgasto, tgastos.dscgasto, tgastos.fechagasto, tgastos.horagasto, ";
                sql += "(select sum(valorgasto) from tgastos, tpersonas where tgastos.cedulagasto = tpersonas.cedula and tpersonas.cedula = '" + cedcobrador + "' AND tgastos.fechagasto between '" + fechaini + "' and '" + fechafin + "') as sumatotal ";
                sql += "FROM tgastos, tpersonas ";
                sql += "WHERE tgastos.cedulagasto::text = tpersonas.cedula::text AND tpersonas.cedula::text = '" + cedcobrador + "'::text AND tgastos.fechagasto >= '" + fechaini + "'::date AND tgastos.fechagasto <= '" + fechafin + "'::date ";
                sql += "ORDER BY tpersonas.nombre; ";
            }

            if (con.Ejecutar(sql))
            {
                if (LSTinformes.SelectedIndex >= 0)
                {
                    //ABRE EL INFORME SELECCIONADO
                    objInformes.AbrirInforme(LSTinformes.SelectedItem.ToString());
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un informe de la lista", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }                
            }
            else
            {
                MessageBox.Show("Ocurrio un problema al momento de generar el reporte de cobros diarios ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chcktodoscobra_CheckedChanged(object sender, EventArgs e)
        {
            if (chcktodoscobra.Checked)
            {
                CBtrabajadores.Enabled = false;
            }
            else
            {
                CBtrabajadores.Enabled = true;
            }
        }

        private void LSTinformes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LSTinformes.SelectedIndex == 1)
            {
                dtpinicio.Enabled = true;
                dtpfinal.Enabled = true;
            }
            else
            {
                dtpinicio.Enabled = false;
                dtpfinal.Enabled = false;
            }
        }      
    }
}