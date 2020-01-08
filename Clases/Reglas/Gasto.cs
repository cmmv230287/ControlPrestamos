using System;
using System.Collections.Generic;
using System.Text;
using ControlPrestamos.Clases.DB;
using ControlPrestamos.Clases.Presentacion;
namespace ControlPrestamos.Clases.Reglas
{
    class Gasto
    {
        private double valor;
        private string cedulapersona;
        private string concepto;

        public Gasto()
        {
            this.valor = 0;
            this.cedulapersona = "";
            this.concepto = "";
        }

        public Gasto(double pValor, string pCedula, string pConcepto)
        {
            this.valor = pValor;
            this.cedulapersona = pCedula;
            this.concepto = pConcepto;
        }
        /// <summary>
        /// Cedula de la persona a la cual se le cargara el gasto
        /// </summary>
        public string Cedula
        {
            get
            {
                return this.cedulapersona;
            }
            set
            {
                this.cedulapersona = value;
            }
        }

        /// <summary>
        /// Concepto del gasto
        /// </summary>
        public string Concepto
        {
            get
            {
                return this.concepto;
            }

            set
            {
                this.concepto = value;
            }
        }

        /// <summary>
        /// Valor gastado
        /// </summary>
        public double Valor
        {
            get
            {
                return this.valor;
            }

            set
            {
                this.valor = value;
            }
        }

        public bool  RegistrarGasto(string fechagasto)
        {
            ConexionDB con = new ConexionDB();
            int numero = con.MaxNumero("SELECT MAX(numerogasto) as numerogasto FROM tgastos") + 1;
            string aux = DatosLogin.usuario;
            string cedulausr = aux.Substring(0, (aux.Length - aux.IndexOf(' ')-1));
            ///////////////////////
            aux = this.cedulapersona;
            this.cedulapersona = aux.Substring(0, aux.IndexOf(' '));
            string sql = "INSERT INTO tgastos(cedulagasto, valorgasto, dscgasto, numerogasto, cedulausragr, fechagasto) ";
            sql += "values('" + this.cedulapersona + "'," + this.valor + ",'" + this.concepto + "'," + numero + ",'" + cedulausr + "','" + fechagasto + "')";
            return con.Ejecutar(sql);         
        }

        public double SumarGastos(string filtro)
        {
            ConexionDB con = new ConexionDB();
            double res = 0;
            string sql = "select sum(valorgasto) from tgastos, tpersonas ";
            sql += filtro;
            res = con.Sumar_Valores_de_Campos(sql);
            return res;
        }

        public bool EliminarGasto(int numero)
        {
            ConexionDB con = new ConexionDB();
            string sql = "delete from tgastos where numerogasto = " + numero;
            return con.Ejecutar(sql);
        }
    }
}
