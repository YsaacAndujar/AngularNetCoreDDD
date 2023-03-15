using AutoMapper;
using Domain;
using Api.Helpers.DTOs.Brand;
using Api.Helpers.DTOs.Car;
using Api.Helpers.DTOs.CarModel;

namespace Api.Helpers
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
