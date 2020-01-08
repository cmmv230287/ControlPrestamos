using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlPrestamos.Clases.DB;

namespace ControlPrestamos.Formularios
{
    public partial class formCuotasDias : Form
    {
        DataTable table = new DataTable();
        public formCuotasDias()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            table = cargar_Grid();
        }

        private void Exportar_Excel(DataRow dr)
        {
            string archivo = Application.StartupPath + "\\InformeDiasSemana.xlsx";
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook libro = app.Workbooks.Open(archivo, Type.Missing, true);
            Microsoft.Office.Interop.Excel.Worksheet hoja = (libro.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet);   
            int cont=0;
            int inicio = 4;
            int indice = inicio;
            app.Visible = true;
            ////hoja.Range["B" + 1].Value = dr["nombre"].ToString();
            ////hoja.Range["B" + 2].Value = dr["codigo"].ToString();
            hoja.Range["B" + 1].Value = "Desde  " + string.Format("{0:dd-MMM-yyyy}", fchini.Value) + "  hasta  " + string.Format("{0:dd-MMM-yyyy}", fchfin.Value);
            for (cont = 0; cont < dgvDiasCuotas.RowCount; cont++)
            {
                hoja.Range["A" + indice].Value = dgvDiasCuotas["nombre", cont].Value;
                hoja.Range["B" + indice].Value = dgvDiasCuotas["codigo", cont].Value;
                hoja.Range["C" + indice].Value = dgvDiasCuotas["lunes", cont].Value;
                hoja.Range["D" + indice].Value = dgvDiasCuotas["martes", cont].Value;
                hoja.Range["E" + indice].Value = dgvDiasCuotas["miercoles", cont].Value;
                hoja.Range["F" + indice].Value = dgvDiasCuotas["jueves", cont].Value;
                hoja.Range["G" + indice].Value = dgvDiasCuotas["viernes", cont].Value;
                hoja.Range["H" + indice].Value = dgvDiasCuotas["sabado", cont].Value;
                                
                hoja.Range["C" + indice].NumberFormat = "$ #.##0,00";
                hoja.Range["D" + indice].NumberFormat = "$ #.##0,00";
                hoja.Range["E" + indice].NumberFormat = "$ #.##0,00";
                hoja.Range["F" + indice].NumberFormat = "$ #.##0,00";
                hoja.Range["G" + indice].NumberFormat = "$ #.##0,00";
                hoja.Range["H" + indice].NumberFormat = "$ #.##0,00";
                indice++;
            }
            hoja.Range["A" + inicio + ":H" + (indice - 1)].Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
            app = null;
            GC.Collect();
        }

        private DataTable cargar_Grid2()
        {            
            ConexionDB con = new ConexionDB();
            string sql = "select  tcliente.nombre ";
            sql += ",tprestamo.codigo ";
            sql += ",tcuotas.abono ";
            sql += ",tcuotas.fecha ";
            sql += ",dias.dsc_dia ";
            sql += "from tprestamo  ";
            sql += "inner join tcuotas on tprestamo.codigo = tcuotas.codigo_prestamo ";
            sql += "inner join dias on dias.cod_dia = tcuotas.cod_dia ";
            sql += "inner join tcliente on tcliente.cedula = tprestamo.cedula_cliente ";
            sql += "where tprestamo.codigo like '" + txtcodigo.Text + "%'";
            sql += "and fecha between to_date('" + String.Format("{0:yyyy-MM-dd}", fchini.Value) + "','yyyy-MM-dd') and to_date('" + String.Format("{0:yyyy-MM-dd}", fchfin.Value) + "','yyyy-MM-dd') "; 
            sql += "order by tcuotas.fecha";
            DataTable dt = con.get_DataTable(sql, con.getConexion());

            int totalFilas = 0;
            totalFilas = ((dt.Rows.Count % 6) == 0) ? (dt.Rows.Count / 6) : int.Parse((dt.Rows.Count / 6).ToString()) + 1;
            int filas = 0;
            int desde = 0;
            int hasta = dt.Rows.Count;
            int f = 0;
            int cont = 0;
            for (filas = 0; filas < totalFilas; filas++)
            {                
                dgvDiasCuotas.Rows.Add();
                dgvDiasCuotas["codigo", filas].Value = dt.Rows[cont]["codigo"].ToString();
                for (f = 0; f < 6; f++) 
                {
                    if (cont < dt.Rows.Count)
                    {
                        string col = dt.Rows[cont]["dsc_dia"].ToString().ToLower();
                        double abono = Double.Parse(dt.Rows[cont]["abono"].ToString());
                        dgvDiasCuotas[col, filas].Value = string.Format("{0:0.00}", abono);
                        cont++;
                        if (col == "sabado")
                        {
                            break;
                        }
                    }
                }
                desde = f;
            }
            return dt;
        }

        private DataTable cargar_Grid()
        {
            ConexionDB con = new ConexionDB();
            dgvDiasCuotas.Rows.Clear();
            string sql2 = "select  num_indice, tcliente.nombre ";
            sql2 += ",tprestamo.codigo ";            
            sql2 += "from tprestamo  ";
            sql2 += "inner join tcuotas on tprestamo.codigo = tcuotas.codigo_prestamo ";
            sql2 += "inner join dias on dias.cod_dia = tcuotas.cod_dia ";
            sql2 += "inner join tcliente on tcliente.cedula = tprestamo.cedula_cliente ";
            sql2 += "inner join tindice on tindice.codigo_prestamo = tprestamo.codigo ";
            sql2 += "where tprestamo.codigo like '" + txtcodigo.Text + "%' ";
            //sql2 += "and fecha between to_date('" + String.Format("{0:yyyy-MM-dd}", fchini.Value) + "','yyyy-MM-dd') and to_date('" + String.Format("{0:yyyy-MM-dd}", fchfin.Value) + "','yyyy-MM-dd') ";
            sql2 += "group by tcliente.nombre, tprestamo.codigo, num_indice ";
            sql2 += "order by num_indice";
            DataTable dt2 = con.get_DataTable(sql2, con.getConexion());

            int totalFilas = 0;
            totalFilas = dt2.Rows.Count;//((dt.Rows.Count % 6) == 0) ? (dt.Rows.Count / 6) : int.Parse((dt.Rows.Count / 6).ToString()) + 1;
            int filas = 0;
            int desde = 0;
            int hasta = dt2.Rows.Count;
            int f = 0;
            int cont = 0;
            string codigo_Actual = "";
            string nombre_cliente = "";
            for (filas = 0; filas < dt2.Rows.Count; filas++)
            {
                dgvDiasCuotas.Rows.Add();
                codigo_Actual = dt2.Rows[filas]["codigo"].ToString();
                nombre_cliente = dt2.Rows[filas]["nombre"].ToString();
                dgvDiasCuotas["codigo", filas].Value = codigo_Actual;
                dgvDiasCuotas["nombre", filas].Value = nombre_cliente;
                Cargar_Codigos(codigo_Actual, filas);
                desde = f;
            }
            return dt2;
        }

        private void Cargar_Codigos(string codigo_Actual, int fila)
        {
            ConexionDB con = new ConexionDB();
            string sql = "select  num_indice, tcliente.nombre ";
            sql += ",tprestamo.codigo ";
            sql += ",tcuotas.abono ";
            sql += ",tcuotas.fecha ";
            sql += ",dias.dsc_dia ";
            sql += "from tprestamo  ";
            sql += "inner join tcuotas on tprestamo.codigo = tcuotas.codigo_prestamo ";
            sql += "inner join dias on dias.cod_dia = tcuotas.cod_dia ";
            sql += "inner join tcliente on tcliente.cedula = tprestamo.cedula_cliente ";
            sql += "inner join tindice on tindice.codigo_prestamo = tprestamo.codigo ";
            sql += "where tprestamo.codigo like '" + codigo_Actual + "%' ";
            sql += "and fecha between to_date('" + String.Format("{0:yyyy-MM-dd}", fchini.Value) + "','yyyy-MM-dd') and to_date('" + String.Format("{0:yyyy-MM-dd}", fchfin.Value) + "','yyyy-MM-dd') ";
            //sql += "group by tcliente.nombre, tprestamo.codigo, num_indice ";
            sql += "order by tcuotas.fecha";

            DataTable dt = con.get_DataTable(sql, con.getConexion());
            for (int cont = 0; cont < dt.Rows.Count; cont++)
            {
                string col = dt.Rows[cont]["dsc_dia"].ToString().ToLower();
                double abono = Double.Parse(dt.Rows[cont]["abono"].ToString());
                dgvDiasCuotas[col, fila].Value = string.Format("{0:0.00}", abono);
                
                if (col == "sabado")
                {
                    break;
                }
            }
        }
        private void formCuotasDias_Load(object sender, EventArgs e)
        {
            string sql = "SELECT dsc_dia FROM dias;";
            ConexionDB con = new ConexionDB();
            DataTable dt = con.get_DataTable(sql, con.getConexion());
            dgvDiasCuotas.Columns.Add("nombre", "Nombre");
            dgvDiasCuotas.Columns.Add("codigo", "Codigo");
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgvDiasCuotas.Columns.Add(dt.Rows[i]["dsc_dia"].ToString().ToLower(), dt.Rows[i]["dsc_dia"].ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            Exportar_Excel(table.Rows[0]);
        }
    }
}
