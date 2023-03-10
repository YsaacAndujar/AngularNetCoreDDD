using AutoMapper;
using Domain;
using FrontApi.Helpers.DTOs.Brand;

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
        }
    }
}
