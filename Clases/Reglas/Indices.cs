using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;
using ControlPrestamos.Clases.DB;
using ControlPrestamos.Clases.Presentacion;
namespace ControlPrestamos.Clases.Reglas
{
    class Indices
    {
        ConexionDB conex = new ConexionDB();
        public Indices()
        {
        }
        /// <summary>
        /// Inserta un nuevo indice para organizar los prestamos
        /// </summary>
        /// <param name="p_indice">indice a insertar</param>
        /// <param name="p_codigo">codigo a insertar</param>
        /// <returns></returns>
        public bool InsertarIndice(int p_indice, string p_codigo, string cobrador)
        {
            string sql = "INSERT INTO tindice(num_indice, codigo_prestamo, cobrador) ";
            sql += "VALUES (" + p_indice + ", '" + p_codigo + "', '" + cobrador + "');";
            return conex.Ejecutar(sql);
        }

        public bool ReorganizarIndices(System.Windows.Forms.DataGridView dgv)
        {
            bool res = false;
            int i, cont=0;
            int ind = 0;
            for (i = 0; i < dgv.RowCount; i++)
            {
                string cod = Convert.ToString(dgv[1,i].Value);
                int indi = Convert.ToInt32(dgv[0,i].Value);
                int tmpindice = ++ind;
                if (this.ActualizarIndice(cod, tmpindice))
                {
                    cont++;
                }                
            }
            if (cont == dgv.RowCount)
            {
                res = true;
            }
            else
            {
                res = false;
            }
            return res;
        }
        /// <summary>
        /// Permite insertar de manera especial un nuevo indice
        /// </summary>
        /// <param name="p_indice">indice del datagridview desde donde debe comenzar la organizacion</param>
        /// <param name="p_codigo">codigo a insertar</param>
        /// <param name="dgv">datagridview del los indices</param>
        /// <returns></returns>
        public bool Organizar(int p_indice, string p_codigo, string cobrador, System.Windows.Forms.DataGridView dgv)
        {
            bool res = false;
            int indice = p_indice;
            string codigo = "";
            int i, cont = 0;
            int fil=-1;
            //ENCONTRAR EL INDICE DE LA FILA DEL DATAGRIDVIEW DONDE DEBE INICIAR LA ORGANIZACION
            for (i = 0; i < dgv.RowCount; i++)
            {
                if (Convert.ToInt32(dgv[0, i].Value) == p_indice)
                {
                    fil = i;
                    break;
                }
            }
            //ACTUALIZAR TODOS LOS INDICES DESDE DONDE EL VALOR DE LA FILA SELECCIONADA EN EL DATAGRIDVIEW
            cont = fil;            
            for (i = fil; i < dgv.RowCount; i++)
            {              
                codigo = Convert.ToString(dgv[1, i].Value);
                indice = Convert.ToInt32(dgv[0, i].Value);
                int tempindice = indice + 1;
                if (this.ActualizarIndice(codigo, tempindice))
                {
                    cont++;
                }
            }
            if (cont == i)
            {
                //SE INSERTA EL NUEVO INDICE CON EL CODIGO
                res = this.InsertarIndice(p_indice, p_codigo, cobrador);
            }
            else
            {
                res = false;
            }
            return res;
        }

        public int ContarIndices()
        {
            string sql = "SELECT COUNT(num_indice) FROM tindice";
            int res = conex.Contar_registros(sql, conex.getConexion());
            return res;
        }

        public int MaximoIndice()
        {
            string sql = "SELECT MAX(num_indice) FROM tindice";
            int res = conex.MaxNumero(sql);
            return res;
        }
        /// <summary>
        /// Actualiza el idnice  del codigo de prestamo especifico
        /// </summary>
        /// <param name="p_indice">nuevo indice del prestamo</param>
        /// <param name="p_newcodigo">nuevo codigo del prestamo</param>
        /// <param name="p_oldcodigo">actual codigo de prestamo</param>
        /// <returns></returns>
        public bool ActualizarIndice(string p_codigo, int p_newindice)
        {
            string sql = "UPDATE tindice SET num_indice = " + p_newindice;
            sql += "WHERE codigo_prestamo = '" + p_codigo + "'";
            return conex.Ejecutar(sql);
        }

        /// <summary>
        /// Elimina el indice del prestamo de un prestamo, al eliminar el indice 
        /// el prestamo dejara de aparecer en el orden de estos
        /// </summary>
        /// <param name="p_indice">indice del prestamo a eliminar</param>
        /// <returns></returns>
        public bool EliminarIndice(string p_codigo)
        {
            string sql = "DELETE FROM tindice WHERE codigo_prestamo = '" + p_codigo + "'";            
            return conex.Ejecutar(sql);
        }
    }
}
