using FluentValidation;

namespace FrontApi.Helpers.DTOs.Brand
{
    public class BrandCreateDto
    {
        public string? name { get; set; }
    }
    public class BrandCreateValidator : AbstractValidator<BrandCreateDto>
    {
        public BrandCreateValidator()
        {
            RuleFor(model => model.name).NotEmpty().WithMessage("Name is required");
        }
    }
}
