using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdgarAguilar.Interfaces;
using EdgarAguilar.Models;

namespace EdgarAguilar.Application
{
    public class ProductoApplication : IProductoApplication
    {
        private IListaProductos _lstProductos;

        public ProductoApplication(IListaProductos lstProductos)
        {
            _lstProductos = lstProductos;
        }

        public async Task<List<Producto>> ObtenerProductosAsync()
        {
            try
            {
                return await Task.Run(() => _lstProductos.Productos);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error obtener lista: {ex.Message}");
            }
        }

        public async Task<Producto> ObtenerProductosAsync(int productoId)
        {
            try
            {
                var response = await Task.Run(() => _lstProductos.Productos.FirstOrDefault(p =>
                                                                        p.ProductoId == productoId));

                return response != null ? response :
                    throw new ApplicationException($"No se encontró el producto: {productoId}");
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error obtener: {ex.Message}");
            }
        }

        public async Task<int> AgregarProductosAsync(ProductoDTO producto)
        {
            try
            {
                var siguienteId = _lstProductos.Productos.Count() > 0 ? _lstProductos.Productos.Max(p => p.ProductoId) : 0;

                _lstProductos.Productos.Add(new Producto
                {
                    ProductoId = siguienteId + 1,
                    Cantidad = producto.Cantidad,
                    Categoria = producto.Categoria,
                    Descripcion = producto.Descripcion,
                    Nombre = producto.Nombre,
                    Precio = producto.Precio
                });

                return _lstProductos.Productos.LastOrDefault(p => p != null).ProductoId;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error Agregar: {ex.Message}");
            }
        }

        public async Task<Producto> ActualizarProductoAsync(Producto producto, int productoId)
        {
            try
            {
                var nuevaLista = Task.Run(() => _lstProductos.Productos.Where(p => p.ProductoId != productoId));
                _lstProductos.Productos = nuevaLista.Result.ToList();
                _lstProductos.Productos.Add(producto);
                return _lstProductos.Productos.FirstOrDefault(p => p.ProductoId == producto.ProductoId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error actualizar: {ex.Message}");
            }
        }

        public async Task<bool> EliminarProductoAsync(int productoId)
        {
            try
            {
                var listaNueva = Task.Run(() => _lstProductos.Productos.Where(p => p.ProductoId != productoId));
                _lstProductos.Productos = listaNueva.Result.ToList();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error eliminar: {ex.Message}");
            }
        }


    }
}
