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
        public CarModelCreateValidator()
        {
            RuleFor(model => model.name).NotEmpty().WithMessage("Name is required");
            RuleFor(model => model.brandId).NotEmpty().WithMessage("Brand Id is required");
        }
    }
}
