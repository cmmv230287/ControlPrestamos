using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using ControlPrestamos.Clases.DB;
using ControlPrestamos.Clases.Presentacion;
using ControlPrestamos.Clases.Reglas;

namespace ControlPrestamos.Formularios
{
    public partial class formOrganizarIndices : Form
    {
        private Indices objIndices;
        private ConexionDB conex = new ConexionDB();
        public formOrganizarIndices()
        {
            InitializeComponent();
        }

        private void formOrganizarIndices_Load(object sender, EventArgs e)
        {
            CargarIndices();
            datos.LlenardgvTrabajadores(CBtrabajadores);
        }

        /// <summary>
        /// Verifica que el codigo a isertar no existe en la tabla de indices
        /// </summary>
        /// <param name="p_codigo">codigo a insertar</param>
        /// <returns></returns>
        private bool VerificarExistenciaIndice(string p_codigo)
        {
            bool res = false;
            //VERIFICA EXISTENCIA DEL QUE SERA AGREGADO
            string sql = "SELECT COUNT(codigo_prestamo) FROM tindice WHERE codigo_prestamo = '" + p_codigo + "'";            
            int cont = conex.Contar_registros(sql, conex.getConexion());            
            if (cont > 0)
            {
                res = true;
            }
            //
            return res;
        }

        private bool VerificarExistenciaPrestamo(string p_codigo)
        {
            //VERIFICA QUE ESTE CONCUERDE LOS PRESTAMOS DE LA TABLA tprestamo
            string sql = "SELECT COUNT(codigo) FROM tprestamo WHERE codigo = '" + p_codigo + "'";
            int cont = conex.Contar_registros(sql, conex.getConexion());
            bool res = false;
            if (cont > 0)
            {
                res = true;
            }
            //
            return res;
        }

        private void CargarIndices()
        {
            //string sql = "SELECT num_indice, codigo_prestamo, get_cobrador(cobrador) FROM tindice ORDER BY num_indice";
            string sql = "SELECT num_indice, codigo_prestamo, get_cobrador(cobrador) FROM tindice ORDER BY num_indice";
            conex.llenar_DGV(sql, dgvindices, conex.getConexion());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TXTcodigo.TextLength >= 0 && CBtrabajadores.Text.Length >= 0)
            {
                //VERIFICA QUE EL INDICE NO EXISTA EN LA TABLA DE INDICES
                if (this.VerificarExistenciaIndice(TXTcodigo.Text) == false)
                {
                    //VERIFICA QUE EL CODIGO DE PRESTAMO EXISTA EN LA TABLA DE PRESTAMO
                    if (this.VerificarExistenciaPrestamo(TXTcodigo.Text))
                    {
                        if (CHKinserccion.Checked)
                        {
                            InserccionEspecial();
                        }
                        else
                        {
                            objIndices = new Indices();
                            int indice = objIndices.MaximoIndice() + 1;
                            string cedulaCobrador = CBtrabajadores.Text;
                            cedulaCobrador = cedulaCobrador.Substring(0, cedulaCobrador.IndexOf(' '));
                            this.objIndices.InsertarIndice(indice, TXTcodigo.Text, cedulaCobrador);
                        }
                        CargarIndices();
                    }
                    else
                    {
                        MessageBox.Show("El prestamo con codigo " + TXTcodigo.Text + " no existe en la base de datos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("El codigo " + TXTcodigo.Text + " ya existe en los indices", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("No pueden quedar campos en blanco", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void InserccionEspecial()
        {
            objIndices = new Indices();
            int fil = dgvindices.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            int indice = Convert.ToInt32(dgvindices[0, fil].Value);
            string cedulaCobrador = CBtrabajadores.Text;
            cedulaCobrador = cedulaCobrador.Substring(0, cedulaCobrador.IndexOf(' '));
            if (this.objIndices.Organizar(indice, TXTcodigo.Text, cedulaCobrador, dgvindices))
            {
                MessageBox.Show("Insetccion exitosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvindices_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            this.contextMenuStrip1.Show();
        }
        
        private void eliminarIndiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objIndices = new Indices();
            int fil = dgvindices.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            string codigo = Convert.ToString(dgvindices[1, fil].Value);
            if (this.objIndices.EliminarIndice(codigo))
            {
                MessageBox.Show("Eliminacion exitosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
            //objIndices.ReorganizarIndices(this.dgvindices);            
            CargarIndices();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            objIndices = new Indices();
            objIndices.ReorganizarIndices(this.dgvindices);
            CargarIndices();
        }     
    }
}