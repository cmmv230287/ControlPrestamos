using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using ControlPrestamos.Clases.Reglas;
using ControlPrestamos.Clases.DB;
using System.Threading;
namespace ControlPrestamos
{
    public partial class ImportarDatos : Form
    {
        OleDbConnection conex = new OleDbConnection();
        OleDbDataReader dr = null;
        Thread hilo = null;
        public ImportarDatos()
        {
            InitializeComponent();
        }

        private void importar_Datos()
        {
            //Microsoft.Office.Interop.Access.Application app = new Microsoft.Office.Interop.Access.Application();
            //app.OpenCurrentDatabase(TXTarchivo.Text, "true", "");

            
            try
            {
                conex.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectarse con Access", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog archivo = new OpenFileDialog();
            archivo.Filter = "Archivo Access |*.mdb";
            if (archivo.ShowDialog() == DialogResult.OK)
            {
                TXTarchivo.Text = archivo.FileName;
                conex.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + TXTarchivo.Text;
                if (conex.ConnectionString != null)
                {
                    this.llenarCombocontablas();
                    groupBox1.Enabled = true;
                }
            }
        }

        private void llenarCombocontablas()
        {
            comboBox1.Items.Clear();
            conex.Open();
            string[] restriccion = new string[] { null, null, null, "Table" };
            //restriccion[3] = "Table";
            DataTable tablas = conex.GetSchema("Tables", restriccion);
            for (int i = 0; i < tablas.Rows.Count; i++)
            {
                if (tablas.Rows[i][2].ToString().Substring(0, 1) != "_")
                {
                    comboBox1.Items.Add(tablas.Rows[i][2].ToString());
                }
            }
            conex.Close();
        }
        private void LlenarDGV()
        {
            try
            {
                string sqlselect = "";
                conex.Open();
                if (comboBox1.Text == "T_Prestamos")
                {
                    sqlselect = "SELECT T_Prestamos.Id, T_Prestamos.codigo, T_Prestamos.valor, T_Prestamos.saldo, T_Prestamos.fecha_ini, T_Prestamos.fecha_fin, T_Prestamos.valor_cuota, T_Prestamos.valor_total, T_Prestamos.numero_cuotas, T_Prestamos.cedula";
                    sqlselect += " FROM T_Prestamos, T_Clientes";
                    sqlselect += " WHERE T_Clientes.cedula = T_Prestamos.cedula";
                }
                else
                {
                    sqlselect = "SELECT *FROM " + comboBox1.Text;
                }
                DataTable tabla = new DataTable();
                OleDbCommand cmd = new OleDbCommand(sqlselect, conex);
                
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(tabla);
                this.dataGridView1.DataSource = tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conex.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LlenarDGV();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            hilo=new Thread(new ThreadStart(this.Importar));
            hilo.IsBackground = true;
            hilo.Start();
            //this.Importar();
        }
        /// <summary>
        /// Devuelve el indice del prestamo correpondiente
        /// </summary>
        /// <param name="codigo">codigo del prestamo relacionado al indice</param>
        /// <returns></returns>
        private int getIndiceOleDb(string codigo)
        {
            int indice = 0;
            string sql = "SELECT num_indice FROM Indices WHERE codigo_prestamo = '" + codigo + "'";
            OleDbDataReader dr = new OleDbCommand(sql, conex).ExecuteReader();
            if(dr.HasRows)
            {
                dr.Read();
                indice = Convert.ToInt32(dr.GetValue(0));                
            }
            return indice;             
        }
        /// <summary>
        /// Inserta las cuotas correspondiente al un prestamo
        /// </summary>
        /// <param name="oldcodigo">codigo de prestamo del archivo acces</param>
        /// <param name="newcodigo">codigo de prestamo</param>
        private void InsertarCuotasPrestamo(string oldcodigo, string newcodigo)
        {
            string sql = "SELECT codigo_prestamo, abono, fecha FROM T_Cuotas";
            sql += " WHERE codigo_prestamo = '" + oldcodigo + "'";
            
            OleDbDataReader dr = new OleDbCommand(sql, conex).ExecuteReader();
            try
            {
                ConexionDB con = new ConexionDB();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        double abono = Convert.ToDouble(dr.GetValue(1));
                        string codigo = newcodigo;
                        string fecha = dr.GetDateTime(2).ToShortDateString();
                        int numero = new Cuota().MaximaCuota() + 1;
                        string sql2 = " INSERT INTO tcuotas(abono, codigo_prestamo, fecha, numero)";
                        sql2 += " VALUES (" + abono + ", '" + codigo + "', '" + fecha + "', " + numero + ");";
                        con.Ejecutar(sql2);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al momento de insertar una cuota: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Importa los datos de las tablas clientes, prestamo y cuotas a la base de datos DB_INVEREG
        /// </summary>
        private void Importar()
        {
            int contfalse =0;
            bool control = false;
            string newcodigo= "";
            string oldcodigo="";
            try
            {
                conex.Open();
                OleDbDataReader dr = null;
                if (comboBox1.Text == "T_Prestamos")
                {
                    string sqlselect = "SELECT codigo, valor, saldo, fecha_ini, fecha_fin, valor_cuota, valor_total, numero_cuotas, T_Prestamos.cedula";
                    sqlselect += " FROM T_Prestamos, T_Clientes";
                    sqlselect += " WHERE T_Clientes.cedula = T_Prestamos.cedula";
                    dr = new OleDbCommand(sqlselect, conex).ExecuteReader();
                }
                //else if (comboBox1.Text == "T_Cuotas")
                //{
                //    dr = new OleDbCommand("SELECT codigo_prestamo, abono, fecha FROM T_Cuotas ORDER BY T_Cuotas.Id", conex).ExecuteReader();
                //}
                else if (comboBox1.Text == "T_Clientes")
                {
                    dr = new OleDbCommand("SELECT *FROM " + comboBox1.Text, conex).ExecuteReader();
                }
                
                if (dr.HasRows)
                {
                    if (dataGridView1.RowCount > 0)
                    {
                        progressBar1.Maximum = dataGridView1.RowCount - 1;
                    }
                    else
                    {
                        progressBar1.Maximum = 1;
                    }
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        string sql = null;
                        dr.Read();
                        //ARMAR INSERT SQL DE CLIENTES
                        if (comboBox1.Text == "T_Clientes")
                        {
                            sql = "INSERT INTO tcliente(nombre, cedula, direccion, telefono, barrio)";
                            sql += "VALUES('" + dr.GetString(1) + "', '" + dr.GetString(2) + "', '" + dr.GetString(4) + "', '" + dr.GetString(5) + "', '" + dr.GetString(3) + "');";
                        }
                        //ARMAR INSERT SQL DE PRESTAMOS
                        else if (comboBox1.Text == "T_Prestamos")
                        {
                            oldcodigo = dr.GetString(0);
                            string cedula = dr.GetString(8);
                            int indice = getIndiceOleDb(dr.GetString(0));
                            string auxcod = new Prestamo().GenerarCodigo();
                            newcodigo = auxcod;
                            double valor = Convert.ToDouble(dr.GetValue(1));
                            double valorcuota = Convert.ToDouble(dr.GetValue(5));
                            double saldo = Convert.ToDouble(dr.GetValue(2));
                            double total = Convert.ToDouble(dr.GetValue(6));
                            string fechaini = dr.GetDateTime(3).ToShortDateString();
                            string fechafin = dr.GetDateTime(4).ToShortDateString();
                            int numcuotas = dr.GetInt32(7);
                            sql = "INSERT INTO tprestamo(codigo, valor, porcentaje, total, fecha_inicio, fecha_final, cuotas, valor_cuota, cedula_cliente, saldo)";
                            sql += " VALUES ('" + auxcod + "', " + valor + ", 0," + total + ",'" + fechaini + "','" + fechafin + "',";
                            sql += "" + numcuotas + ", " + Convert.ToString(valorcuota).Replace(",", ".") + ", '" + cedula + "', " + saldo + "); ";
                            sql += "INSERT INTO tindice(num_indice, codigo_prestamo) ";
                            sql += "VALUES (" + indice + ", '" + auxcod + "');";
                            control = true;
                        }
                        
                        ConexionDB conexOdbc = new ConexionDB();
                        if (conexOdbc.Ejecutar(sql) == false)
                        {
                            contfalse++;
                        }
                        else
                        {
                            if (control)
                            {
                                this.InsertarCuotasPrestamo(oldcodigo, newcodigo);
                                control = false;
                            }
                        }
                        progressBar1.Value = i;
                    }

                    if (contfalse >= 1)
                    {
                        MessageBox.Show(contfalse + " Registros devolvieron false", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {                        
                        MessageBox.Show("Datos importados con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    dr.Close();
                    dr = null;
                }
                else
                {
                    MessageBox.Show("No hay datos disponibles en el DataReader", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conex.Close();
                progressBar1.Value = 0;
            }
        }

        private void ImportarDatos_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i;
            string sql = "";
            string ced = "";
            int res = 0;
            for (i = 0; i < dataGridView1.RowCount; i++)
            {
                ced = Convert.ToString(dataGridView1[9, i].Value);
                sql = "SELECT COUNT(codigo) FROM tprestamo WHERE cedula_cliente='" + ced + "'";
                res = new ConexionDB().Contar_registros(sql, new ConexionDB().getConexion());
                if (res <= 0)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Black;
                }
            }
        }        
    }
}