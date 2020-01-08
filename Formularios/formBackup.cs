using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
namespace ControlPrestamos.Formularios
{
    public partial class formBackup : Form
    {
        public formBackup()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            progressBar1.Visible = true;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Program Files\PostgreSQL\9.0\bin\pg_dump -h localhost -p 5432 -U postgres -F c -b -v -f 'D:\db_prueba.backup' 'db_prueba'");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               
            }
        }
    }
}
