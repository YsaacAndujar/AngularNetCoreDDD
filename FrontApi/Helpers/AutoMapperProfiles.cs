using AutoMapper;
using Domain;
using FrontApi.Helpers.DTOs.Brand;
using FrontApi.Helpers.DTOs.Car;
using FrontApi.Helpers.DTOs.CarModel;

namespace FrontApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<Brand, BrandCreateDto>().ReverseMap();
            CreateMap<BrandDto, BrandCreateDto>();
            CreateMap<Brand, BrandUpdateDto>();

            CreateMap<CarModel, CarModelDto>().ReverseMap();
            CreateMap<CarModel, CarModelCreateDto>().ReverseMap();
            CreateMap<CarModelDto, CarModelCreateDto>();
            CreateMap<CarModel, CarModelUpdateDto>();

            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<Car, CarCreateDto>().ReverseMap();
            CreateMap<CarDto, CarCreateDto>();
            CreateMap<Car, CarUpdateDto>();
        }
    }
}
