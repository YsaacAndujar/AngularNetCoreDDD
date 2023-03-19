using Application.Services;
using FluentValidation;

namespace Api.Helpers.DTOs.CarModel
{
    public class CarModelCreateDto
    {
        public int? brandId { get; set; }
        public string? name { get; set; }

    }
    public class CarModelCreateValidator : AbstractValidator<CarModelCreateDto>
    {
        BrandService brandService { get; set; }
        public CarModelCreateValidator(BrandService _brandService)
        {
            brandService = _brandService;
            RuleFor(model => model.name).NotEmpty().WithMessage("Name is required");
            RuleFor(model => model.brandId).NotEmpty().WithMessage("Brand Id is required");
            RuleFor(model => model.brandId).Custom((brandId, context) => {
                if(brandId == null) { return; }
                if (brandService.FindById((int)brandId) == null)
                {
                    context.AddFailure("Brand does not exist");
                }
            });
        }
    }
}
