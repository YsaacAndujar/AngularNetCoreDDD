using FluentValidation;

namespace Api.Helpers.DTOs.CarModel
{
    public class CarModelUpdateDto
    {
        public int? id { get; set; }
        public int? brandId { get; set; }
        public string? name { get; set; }

    }
    public class CarModelUpdateValidator : AbstractValidator<CarModelUpdateDto>
    {
        public CarModelUpdateValidator()
        {
            RuleFor(model => model.name).NotEmpty().WithMessage("Name is required");
            RuleFor(model => model.brandId).NotEmpty().WithMessage("Brand Id is required");
            RuleFor(model => model.id).NotEmpty().WithMessage("Id is required");
        }
    }
}
