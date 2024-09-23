using AutoMapper;
using Web_API.Data.Dtos.Filme;
using Web_API.Data.Dtos.Usuario;
using Web_API.Models;

namespace Web_API.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
            CreateMap<Usuario, ReadUsuarioDto>();
        }
    }
}
