using System;
using System.Collections.Generic;
using System.Text;
using ControlPrestamos.Clases.DB;
using System.Windows.Forms;
using DAO;
namespace ControlPrestamos.Clases.Presentacion
{
    class Informes
    {
        public Informes()
        {
        }
        /// <summary>
        /// Retorna una lista de nombres de los informes hechos en el archivo acces
        /// </summary>
        /// <returns></returns>
        public List<string> GetInformes()
        {
            List<string> lista = new List<string>();
            int i=1;           
            while (i <= getNumInformes())
            {
                //LLENA LA LISTA
                lista.Add(new ConexionDB().Leer_Archivo_ini(i, Application.StartupPath + "\\listaInformes.ini"));
                i++;
            }          
            return lista;
        }
        /// <summary>
        /// Trae el numero de nombres de informes escritos en el archivo listaInformes.ini
        /// </summary>
        /// <returns></returns>
        private int getNumInformes()
        {
            int cont = 0;            
            System.IO.StreamReader sr = new System.IO.StreamReader(Application.StartupPath + "\\listaInformes.ini");
            while (sr.ReadLine() != null)
            {               
                cont++;
            }
            return cont;
        }

        public void AbrirInforme(string informe)
        {
            Microsoft.Office.Interop.Access.Application app = new Microsoft.Office.Interop.Access.Application();
            app.Visible = true;
            app.OpenCurrentDatabase(Application.StartupPath + "\\InformesInverReg.mdb", false, "");            
            app.DoCmd.OpenReport(informe, Microsoft.Office.Interop.Access.AcView.acViewPreview);//, "", "", Microsoft.Office.Interop.Access.AcWindowMode.acWindowNormal, "");
        }
    }
}
