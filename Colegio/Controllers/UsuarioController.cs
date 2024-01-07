using AutoMapper;
using Colegio.Dto;
using Colegio.Models;
using Colegio.Repositories.IRepositories;
using Colegio.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Colegio.Controllers;

[Route("usuario")]
[ApiController]
public class UsuarioController : ControllerBase
{
   private readonly IUsuarioRepository _usuarioRepository;
   private readonly IEstudianteRepository _estudianteRepository;
   private readonly IMapper _mapper;
    
   public UsuarioController(IMapper mapper, IUsuarioRepository usuarioRepository, IEstudianteRepository estudianteRepository)
   {
      this._mapper = mapper;
      this._usuarioRepository = usuarioRepository;
      this._estudianteRepository = estudianteRepository;
   }

   [HttpPost]
   [ProducesResponseType(204)]
   [ProducesResponseType(400)]
   public IActionResult RegisterEstudiante(UsuarioDto usuarioDto, long numeroDocumento)
   {
      var usuario = _mapper.Map<Usuario>(usuarioDto);
      usuario.PasswordHash = Encryptor.Encrypt(usuarioDto.Password);

      if (_usuarioRepository.UsuarioExists(usuario.UserName))
         return Conflict("The Object Already Exists");

      if (!_estudianteRepository.EstudianteExists(numeroDocumento))
         return NotFound("El estudiante no existe");

      if (_usuarioRepository.Add(usuario))
      {
         var estudiante = _estudianteRepository.Get(e => e.NumeroDocumento == numeroDocumento);
         estudiante.Usuario = usuario;
         _estudianteRepository.Update(estudiante);
         return Ok();
      }

      ModelState.AddModelError("", "Something Wrong Happened");
      return StatusCode(500, ModelState);
   }
}