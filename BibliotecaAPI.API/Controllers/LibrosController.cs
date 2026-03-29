using BibliotecaApi.Domain.Entities;
using BibliotecaAPI.Application.DTO;
using BibliotecaAPI.Application.DTO.Libro;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using AutoMapper;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController : ControllerBase
    {
        protected RespuestaAPI<ResultLibroDTO> _respuestaApi_Add;
        protected RespuestaAPI<bool> _respuestaApi_UpDel;
        protected RespuestaAPI<List<LibroDTO>> _respuestaApi_Getall;
        protected RespuestaAPI<LibroDTO> _respuestaApi_GetById;

        private readonly IMapper _mapper;
        private readonly ILogger<LibrosController> _logger;
        private readonly LibroService _service;

        public LibrosController(IMapper mapper, ILogger<LibrosController> logger, LibroService service)
        {          
            _mapper = mapper;
            _logger = logger;
            _service = service;
            this._respuestaApi_Add = new();
            this._respuestaApi_UpDel = new();
            this._respuestaApi_Getall = new();
            this._respuestaApi_GetById = new();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RespuestaAPI<List<LibroDTO>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RespuestaAPI<List<LibroDTO>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _respuestaApi_Getall.StatusCode = HttpStatusCode.BadRequest;
                    _respuestaApi_Getall.IsSuccess = false;
                    _respuestaApi_Getall.ErrorMessages.Add("ModelState: " + ModelState.IsValid.ToString());
                    return BadRequest(_respuestaApi_Getall);
                }

                var listaLibro = new List<LibroDTO>();

                //---- I: Obtener y mapear
                //List<Libro> listaLibro = ((IList<Libro>)await _service.GetLibros()).ToList();


                listaLibro = _mapper.Map<List<Libro>, List<LibroDTO> >(((IList<Libro>)await _service.GetLibros()).ToList());
                //var ll = _mapper.Map<List<Libro>, List<LibroDTO>>(listaLibro.ToList());

                //if (listaLibro != null)
                //{
                //    foreach (var lista in listaLibro)
                //    {
                //        listaLibroDTO.Add(_mapper.Map<LibroDTO>(lista));
                //    }
                //}
                //---- F: Obtener y mapear

                _respuestaApi_Getall.StatusCode = HttpStatusCode.OK;
                _respuestaApi_Getall.IsSuccess = true;
                _respuestaApi_Getall.Result = listaLibro;
                return Ok(_respuestaApi_Getall);
            }
            catch (Exception ex)
            {
                _respuestaApi_Getall.StatusCode = HttpStatusCode.BadRequest;
                _respuestaApi_Getall.IsSuccess = false;
                _respuestaApi_Getall.ErrorMessages.Add("GetAll - Error: " + ex.Message);
                return BadRequest(_respuestaApi_Getall);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RespuestaAPI<LibroDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RespuestaAPI<LibroDTO>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _respuestaApi_GetById.StatusCode = HttpStatusCode.BadRequest;
                    _respuestaApi_GetById.IsSuccess = false;
                    _respuestaApi_GetById.ErrorMessages.Add("ModelState: " + ModelState.IsValid.ToString());
                    return BadRequest(_respuestaApi_GetById);
                }

                var olibro = await _service.GetLibro(id);

                 //---- I: Obtener y mapear    
                if (olibro != null)
                {

                    LibroDTO xlibro = _mapper.Map<LibroDTO>(olibro);
    
                    _respuestaApi_GetById.StatusCode = HttpStatusCode.OK;
                    _respuestaApi_GetById.IsSuccess = true;
                    _respuestaApi_GetById.Result = xlibro;
                    return Ok(_respuestaApi_GetById);
                }
                else
                {
                    _respuestaApi_GetById.StatusCode = HttpStatusCode.NotFound;
                    _respuestaApi_GetById.IsSuccess = false;
                    _respuestaApi_GetById.Result = new LibroDTO();
                    return BadRequest(_respuestaApi_GetById);
                }
                //---- F: Obtener y mapear 
            }
            catch (Exception ex)
            {
                _respuestaApi_GetById.StatusCode = HttpStatusCode.BadRequest;
                _respuestaApi_GetById.IsSuccess = false;
                _respuestaApi_GetById.ErrorMessages.Add("GetById - Error: " + ex.Message);
                return BadRequest(_respuestaApi_GetById);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RespuestaAPI<ResultLibroDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RespuestaAPI<ResultLibroDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add([FromBody] LibroDTO dto)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    _respuestaApi_Add.StatusCode = HttpStatusCode.BadRequest;
                    _respuestaApi_Add.IsSuccess = false;
                    _respuestaApi_Add.ErrorMessages.Add("ModelState: " + ModelState.IsValid.ToString());
                    return BadRequest(_respuestaApi_Add);
                }
                if (dto == null)
                {
                    _respuestaApi_Add.StatusCode = HttpStatusCode.BadRequest;
                    _respuestaApi_Add.IsSuccess = false;
                    _respuestaApi_Add.ErrorMessages.Add("CLibroDTO vacio.");
                    return BadRequest(_respuestaApi_Add);
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(dto.Titulo))
                    {
                        _respuestaApi_Add.StatusCode = HttpStatusCode.BadRequest;
                        _respuestaApi_Add.IsSuccess = false;
                        _respuestaApi_Add.ErrorMessages.Add("El título es obligatorio.");
                        return BadRequest(_respuestaApi_Add);
                    }

                    if (string.IsNullOrWhiteSpace(dto.Autor))
                    {
                        _respuestaApi_Add.StatusCode = HttpStatusCode.BadRequest;
                        _respuestaApi_Add.IsSuccess = false;
                        _respuestaApi_Add.ErrorMessages.Add("Autor es obligatorio.");
                        return BadRequest(_respuestaApi_Add);
                    }
                }

                //---- I: Mapeo y Crear  
                var oLibro = _mapper.Map<Libro>(dto);

                await _service.CrearLibro(oLibro);
                //---- F: Mapeo y Crear  

                //---- I: Result             
                ResultLibroDTO RLibroDTO = new ResultLibroDTO()
                {
                    Id = oLibro.Id                    
                };
                //---- F: Result

                //var created = await _service.CrearLibro(libro);
                //return CreatedAtAction(nameof(Get), new { id = created.Id }, created);

                //------------------------------------------- 
                _respuestaApi_Add.StatusCode = HttpStatusCode.OK;
                _respuestaApi_Add.IsSuccess = true;
                _respuestaApi_Add.Result = RLibroDTO;
                return Ok(_respuestaApi_Add);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                _respuestaApi_Add.StatusCode = HttpStatusCode.BadRequest;
                _respuestaApi_Add.IsSuccess = false;
                _respuestaApi_Add.ErrorMessages.Add("AddLibro - Error: " + ex.Message);
                return BadRequest(_respuestaApi_Add);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RespuestaAPI<bool>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RespuestaAPI<bool>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] MLibroDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _respuestaApi_UpDel.StatusCode = HttpStatusCode.BadRequest;
                    _respuestaApi_UpDel.IsSuccess = false;
                    _respuestaApi_UpDel.ErrorMessages.Add("ModelState: " + ModelState.IsValid.ToString());
                    return BadRequest(_respuestaApi_UpDel);
                }
                if (dto == null)
                {
                    _respuestaApi_UpDel.StatusCode = HttpStatusCode.BadRequest;
                    _respuestaApi_UpDel.IsSuccess = false;
                    _respuestaApi_UpDel.ErrorMessages.Add("MLibroDTO vacio.");
                    return BadRequest(_respuestaApi_UpDel);
                }

                //---- I: Mapeo y Crear                
                var olibro = _mapper.Map<Libro>(dto);
                //olibro.Id = id;

                //----
                var updated = await _service.ActualizarLibro(olibro);
                if (!updated) {
                    _respuestaApi_UpDel.StatusCode = HttpStatusCode.NotFound;
                    _respuestaApi_UpDel.IsSuccess = false;                    
                    return BadRequest(_respuestaApi_UpDel);
                }
                //---- F: Mapeo y Crear

                //------------------------------------------- 
                _respuestaApi_UpDel.StatusCode = HttpStatusCode.OK;
                _respuestaApi_UpDel.IsSuccess = true;
                _respuestaApi_UpDel.Result = true;
                return Ok(_respuestaApi_UpDel);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                _respuestaApi_UpDel.StatusCode = HttpStatusCode.BadRequest;
                _respuestaApi_UpDel.IsSuccess = false;
                _respuestaApi_UpDel.ErrorMessages.Add("Update - Error: " + ex.Message);
                return BadRequest(_respuestaApi_UpDel);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RespuestaAPI<bool>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RespuestaAPI<bool>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _respuestaApi_UpDel.StatusCode = HttpStatusCode.BadRequest;
                    _respuestaApi_UpDel.IsSuccess = false;
                    _respuestaApi_UpDel.ErrorMessages.Add("ModelState: " + ModelState.IsValid.ToString());
                    return BadRequest(_respuestaApi_UpDel);
                }
 
                //---- I: Mapeo y Crear       
                var deleted = await _service.EliminarLibro(id);
                if (!deleted)
                {
                    _respuestaApi_UpDel.StatusCode = HttpStatusCode.NotFound;
                    _respuestaApi_UpDel.IsSuccess = false;
                    return BadRequest(_respuestaApi_UpDel);
                }
                //---- F: Mapeo y Crear

                //------------------------------------------- 
                _respuestaApi_UpDel.StatusCode = HttpStatusCode.OK;
                _respuestaApi_UpDel.IsSuccess = true;
                _respuestaApi_UpDel.Result = true;
                return Ok(_respuestaApi_UpDel);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                _respuestaApi_UpDel.StatusCode = HttpStatusCode.BadRequest;
                _respuestaApi_UpDel.IsSuccess = false;
                _respuestaApi_UpDel.ErrorMessages.Add("Delete - Error: " + ex.Message);
                return BadRequest(_respuestaApi_UpDel);
            }


        }

    }
}