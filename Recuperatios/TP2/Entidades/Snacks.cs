using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks : Producto
    {
        #region Constructores
        /// <summary>
        /// Constructor de la clase Snack, setea los datos a traves del constructor
        /// de la clase padre
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        public Snacks(EMarca marca, string patente, ConsoleColor color)
            : base(patente,marca,color)
        {
            
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Usando el método mostrar de la clase base y agregando información 
        /// propia de la clase, devuelve los datos del snack
        /// </summary>
        /// <returns>Retorna un string con toda la informacion del Snack</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("");
            sb.AppendFormat("CALORIAS : {0} \r\n", this.CantidadCalorias);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
