using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace ControlPrestamos.Clases.Presentacion
{
    enum TipoError
    {
        EXISTENCIA = 1,
        DATOS_INVALIDOS=2,
        ELIMINACION_POSITIVA=3,
        ELIMINACION_NEGATIVA = 4,
        INSERCCION_NEGATIVA=5,
        INSERCCION_POSITIVA=6,
        ACTUALIZACION_NEGATIVA=7,
        ACTUALIZACION_POSITIVA=8
    }
    class Mensajes
    {
        private string mensaje;

        public Mensajes()
        {
            this.mensaje = "";
        }

        public string Mensaje
        {
            get
            {
                return this.mensaje;
            }
        }

        public void Getmensaje(TipoError tipoerror)
        {
            switch (tipoerror)
            {
                case TipoError.EXISTENCIA :
                    this.mensaje = "Este registro ya existe";
                    MessageBox.Show(this.mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case TipoError.ELIMINACION_POSITIVA :
                    this.mensaje = "Eliminacion realizada con exito!!!";
                    MessageBox.Show(this.mensaje, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case TipoError.ELIMINACION_NEGATIVA :
                    this.mensaje = "Error al momento de eliminar los datos";
                    MessageBox.Show(this.mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case TipoError.DATOS_INVALIDOS :
                    this.mensaje = "Verifique que los campos no esten en blanco y que tengan el formato correcto";
                    MessageBox.Show(this.mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case TipoError.INSERCCION_NEGATIVA :
                    this.mensaje = "Error al momento de insertar los datos";
                    MessageBox.Show(this.mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case TipoError.INSERCCION_POSITIVA :
                    this.mensaje = "Datos insertado con exito";
                    MessageBox.Show(this.mensaje, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case TipoError.ACTUALIZACION_POSITIVA :
                    this.mensaje = "Datos actualizado con exito";
                    MessageBox.Show(this.mensaje, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case TipoError.ACTUALIZACION_NEGATIVA :
                    this.mensaje = "Error al actualizar los datos";
                    MessageBox.Show(this.mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }        
    }
}
