using AutoMapper;
using Colegio.Dto;
using Colegio.Models;

namespace Colegio.Utilities;

public class ProfileMapper : Profile
{
    public ProfileMapper()
    {
        CreateMap<Estudiante, EstudianteDto>();
        CreateMap<EstudianteDto, Estudiante>();
    }
}