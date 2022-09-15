using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdgarAguilar.Models;

namespace EdgarAguilar.Interfaces
{
    public interface IListaProductos
    {
        public List<Producto> Productos { get; set; }
    }
}
