using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;
using System.Data;
using System.IO;
using System.Windows.Forms;
using ControlPrestamos;
namespace ControlPrestamos.Clases.DB
{
    class ConexionDB
    {
        OdbcConnection conexion = null;
        string pathArchivo = Application.StartupPath;//DIRECCION DONDE SE ESNCUENTRA EL ARCHIVO QUE CONTIENE LA CONEXION

        public ConexionDB()
        {
            conexion = new OdbcConnection();
            //conexion.ConnectionString = Leer_Archivo_ini(1, pathArchivo + "\\config.ini");
            conexion.ConnectionString = Leer_Archivo_ini(1, pathArchivo + "\\config2.ini") + datos.cadconex;
        }
        
        public bool Conectar()
        {           
            bool res = false;
            try
            {
                if(conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
                conexion.Open();
                res = true;
            }
            catch
            {
                throw new Exception("Error al momento de conectarse a la base de datos");
            }
            return res;
        }

        public bool Desconectar()
        {
            bool res = false;
            try
            {
                conexion.Close();
                res = true;
            }
            catch
            {
                throw new Exception("Error al momento de Desconectarse a la base de datos");
            }
            return res;
        }
        /// <summary>
        /// Devuelve el objeto tipo odbc que contiene la conexion actual
        /// </summary>
        /// <returns></returns>
        public OdbcConnection getConexion()
        {
            return this.conexion;            
        }
        /// <summary>
        /// lee el archivo donde se encuntra la conexion
        /// </summary>
        /// <param name="linea">linea que se va a leer</param>
        /// <param name="Archivo">ruta y nombre del archivo</param>
        /// <returns></returns>
        public string Leer_Archivo_ini(int linea, string Archivo)
        {
            StreamReader lec = new StreamReader(Archivo);
            string res = string.Empty;
            int cont = 0;
            while (cont < linea)
            {
                res = lec.ReadLine();
                cont++;
            }
            lec.Close();
            int pos = res.IndexOf("=");
            res = res.Substring(pos + 1, res.Length - (pos + 1));
            return res;
        }
        /// <summary>
        /// Devuelve el maximo numero entero segun la consulta sql
        /// </summary>
        /// <param name="sqlmax">Consulta Sql tipo MAX</param>
        /// <returns>Retorna un valor entero</returns>
        public int MaxNumero(string sqlmax)
        {
            string res;           
            try
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                conexion.Open();
                res = Convert.ToString(new OdbcCommand(sqlmax, conexion).ExecuteScalar());
                if (res == "")
                {
                    res = "0";
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error al momento de consultar el maximo: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
            return Convert.ToInt32(res);
        }
        //EJECUTA EL COMANDO SQL YA SEA INSERT, DELETE O UPDATE
        public bool Ejecutar(string sql)
        {
            bool res = false;
            if (this.Ejecutar_SQL(sql, this.getConexion()))
            {
                res = true;
            }
            return res;
        }
        /// <summary>
        /// LLena un comboBox con los datos de una consulta sqlSelect
        /// </summary>
        /// <param name="sql">Select a ejecutar</param>
        /// <param name="combo">ComboBox a llenar</param>
        /// <param name="conex">Conexion Odbc</param>
        public void Llenar_Listbox(string sql, ComboBox combo, OdbcConnection conex)
        {
            try
            {               
                if (conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }
                conex.Open();

                System.Data.Odbc.OdbcDataReader dr = new OdbcCommand(sql,conex).ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    //combo.Text = dr.GetString(0);
                    combo.Text = "<Seleccione uno>";
                    do{
                        combo.Items.Add(dr.GetString(0));
                    }while (dr.Read());                   
                }                
            }
            catch
            {
                throw new Exception("Error al momento de cargar el comoboBox con los prestamos");
            }
        }

        /// <summary>
        /// LLena un ListBox con los datos de una consulta sqlSelect
        /// </summary>
        /// <param name="sql">Select a ejecutar</param>
        /// <param name="combo">ComboBox a llenar</param>
        /// <param name="conex">Conexion Odbc</param>
        public void Llenar_Listbox(string sql, ListBox lista, OdbcConnection conex)
        {
            try
            {
                if (conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }
                conex.Open();                
                System.Data.Odbc.OdbcDataReader dr = new OdbcCommand(sql, conex).ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();                                       
                    do
                    {
                        lista.Items.Add(dr.GetString(0));
                    } while (dr.Read());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Ejecuta cualquier consulta SQL que sea de INSERCION, ACTUALIZACION y ELIMINACION
        /// pero no las de SELECCION
        /// </summary>
        /// <param name="sql">SQL a ejecutar</param>
        /// <param name="conex">Conexion Odbc</param>
        /// <returns></returns>
        private bool Ejecutar_SQL(string sql, OdbcConnection conex)
        {
            bool val = false;
            OdbcTransaction tr = null;
            OdbcCommand cmd;
            try
            {
                if (conex.State == System.Data.ConnectionState.Open)
                {
                    conex.Close();
                }
                conex.Open();
                //SE INICIALIZA LA TRANSACCION
                tr = conex.BeginTransaction();
                //SE INICIALIZA EL COMANDO
                cmd = new OdbcCommand(sql, conex, tr);
                //EJECU TA EL COMANDO
                cmd.ExecuteNonQuery();
                //CONFIRMA LA TRANSACCION
                tr.Commit();
                val = true;
            }
            catch (Exception ex)
            {
                try
                {
                    tr.Rollback();
                }
                catch
                {
                }
                val = false;
            }
            finally
            {
                conex.Close();
            }
            return val;
        }
        
        public Int32 Contar_registros(string sql, OdbcConnection conex)
        {
            int res = 0;
            try
            {
                conex.Open();
                res = Convert.ToInt32(new OdbcCommand(sql, conex).ExecuteScalar());
            }
            catch (Exception ex)
            {
                res = 0;
                MessageBox.Show("Error al momento de contar registros: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conex.Close();
            }
            return res;
        }

        public OdbcDataReader getDataSelect_SQL(string sqlselect, OdbcConnection conex)
        {
            if (conex.State == System.Data.ConnectionState.Open)
            {
                conex.Close();
            }
            conex.Open();
            OdbcDataReader dr = null;
            try
            {
                dr = new OdbcCommand(sqlselect, conex).ExecuteReader();
            }
            catch
            {
                dr = null;
                throw new Exception("Error al momento de devolver el datareader con los datos del SELECT");
            }
            return dr;
        }

        public string getDataSelect_SQL2(string sqlselect)
        {
            string res = "";
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
            conexion.Open();
            OdbcDataReader dr = null;
            try
            {
                dr = new OdbcCommand(sqlselect, conexion).ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    res = dr.GetString(0);
                }
            }
            catch
            {
                dr = null;
                res = null;
                throw new Exception("Error al momento de devolver el datareader con los datos del SELECT");
            }
            return res;
        }

        public int getDataSelect_SQL3(string sqlselect, OdbcConnection conex)
        {
            int res = 0;
            if (conex.State == System.Data.ConnectionState.Open)
            {
                conex.Close();
            }
            conex.Open();
            OdbcDataReader dr = null;
            try
            {
                dr = new OdbcCommand(sqlselect, conex).ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    res = dr.GetInt32(0);
                }
            }
            catch
            {
                dr = null;
                res = 0;
                throw new Exception("Error al momento de devolver el datareader con los datos del SELECT");
            }
            return res;
        }

        public List<string> getDataSelect_SQL_Lista(string sqlselect)
        {
            List<string> res = new List<string>();
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
            conexion.Open();
            OdbcDataReader dr = null;
            try
            {
                dr = new OdbcCommand(sqlselect, conexion).ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        res.Add(dr.GetString(0));
                    }
                }
            }
            catch
            {
                dr = null;
                res = null;
                throw new Exception("Error al momento de devolver el datareader con los datos del SELECT");
            }
            return res;
        }

        public double Sumar_Valores_de_Campos(string sqlsum)
        {
            double res = 0;
            OdbcDataReader dr = null;
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
            conexion.Open();
            try
            {
                dr = new OdbcCommand(sqlsum, conexion).ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    if (dr.IsDBNull(0))
                    {
                        res = 0;
                    }
                    else
                    {
                        res = Convert.ToDouble(dr.GetValue(0));
                    }
                }
                //if (Convert.ToDouble(new OdbcCommand(sqlsum, conexion).ExecuteScalar()) >= 0)
                //{
                //    res = Convert.ToDouble(new OdbcCommand(sqlsum, conexion).ExecuteScalar());
                //}
                //else
                //{
                //    res = 0;
                //}
            }
            catch (Exception ex)
            {
                res = 0;
                MessageBox.Show("Error al momento de realizar la suma de valores de la Data Base: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dr.Close();
            }
            return res;
        }

        /// <summary>
        /// Esta funcion llena un datagridview con una consulta sql, el datagridview debe tener columnas establecidas.
        ///
        /// </summary>
        /// <param name="SQL">Clausula SQL SELECT a ejecutar</param>
        /// <param name="dgv">Datagridview a llenar con los registros que cumplen la clausula</param>
        /// <param name="conex">Conexion Odbc a la base de datos</param>
        public void llenar_DGV(string SQL, DataGridView dgv, OdbcConnection conex)
        {
            try
            {
                if (conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }
                conex.Open();
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de Error Odbc", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //OdbcTransaction trs = conex.BeginTransaction();
            OdbcCommand cmd = new OdbcCommand(SQL, conex);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable tb = new DataTable();
            try
            {
                da.Fill(tb);
                for (int i = 0; i < dgv.ColumnCount; i++)
                {
                    dgv.Columns[i].DataPropertyName = tb.Columns[i].ColumnName;
                }
                dgv.DataSource = tb;
                //trs.Commit();
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            finally
            {
                conex.Close();
            }
        }

        public DataTable get_DataTable(string SQL, OdbcConnection conex)
        {
            DataTable tb = new DataTable();
            try
            {
                if (conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }
                conex.Open();
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de Error Odbc", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //OdbcTransaction trs = conex.BeginTransaction();
            OdbcCommand cmd = new OdbcCommand(SQL, conex);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            
            try
            {
                da.Fill(tb);                
                //trs.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conex.Close();
            }
            return tb;
        }
    }    
}
