using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdgarAguilar.Models;

namespace EdgarAguilar.Interfaces
{
    public interface IProductoApplication
    {
        public Task<List<Producto>> ObtenerProductosAsync();
        public Task<Producto> ObtenerProductosAsync(int productoId);
        public Task<int> AgregarProductosAsync(ProductoDTO producto);
        public Task<Producto> ActualizarProductoAsync(Producto producto, int productoId);
        public Task<bool> EliminarProductoAsync(int productoId);
       
    }
}
