using AutoMapper;
using Colegio.Dto;
using Colegio.Models;

namespace Colegio.Utilities;

public class ProfileMapper : Profile
{
    public ProfileMapper()
    {
        CreateMapEstudianteToEstudianteDto();
        CreateMapUsuarioDtoToUsuario();
        CreateMapUsuarioLoginDtoToUsuario();
    }

    private void CreateMapUsuarioLoginDtoToUsuario()
    {
        CreateMap<UsuarioLoginDto, Usuario>()
            .ForMember(usuario => usuario.PasswordHash,
                option => 
                option.MapFrom(usuarioLoginDto => usuarioLoginDto.Password))
            .ForMember(usuario => usuario.Nombre,
                option => 
                    option.MapFrom(usuarioLoginDto => usuarioLoginDto.UserName));;
    }

    private void CreateMapUsuarioDtoToUsuario()
    {
        CreateMap<UsuarioDto, Usuario>()
            .ForMember(usuario => usuario.PasswordHash, 
                option => option.MapFrom(usuarioDto => usuarioDto.Password))
            .ForMember(usuario => usuario.Id, 
                option => option.MapFrom(usuarioDto => usuarioDto.NumeroDocumento));
    }

    private void CreateMapEstudianteToEstudianteDto()
    {
        CreateMap<Estudiante, EstudianteDto>()
            .ForMember(dto => dto.Nombre, 
                option => option.MapFrom(estudiante => estudiante.Usuario.Nombre))
            .ForMember(dto => dto.NumeroDocumento, 
                option => option.MapFrom(estudiante => estudiante.Usuario.Id))
            .ForMember(dto => dto.Username, 
                option => option.MapFrom(estudiante => estudiante.Usuario.UserName))
            .ForMember(dto => dto.Edad, 
                option => option.MapFrom(estudiante => estudiante.Usuario.Edad))
            .ForMember(dto => dto.GrupoSanguineo, 
                option => option.MapFrom(estudiante => estudiante.Usuario.GrupoSanguineo))
            .ForMember(dto => dto.DireccionResidencia, 
                option => option.MapFrom(estudiante => estudiante.Usuario.DireccionResidencia))
            .ForMember(dto => dto.FechaNacimiento, 
                option => option.MapFrom(estudiante => estudiante.Usuario.FechaNacimiento));
    }
}