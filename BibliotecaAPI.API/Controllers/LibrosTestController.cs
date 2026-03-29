using BibliotecaApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosTestController : ControllerBase
    {
        private readonly CrearLibroUseCase _crearLibro;

        public LibrosTestController(CrearLibroUseCase crearLibro)
        {
            _crearLibro = crearLibro;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Crear(LibroDTO dto)
        {
            await _crearLibro.Ejecutar(dto);
            return Ok();
        }
    }
}



