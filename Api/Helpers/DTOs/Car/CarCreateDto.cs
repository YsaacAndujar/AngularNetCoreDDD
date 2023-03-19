using Application.Services;
using FluentValidation;

namespace Api.Helpers.DTOs.Car
{
    public class CarCreateDto
    {
        public int? year { get; set; } 

        public int? carModelId { get; set; }
    }
    public class CarCreateValidator : AbstractValidator<CarCreateDto>
    {
        CarModelService carModelService { get; set; }
        public CarCreateValidator(CarModelService _carModelService)
        {
            carModelService = _carModelService;
            RuleFor(model => model.year).NotEmpty().WithMessage("Year is required");
            RuleFor(model => model.carModelId).NotEmpty().WithMessage("Car Model Id is required");
            RuleFor(model => model.carModelId).Custom((carModelId, context) => {
                if (carModelId == null) { return; }
                if (carModelService.FindById((int)carModelId) == null)
                {
                    context.AddFailure("Car Model does not exist");
                }
            });
        }
    }
}
