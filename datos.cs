using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace ControlPrestamos
{
    class datos
    {
        public static string cadconex = System.Configuration.ConfigurationSettings.AppSettings["conn"]; //"UID=cmmv;PWD=0519555;database=db_prueba"; 
        public static void LlenardgvTrabajadores(ComboBox CBtrabajadores)
        {
            ControlPrestamos.Clases.DB.ConexionDB con = new Clases.DB.ConexionDB();
            string sql = "select cedula||' '||nombre from tpersonas";
            con.Llenar_Listbox(sql, CBtrabajadores, con.getConexion());
        }
        /// <summary>
        /// Devuelve la parte de la cade que se encuentra antes del primer espacio de toda la cadena
        /// </summary>
        /// <param name="cadena">Cade de caracteres</param>
        /// <returns></returns>
        static public string getSubstringSpacio(string cadena, char separador)
        {
            return cadena.Substring(0, cadena.IndexOf(separador));
        }

        /// <summary>
        /// Devuelve la parte de la cade que se encuentra despues del primer espacio de toda la cadena
        /// </summary>
        /// <param name="cadena">Cade de caracteres</param>
        /// <returns></returns>
        static public string getSubstringSpacio2(string cadena, char separador)
        {
            return cadena.Substring(cadena.IndexOf(separador) + 1, (cadena.Length - cadena.IndexOf(separador)) - 1);
        }
    }
}
