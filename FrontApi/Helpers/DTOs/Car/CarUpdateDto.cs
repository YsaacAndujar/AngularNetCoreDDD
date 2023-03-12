using FluentValidation;

namespace FrontApi.Helpers.DTOs.Car
{
    public class CarUpdateDto
    {
        public int? id { get; set; }

        public int? year { get; set; }

        public int? carModelId { get; set; }
    }
    public class CarUpdateValidator : AbstractValidator<CarUpdateDto>
    {
        public CarUpdateValidator()
        {
            RuleFor(model => model.id).NotEmpty().WithMessage("Id is required");
            RuleFor(model => model.year).NotEmpty().WithMessage("Year is required");
            RuleFor(model => model.carModelId).NotEmpty().WithMessage("Car Model Id is required");
        }
    }
}
