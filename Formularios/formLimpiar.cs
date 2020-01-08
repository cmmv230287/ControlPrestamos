using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlPrestamos.Clases.DB;
using ControlPrestamos.Clases.Reglas;
using ControlPrestamos.Clases.Presentacion;

namespace ControlPrestamos.Formularios
{
    public partial class formLimpiar : Form
    {
        Mensajes msg = new Mensajes();
        ConexionDB conex = new ConexionDB();
        int tipo = 1;
        public formLimpiar()
        {
            InitializeComponent();
        }

        private void formLimpiar_Load(object sender, EventArgs e)
        {
            string msgaux = "Antes de continuar tenga en cuenta lo siguiente: \n";
            msgaux+="1) Al eliminar un cliente se eliminara todos los prestamos y cuotas relacionados a este. \n";
            msgaux += "2) Al eliminar un prestamo automaticammente se eliminaran todas las cuotas relacionadas a este. \n";

            MessageBox.Show(msgaux, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        /// <summary>
        /// Trae los datos del prestamo que sera eliminado
        /// </summary>
        /// <param name="codigo">Codigo del prestamo a eliminar</param>
        private void getDatosPrestamos(string codigo)
        {
            System.Data.Odbc.OdbcDataReader dr = null;
            Prestamo objPrestamo = new Prestamo();
            string sqlselect = "SELECT codigo, valor, porcentaje, total, fecha_inicio, fecha_final, cuotas, valor_cuota, cedula_cliente, saldo";
            sqlselect += " FROM tprestamo WHERE codigo = '" + codigo + "'";
            dr = objPrestamo.getObjDatareader(sqlselect);
            if (dr.HasRows)
            {
                TXTvalor.Text = dr.GetString(1);
                TXTporcent.Text = dr.GetString(2);
                TXTtotal.Text = dr.GetString(3);
                TXTnumcuotas.Text = dr.GetString(6);
                TXTvalorcuota.Text = dr.GetString(7);
                TXTsaldo.Text = dr.GetString(9);
                LBLcodigo.Text = dr.GetString(0);

                TXTfechaini.Text = dr.GetDateTime(4).ToShortDateString();
                TXTfechafin.Text = dr.GetDateTime(5).ToShortDateString();
            }
            else
            {
                this.ReestablecerPrestamo();
            }
        }

        private void ReestablecerPrestamo()
        {
            TXTvalor.Text = "";
            TXTporcent.Text = "";
            TXTtotal.Text = "";
            TXTnumcuotas.Text = "";
            TXTvalorcuota.Text = "";
            TXTsaldo.Text = "";
            LBLcodigo.Text = "";

            TXTfechaini.Text = "";
            TXTfechafin.Text = "";
        }

        private void traerDatosCliente(string cedulaCliente)
        {
            this.listBox1.Items.Clear();

            Cliente objCliente = new Cliente();
            Prestamo objPrestamo = new Prestamo();
            objCliente.getSelectData1(cedulaCliente);
            TXTnombre.Text = objCliente.Nombre;
            TXTcedula.Text = objCliente.Cedula;
            TXTbarrio.Text = objCliente.Barrio;
            TXTdireccion.Text = objCliente.Direccion;
            TXTtelefono.Text = objCliente.Telefono;

            //CARGA LOS CODIGOS DE PRESTAMOS EN EL COMBOBOX
            string sql = "SELECT codigo FROM tprestamo WHERE cedula_cliente = '" + TXTcedula.Text + "'";
            this.llenarListbox(sql, listBox1);            
        }

        public void llenarListbox(string sql, ListBox lista)
        {
            conex.Llenar_Listbox(sql, lista, conex.getConexion());
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            this.Traerdatos(this.tipo);
        }

        /// <summary>
        /// Trae los datos del cliente o el prestamo dependiendo del argumento
        /// </summary>
        /// <param name="tipoDato">tipo de dato que se traera (1 o 2)</param>
        public void Traerdatos(int tipoDato)
        {
            switch (tipoDato)
            {
                case 1: 
                    this.getDatosPrestamos(TXTbuscar.Text);
                    break;
                case 2:
                    this.traerDatosCliente(TXTbuscar.Text);
                    break;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string aux=null, msgaux = null;
            if (this.tipo == 1)
            {
                aux = "prestamo";                
            }
            else if (this.tipo == 2)
            {
                aux = "cliente";               
            }
            msgaux = "Se eliminara el " + aux + " " + LBLcodigo.Text + " ¿Desea continuar?";
            if (MessageBox.Show(msgaux, "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.EliminarPrestamo_Cliente(this.tipo);
            }
        }

        /// <summary>
        /// Elimina el prestamo o el cliente dependiendo del argumento tipo
        /// </summary>
        /// <param name="tipo">Tipo de eliminacion (1 o 2)</param>
        private void EliminarPrestamo_Cliente(int tipo)
        {
            Prestamo objPrestamo = new Prestamo();
            Cliente objCliente = new Cliente();
            bool res = false;
            if (tipo == 1)
            {
                res = objPrestamo.EliminarPrestamo(LBLcodigo.Text);
            }
            else if (tipo == 2)
            {
                res = objCliente.EliminarCliente(TXTcedula.Text);
            }
            if (res)
            {
                msg.Getmensaje(TipoError.ELIMINACION_POSITIVA);
            }
            else
            {
                msg.Getmensaje(TipoError.ELIMINACION_NEGATIVA);
            }
        }

        
        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "TBprestamos")
            {
                label1.Text = "Codigo de Prestamo:";
                tipo = 1;                
            }
            else if (tabControl1.SelectedTab.Name == "TBclientes")
            {
                label1.Text = "Cedula de Cliente:";
                tipo = 2;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}