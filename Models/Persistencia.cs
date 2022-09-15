using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdgarAguilar.Interfaces;

namespace EdgarAguilar.Models
{
    public class Persistencia : IListaProductos
    {
        private List<Producto> productos;
        public List<Producto> Productos
        {
            get
            {
                if (productos == null)
                    productos = new List<Producto>();
                return productos;
            }

            set { productos = value; }
        }
    }
}
