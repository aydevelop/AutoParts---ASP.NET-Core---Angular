using AutoMapper;
using Database.Model;
using Infrastructure.DtoResponse;

namespace Infrastructure.Util
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AppUser, UserResponse>();
        }
    }
}
