using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Changuito
    {
        List<Producto> productos;
        int espacioDisponible;
        public enum ETipo
        {
            Dulce,
            Leche,
            Snacks,
            Todos
        }

        #region "Constructores"
        private Changuito()
        {
            this.productos = new List<Producto>();
        }
        public Changuito(int espacioDisponible):this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el Changuito y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Changuito c, ETipo tipo)
        {
            StringBuilder productosChango = new StringBuilder();

            productosChango.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c.productos.Count, c.espacioDisponible);
            productosChango.AppendLine("");
            foreach (Producto producto in c.productos)
            {
                switch(tipo)
                {
                    case ETipo.Snacks:
                        if(producto is Snacks)
                        {
                            productosChango.AppendLine(((Snacks)producto).Mostrar());
                        }
                        break;
                    case ETipo.Dulce:
                        if (producto is Dulce)
                        {
                            productosChango.AppendLine(((Dulce)producto).Mostrar());
                        }
                        break;
                    case ETipo.Leche:
                        if (producto is Leche)
                        {
                            productosChango.AppendLine(((Leche)producto).Mostrar());
                        }
                        break;
                    default:
                        productosChango.AppendLine(producto.Mostrar());
                        break;
                }

            }

            return productosChango.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            Changuito retorno = c;
            bool flag = true;
            if(!(c is null) && !(p is null))
            {
                if(retorno.productos.Count < retorno.espacioDisponible)
                {
                    foreach (Producto producto in retorno.productos)
                    {
                        if (producto == p)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if(flag)
                    {
                        retorno.productos.Add(p);

                    }

                }
            }            
            return retorno;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
            foreach (Producto v in c.productos)
            {
                if (v == p)
                {
                    c.productos.Remove(p);
                    
                    break;
                }
            }

            return c;
        }
        #endregion
    }
}
