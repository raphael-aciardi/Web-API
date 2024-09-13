using AutoMapper;
using Web_API.Data.Dtos.Filme;
using Web_API.Models;

namespace Web_API.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
        }
    }
}

