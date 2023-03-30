﻿using AutoMapper;
using MagicVilla_API.Datos;
using MagicVilla_API.Modelos;
using MagicVilla_API.Modelos.Dto;
using MagicVilla_API.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MagicVilla_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NumeroVillaController : ControllerBase
    {
        private readonly ILogger<NumeroVillaController> _logger;
        private readonly IVillaRepositorio _villaRepo;
        private readonly INumeroVillaRepositorio _numeroRepo;
        private readonly IMapper _mapper;
        protected APIresponse _response;

        public NumeroVillaController(ILogger<NumeroVillaController> logger, IVillaRepositorio villaRepo, INumeroVillaRepositorio numeroRepo, IMapper mapper)
        {
            _logger = logger;
            _villaRepo = villaRepo;
            _numeroRepo = numeroRepo;
            _mapper = mapper;
            _response= new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIresponse>> GetNumeroVillas()
        {
            try
            {
                _logger.LogInformation("Obtenerr Numero Villas");
                IEnumerable<NumeroVilla> numerovillaList = await _numeroRepo.ObtenerTodos();

                _response.Resultado = _mapper.Map<IEnumerable<NumeroVillaDto>>(numerovillaList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.Message };
                
            }
            return _response;
           
        }


        [HttpGet("id:int", Name = "GetNumeroVilla")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<APIresponse>> GetNumeroVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.LogError("Error al traer numero villa con Id " + id);
                    _response.IsExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var numerovilla = await _numeroRepo.Obtener(v => v.VillaNo == id);
                if (numerovilla == null)
                {
                    _response.IsExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _response.Resultado = _mapper.Map<NumeroVillaDto>(numerovilla);
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                 
            }

            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIresponse>> CrearNumeroVilla([FromBody] NumeroVillaCreateDto CreateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await _numeroRepo.Obtener(v => v.VillaNo == CreateDto.VillaNo) != null)
                {
                    ModelState.AddModelError("NombreExiste", "El numero de villa ya existe");
                    return BadRequest(ModelState);
                }
                if (await _villaRepo.Obtener(v=>v.Id==CreateDto.VillaId) == null)
                {
                    ModelState.AddModelError("ClaveForanea", "El Id de la villa No existe");
                    return BadRequest(ModelState);
                }

                if (CreateDto == null)
                {
                    return BadRequest(CreateDto);
                }

                NumeroVilla modelo = _mapper.Map<NumeroVilla>(CreateDto);
                modelo.FechaCreacion = DateTime.Now;
                modelo.FechaActualizacion= DateTime.Now;    

                await _numeroRepo.Crear(modelo);

                _response.Resultado = modelo;
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetNumeroVilla", new { id = modelo.VillaNo}, _response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                
            }

            return _response;

        }

        [HttpDelete("id:int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteNumeroVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsExitoso=false;
                    _response.StatusCode=HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var numerovilla = await _numeroRepo.Obtener(v => v.VillaNo == id);
                if (numerovilla == null)
                {
                    _response.IsExitoso=false;
                    _response.StatusCode=HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _numeroRepo.Remover(numerovilla);

                _response.StatusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
               
            }
            return BadRequest(_response);

        }
        [HttpPut("id:int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpddateNumeroVilla(int id, [FromBody] NumeroVillaUpdateDto UpdateDto) 
        {
            if (UpdateDto == null || id != UpdateDto.VillaNo) 
            {
                _response.IsExitoso = false;
                _response.StatusCode=HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            if (await _villaRepo.Obtener(v=>v.Id == UpdateDto.VillaId) == null)
            {
                ModelState.AddModelError("ClaveForanea", "El Id de la villa no existe!");
                return BadRequest(ModelState);
            }

            NumeroVilla modelo = _mapper.Map<NumeroVilla>(UpdateDto);

            await _numeroRepo.Actualizar(modelo);
            _response.StatusCode = HttpStatusCode.NoContent;
            
            return Ok(_response); 

        }

        
    }
}
