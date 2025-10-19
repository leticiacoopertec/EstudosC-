using AutoMapper;
using CrudDapperVideo.DTO;
using CrudDapperVideo.Models;

namespace CrudDapperVideo.Profiles
{
    public class ProfileAutoMapper : Profile
    {
        public ProfileAutoMapper() 
        {
            CreateMap<Usuario, UsuarioListarDTO>();
        }
    }
}
