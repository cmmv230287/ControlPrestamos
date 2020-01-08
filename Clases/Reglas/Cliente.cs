using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;
using ControlPrestamos.Clases.DB;
using ControlPrestamos.Clases.Presentacion;
namespace ControlPrestamos.Clases.Reglas
{
    class Cliente
    {
        private string nombre = string.Empty;
        private string cedula = string.Empty;
        private string direccion = string.Empty;
        private string telefono = string.Empty;
        private string barrio = string.Empty;
        ConexionDB conex = new ConexionDB();
        private Mensajes msg = new Mensajes();
        #region CONSTRUCTORES
        public Cliente()
        {
            this.nombre = "";
            this.cedula = "";
            this.direccion = "";
            this.telefono = "";
            this.barrio = "";
        }
        /// <summary>
        /// Constructor que inicializa las propiedades del objeto
        /// </summary>
        /// <param name="nom">Nombre del cliente</param>
        /// <param name="ced">Cedula del cliente</param>
        /// <param name="dir">Direccion del cliente</param>
        /// <param name="tel">Telefono del cliente</param>
        /// <param name="bar">Barrio del cliente</param>
        public Cliente(string nom, string ced, string dir, string tel, string bar)
        {
            this.nombre = nom;
            this.cedula = ced;
            this.direccion = dir;
            this.telefono = tel;
            this.barrio = bar;
        }
        #endregion

        #region PROPIEDADES
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public string Cedula
        {
            get
            {
                return this.cedula;
            }
            set
            {
                this.cedula = value;
            }
        }

        public string Direccion
        {
            get
            {
                return this.direccion;
            }
            set
            {
                this.direccion = value;
            }
        }

        public string Telefono
        {
            get
            {
                return this.telefono;
            }
            set
            {
                this.telefono = value;
            }
        }

        public string Barrio
        {
            get
            {
                return this.barrio;
            }
            set
            {
                this.barrio = value;
            }
        }
        #endregion

        #region METODOS
        private Int32 verificarExistencia()
        {
            string sql = "SELECT COUNT(cedula) FROM tcliente WHERE cedula = '" + this.cedula + "'";
            Int32 res = conex.Contar_registros(sql, conex.getConexion());
            return res;
        }
        public int getNumClientes()
        {
            int res = 0;
            res = conex.Contar_registros("SELECT COUNT(cedula) FROM tcliente", conex.getConexion());
            return res;
        }
        public bool InsertarCliente()
        {
            bool res = false;
            Int32 cont = 0;
            if (this.ValidarDatos())
            {
                string sql = "INSERT INTO tcliente(nombre, cedula, direccion, telefono, barrio)";
                sql += "VALUES ('" + Nombre.ToLower() + "', '" + Cedula + "', '" + Direccion + "', '" + Telefono + "', '" + Barrio + "');";
                //ESTE IF VERIFICA LA EXISTENCIA DE UN CLIENTE EN LA DB
                cont = this.verificarExistencia();
                if (cont == 0)
                {
                    res = conex.Ejecutar(sql);
                }
                else
                {
                    msg.Getmensaje(TipoError.EXISTENCIA);
                    res = false;
                }
            }
            else
            {
                msg.Getmensaje(TipoError.DATOS_INVALIDOS);
            }
            return res;
        }

        public bool ActualizarCliente(string actualcedula, string nuevacedula)
        {
            bool res = false;
            Int32 cont = 0;
            if (this.ValidarDatos())
            {
                string sql = "UPDATE tcliente SET nombre='" + Nombre.ToLower() + "', cedula='" + nuevacedula + "', direccion='" + Direccion + "', telefono='" + Telefono + "', barrio='" + Barrio + "'";
                sql += " WHERE cedula = '" + actualcedula + "';";
                res = conex.Ejecutar(sql);
            }
            return res;
        }
        /// <summary>
        /// Elimina un cliente de la base de datos
        /// </summary>
        public bool EliminarCliente()
        {
            bool res = false;
            Int32 cont = 0;
            //string msg = "Error al registrar el cliente, cierre y abra el modulo nuevamente y verifique si el cliente fue registrado,";
            //msg += " si este problema persiste comuniquese con el administrador";

            string sql = "DELETE FROM tcliente WHERE cedula = '" + Cedula + "';";
            //ESTE IF VERIFICA LA EXISTENCIA DE UN CLIENTE EN LA DB
            cont = this.verificarExistencia();
            if (cont == 0)
            {
                res = conex.Ejecutar(sql);
            }
            else
            {
                res = false;
            }
            return res;
        }
        /// <summary>
        /// Elimina un cliente de la base de datos
        /// </summary>
        /// <param name="cedula">cedula del cliente a eliminar</param>
        /// <returns></returns>
        public bool EliminarCliente(string cedula)
        {
            bool res = false;
            Int32 cont = 0;

            string sql = "DELETE FROM tcliente WHERE cedula = '" + cedula + "';";
            res = conex.Ejecutar(sql);
            return res;
        }
        /// <summary>
        /// Valida que las propiedades de la clase no esten en blanco
        /// </summary>
        /// <returns></returns>
        public bool ValidarDatos()
        {
            bool res = false;
            if (Nombre != "" && Cedula != "" && Direccion != "" && Telefono != "" && Barrio != "")
            {
                res = true;
            }
            return res;
        }
        /// <summary>
        /// devuelve 
        /// </summary>
        /// <returns></returns>
        public Cliente getSelectData1(string cedcli)
        {
            Cliente res = new Cliente();
            OdbcDataReader dr = null;
            string sql = "SELECT UPPER(nombre), cedula, direccion, telefono, barrio";
            sql += " FROM tcliente WHERE cedula = '" + cedcli + "';";
            dr = conex.getDataSelect_SQL(sql, conex.getConexion());
            if (dr.HasRows)
            {
                Nombre = dr.GetString(0);
                Cedula = dr.GetString(1);
                Direccion = dr.GetString(2);
                Telefono = dr.GetString(3);
                Barrio = dr.GetString(4);

                res = this;
            }
            else
            {
                res = null;
            }
            return res;
        }

        /// <summary>
        /// Devuelve un objeto datareader con los datos del sql select
        /// </summary>
        /// <param name="sqlselect">sql select a ejecutar</param>
        /// <returns></returns>
        public OdbcDataReader getSelectData2(string sqlselect)
        {
            OdbcDataReader dr = null;

            dr = conex.getDataSelect_SQL(sqlselect, conex.getConexion());

            return dr;
        }

        #endregion
    }
}
