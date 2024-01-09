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
   private readonly IMapper _mapper;
    
   public UsuarioController(IMapper mapper, IUsuarioRepository usuarioRepository)
   {
      this._mapper = mapper;
      this._usuarioRepository = usuarioRepository;
   }

   [HttpPost]
   [ProducesResponseType(204)]
   [ProducesResponseType(400)]
   public IActionResult Register(UsuarioDto usuarioDto)
   {
      var usuario = _mapper.Map<Usuario>(usuarioDto);
      usuario.PasswordHash = Encryptor.Encrypt(usuarioDto.Password);

      if (_usuarioRepository.UsuarioExists(usuarioDto.NumeroDocumento) 
          || _usuarioRepository.UsuarioExistsByUsername(usuarioDto.UserName))
         return Conflict("The Object Already Exists");

      if (_usuarioRepository.Add(usuario))
         return Ok();

      ModelState.AddModelError("", "Something Wrong Happened");
      return StatusCode(500, ModelState);
   }
}