using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Colegio.Dto;
using Colegio.Models;
using Colegio.Repositories.IRepositories;
using Colegio.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Colegio.Controllers;

[Route("auth")]
[ApiController]
public class UsuarioController : ControllerBase
{
   private readonly IUsuarioRepository _usuarioRepository;
   private readonly IMapper _mapper;
   private readonly IConfiguration _configuration;
    
   public UsuarioController(IMapper mapper, IUsuarioRepository usuarioRepository, 
      IConfiguration configuration)
   {
      this._mapper = mapper;
      this._usuarioRepository = usuarioRepository;
      this._configuration = configuration;
   }

   [HttpPost("register")]
   [ProducesResponseType(200)]
   [ProducesResponseType(409)]
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
    
   [HttpPost("login")]
   [ProducesResponseType(200, Type = typeof(string))]
   [ProducesResponseType(404)]
   public IActionResult Login(UsuarioLoginDto usuarioDto)
   {
      usuarioDto.Password = Encryptor.Encrypt(usuarioDto.Password);

      if (!_usuarioRepository.UsuarioExistsByUsername(usuarioDto.UserName))
         return NotFound("User not found");

      var usuario = _usuarioRepository.GetUsuarioByUsernamePassword(
         usuarioDto.UserName, usuarioDto.Password
      );
      
      if(usuario == null)
         return NotFound("User not found");
      
      if (!ModelState.IsValid)
         return BadRequest();

      string token = CreateToken(usuario);
      
      return Ok(token);
   }

   private string CreateToken(Usuario usuario)
   {
      var roles = _usuarioRepository.GetRoles(usuario);
      
      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

      var claims = new List<Claim>
      {
         new Claim(ClaimTypes.Name, usuario.UserName)
      };

      claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

      var tokenDescriptor = new SecurityTokenDescriptor
      {
         Subject = new ClaimsIdentity(claims),
         Expires = DateTime.Now.AddDays(1),
         SigningCredentials = credentials,
         Issuer = _configuration["Jwt:Issuer"],
         Audience = _configuration["Jwt:Audience"]
      };

      var tokenHandler = new JwtSecurityTokenHandler();
      var token = tokenHandler.CreateToken(tokenDescriptor);

      return tokenHandler.WriteToken(token);
   }
}