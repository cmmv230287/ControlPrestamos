using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlPrestamos.Formularios;
using ControlPrestamos.Clases.Reglas;
namespace ControlPrestamos
{
    public partial class Principal : Form
    {
        public bool inicio = false;
        public string usuario = "";
        public string passw = "";
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            formInicio frminicio = new formInicio();           
            frminicio.ShowDialog();            
            this.usuario = frminicio.TXTusuario.Text;
            this.passw = frminicio.TXTpasword.Text;
            if (frminicio.inicio == false)
            {
                this.Close();
            }

            if (this.usuario == "1128053812")
            {
                importarClientesToolStripMenuItem.Visible = true;
            }
            toolStripStatusLabel2.Text = new Usuario().getNombreUsuario(this.usuario);
        }

        private void administrarPrestamosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formClientes frmPrestamos = new formClientes();
            abrirFormulariohijo(frmPrestamos);
        }

        private void elimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formLimpiar limpiar = new formLimpiar();
            abrirFormulariohijo(limpiar);
        }

        private void abrirFormulariohijo(Form frm)
        {
            frm.MdiParent = this;
            frm.Show();
        }

        private void imprimirInformesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formInformes informes = new formInformes();
            abrirFormulariohijo(informes);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("El programa se cerrara, desea continuar?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}
        }

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void importarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportarDatos importar = new ImportarDatos();
            importar.StartPosition = FormStartPosition.CenterScreen;
            this.abrirFormulariohijo(importar);
        }

        private void organizarIndicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formOrganizarIndices formorganizar = new formOrganizarIndices();
            formorganizar.StartPosition = FormStartPosition.CenterScreen;
            this.abrirFormulariohijo(formorganizar);
        }

        private void registrarGastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formGastos formgastos = new formGastos();
            formgastos.StartPosition = FormStartPosition.CenterScreen;
            this.abrirFormulariohijo(formgastos);
        }

        private void registrarPersonasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formPersona frmperso = new formPersona();
            frmperso.StartPosition = FormStartPosition.CenterScreen;
            this.abrirFormulariohijo(frmperso);
        }

        private void Principal_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            //string fecha = String.Format("{0:ddMMyyyy}", new DateTime());
            //if (System.IO.Directory.Exists(@"D:\Backup Control de Prestamos\") == false)
            //{
            //    System.IO.Directory.CreateDirectory(@"D:\Backup Control de Prestamos\");
            //}
            System.IO.File.Create(Application.StartupPath + "\\db_prueba.backup");
           System.Diagnostics.Process.Start(Application.StartupPath + "\\ControlPrestamosBackUp.bat");// C:\Program Files\PostgreSQL\9.0\bin\pg_dump -h localhost -p 5432 -U postgres -F c -b -v -f 'D:\Backup Control de Prestamos\db_prueba.backup' 'db_prueba'");
        }

        private void tiposDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formFrecPago frepag = new formFrecPago();
            frepag.ShowDialog();
        }

        private void cuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formConfig config = new formConfig();
            config.usuario = this.usuario;
            config.passw = this.passw;
            this.abrirFormulariohijo(config);
        }

        private void listadoCuotasPorDiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formCuotasDias cd = new formCuotasDias();
            cd.ShowDialog();
        }
    }
}