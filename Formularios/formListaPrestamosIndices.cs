using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlPrestamos.Clases.DB;
using ControlPrestamos.Clases.Reglas;

namespace ControlPrestamos.Formularios
{
    public partial class formListaPrestamosIndices : Form
    {
        ConexionDB con = new ConexionDB();
        public formListaPrestamosIndices()
        {
            InitializeComponent();
        }

        private void formListaPrestamosIndices_Load(object sender, EventArgs e)
        {
            caragar();
        }

        private void caragar()
        {
            string sql = "select codigo, fecha_inicio, fecha_final, cedula_cliente, nombre ";
            sql += "from tprestamo ";
            sql += "inner join tindice on tindice.codigo_prestamo = tprestamo.codigo ";
            sql += "inner join tcliente on tprestamo.cedula_cliente = tcliente.cedula order by codigo";
            con.llenar_DGV(sql, dgvPrestamosIndices, con.getConexion());
        }

        private void caragar_sin_indices()
        {
            string sql = "select codigo, fecha_inicio, fecha_final, cedula_cliente, nombre ";
            sql += "from tprestamo ";
            sql += "left join tindice on tindice.codigo_prestamo = tprestamo.codigo ";
            sql += "left join tcliente on tprestamo.cedula_cliente = tcliente.cedula ";
            sql += "where (select count(1) from tindice where codigo_prestamo = codigo) <= 0  order by codigo ";
            con.llenar_DGV(sql, dgvPrestamosIndices, con.getConexion());
        } 

        private void button1_Click(object sender, EventArgs e)
        {
             caragar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            caragar_sin_indices();
            //int i = 0;
            //for(i=0; i < dgvPrestamosIndices.Rows.Count; i++)
            //{
            //    string codigo_prestamo = Convert.ToString(dgvPrestamosIndices[0, i].Value);
            //    int existe = int.Parse(dgvPrestamosIndices["c_existe", i].Value.ToString());
            //    if (existe > 0)
            //    {
            //        dgvPrestamosIndices.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
            //        dgvPrestamosIndices.Rows[i].DefaultCellStyle.SelectionBackColor = Color.DarkRed;
            //    }
            //}
        }
    }
}
