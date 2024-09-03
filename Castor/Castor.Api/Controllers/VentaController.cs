using Castor.Entidad.DTO;
using Castor.Entidad.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Castor.Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class VentaController : ControllerBase
    {
        [HttpPost]
        public async Task<BaseDto<int>> Post()
        {
            BaseDto<int> response = new BaseDto<int>();
            try
            {
                response.completado = true;
            }
            catch (Exception ex )
            {
                response.completado = false;

                throw ex;
            }

            return response;
        }
        [HttpGet]
        public async Task<BaseDto<List<Venta>>> Get()
        {
            BaseDto<List<Venta>> response = new BaseDto<List<Venta>>();
            try
            {
                response.completado = true;
            }
            catch (Exception ex)
            {
                response.completado = false;

                throw ex;
            }

            return response;
        }
        [HttpDelete]
        public async Task<BaseDto<int>> Delete()
        {
            BaseDto<int> response = new BaseDto<int>();
            try
            {
                response.completado = true;
            }
            catch (Exception ex)
            {
                response.completado = false;

                throw ex;
            }

            return response;
        }
        [HttpGet("ById")]
        public async Task<BaseDto<Venta>> GetById()
        {
            BaseDto<Venta> response = new BaseDto<Venta>();
            try
            {
                response.completado = true;
            }
            catch (Exception ex)
            {
                response.completado = false;

                throw ex;
            }

            return response;
        }
    }
}
