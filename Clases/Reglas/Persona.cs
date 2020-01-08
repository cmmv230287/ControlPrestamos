using System;
using System.Collections.Generic;
using System.Text;
using ControlPrestamos.Clases.DB;
using System.Data.Odbc;
namespace ControlPrestamos.Clases.Reglas
{
    class Persona
    {
        private string cedula;
        private string nombre;
        private Int16 tipo;
        private ConexionDB con = new ConexionDB();
        #region CONTRUCTORES

        public Persona()
        {
            this.cedula = null;
            this.nombre = null;
            this.tipo = 0;
        }

        public Persona(string p_cedula, string p_nombre, Int16 p_tipo)
        {
            this.cedula = p_cedula;
            this.nombre = p_nombre;
            this.tipo = p_tipo;
        }
        #endregion

        #region PROPIEDADES

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public string Cedula
        {
            get { return this.cedula; }
            set { this.cedula = value; }
        }

        public Int16 Tipo
        {
            get { return this.tipo; }
            set { this.tipo = value; }
        }
        #endregion

        #region METODOS
        public bool registrarPersona()
        {
            string sql = "INSERT INTO tpersonas(cedula, nombre, tipo) ";
            sql += "VALUES ('" + Cedula + "', '" + Nombre + "', " + Tipo + ");";
            return con.Ejecutar(sql);
        }

        public bool actualizarPersona(string p_cedula, string p_nombre, Int16 p_tipo, string oldcedula)
        {
            string sql = "UPDATE tpersonas SET cedula='" + p_cedula + "', nombre='" + p_nombre + "', tipo=" + p_tipo;
            sql += "WHERE cedula='" + oldcedula + "'";
            return con.Ejecutar(sql);
        }

        public bool eliminarPersona(string p_cedula)
        {
            string sql = "DELETE FROM tpersonas WHERE cedula='" + p_cedula + "'";
            return con.Ejecutar(sql);
        }

        public bool verificarexistencia(string p_cedula)
        {
            bool res = false;
            string sql = "SELECT count(cedula) FROM tpersonas WHERE cedula = '" + p_cedula + "'";
            if (con.getDataSelect_SQL3(sql, con.getConexion()) > 0)
            {
                res = true;
            }
            return res;
        }

        public Persona getPersona(string p_cedula)
        {
            Persona res = new Persona();
            string sql = "SELECT cedula, nombre, tipo FROM tpersonas WHERE cedula like '" + p_cedula + "%'";
            try
            {
                con.Conectar();
                OdbcDataReader dr = new OdbcCommand(sql, con.getConexion()).ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        res.Cedula = dr.GetString(0);
                        res.Nombre = dr.GetString(1);
                        res.Tipo = dr.GetInt16(2);
                    }
                }
            }
            catch 
            {
                res = null;
            }
            con.Desconectar();
            return res;
        }
        #endregion

    }
}
