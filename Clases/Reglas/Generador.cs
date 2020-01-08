using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;
namespace ControlPrestamos.Clases.Reglas
{
    class Generador
    {
        public Generador()
        {

        }
        /// <summary>
        /// Esta funcion genera un numero con el formato '0000-9999', el cual lo recibe como el MAX(campo),
        /// quien le trae el maximo valor en el campo especifico y lo aumenta en 1 aleatoriamente
        /// </summary>
        /// <param name="conex">Conexion odbc actual</param>
        /// <param name="numCifras">Numero de cifras a manejar en el codigo</param> 
        /// <param name="SqlSelectMAX">Sql select MAX que se ejecutara</param>
        /// <returns></returns>
        public string Generar_Codigo(OdbcConnection conex, int numCifras, string SqlSelectMAX)
        {
            OdbcCommand cmd = new OdbcCommand(SqlSelectMAX, conex);
            string res = "", aux = "";
            int aux3;
            if (conex.State == System.Data.ConnectionState.Open)
            {
                conex.Close();
            }
            conex.Open();

            res = Convert.ToString(cmd.ExecuteScalar());

            if (res != "")
            {
                aux3 = Convert.ToInt32(res);
                for (int i = 0; res[i] == '0'; i++)
                {
                    aux += Convert.ToString(res[i]);
                }
                aux3++;
                res = Convert.ToString(aux3);
                if (res.Length < numCifras)
                {
                    string str = null;
                    for (int n = 0; n < (numCifras - res.Length); n++)
                    {
                        str += "0";
                    }
                    res = str + res;
                }
            }
            else
            {
                //ESTE FOR GENERA EL PRIMER CODIGO SEGUN EL NUMERO DE CIFRAS 
                for (int i = 0; i < numCifras; i++)
                {
                    if ((numCifras - i) == 1)
                    {
                        res += "1";
                    }
                    else
                    {
                        res += "0";
                    }
                }
            }
            conex.Close();
            return res;
        }

        public string Generar_Codigo2(string codigobase, int numCifras)
        {
            
            string res = "", aux = "";
            int aux3;

            res = codigobase;

            if (res != "")
            {
                aux3 = Convert.ToInt32(res);
                for (int i = 0; res[i] == '0'; i++)
                {
                    aux += Convert.ToString(res[i]);
                }
                aux3++;
                res = Convert.ToString(aux3);
                if (res.Length < numCifras)
                {
                    string str = null;
                    for (int n = 0; n < (numCifras - res.Length); n++)
                    {
                        str += "0";
                    }
                    res = str + res;
                }
            }
            else
            {
                //ESTE FOR GENERA EL PRIMER CODIGO SEGUN EL NUMERO DE CIFRAS 
                for (int i = 0; i < numCifras; i++)
                {
                    if ((numCifras - i) == 1)
                    {
                        res += "1";
                    }
                    else
                    {
                        res += "0";
                    }
                }
            }            
            return res;
        }

        public bool ReindexarPrestamos(System.Windows.Forms.DataGridView dgv)
        {
            ControlPrestamos.Clases.DB.ConexionDB con = new DB.ConexionDB();
            Prestamo pres = new Prestamo();
            bool res = false;
            int numpres = con.MaxNumero("select count(codigo) from tprestamo");
            int i = 0;
            int cont=0;
            string sql = "";
            //string sql2 = "update tindice set";
            string newcodigo = "";
            string oldcodigo = "";
            string codbase = "";            
            for (i = 0; i < numpres; i++)
            {
                oldcodigo = Convert.ToString(dgv["c_codigo", i].Value);
                newcodigo = Generar_Codigo2(codbase,4);
                codbase = newcodigo;
                sql = "update tprestamo set codigo='" + newcodigo + "' where codigo = '" + oldcodigo + "'; ";
                sql += "update tindice set codigo_prestamo = '" + newcodigo + "' where trim(codigo_prestamo) = '" + oldcodigo + "';";
                sql += "Update tcuotas set codigo_prestamo = '" + newcodigo + "' where trim(codigo_prestamo) = '" + oldcodigo + "';";
                if (con.Ejecutar(sql))
                {
                    cont++;
                }
            }

            if (cont == numpres)
            {
                res = true;
            }
            return res;
        }
    }
}
