using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;
using ControlPrestamos.Clases.DB;
namespace ControlPrestamos.Clases.Reglas
{
    class FrecPago
    {
        ConexionDB con = null;
        public FrecPago()
        {
            con = new ConexionDB();
        }

        public List<string> get_Frecuencias_Pagos_List(){
            List<string> lista = con.getDataSelect_SQL_Lista("SELECT codigo||' '||decripcion FROM tfrecpago");
            return lista;
        }

        public string get_Frecuencia_Pago(int codigo)
        {
            ConexionDB con = new ConexionDB();
            return con.getDataSelect_SQL2(string.Format("select get_descripcion_frecpago({0})", codigo));
        }
        public bool guardar_frecpag(string p_descripcion, int p_color)
        {
            ConexionDB con = new ConexionDB();
            string sql = string.Format("INSERT INTO tfrecpago(decripcion, color, descripcion_corta) VALUES ('{0}', {1}, upper(substring('{0}', 1, 1)));", p_descripcion, p_color);
            return con.Ejecutar(sql);
        }

        public bool actualizar_frecpag(string p_descripcion, int p_color, int codigo)
        {
            ConexionDB con = new ConexionDB();
            string sql = string.Format("UPDATE tfrecpago SET decripcion={0}, color={1}, descripcion_corta=upper(substring('{0}', 1, 1))  WHERE codigo = {2};", p_descripcion, p_color, codigo);
            return con.Ejecutar(sql);
        }

        public bool eliminar_frecpag(int codigo)
        {
            ConexionDB con = new ConexionDB();
            string sql = string.Format("DELETE FROM tfrecpago WHERE codigo = {0};", codigo);
            return con.Ejecutar(sql);
        }
    }
}
