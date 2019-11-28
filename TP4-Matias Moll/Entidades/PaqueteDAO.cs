using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Atributos
        private static SqlCommand comando;
        private static SqlConnection conexion;
        #endregion

        #region Contructor
        static PaqueteDAO()
        {
            conexion = new SqlConnection("server=BANGHO;database=correo-sp-2017;integrated security=true");
        }
        #endregion

        #region Metodos
        public static bool Insertar(Paquete p)
        {
            bool retorno = false;
            StringBuilder com = new StringBuilder();
            com.AppendFormat($"INSERT INTO Paquetes(direccionEntrega,trackingID,alumno) VALUES('" + p.DireccionEntrega + "','" + p.TrackingID + "','Matias Moll')");
            try
            {
                conexion.Open();
                comando = new SqlCommand(com.ToString(),conexion);
                if(comando.ExecuteNonQuery() == 1)
                {
                    retorno = true;
                }
            }catch(Exception ex)
            {
                throw new Exception("Error al guardar en la base de datos", ex);
            }finally
            {
                if(conexion !=  null)
                {
                    conexion.Close();
                }
            }
            return retorno;
        }
        #endregion

    }
}
