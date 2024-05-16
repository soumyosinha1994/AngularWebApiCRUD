using AngularWebApiCRUD.DTO;
using AngularWebApiCRUD.Model;
using AutoMapper;

namespace AngularWebApiCRUD.Automapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            //CreateMap<Employee, EmployeeDTO>().ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name)).ReverseMap();
            CreateMap<Login, LoginDTO>().ReverseMap();
        }
        
    }
}
