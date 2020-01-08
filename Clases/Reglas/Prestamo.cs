using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using ControlPrestamos.Clases.DB;
using ControlPrestamos.Clases.Presentacion;
namespace ControlPrestamos.Clases.Reglas
{
    class Prestamo
    {
        private string codigo;
        private double valor;
        private double porcentaje;
        private double total;
        private int numcuota;
        private double valorcuota;
        private string fchinicial;
        private string fchfinal;
        private double saldo;
        private string cedulacliente;
        private int cod_frecpag;
        ConexionDB conex = new ConexionDB();
        Mensajes msg = new Mensajes();
        #region CONSTRUCTORES
        public Prestamo()
        {
            codigo = "";
            valor = 0;
            porcentaje = 0;
            total = 0;
            numcuota = 0;
            valorcuota = 0;
            fchinicial = "00/00/0000";
            fchfinal = "00/00/0000";
            saldo = 0;
            cedulacliente = "";
        }

        public Prestamo(string cod, double val, double por,double tot,int cuotas,double valcuota, string fechaini, string fechafin, double sal, string ced, int codfrecpag)
        {
            codigo = cod;
            valor = val;
            porcentaje = por;
            total = tot;
            numcuota = cuotas;
            valorcuota = valcuota;
            fchinicial = fechaini;
            fchfinal = fechafin;
            saldo = sal;
            cedulacliente = ced;
            cod_frecpag = codfrecpag;
        }
        #endregion

        #region PROPIEDADES
        public string Codigo
        {
            get { return this.codigo; }
            set { this.codigo = value; }
        }
        public int Cod_FrePag
        {
            get { return this.cod_frecpag; }
            set { this.cod_frecpag = value; }
        }
        public double Valor
        {
            get { return this.valor; }
            set { this.valor = value; }
        }

        public double Porcentaje
        {
            get { return this.porcentaje; }
            set { this.porcentaje = value; }
        }

        public double Total
        {
            get { return this.total; }
            set { this.total = value; }
        }

        public int Numcuota
        {
            get { return this.numcuota; }
            set { this.numcuota = value; }
        }

        public double ValorCuota
        {
            get { return this.valorcuota; }
            set { this.valorcuota = value; }
        }

        public string FechaInicial
        {
            get { return this.fchinicial; }
            set { this.fchinicial = value; }
        }

        public string FechaFinal
        {
            get { return this.fchfinal; }
            set { this.fchfinal = value; }
        }

        public double Saldo
        {
            get { return this.saldo; }
            set { this.saldo = value; }
        }

        public string CedulaCliente
        {
            get { return this.cedulacliente; }
            set { this.cedulacliente = value; }
        }
        #endregion

        #region METODOS
        private bool ValidarDatos()
        {
            bool res = false;
            if (Valor > 0 && Porcentaje > 0 && Total > 0 && FechaInicial != "" && FechaFinal != "" && Numcuota > 0 && ValorCuota > 0 && CedulaCliente != "" && Saldo > 0)
            {
                res = true;
            }
            return res;
        }

        private int getMaximoIndice()
        {
            string sql = "SELECT MAX(indice) FROM tprestamo";
           return conex.MaxNumero(sql);
        }

        public bool InsertarPrestamo(int indice)
        {
            bool res = false;
            //int indice;
            if (this.ValidarDatos())
            {
                //indice = this.getMaximoIndice() + 1;
                string sql = "INSERT INTO tprestamo(codigo, valor, porcentaje, total, fecha_inicio, fecha_final, cuotas, valor_cuota, cedula_cliente, codigo_frecpag, saldo,  indice) ";
                sql += "VALUES ('" + Codigo + "',";
                sql += Valor.ToString().Replace(",", ".") + ",";
                sql += Porcentaje.ToString().Replace(",", ".") + ",";
                sql += Total.ToString().Replace(",", ".") + ",'";
                sql += FechaInicial + "','";
                sql += FechaFinal + "',";
                sql += Numcuota + ",";
                sql += ValorCuota.ToString().Replace(",", ".") + ",'";
                sql += CedulaCliente + "',";
                sql += Cod_FrePag + ", ";
                sql += Saldo.ToString().Replace(",", ".") + ", " + indice + ");";
               
                //SE EJECUTA LA CONSULTA
                res = conex.Ejecutar(sql);               
            }
            else
            {
                msg.Getmensaje(TipoError.DATOS_INVALIDOS);
            }
            return res;
        }

        public OdbcDataReader getObjDatareader(string sqlselect)
        {
            return conex.getDataSelect_SQL(sqlselect, conex.getConexion());
        }
        /// <summary>
        /// Elimina el prestamo y todas la cuotas relacionadas a este
        /// </summary>
        /// <param name="cod">codigo del prestamo a eliminar</param>
        /// <returns></returns>
        public bool EliminarPrestamo(string cod)
        {
            string sql = "DELETE FROM tprestamo WHERE codigo = '" + cod + "';";
            //string sql2 = "DELETE FROM tcuotas WHERE codigo_prestamo = '" + cod + "';";
            bool res = false;
            if (conex.Ejecutar(sql))
            {
                res = true;
            }
            return res;
        }

        public bool ActualizarCedulaPrestamo(string p_cedulavieja, string p_cedulanueva)
        {
            string sql = "UPDATE tprestamo SET cedula_cliente='" + p_cedulanueva + "' WHERE cedula_cliente = '" + p_cedulavieja + "';";
            bool res = conex.Ejecutar(sql);
            return res;
        }

        public bool ActualizarPrestamo(string codigo, double valor, double porcentaje, double total, double saldo, string fecha_ini, string fecha_fin, int numcuotas, double valorcuota, int codigo_frecpag)
        {
            string sql = "UPDATE tprestamo ";
            sql += "SET  valor=" + valor.ToString().Replace(',', '.') + ", porcentaje=" + porcentaje.ToString().Replace(',', '.') + ", total=" + total.ToString().Replace(',', '.') + ", fecha_inicio='" + fecha_ini + "', fecha_final='" + fecha_fin + "', ";
            sql += "cuotas=" + numcuotas + ", valor_cuota=" + valorcuota.ToString().Replace(',', '.') + ", saldo=" + saldo.ToString().Replace(',', '.') + ", codigo_frecpag=" + codigo_frecpag;
            sql += " WHERE codigo = '" + codigo + "'";
            bool res = conex.Ejecutar(sql);
            return res;
        }

        public void llenarListbox(string sql, ComboBox lista)
        {
            conex.Llenar_Listbox(sql,lista,conex.getConexion());
        }        

        public void Filtrar_Prestamo(string sql, DataGridView dgv)
        {
            conex.llenar_DGV(sql, dgv, conex.getConexion());
        }

        //GENERA Y RETORNA EL CODIGO DE PRESTAMO
        public String GenerarCodigo()
        {
            Generador gen = new Generador();
            string res = gen.Generar_Codigo(conex.getConexion(), 4, "SELECT MAX(codigo) FROM tprestamo;");
            return res;
        }

        public bool GuardarIndices(int p_indice, string p_codigo)
        {
            string sql = "UPDATE tprestamo SET indice = " + p_indice + " WHERE codigo = '" + p_codigo + "'";
            return conex.Ejecutar(sql);
        }

        //public void ReorganizarIndice(int p_indice, string p_codigo, int indiceinicio)
        //{
        //    string sql = "UPDATE tprestamo SET indice = " + p_indice + " WHERE codigo = '" + p_codigo + "'";

        //}

        public double GetGanaciaenIntereses(string filtro)
        {
            double res=0;
            string sql = "select SUM(((valor * porcentaje) / 100)) as interes from tprestamo, tcliente ";
            sql += filtro;
            res = new DB.ConexionDB().Sumar_Valores_de_Campos(sql);
            return res;
        }
        public double SumaSaldos()
        {
            return conex.Sumar_Valores_de_Campos("SELECT SUM(saldo) FROM tprestamo WHERE estado = 'Activo'");
        }

        public int GetMaximoIndice()
        {
            return conex.MaxNumero("SELECT MAX(indice) FROM tprestamo");
        }

        public bool CambiarEstado(string codigo, string nuevoestado)
        {
            string sql = "update tprestamo set estado='" + nuevoestado + "' where codigo = '" + codigo + "'";
            ConexionDB con = new ConexionDB();
            return con.Ejecutar(sql);
        }

        /// <summary>
        /// Retorna la suma de todo lo que se ha cobrado entre dos fechas
        /// </summary>
        /// <param name="fecha1">fecha inicial</param>
        /// <param name="fecha2">fecha final</param>
        /// <returns>valor del recaudo</returns>
        public double getRecaudo(string fecha1, string fecha2)
        {
            ConexionDB con = new ConexionDB();
            string sql = "select sum(abono) from tcuotas where fecha between '" + fecha1 + "' and '" + fecha2 + "'";
            double res = con.Sumar_Valores_de_Campos(sql);
            return res;
        }

        /// <summary>
        /// Retorna la suma de todo lo que se ha prestado entre dos fechas
        /// </summary>
        /// <param name="fecha1">fecha inicial</param>
        /// <param name="fecha2">fecha final</param>
        /// <returns>valor prestado</returns>
        public double getPrestado(string fecha1, string fecha2)
        {
            ConexionDB con = new ConexionDB();
            string sql = "select sum(valor) from tprestamo, tcliente where cedula = cedula_cliente and fecha_inicio between '" + fecha1 + "' and '" + fecha2 + "'";
            double res = con.Sumar_Valores_de_Campos(sql);
            return res;
        }

        /// <summary>
        /// Retorna la suma de todo lo que se ha ganado en intereses entre dos fechas
        /// </summary>
        /// <param name="fecha1">fecha inicial</param>
        /// <param name="fecha2">fecha final</param>
        /// <returns>valor intereses</returns>
        public double getInteresesporFecha(string fecha1, string fecha2)
        {
            ConexionDB con = new ConexionDB();        
            string sql = "select SUM(((valor * porcentaje) / 100)) as interes from tprestamo, tcliente ";
            sql += "where cedula = cedula_cliente and fecha_inicio between '" + fecha1 + "' and '" + fecha2 + "'";
            double res = con.Sumar_Valores_de_Campos(sql);
            return res;
        }

        public int getColorFecueciaPago(int codigo_frecpag)
        {
            ConexionDB con = new ConexionDB();
            return con.getDataSelect_SQL3("select get_colorFrecPago(" + codigo_frecpag + ") ", con.getConexion());
        }

        public int getCodigoFecueciaPago(string codigo_prestamo)
        {
            ConexionDB con = new ConexionDB();
            return con.getDataSelect_SQL3("select get_codfrecpag('" + codigo_prestamo + "') ", con.getConexion());
        }

        ////public int validar_existencia_prestamo_en_indice(string codigo_prestamo)
        ////{
        ////    ConexionDB con = new ConexionDB();
        ////    string sql = string.Format("select count(1) from tindice.codigo_prestamo = {0}", codigo_prestamo);
        ////    return con.getDataSelect_SQL3(sql, con.getConexion());
        ////}
    }
        #endregion
    
}
