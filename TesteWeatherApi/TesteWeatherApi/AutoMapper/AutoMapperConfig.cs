using AutoMapper;
using TesteWeatherApi.Data.Models;
using TesteWeatherApi.ViewModels;

namespace TesteWeatherApi.AutoMapper
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<BaseWeatherViewModel, BaseWeatherEntity>()
            .ForMember(dest => dest.Coord, opt => opt.MapFrom(src => src.Coord))
            .ForMember(dest => dest.Clouds, opt => opt.MapFrom(src => src.Clouds))
            .ForMember(dest => dest.Main, opt => opt.MapFrom(src => src.Main))
            .ForMember(dest => dest.Rain, opt => opt.MapFrom(src => src.Rain))
            .ForMember(dest => dest.Sys, opt => opt.MapFrom(src => src.Sys))
            .ForMember(dest => dest.Weather, opt => opt.MapFrom(src => src.Weather))
            .ForMember(dest => dest.Wind, opt => opt.MapFrom(src => src.Wind)).ReverseMap();

            CreateMap<CoordEntity, Coord>().ReverseMap();
            CreateMap<CloudsEntity, Clouds>().ReverseMap();
            CreateMap<MainEntity, Main>().ReverseMap();
            CreateMap<RainEntity, Rain>().ReverseMap();
            CreateMap<SysEntity, Sys>().ReverseMap();
            CreateMap<WeatherEntity, Weather>().ReverseMap();
            CreateMap<Wind, WindEntity>().ReverseMap();


            CreateMap<BaseWeatherEntity, TemperatureViewModel>().ReverseMap();

            CreateMap<BaseWeatherEntity, TemperatureViewModel>()
               .ForMember(dest => dest.Temp, opt => opt.MapFrom(src => src.Main.Temp))
               .ForMember(dest => dest.Temp_max, opt => opt.MapFrom(src => src.Main.Temp_max))
               .ForMember(dest => dest.Temp_min, opt => opt.MapFrom(src => src.Main.Temp_min)).ReverseMap();


            CreateMap<BaseWeatherViewModel, TemperatureViewModel>().ReverseMap();
            CreateMap<BaseWeatherViewModel, TemperatureViewModel>()
            .ForMember(dest => dest.Temp, opt => opt.MapFrom(src => src.Main.Temp))
            .ForMember(dest => dest.Temp_max, opt => opt.MapFrom(src => src.Main.Temp_max))
            .ForMember(dest => dest.Temp_min, opt => opt.MapFrom(src => src.Main.Temp_min)).ReverseMap();
        }
    }
}
