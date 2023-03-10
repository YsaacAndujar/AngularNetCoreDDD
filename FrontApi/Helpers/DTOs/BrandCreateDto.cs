using Domain;
using FluentValidation;

namespace FrontApi.DTOs
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
