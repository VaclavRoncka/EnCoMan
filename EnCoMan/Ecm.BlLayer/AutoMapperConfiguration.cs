using System;
using AutoMapper;
using Ecm.Common.Dto;
using Ecm.DbLayer;

namespace Ecm.BlLayer
{
    public static class AutoMapper
    {
        public static IMapper Instance { get; private set; }
        
        static AutoMapper()
        {
            Instance = new MapperConfiguration(c =>
            {
                c.CreateMap<Configuration, ConfigurationDto>();
                c.CreateMap<User, UserDto>();
                c.CreateMap<EnergyType, EnergyTypeDto>();
                c.CreateMap<Periodicity, PeriodicityDto>();

                c.CreateMap<ConfigurationDto, Configuration>();
                c.CreateMap<UserDto, User>();
                c.CreateMap<EnergyTypeDto, EnergyType>();
                c.CreateMap<PeriodicityDto, Periodicity>();
            }).CreateMapper();
        }
    }

    



}