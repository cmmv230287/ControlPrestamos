using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ControlPrestamos.Clases.DB;
using ControlPrestamos.Clases.Presentacion;
using ControlPrestamos.Clases.Reglas;

namespace ControlPrestamos.Formularios
{
    public partial class formClientes : Form
    {
        private bool actualizarcliente = false;
        private System.Threading.Thread hilo = null;
        private Mensajes msg = new Mensajes();
        private bool nuevoprestamo = false;
        private Point punto;
        private string viejacedula = "";//ALMACENA LA CEDULA DE UN CLIENTE CUANDO SE HACE DOBLE CLIC SOBRE EL DATAGRIDVIEW

        public formClientes()
        {
            InitializeComponent();
            this.rcedulagastos.CheckedChanged += new EventHandler(rnombregastos_CheckedChanged);
        }

        /// <summary>
        /// ACTIVA O DESACTIVA EL BOTON PARA REGISTRAR UNA NUEVA CUOTA AL PRESTAMO ACTUAL
        /// </summary>
        private void ActivarDesactivarRegistroCuota(bool val)
        {
            //this.toolStripButton3.Enabled = val;
            this.toolStripButton5.Enabled = val;
            this.button3.Enabled = val;
        }

        private void ActualizarIndices()
        {
            progressBar1.Visible = true;
            habilitardeshabilitarGbox(false);
            int i, res, cont = 0;
            res = VerificarRepetidos();
            if (res == 1)
            {
                int progress = 1;
                progressBar1.Maximum = this.dgvprestamos.RowCount;
                progressBar1.Minimum = 1;
                Prestamo pres = new Prestamo();
                for (i = 0; i < this.dgvprestamos.RowCount; i++)
                {
                    int indice = Convert.ToInt32(this.dgvprestamos["c_indice", i].Value);
                    string cod = Convert.ToString(this.dgvprestamos["c_codigo", i].Value);
                    if (pres.GuardarIndices(indice, cod) == false)
                    {
                        cont++;
                    }
                    else
                    {
                        progressBar1.Value = progress;
                    }
                    progress++;
                }
                if (cont == 0)
                {
                    MessageBox.Show("Indices reorganizados con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al momento de reorganizar los indices", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string var = Convert.ToString(this.dgvprestamos["c_indice", res].Value);
                MessageBox.Show("El idice " + var + " esta repetido corrijalo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            progressBar1.Visible = false;
            habilitardeshabilitarGbox(true);
        }

        /// <summary>
        /// Arma el filtro dependiendo de la pestaña y el radiobutton seleccionado
        /// </summary>
        /// <returns></returns>
        private string Armar_Filtro()
        {
            string filtro = "";
            if (this.tabControl1.SelectedTab == this.tabPage1)
            {
                #region FILTRO PRESTAMO

                if (this.rcedula.Checked)
                {
                    filtro = " WHERE cedula = cedula_cliente AND cedula_cliente LIKE '" + TXTbuscar.Text + "%'";
                }
                else if (this.rcodigo.Checked)
                {
                    filtro = " WHERE cedula = cedula_cliente AND codigo LIKE '" + TXTbuscar.Text + "%'";
                }
                else if (this.rnombre.Checked)
                {
                    filtro = " WHERE cedula = cedula_cliente AND nombre LIKE '" + TXTbuscar.Text.ToLower() + "%'";
                }
                else if (this.rterminados.Checked)
                {
                    filtro = " WHERE cedula = cedula_cliente AND estado != 'Activo'";
                }
                else if (this.ractivos.Checked)
                {
                    filtro = " WHERE cedula = cedula_cliente AND estado = 'Activo'";
                }
                else if (this.rtodos.Checked)
                {
                    filtro = " WHERE cedula = cedula_cliente";
                }

                #endregion FILTRO PRESTAMO
            }
            else if (this.tabControl1.SelectedTab == this.tabPage2)
            {
                #region FILTRO CLIENTE

                if (this.rnomcliente.Checked)
                {
                    filtro = " WHERE nombre LIKE LOWER('" + TXTbuscarcliente.Text + "%')";
                }
                else if (this.rcedcliente.Checked)
                {
                    filtro = " WHERE cedula LIKE '" + TXTbuscarcliente.Text + "%'";
                }
                else if (this.rbarriocliente.Checked)
                {
                    filtro = " WHERE barrio LIKE LOWER('" + TXTbuscarcliente.Text + "%')";
                }
                else if (this.rtodosclientes.Checked)
                {
                    filtro = "";
                }

                #endregion FILTRO CLIENTE
            }
            else if (this.tabControl1.SelectedTab == this.tabPage3)
            {
                #region FILTRO CUOTAS

                if (this.rfechacuota.Checked)
                {
                    filtro = " WHERE fecha = '" + DTPcuotas.Value.ToShortDateString() + "'";
                }
                else if (this.rcodigocuota.Checked)
                {
                    filtro = " WHERE codigo_prestamo = '" + this.TXTbuscarcuota.Text + "'";
                }
                else if (this.rtodoscuotas.Checked)
                {
                    filtro = "";
                }

                #endregion FILTRO CUOTAS
            }
            else if (this.tabControl1.SelectedTab == this.tabPage4)
            {
                #region FILTRO GASTOS

                if (this.rcedulagastos.Checked)
                {
                    filtro = " WHERE cedula = cedulagasto AND cedula LIKE '" + TXTbuscargasto.Text + "%'";
                }
                else if (this.rnombregastos.Checked)
                {
                    filtro = " WHERE cedula = cedulagasto AND nombre like '" + TXTbuscargasto.Text + "%'";
                }
                else if (this.rfechagastos.Checked)
                {
                    filtro = "WHERE cedula = cedulagasto AND fechagasto BETWEEN '" + this.DTPgastos1.Value.ToShortDateString() + "' AND '" + this.DTPgastos2.Value.ToShortDateString() + "'";
                }
                else if (this.rtodosgastos.Checked)
                {
                    filtro = "WHERE cedula = cedulagasto";
                }

                #endregion FILTRO GASTOS
            }
            return filtro;
        }

        /// <summary>
        /// Bloquea o desbloquea el boton Reorganizar
        /// </summary>
        /// <param name="val">Valor true o false (desbloquear o bloquear)</param>
        private void BloqDesbloqBtnReorganizar(bool val)
        {
            button1.Enabled = val;
        }

        private void BloqDesbloqCamposPrestamo(bool val)
        {
            TXTvalor.ReadOnly = val;
            TXTvalorcuota.ReadOnly = val;
            TXTtotal.ReadOnly = val;
            TXTporcent.ReadOnly = val;
            TXTnumcuotas.ReadOnly = val;
            TXTsaldo.ReadOnly = val;
            cbfrepag.Enabled = !val;
        }

        //BLOQUEA O DESBLOQUE EL GROUPBOX DEL PRESTAMO
        private void BloquearDesbloquearPrestamo(bool var)
        {
            this.groupBox3.Enabled = var;
            this.groupBox4.Enabled = var;
            this.button8.Enabled = var;
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            this.Filtrar(this.Armar_Filtro());
            //Esto es importante aunque este en comentario
            //Asigna a el Label interes la ganancia de intereses
            //this.LBinteres.Text = Convert.ToString(new Prestamo().GetGanaciaenIntereses(this.Armar_Filtro()));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hilo = null;
            Control.CheckForIllegalCrossThreadCalls = false;
            hilo = new System.Threading.Thread(new System.Threading.ThreadStart(this.ActualizarIndices));
            hilo.IsBackground = true;
            hilo.Start();
            //BLOQUEA O DESBLOQUEA EL BOTON REORGANIZAR
            this.BloqDesbloqBtnReorganizar(false);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int ind = this.dgvgastos.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            int numero = Convert.ToInt32(this.dgvgastos["c_numerogasto", ind].Value);
            if (new Gasto().EliminarGasto(numero))
            {
                MessageBox.Show("Gasto Eliminado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Gasto no Eliminado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.bttneliminargasto.PerformClick();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Filtrar(this.Armar_Filtro());
            this.LBsumagasto.Text = Convert.ToString(new Gasto().SumarGastos(this.Armar_Filtro()));
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            Prestamo pres = new Prestamo();
            LBrecaudo.Text = Convert.ToString(pres.getRecaudo(DTPinicial.Value.ToShortDateString(), DTPfinal.Value.ToShortDateString()));
            LBprestado.Text = Convert.ToString(pres.getPrestado(DTPinicial.Value.ToShortDateString(), DTPfinal.Value.ToShortDateString()));
            LBinteres.Text = Convert.ToString(pres.getInteresesporFecha(DTPinicial.Value.ToShortDateString(), DTPfinal.Value.ToShortDateString()));
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SaveFileDialog op = new SaveFileDialog();
            op.Filter = "Archivo TXT|*.txt";
            string path = "";
            if (op.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = op.FileName;
            }

            string[] contenido = { "", "", "", "", "", "", "", "", "", "", "", "", "" };
            contenido[0] = "ESTADO DE GENERAL DE LOS PRESTAMOS";
            contenido[1] += "ARCHIVO CREADO EL DIA " + DateTime.Now.ToString();
            contenido[2] += "";
            contenido[3] += "RECAUDO: $ " + LBrecaudo.Text;
            contenido[4] += "PRESTADO: $ " + LBprestado.Text;
            contenido[5] += "INTERESES: $ " + LBinteres.Text;
            if (path.Length > 0)
            {
                File.WriteAllLines(path, contenido);
            }
        }

        //ACTUALIZA LOS DATOS DEL CLIENTE
        private void button2_Click(object sender, EventArgs e)
        {
            Cliente objCliente = new Cliente();

            objCliente.Nombre = TXTnombre.Text;
            objCliente.Cedula = TXTcedula.Text;
            objCliente.Barrio = TXTbarrio.Text;
            objCliente.Direccion = TXTdireccion.Text;
            objCliente.Telefono = TXTtelefono.Text;

            bool res = objCliente.ActualizarCliente(TXTbuscar.Text, TXTcedula.Text);
            if (res)
            {
                MessageBox.Show("Cliente actualizado con exito!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al actualizar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //BUSCA LOS DATOS DEL CLIENTE SEGUN LA CEDULA
        private void button2_Click_1(object sender, EventArgs e)
        {
            ConexionDB conex = new ConexionDB();
            string p_cedula = this.TXTbuscarced.Text;
            int rescont = 0;
            string sql = "SELECT COUNT(cedula) FROM tcliente WHERE cedula = '" + p_cedula + "'";
            rescont = conex.Contar_registros(sql, conex.getConexion());
            if (rescont > 0)
            {
                traerDatosCliente(p_cedula);
                this.actualizarcliente = true;
                this.BloqDesbloqCamposPrestamo(true);
                this.viejacedula = p_cedula;
            }
            else
            {
                MessageBox.Show("Este registro no existe", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ACTUALIZA EL DATARID DE LAS CUOTAS
            this.CargarCuotasPrestamos(LBLcodigo.Text);
            this.LBabonado.Text = Convert.ToString(this.getSumaCuotasporPrestamo(LBLcodigo.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Filtrar(this.Armar_Filtro());
            this.SumarCuotasDGV();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Filtrar(this.Armar_Filtro());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string codigo = "";
            int numero;
            int i = 0;
            int cont = 0;
            int cont2 = 0;
            List<int> lista = this.IndicesEliminar();

            for (i = 0; i < lista.Count; i++)
            {
                codigo = this.dgvcuotas2[1, lista[i]].Value.ToString();
                numero = Convert.ToInt32(this.dgvcuotas2["c_numero", lista[i]].Value);
                cont2++;
                if (new Cuota().EliminarCuota(codigo, numero))
                {
                    cont++;
                }
            }

            if (cont == cont2)
            {
                new Mensajes().Getmensaje(TipoError.ELIMINACION_POSITIVA);
            }
            else
            {
                new Mensajes().Getmensaje(TipoError.ELIMINACION_NEGATIVA);
            }
            this.CargarCuotasPrestamos(codigo);
            this.Filtrar(this.Armar_Filtro());
        }

        //ACTUALIZAR DATOS DEL PRESTAMO
        private void button8_Click(object sender, EventArgs e)
        {
            string codigo = LBLcodigo.Text;
            double valor = Convert.ToDouble(TXTvalor.Text);
            double porcent = Convert.ToDouble(TXTporcent.Text);
            double total = Convert.ToDouble(TXTtotal.Text);
            double saldo = Convert.ToDouble(TXTsaldo.Text);
            int numcuotas = Convert.ToInt32(TXTnumcuotas.Text);
            double Valorcuota = Convert.ToDouble(TXTvalorcuota.Text);
            string fch_inicial = DTPfchinicial.Value.ToShortDateString();
            string fch_final = DTPfchfinal.Value.ToShortDateString();
            int codigo_frecpag = Int32.Parse(cbfrepag.Text.Substring(0, cbfrepag.Text.IndexOf(' ')));

            bool res = new Prestamo().ActualizarPrestamo(codigo, valor, porcent, total, saldo, fch_inicial, fch_final, numcuotas, Valorcuota, codigo_frecpag); //,Convert.ToInt32(TXTindice.Text));
            if (res)
            {
                new Mensajes().Getmensaje(TipoError.ACTUALIZACION_POSITIVA);
            }
            else
            {
                new Mensajes().Getmensaje(TipoError.ACTUALIZACION_NEGATIVA);
            }
        }

        /// <summary>
        /// Calcula el valor del total aplicandole el porcentaje
        /// </summary>
        private void CalcularTotal()
        {
            if (TXTvalor.TextLength > 0 && TXTporcent.TextLength > 0)
            {
                double Valor = Convert.ToDouble(TXTvalor.Text);
                double Porcentaje = Convert.ToDouble(TXTporcent.Text);
                double res = Valor + ((Valor * Porcentaje) / 100);
                TXTtotal.Text = res.ToString();
            }
            else
            {
                TXTtotal.Text = "";
            }
        }

        /// <summary>
        /// Calcula el valor total a pagar
        /// </summary>
        private void CalcularValorCuota()
        {
            if (TXTnumcuotas.TextLength > 0 && TXTtotal.TextLength > 0)
            {
                double cuotas = Convert.ToDouble(TXTnumcuotas.Text);
                double total = Convert.ToDouble(TXTtotal.Text);
                double res = total / cuotas;
                TXTvalorcuota.Text = res.ToString();
            }
            else
            {
                TXTvalorcuota.Text = "";
            }
        }

        private void cambiarIndiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int indexrowselect = dgvprestamos.Rows.GetFirstRow(DataGridViewElementStates.Selected);
        }

        //CARGA LOS CODIGOS DE PRESTAMOS EN EL COMBOBOX
        private void Cargar_PrestamosList()
        {
            Prestamo objPrestamo = new Prestamo();
            string sql = "SELECT codigo FROM tprestamo WHERE tprestamo.cedula_cliente = '" + TXTcedula.Text + "'";
            objPrestamo.llenarListbox(sql, this.CBprestamos);
        }

        //CARGA LAS CUOTAS DEL PRESTAMO ESPECIFICO
        private void CargarCuotasPrestamos(string p_codigoprestamo)
        {
            groupBox4.Visible = true;
            Cuota objCuota = new Cuota();
            string sql = "SELECT abono, fecha FROM tcuotas WHERE codigo_prestamo = '" + p_codigoprestamo + "';";
            objCuota.CargarCuotas(sql, this.dgvcuotas);
            this.LBabonado.Text = Convert.ToString(this.getSumaCuotasporPrestamo(LBLcodigo.Text));
        }

        private void CBestadoprestamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBestadoprestamo.Focused)
            {
                Prestamo pres = new Prestamo();
                string nuevoestado = CBestadoprestamo.Text;
                if (pres.CambiarEstado(LBLcodigo.Text, nuevoestado))
                {
                    new Mensajes().Getmensaje(TipoError.ACTUALIZACION_POSITIVA);
                    btnbuscar.PerformClick();
                }
            }
        }

        private void CBprestamos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBprestamos.Text == "<Nuevo>")
            {
                this.nuevoprestamo = true;
                this.actualizarcliente = false;
                //BloquearDesbloquearPrestamo(true);
                this.BloqDesbloqCamposPrestamo(false);
                ReestablecerPrestamos();
                this.ActivarDesactivarRegistroCuota(false);
            }
            else
            {
                this.getDatosPrestamos(CBprestamos.Text);
                this.ActivarDesactivarRegistroCuota(true);
                //ACTUALIZA EL DATARID DE LAS CUOTAS
                this.CargarCuotasPrestamos(LBLcodigo.Text);
                this.LBabonado.Text = Convert.ToString(this.getSumaCuotasporPrestamo(LBLcodigo.Text));
                this.BloqDesbloqCamposPrestamo(false);
            }
        }

        private void Chkauto_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Chkauto.Checked)
            {
                TXTindice.Enabled = false;
            }
            else
            {
                TXTindice.Enabled = true;
            }
        }

        private void ColorSeleccionFila()
        {
            int i = 0;
            for (i = 0; i < this.dgvcuotas2.RowCount; i++)
            {
                if (Convert.ToInt32(this.dgvcuotas2["c_selectchk", i].Value) == 1)
                {
                    this.dgvcuotas2.Rows[i].DefaultCellStyle.BackColor = SystemColors.GradientActiveCaption;
                    this.dgvcuotas2.Rows[i].DefaultCellStyle.SelectionBackColor = SystemColors.GradientActiveCaption;
                    this.dgvcuotas2.Rows[i].DefaultCellStyle.SelectionForeColor = SystemColors.ControlText;
                    this.dgvcuotas2.Rows[i].DefaultCellStyle.ForeColor = SystemColors.ControlText;
                }
                else
                {
                    this.dgvcuotas2.Rows[i].DefaultCellStyle.BackColor = SystemColors.Window;
                    this.dgvcuotas2.Rows[i].DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
                    this.dgvcuotas2.Rows[i].DefaultCellStyle.SelectionForeColor = Color.White;
                    this.dgvcuotas2.Rows[i].DefaultCellStyle.ForeColor = SystemColors.ControlText;
                }
            }
        }

        private void ContarClientes()
        {
            Cliente cli = new Cliente();
            int numcli = cli.getNumClientes();
            LBnumeroCli.Text = "Actualmente hay " + numcli.ToString() + " clientes registrados";
        }

        /// <summary>
        /// Cuenta los prestamos
        /// </summary>
        private void ContarPrestamos()
        {
            ConexionDB con = new ConexionDB();
            this.LBnumprestamos.Text = con.Contar_registros("SELECT COUNT(codigo) FROM tprestamo", con.getConexion()).ToString();
        }

        private void dgvclientes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string p_cedula = this.dgvclientes["c_cedcli", e.RowIndex].Value.ToString();
            traerDatosCliente(p_cedula);
            this.getDatosPrestamos("0");
            this.actualizarcliente = true;
            this.BloqDesbloqCamposPrestamo(true);
            this.viejacedula = p_cedula;
        }

        private void dgvcuotas2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ColorSeleccionFila();
        }

        private void dgvcuotas2_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvcuotas2_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
        }

        private void dgvprestamos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.BloqDesbloqBtnReorganizar(true);
        }

        private void dgvprestamos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                colorear2(e.RowIndex);
            }            
        }

        private void dgvprestamos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string p_cedula = this.dgvprestamos["c_cedula", e.RowIndex].Value.ToString();
            string p_codigo = this.dgvprestamos["c_codigo", e.RowIndex].Value.ToString();
            this.traerDatosCliente(p_cedula);
            this.getDatosPrestamos(p_codigo);
            this.actualizarcliente = true;
            this.BloqDesbloqCamposPrestamo(true);
            this.viejacedula = p_cedula;

            if (e.Button == MouseButtons.Left && e.ColumnIndex == 0)
            {
                dgvprestamos.ReadOnly = false;
            }
            else
            {
                dgvprestamos.ReadOnly = true;
            }
        }

        /// <summary>
        /// Filtra los datos del Prestamo, Clientes o Cuotas
        /// </summary>
        /// <param name="filtro">Filtro de tipo WHERE que complementara la consulta sql SELECT</param>
        private void Filtrar(string filtro)
        {
            string sql = null;
            DataGridView dgvaux = null;
            //PRESTAMOS
            if (this.tabControl1.SelectedTab == this.tabPage1)
            {
                sql = "SELECT codigo, cedula_cliente, UPPER(nombre), valor, porcentaje, total, cuotas, valor_cuota, saldo, fecha_inicio, fecha_final";
                sql += " FROM tprestamo, tcliente";
                sql += filtro + " ORDER BY indice";
                dgvaux = this.dgvprestamos;
            }
            //CLIENTES
            else if (this.tabControl1.SelectedTab == this.tabPage2)
            {
                sql = "SELECT cedula, UPPER(nombre), barrio, direccion, telefono";
                sql += " FROM tcliente";
                sql += filtro + " ORDER BY nombre ASC";
                dgvaux = this.dgvclientes;
            }
            //CUOTAS
            else if (this.tabControl1.SelectedTab == this.tabPage3)
            {
                sql = "SELECT abono, codigo_prestamo, fecha, (select nombre from tpersonas where cedula = cobrador) as nombre, numero, false";
                sql += " FROM tcuotas";
                sql += filtro + " ORDER BY fecha DESC";
                dgvaux = this.dgvcuotas2;
            }
            //Gastos
            else if (this.tabControl1.SelectedTab == this.tabPage4)
            {
                sql = "SELECT nombre, cedulagasto, valorgasto, dscgasto,fechagasto, numerogasto ";
                sql += "FROM tgastos, tpersonas ";
                sql += filtro + " ORDER BY nombre";
                dgvaux = this.dgvgastos;
            }
            Prestamo objPrestamo = new Prestamo();
            objPrestamo.Filtrar_Prestamo(sql, dgvaux);
        }

        private void formClientes_Activated(object sender, EventArgs e)
        {
            //ACTUALIZA LOS CAMPOS DEL PRESTAMO
            this.getDatosPrestamos(LBLcodigo.Text);
            //ACTUALIZA LA SUMA DE LOS SALDOS
            this.getSumadeSaldos();
            //CUENTA TODOS LOS CLIENTES REGISTRADOS
            this.ContarClientes();
            //ACTUALIZA EL DATAGRIDVIEW DE LOS PRESTAMOS
            //this.FiltrarPrestamos(this.Armar_Filtro());
            if (ControlPrestamos.Clases.Presentacion.DatosLogin.segnal == 0)
            {
                this.bttneliminargasto.PerformClick();
            }
        }

        private void formClientes_Load(object sender, EventArgs e)
        {
            this.BloqDesbloqCamposPrestamo(true);
            this.Filtrar(this.Armar_Filtro());
            this.getSumadeSaldos();
            this.ContarClientes();
            this.ContarPrestamos();
            this.resaltarPrestamosAtrasados();
            this.getSumaCuotas();
            this.get_Frec_Pagos();
            //this.LBinteres.Text = Convert.ToString(new Prestamo().GetGanaciaenIntereses(this.Armar_Filtro()));
            //this.CargarCuotasPrestamos(codigo);
        }

        //GENERA EL CODIGO DE PRESTAMO Y LO ASIGNA EN EL LABEL INDICADO
        private void GenerarCodigoPrestamo()
        {
            Prestamo objPrestamo = new Prestamo();
            LBLcodigo.Text = objPrestamo.GenerarCodigo();
        }

        private void getDatosPrestamos(string codigo)
        {
            System.Data.Odbc.OdbcDataReader dr = null;
            Prestamo objPrestamo = new Prestamo();
            string sqlselect = "SELECT codigo, valor, porcentaje, total, fecha_inicio, fecha_final, cuotas, valor_cuota, cedula_cliente, saldo, estado, get_descripcion_frecpago(codigo_frecpag)";
            sqlselect += " FROM tprestamo WHERE codigo = '" + codigo + "'";
            dr = objPrestamo.getObjDatareader(sqlselect);
            if (dr.HasRows)
            {
                double sumacuotas = this.getSumaCuotasporPrestamo(dr.GetString(0));
                double aux = Convert.ToDouble(dr.GetValue(3));
                TXTvalor.Text = Convert.ToString(dr.GetValue(1));
                TXTporcent.Text = Convert.ToString(dr.GetValue(2));
                TXTtotal.Text = Convert.ToString(dr.GetValue(3));
                TXTnumcuotas.Text = dr.GetString(6);
                TXTvalorcuota.Text = Convert.ToString(dr.GetValue(7));
                //CBestadoprestamo.Text = dr.GetString(10);
                //TXTsaldo.Text = string.Format("{0:f}", (aux - sumacuotas));
                TXTsaldo.Text = Convert.ToString(dr.GetValue(9));
                LBLcodigo.Text = dr.GetString(0);
                //TXTindice.Text = dr.GetString(10);
                DTPfchinicial.Value = dr.GetDateTime(4);
                DTPfchfinal.Value = dr.GetDateTime(5);
                button3.Enabled = true;
                cbfrepag.Text = dr.GetString(11);
            }
            else
            {
                TXTvalor.Text = "";
                TXTporcent.Text = "";
                TXTtotal.Text = "";
                TXTnumcuotas.Text = "";
                TXTvalorcuota.Text = "";
                TXTsaldo.Text = "";
                LBLcodigo.Text = "";
                TXTindice.Text = "";
                DTPfchinicial.Value = DateTime.Now;
                DTPfchfinal.Value = DateTime.Now;
                button3.Enabled = false;
            }
        }

        private void getSumaCuotas()
        {
            Cuota couta = new Cuota();
            LBsumcuotas.Text = Convert.ToString(couta.SumarCuotas());
        }

        /// <summary>
        /// Devuelve la suma de las cuotas corespondiente al codigo de prestamo que entra como parametro
        /// </summary>
        /// <param name="codigo">codigo del prestamo</param>
        /// <returns></returns>
        private double getSumaCuotasporPrestamo(string codigo)
        {
            double res = new Cuota().SumarCuotas(codigo);
            return res;
        }

        private void getSumadeSaldos()
        {
            Prestamo objPrestamo = new Prestamo();
            this.LBsumasaldo.Text = string.Format("{0:f}", objPrestamo.SumaSaldos());
        }

        private void Guardar()
        {
            //if (TXTindice.Text != "")
            //{
            //ORDENAR DATAGRIDVIEW
            this.dgvprestamos.Sort(dgvprestamos.Columns[0], ListSortDirection.Ascending);
            if (this.actualizarcliente && this.nuevoprestamo == false)
            {
                TXTindice.Text = "0";
            }
            int indice = Convert.ToInt32(TXTindice.Text);
            //GUARDAR PRESTAMO NUEVO

            this.Realizar_Prestamo(this.nuevoprestamo, this.actualizarcliente);
            this.pictureBox1.Visible = false;
            //}
            //else
            //{
            //    msg.Getmensaje(TipoError.DATOS_INVALIDOS);
            //}
            this.Filtrar(this.Armar_Filtro());
            Cargar_PrestamosList();
            TXTindice.Text = "";
        }

        private void habilitardeshabilitarGbox(bool p_valor)
        {
            this.groupBox2.Enabled = p_valor;
            this.groupBox3.Enabled = p_valor;
            this.groupBox4.Enabled = p_valor;
            this.toolStrip1.Enabled = p_valor;
        }

        private void imprimirResumenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConexionDB con = new ConexionDB();
            int idnfil = dgvprestamos.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            string codigo = Convert.ToString(this.dgvprestamos["c_codigo", idnfil].Value);
            Informes objInformes = new Informes();
            string sql = "CREATE OR REPLACE VIEW vista_cuotas AS ";
            sql += "SELECT tprestamo.codigo, tcliente.nombre, tcuotas.fecha, tcuotas.abono, tprestamo.fecha_inicio, tprestamo.fecha_final, tprestamo.valor, tprestamo.total, tprestamo.saldo ";
            sql += "FROM tprestamo, tcliente, tcuotas ";
            sql += "WHERE 	tcliente.cedula = tprestamo.cedula_cliente AND ";
            sql += "tcuotas.codigo_prestamo = '" + codigo + "' AND ";
            sql += "tcuotas.codigo_prestamo = tprestamo.codigo 	";
            sql += "ORDER BY tcuotas.fecha";

            string rpt = "InformeCuotas"; //con.Leer_Archivo_ini(2, Application.StartupPath + "\\listaInformes.ini");
            if (con.Ejecutar(sql))
            {
                objInformes.AbrirInforme(rpt);
            }
        }

        private List<int> IndicesEliminar()
        {
            int i = 0;
            List<int> indices = new List<int>();
            for (i = 0; i < this.dgvcuotas2.RowCount; i++)
            {
                if (Convert.ToInt32(this.dgvcuotas2["c_selectchk", i].Value) == 1)
                {
                    indices.Add(i);
                }
            }
            return indices;
        }

        private void label40_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void LBLcodigo_TextChanged(object sender, EventArgs e)
        {
            this.CargarCuotasPrestamos(LBLcodigo.Text);
        }

        private void LimpiarCampos()
        {
            TXTbarrio.Clear();
            TXTbuscar.Clear();
            TXTcedula.Clear();
            TXTdireccion.Clear();
            TXTnombre.Clear();
            TXTnumcuotas.Text = "0";
            TXTporcent.Text = "0";
            TXTtelefono.Clear();
            TXTtotal.Clear();
            TXTvalor.Text = "0";
            TXTvalorcuota.Clear();
            CBprestamos.Text = "";
            CBprestamos.Items.Clear();            
            this.GenerarCodigoPrestamo();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel3.Visible = true;
            panel3.Size = new Size(panel3.Size.Width, 317);
        }

        private void NuevoIndice()
        {
            Prestamo pres = new Prestamo();
            TXTindice.Text = Convert.ToString(pres.GetMaximoIndice() + 1);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                punto = e.Location;
            }
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.panel3.Left += e.X - punto.X;
                this.panel3.Top += e.Y - punto.Y;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rtodoscuotas.Checked)
            {
                TXTbuscarcuota.Enabled = false;
            }
            else
            {
                TXTbuscarcuota.Enabled = true;
            }
            if (this.rtodoscuotas.Checked || this.rcodigocuota.Checked || this.rfechacuota.Checked)
            {
                TXTbuscarcuota.Text = "";
            }
            if (this.rtodoscuotas.Checked)
            {
                TXTbuscarcuota.Visible = true;
                DTPcuotas.Visible = false;
            }
        }

        private void rcodigocuota_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rcodigocuota.Checked)
            {
                TXTbuscarcuota.Visible = true;
                DTPcuotas.Visible = false;
            }
        }

        /// <summary>
        /// REALIZA EL PRESTAMO VALIDANDO LA INSERCCION DE LOS DATOS DEL CLIENTE Y LOS DATOS DEL PRESTAMO DE ESE CLIENTE
        /// </summary>
        private void Realizar_Prestamo(bool p_nuevoprestamo, bool p_actualizarcliente)
        {
            bool verificador = false;
            bool res = false;
            bool res2 = false;
            int indice = 0;
            //INICIALIZAMOS EL OBJETO CLIENTE DE MANERA LOCAL
            Cliente objCliente = new Cliente(TXTnombre.Text, TXTcedula.Text, TXTdireccion.Text, TXTtelefono.Text, TXTbarrio.Text);
            //DECLARAMOS EL OBJETO PRESTAMO EL CUAL ESTA DECLARADO COMO PROPIEDAD DE ESTE FORM
            Prestamo objPrestamo = null;
            if (this.VerificarCampos(groupBox2))
            {
                //ESTA VARIABLE RECIBE EL VALOR DE LA VERIFICACION DE LOS CAMPOS DEL PRESTAMO
                verificador = this.VerificarCampos(groupBox3);
                if (verificador)
                {
                    string fechaini = DTPfchinicial.Value.ToShortDateString();
                    string fechafin = DTPfchfinal.Value.ToShortDateString();
                    double valor = Convert.ToDouble(TXTvalor.Text);
                    double porcentaje = Convert.ToDouble(TXTporcent.Text);
                    double total = Convert.ToDouble(TXTtotal.Text);
                    int cuotas = Convert.ToInt32(TXTnumcuotas.Text);
                    double valcuota = Convert.ToDouble(TXTvalorcuota.Text);
                    double saldo = Convert.ToDouble(TXTtotal.Text);
                    string cedula = Convert.ToString(TXTcedula.Text);
                    int codfrepag = Convert.ToInt32(cbfrepag.Text.Substring(0, cbfrepag.Text.IndexOf(' ')));
                    objPrestamo = new Prestamo(LBLcodigo.Text, valor, porcentaje, total, cuotas, valcuota, fechaini, fechafin, saldo, cedula, codfrepag);

                    indice = Convert.ToInt32(TXTindice.Text);
                }
                //SE GUARDA EL PRESTAMO Y LOS DATOS DEL CLIENTE
                if (p_nuevoprestamo == false && p_actualizarcliente == false)
                {
                    if (verificador)
                    {
                        res = objCliente.InsertarCliente();
                        res2 = objPrestamo.InsertarPrestamo(indice);

                        if (res && res2)
                        {
                            Cuota cuo = new Cuota(0, LBLcodigo.Text, DateTime.Now.ToShortDateString(), "XXXX", int.Parse(DateTime.Now.DayOfWeek.ToString("d")));
                            cuo.InsertarCuota();
                            msg.Getmensaje(TipoError.INSERCCION_POSITIVA);
                        }
                        else
                        {
                            msg.Getmensaje(TipoError.INSERCCION_NEGATIVA);
                        }
                    }
                    else
                    {
                        msg.Getmensaje(TipoError.DATOS_INVALIDOS);
                    }
                }
                //SE GUARDA EL PRESTAMO
                else if (p_nuevoprestamo == true && p_actualizarcliente == false)
                {
                    if (verificador)
                    {
                        res2 = objPrestamo.InsertarPrestamo(indice);
                        if (res2)
                        {
                            msg.Getmensaje(TipoError.INSERCCION_POSITIVA);
                        }
                        else
                        {
                            msg.Getmensaje(TipoError.INSERCCION_NEGATIVA);
                        }
                        //BLOQUEA EL GROUPBOX QUE CONTIENE LOS DATOS DEL PRESTAMO
                        this.BloqDesbloqCamposPrestamo(true);
                        p_nuevoprestamo = false;
                    }
                    else
                    {
                        msg.Getmensaje(TipoError.DATOS_INVALIDOS);
                    }
                }//SE GUARDA LA ACTUALIZACION DE LOS DATOS DEL CLIENTE
                else if (p_nuevoprestamo == false && p_actualizarcliente == true)
                {
                    objPrestamo = new Prestamo();
                    res = objCliente.ActualizarCliente(this.viejacedula, TXTcedula.Text);
                    res2 = objPrestamo.ActualizarCedulaPrestamo(this.viejacedula, TXTcedula.Text);
                    if (res)
                    {
                        msg.Getmensaje(TipoError.ACTUALIZACION_POSITIVA);
                    }
                    else
                    {
                        msg.Getmensaje(TipoError.ACTUALIZACION_NEGATIVA);
                    }
                    p_actualizarcliente = false;
                }
                //this.ReestablecerPrestamos(); //REESTABLECE LOS CAMPOS DEL PRESTAMO DESPUES DE GUARDAR
            }
            else
            {
                msg.Getmensaje(TipoError.DATOS_INVALIDOS);
            }
        }

        private void ReenumerarIndices()
        {
            progressBar1.Visible = true;
            habilitardeshabilitarGbox(false);
            int i, cont = 1;
            Prestamo pres = new Prestamo();
            progressBar1.Maximum = this.dgvprestamos.RowCount + 1;
            progressBar1.Minimum = 1;
            for (i = 0; i < this.dgvprestamos.RowCount; i++)
            {
                this.UseWaitCursor = true;
                string cod = Convert.ToString(this.dgvprestamos["c_codigo", i].Value);
                pres.GuardarIndices(cont, cod);
                cont++;
                this.progressBar1.Value = cont;
            }
            this.UseWaitCursor = false;
            progressBar1.Visible = false;
            habilitardeshabilitarGbox(true);
        }

        private void ReestablecerPrestamos()
        {
            TXTvalor.Text = "0";
            TXTnumcuotas.Text = "0";
            TXTvalorcuota.Text = "0";
            TXTtotal.Text = "";
            TXTporcent.Text = "0";
            DTPfchinicial.Value = DateTime.Now;
            DTPfchfinal.Value = DateTime.Now;
            GenerarCodigoPrestamo();
            this.NuevoIndice();
            Chkauto.Checked = true;
            this.NuevoIndice();
        }

        /// <summary>
        /// Resalta los prestamos que estan atrasados con un color rojo
        /// </summary>
        private void resaltarPrestamosAtrasados()
        {
            int i, cont = 0;
            for (i = 0; i < dgvprestamos.RowCount; i++)
            {
                string fecha = Convert.ToString(dgvprestamos["c_fechafin", i].Value);
                if (Convert.ToDateTime(fecha) < Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                {
                    dgvprestamos.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
                    dgvprestamos.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    cont++;
                }
                else
                {
                    dgvprestamos.Rows[i].DefaultCellStyle.BackColor = Color.DarkGreen;
                    dgvprestamos.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
            }
            this.LBatrasados.Text = cont.ToString();
        }

        private void rfechacuota_CheckedChanged(object sender, EventArgs e)
        {
            if (rfechacuota.Checked)
            {
                TXTbuscarcuota.Visible = false;
                DTPcuotas.Visible = true;
            }
        }

        private void rfechagastos_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rfechagastos.Checked)
            {
                DTPgastos1.Enabled = true;
                DTPgastos2.Enabled = true;
            }
            else
            {
                DTPgastos1.Enabled = false;
                DTPgastos2.Enabled = false;
            }
        }

        private void rnombregastos_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rnombregastos.Checked || this.rcedulagastos.Checked)
            {
                this.TXTbuscargasto.Enabled = true;
            }
            else
            {
                this.TXTbuscargasto.Enabled = false;
            }
        }

        private void rtodos_CheckedChanged(object sender, EventArgs e)
        {
            if (rtodos.Checked)
            {
                TXTbuscar.Enabled = false;
            }
            else
            {
                TXTbuscar.Enabled = true;
            }
        }

        private void rtodosclientes_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rtodosclientes.Checked)
            {
                this.TXTbuscarcliente.Enabled = false;
            }
            else
            {
                this.TXTbuscarcliente.Enabled = true;
            }
        }

        private void SumarCuotasDGV()
        {
            int i;
            double sum = 0;
            for (i = 0; i < this.dgvcuotas2.RowCount; i++)
            {
                sum += Convert.ToDouble(dgvcuotas2[0, i].Value);
            }
            LBsumcuotas.Text = Convert.ToString(sum);
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == this.tabPage1 || e.TabPage == this.tabPage2 || e.TabPage == this.tabPage3 || e.TabPage == this.tabPage4)
            {
                this.Filtrar(this.Armar_Filtro());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        //GUARDAR PRESTAMO Y DATOS DEL CLIENTE
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Visible = true;
            this.Guardar();
            //Control.CheckForIllegalCrossThreadCalls = false;
            //hilo = new System.Threading.Thread(new System.Threading.ThreadStart(Guardar));
            //hilo.IsBackground = true;
            //hilo.Start();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.GenerarCodigoPrestamo();
            this.LimpiarCampos();
            //this.BloquearDesbloquearPrestamo(true);
            this.BloqDesbloqCamposPrestamo(false);
            //PONE EN false LAS VARIABLES QUE ESTABLECEN CUANDO SE ACTUALIZA UN CLIENTE y CUANDO SE GUARDA UN NUEVO PRESTAMO
            this.actualizarcliente = false;
            this.nuevoprestamo = false;
            this.NuevoIndice();
            Chkauto.Checked = true;
            ActivarDesactivarRegistroCuota(false);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            formCuotas frmcuotas = new formCuotas();
            frmcuotas.MdiParent = this.MdiParent;
            //frmcuotas.TXTcodigo.Text = LBLcodigo.Text;
            frmcuotas.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            hilo = new System.Threading.Thread(new System.Threading.ThreadStart(this.ReenumerarIndices));
            hilo.IsBackground = true;
            hilo.Start();
            this.Filtrar(this.Armar_Filtro());
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            formLimpiar limpiar = new formLimpiar();
            limpiar.TXTbuscar.Text = LBLcodigo.Text;
            limpiar.Traerdatos(1);
            limpiar.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            this.resaltarPrestamosAtrasados();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.Filtrar(this.Armar_Filtro());
            //this.btnbuscar.PerformClick();
            //this.button5.PerformClick();
            //this.button4.PerformClick();
            this.getSumadeSaldos();
            this.ContarClientes();
            this.ContarPrestamos();
            this.getSumaCuotas();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            colorear();
            //Generador gen = new Generador();
            //gen.ReindexarPrestamos(dgvprestamos);
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            formListaPrestamosIndices frmlist = new formListaPrestamosIndices();
            frmlist.Show();
        }

        /// <summary>
        /// Trae los datos del cliente y se los asigna al textBox correspondiente
        /// </summary>
        /// <param name="cedulaCliente">Cedula del cliente</param>
        private void traerDatosCliente(string cedulaCliente)
        {
            this.CBprestamos.Items.Clear();

            Cliente objCliente = new Cliente();
            Prestamo objPrestamo = new Prestamo();
            objCliente.getSelectData1(cedulaCliente);
            TXTnombre.Text = objCliente.Nombre;
            TXTcedula.Text = objCliente.Cedula;
            TXTbarrio.Text = objCliente.Barrio;
            TXTdireccion.Text = objCliente.Direccion;
            TXTtelefono.Text = objCliente.Telefono;

            //CARGA LOS CODIGOS DE PRESTAMOS EN EL COMBOBOX
            this.Cargar_PrestamosList();
            this.CBprestamos.Items.Add("<Nuevo>");
            this.actualizarcliente = true;
        }

        private void TXTbuscar_TextChanged(object sender, EventArgs e)
        {
            this.Filtrar(this.Armar_Filtro());
        }

        private void TXTbuscarced_MouseClick(object sender, MouseEventArgs e)
        {
            this.TXTbuscarced.SelectAll();
        }

        private void TXTbuscarcliente_TextChanged(object sender, EventArgs e)
        {
            this.Filtrar(this.Armar_Filtro());
        }

        private void TXTbuscargasto_TextChanged(object sender, EventArgs e)
        {
            this.Filtrar(this.Armar_Filtro());
            this.LBsumagasto.Text = Convert.ToString(new Gasto().SumarGastos(this.Armar_Filtro()));
        }

        //CALCULA EL VALOR DE LA CUOTA
        private void TXTnumcuotas_TextChanged(object sender, EventArgs e)
        {
            this.CalcularValorCuota();
        }

        //CALCULA EL VALOR TOTAL
        private void TXTporcent_TextChanged(object sender, EventArgs e)
        {
            TXTporcent.Text.Replace(".", ",");
            this.CalcularTotal();
        }

        private void TXTtotal_TextChanged(object sender, EventArgs e)
        {
            TXTsaldo.Text = TXTtotal.Text;
        }

        /// <summary>
        /// Verifica que un groupBox no tenga textBox vacios
        /// </summary>
        /// <param name="gb">GroupBox a verificar</param>
        /// <returns>retorna false si hay algun campo vacio y retorna true si no hay</returns>
        private bool VerificarCampos(GroupBox gb)
        {
            int i, j, cont = 0, cont2 = 0;
            bool res = false;
            //ITERACION QUE CUENTA LOS CONTROLES DENTRO DEL GROUPBOX
            for (i = 0; i < gb.Controls.Count; i++)
            {
                Control obj = new Control();
                obj = gb.Controls[i];
                //VERIFICA SI EL CONTROL ACTUAL ES UN TEXTBOX
                if (gb.Controls[i].GetType() == typeof(TextBox))
                {
                    cont += 1;
                    //VERIFICA QUE EL TEXTBOX SEA DIFERENTE DE LOS SIGUIENTES VALORES
                    if (obj.Text != "" && obj.Text != " " && obj.Text != "0")
                    {
                        cont2 += 1;
                    }
                }
            }

            if (cont == cont2)
            {
                res = true;
            }
            return res;
        }

        /// <summary>
        /// Actualiza los indices
        /// </summary>
        /// <param name="p_indice">indice del datagridview donde inicia la actualizacion</param>
        /// <param name="p_codigo">codigo del indice donde incia la actualizacion</param>
        //private void VerificarActualizarIndices(int p_indice, string p_codigo)
        //{
        //    int i;
        //    int cont = 0;
        //    int rowindex = -1;
        //    //string cod, msg;

        //    Prestamo objPrestamo = new Prestamo();
        //    //BUSCAR LA FILA DONDE INICIARA LA ACTUALIZACION
        //    int aux = p_indice;
        //    for (i = 0; i < this.dgvprestamos.RowCount; i++)
        //    {
        //        int tempindice = Convert.ToInt32(this.dgvprestamos["c_indice", i].Value);
        //        if (p_indice == tempindice)
        //        {
        //            rowindex = i;
        //            break;
        //        }
        //        else
        //        {
        //            cont++;
        //        }
        //    }
        //    //ACTUALIZA LOS INDICES SEGUN EL ORDEN DEL DATAGRIDVIEW
        //    if (rowindex >= 0)
        //    {
        //        for (i = rowindex; i < this.dgvprestamos.RowCount; i++)
        //        {
        //            int tempindice = Convert.ToInt32(this.dgvprestamos["c_indice", i].Value) + 1;
        //            string tempcod = Convert.ToString(this.dgvprestamos["c_codigo", i].Value);

        //            objPrestamo.GuardarIndices(tempindice, tempcod);
        //            //cont++;
        //        }
        //    }
        //}
        /// <summary> /// Verifica que no haya indices repetidos, en el datagridview.
        /// si hay alguno repetido retorna el indice de este en el datagridview
        /// </summary>
        /// <returns>retirna un entero</returns>
        private int VerificarRepetidos()
        {
            int i, j, indice, res = 1;
            for (i = 0; i < this.dgvprestamos.RowCount; i++)
            {
                int cont = 0;
                int rowindex = -1;
                indice = Convert.ToInt32(this.dgvprestamos["c_indice", i].Value);
                for (j = 0; j < this.dgvprestamos.RowCount; j++)
                {
                    int auxindice = Convert.ToInt32(this.dgvprestamos["c_indice", j].Value);
                    if (indice == auxindice)
                    {
                        rowindex = j;
                        cont++;
                    }
                }
                if (cont > 1)
                {
                    res = rowindex;
                    break;
                }
            }
            return res;
        }

        private void colorear()
        {
            Prestamo pre = new Prestamo();
            for (int i = 0; i < dgvprestamos.RowCount; i++)
            {
                int codigo_frecpag = pre.getCodigoFecueciaPago(Convert.ToString(dgvprestamos[0, i].Value));
                int color = pre.getColorFecueciaPago(codigo_frecpag);
                dgvprestamos[0, i].Style.BackColor = Color.FromArgb(color);
                dgvprestamos[0, i].Style.SelectionBackColor = Color.FromArgb(color);
                dgvprestamos[0, i].Style.SelectionForeColor = Color.Black;
            }
        }

        private void colorear2(int fila)
        {
            Prestamo pre = new Prestamo();
            int codigo_frecpag = pre.getCodigoFecueciaPago(Convert.ToString(dgvprestamos[0, fila].Value));
            int color = pre.getColorFecueciaPago(codigo_frecpag);
            lbltipopag.Text = new FrecPago().get_Frecuencia_Pago(codigo_frecpag);            
            panel5.BackColor = Color.FromArgb(color); 
        }

        private void get_Frec_Pagos()
        {
            List<string> lista = new FrecPago().get_Frecuencias_Pagos_List();
            foreach (string str in lista)
            {
                cbfrepag.Items.Add(str);
            }
            cbfrepag.Text = lista[0];
        }

        private void dgvprestamos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}