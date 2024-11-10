using AutoMapper;
using Localizard.Domain.Entites;
using Localizard.Domain.ViewModel;

namespace Localizard.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, LoginDto>();
        CreateMap<LoginDto, User>();
        
        CreateMap<User, GetUsersDto>();
        CreateMap<GetUsersDto, User>();
        
        CreateMap<ProjectInfo, LanguageDto>();
        CreateMap<LanguageDto, ProjectInfo>();
        
        CreateMap<ProjectInfo, ProjectInfoDto>();
        CreateMap<ProjectInfoDto, ProjectInfo>();
    }
    
}