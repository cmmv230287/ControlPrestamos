using System;
using System.Collections.Generic;
using System.Text;
using ControlPrestamos.Clases.DB;
using System.Windows.Forms;
namespace ControlPrestamos.Clases.Reglas
{
    class Cuota
    {
        private double abono;
        private string codigoprestamo;
        private string fecha;
        private string cedcobrador;
        private int cod_dia;
        private ConexionDB conex = new ConexionDB();

        public double Abono
        {
            get
            {
                return this.abono;
            }
            set
            {
                this.abono = value;
            }
        }

        public string CodigoPrestamo
        {
            get
            {
                return this.codigoprestamo;
            }
            set
            {
                this.codigoprestamo = value;
            }
        }

        public string Fecha
        {
            get
            {
                return this.fecha;
            }
            set
            {
                this.fecha = value;
            }
        }

        public string CedulaCobrador
        {
            get
            {
                return this.cedcobrador;
            }
            set
            {
                this.cedcobrador = value;
            }
        }

        public int Cod_Dia
        {
            get
            {
                return this.cod_dia;
            }
            set
            {
                this.cod_dia = value;
            }
        }
        #region CONSTRUCTORES
        public Cuota()
        {
            this.abono = 0;
            this.codigoprestamo = "0000";
            this.fecha = "00/00/0000";
            this.cedcobrador = "00000";
        }
        
        public Cuota(double abono, string codigo, string fecha, string cedulacobrador, int cod_dia)
        {
            this.abono = abono;
            this.codigoprestamo = codigo;
            this.fecha = fecha;
            this.cedcobrador = cedulacobrador;
            this.cod_dia = cod_dia;
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Inserta los datos de la cuota en la tabla
        /// </summary>
        /// <returns>true si fue exitoso y false si hubo algun error</returns>
        public bool InsertarCuota()
        {
            bool res = false;
            int numero = 0;
            //string fecha = DateTime.Now.ToShortDateString().Replace('/', '-');
            //fecha = fecha.Substring(6, 4) + "-" + fecha.Substring(3, 2) + "-" + fecha.Substring(0, 2);
            
            if (this.MaximaCuota() == 0)
            {
                numero = 1;
            }
            else if (this.MaximaCuota() > 0)
            {
                numero = this.MaximaCuota() + 1;
            }
            if (this.ValidardatosCuota())
            {
                string sql = "INSERT INTO tcuotas(abono, codigo_prestamo, fecha, numero, cobrador, cod_dia)";
                sql += " VALUES (" + Abono.ToString().Replace(",", ".") + ",";
                sql += "'" + CodigoPrestamo + "',";
                sql += "'" + this.Fecha + "', " + numero + ",'" + CedulaCobrador + "', " + Cod_Dia + ");";
                res = conex.Ejecutar(sql);
            }
            else
            {
                res = false;
            }
            return res;
        }

        public int MaximaCuota()
        {
            string sql = "SELECT MAX(numero) FROM tcuotas";
            int res = conex.MaxNumero(sql);
            return res;
        }
        public double SumarCuotas()
        {
            string sql = "SELECT SUM(abono) FROM tcuotas";
            double res = conex.Sumar_Valores_de_Campos(sql);
            return res;
        }
        public double SumarCuotas(string codigo_prestamo)
        {
            string sql = "SELECT SUM(abono) FROM tcuotas WHERE codigo_prestamo = '" + codigo_prestamo + "'";
            double res = conex.Sumar_Valores_de_Campos(sql);
            return res;
        }
        public bool EliminarCuota(string p_codigo, int p_numero)
        {
            string sql = "DELETE FROM tcuotas WHERE codigo_prestamo = '" + p_codigo + "' AND numero = " + p_numero;
            return conex.Ejecutar(sql);
        }

        public bool ModificarCuota(string p_oldcodigo, string p_oldfecha, string p_newcodigo, string p_newfecha, double p_abono)
        {
            string sql = "UPDATE tcuotas SET abono=" + p_abono + ", codigo_prestamo='" + p_newcodigo + "', fecha='" + p_newfecha + "'";
            sql += " WHERE codigo_prestamo = '" + p_oldcodigo + "' AND fecha = '" + p_oldfecha + "'";
            return conex.Ejecutar(sql);
        }
        public bool ValidardatosCuota()
        {
            bool res = true;
            if (CodigoPrestamo == "0000" || Fecha == "00/00/0000")
            {
                res = false;
            }
            return res;
        }

        public int verificarExistencia(string codigo, string fecha)
        {
            string sql = "select count(codigo_prestamo) from tcuotas where codigo_prestamo = '" + codigo + "' and fecha = '" + fecha + "'";
            ConexionDB con = new ConexionDB();
            return con.getDataSelect_SQL3(sql, con.getConexion());
        }
        public void CargarCuotas(string sql, DataGridView dgv)
        {
            conex.llenar_DGV(sql, dgv, conex.getConexion());
        }
        #endregion

    }
}
