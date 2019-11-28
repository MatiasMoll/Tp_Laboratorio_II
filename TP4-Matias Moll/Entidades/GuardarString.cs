using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Entidades
{
   public static class GuardarString
   {
        public static bool Guardar(this string texto, string archivo)
        {
            bool retorno = true;
            StreamWriter aux = null;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" +archivo;
            try
            {
                if (File.Exists(path))
                {
                    aux = new StreamWriter(path, true);
                }
                else
                {
                    aux = new StreamWriter(path, false);
                }
                using(aux)
                {
                    aux.WriteLine(texto);
                }
                
            }catch(Exception e)
            {
                retorno = false;
            }finally
            {
                if( aux != null)
                {
                    aux.Close();
                }
            }
            return retorno;
        }
   }
}
