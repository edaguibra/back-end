using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdgarAguilar.Interfaces;
using EdgarAguilar.Models;

namespace EdgarAguilar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private IProductoApplication ProductoApplication { get; set; }

        public ProductoController(IProductoApplication productoApplication)
        {
            ProductoApplication = productoApplication;
        }

        /// <summary>
        /// Obtener la lista de productos
        /// </summary>
        /// <returns>Regresa objeto de tipo <see cref="List{T}<"/></returns>
        [HttpGet, Route("")]
        [ProducesResponseType(typeof(List<Producto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Producto>>> ObtenerProductosAsync()
        {
            try
            {
                var response = await ProductoApplication.ObtenerProductosAsync();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Obtener un producto por productoId
        /// </summary>
        /// <returns>Regresa objeto de tipo <see cref="List{T}<"/></returns>
        [HttpGet, Route("{productoId}")]
        [ProducesResponseType(typeof(Producto), StatusCodes.Status200OK)]
        public async Task<ActionResult<Producto>> ObtenerProductoAsync(int productoId)
        {
            try
            {
                var response = await ProductoApplication.ObtenerProductosAsync(productoId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Agregar un producto
        /// </summary>
        /// <param name="payload">Parametro de tipo <see cref="Producto"/>.Modelo para agregar un producto</param>
        /// <returns>Regresa objeto de tipo <see cref="{T}<"/></returns>
        [HttpPost, Route("")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> AgregarProductoAsync(ProductoDTO producto)
        {
            try
            {
                var response = ProductoApplication.AgregarProductosAsync(producto);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Eliminar un producto por productoId
        /// </summary>
        /// <returns>Regresa objeto de tipo <see cref="bool<"/></returns>
        [HttpDelete, Route("{productoId}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> EliminarProductoAsync(int productoId)
        {
            try
            {
                var response = await ProductoApplication.EliminarProductoAsync(productoId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
