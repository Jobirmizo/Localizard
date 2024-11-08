﻿using AutoMapper;
using Localizard.Domain.Entites;
using Localizard.Domain.ViewModel;

namespace Localizard.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, LoginDto>();
    }
    
}