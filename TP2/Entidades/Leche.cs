using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        #region Enumerado
        public enum ETipo
        {
            Entera,
            Descremada
        }ETipo tipo;
        #endregion

        #region Constructores
        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        public Leche(EMarca marca, string patente, ConsoleColor color)
            : this(marca, patente, color, ETipo.Entera)
        {
        }
        /// <summary>
        /// Crea un objeto de la clase Leche, reutilizando el constructor anterior
        /// ademas de setear el tipo con un dato de entrada
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        /// <param name="tipos"></param>
        public Leche(EMarca marca, string patente, ConsoleColor color, ETipo tipos)
            :base(patente, marca, color)
        {
            tipo = tipos;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Usando el método mostrar de la clase base y agregando información 
        /// propia de la clase, devuelve los datos de la leche
        /// </summary>
        /// <returns>Retorna un string con toda la informacion de la leche</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendFormat("CALORIAS : {0} \r\n", this.CantidadCalorias);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
