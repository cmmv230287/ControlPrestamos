using System;
using System.Collections.Generic;
using System.Text;
using ControlPrestamos.Clases.DB;

namespace ControlPrestamos.Clases.Reglas
{
    class Usuario
    {
        ConexionDB conex = new ConexionDB();
        private string usuario;
        private string pasw;
        private string nombre;

        #region CONSTRUCTORES
        public Usuario()
        {
            this.usuario = "";
            this.pasw = "";
            this.nombre = "";
        }

        public Usuario(string Usuar, string Pass)
        {
            this.usuario = Usuar;
            this.pasw = Pass;
            this.nombre = "";
        }
        #endregion

        #region PROPIEDADES
        public string admUsuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }

        public string admPassword
        {
            get { return this.pasw; }
            set { this.pasw = value; }
        }

        public string admNombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        #endregion

        #region METODOS
        public bool iniciarSession()
        {
            return VerificarExistenciaUsuario();            
        }

        private bool VerificarExistenciaUsuario()
        {
            bool res = false;
            string sql = "SELECT COUNT(nombre) FROM tlogin WHERE usuario = '" + admUsuario + "'  AND passw = '" + admPassword + "'";
            if (conex.Contar_registros(sql, conex.getConexion()) > 0)
            {                
                res = true;
            }
            return res;
        }

        public bool CambiarPassword(string actualpass, string nuevopass, string usuar)
        {
            string sql = "UPDATE tlogin SET passw='" + nuevopass + "' WHERE usuario='" + usuar + "'";
            return conex.Ejecutar(sql);
        }
        /// <summary>
        /// Devuelve el nombre del usuario actualmente conectado dependiendo de la identificacion
        /// </summary>
        /// <param name="identificacion">Identificacion del usuario (normalmente es la cedula)</param>
        /// <returns></returns>
        public string getNombreUsuario(string identificacion)
        {
            string sql = "SELECT nombre FROM tlogin WHERE usuario = '" + identificacion + "'";
            string res = null;
            System.Data.Odbc.OdbcDataReader dr = conex.getDataSelect_SQL(sql, conex.getConexion());
            if (dr.HasRows)
            {
                dr.Read();
                res = dr.GetString(0).ToUpper();
            }
            return res;
        }
        #endregion

    }
}
