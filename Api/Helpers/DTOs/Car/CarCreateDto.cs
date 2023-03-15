using FluentValidation;

namespace Api.Helpers.DTOs.Car
{
    public class CarCreateDto
    {
        public int year { get; set; } 

        public int carModelId { get; set; }
    }
    public class CarCreateValidator : AbstractValidator<CarCreateDto>
    {
        public CarCreateValidator()
        {
            RuleFor(model => model.year).NotEmpty().WithMessage("Year is required");
            RuleFor(model => model.carModelId).NotEmpty().WithMessage("Car Model Id is required");
        }
    }
}
