using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region Metodos
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;
            if (!(archivo is null && datos is null))
            {
                StreamWriter writer = null;
                try
                {

                    using (writer = new StreamWriter(archivo))
                    {
                        writer.WriteLine(datos);
                    }
                    retorno = true;
                }
                catch (Exception)
                {
                    throw new ArchivosException();
                }
                finally
                {
                    if (!(writer is null))
                    {
                        writer.Close();
                    }
                        
                }
            }
            return retorno;
        }
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            datos = "";
            try
            {
                using (StreamReader aux = new StreamReader(archivo))
                {
                    datos += aux.ReadToEnd();
                }
                retorno = true;
            }
            catch (Exception)
            {
                datos = "";
                retorno = false;
            }
            return retorno;
        }
        #endregion
    }
}
