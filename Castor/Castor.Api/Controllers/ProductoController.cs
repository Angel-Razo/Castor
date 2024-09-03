using Castor.Datos;
using Castor.Entidad.DTO;
using Castor.Entidad.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Castor.Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ProductoController : Controller
    {
        private readonly IProductoDatos _productoDatos;

        public ProductoController(IProductoDatos productoDatos)
        {
            _productoDatos = productoDatos;
        }

        [HttpPost]
        public async Task<BaseDto<int>> Post(Producto producto)
        {
            BaseDto<int> response = new BaseDto<int>();

            try
            {
                response.completado = true;
                response.Mensaje = string.Empty;
                response.Datos = _productoDatos.NuevoProducto(producto);
            }
            catch (Exception ex)
            {
                response.completado = false;
                response.Mensaje = ex.Message;
                throw ;
            }
            return response;
        }
        [HttpDelete]
        public async Task<BaseDto<int>> Delete(int idProducto, int idUsuario) 
        {
            BaseDto<int> response = new BaseDto<int>();
            response.completado = false;

            try
            {
                response.completado = true;
                response.Datos = _productoDatos.EliminarProducto(idProducto, idUsuario);
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
                throw;
            }
            return response;
        }
        [HttpGet]
        public async Task<BaseDto<List<Producto>>> Get()
        {
            BaseDto<List<Producto>> response = new BaseDto<List<Producto>>();
            try
            {
                response.completado = true;
                response.Mensaje = string.Empty;
                response.Datos = _productoDatos.ObteberProductosTodos();
            }
            catch (Exception ex)
            {
                response.completado = false;
                response.Mensaje = ex.Message;
                throw ex;
            }
                
            return response;
        }
        [HttpGet("ProductosActivos")]
        public async Task<BaseDto<List<Producto>>> GetActive()
        {
            BaseDto<List<Producto>> response = new BaseDto<List<Producto>>();
            try
            {
                response.completado = true;
                response.Mensaje = string.Empty;
                response.Datos = _productoDatos.ObteberProductosActivos();
            }
            catch (Exception ex)
            {
                response.completado = false;
                response.Mensaje = ex.Message;
                throw ex;
            }

            return response;
        }

    }
}
