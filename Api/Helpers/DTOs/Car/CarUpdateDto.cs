using Application.Services;
using FluentValidation;

namespace Api.Helpers.DTOs.Car
{
    public class CarUpdateDto
    {
        public int? id { get; set; }

        public int? year { get; set; }

        public int? carModelId { get; set; }
    }
    public class CarUpdateValidator : AbstractValidator<CarUpdateDto>
    {
        CarModelService carModelService { get; set; }

        public CarUpdateValidator(CarModelService _carModelService)
        {
            carModelService = _carModelService;
            RuleFor(model => model.id).NotEmpty().WithMessage("Id is required");
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
