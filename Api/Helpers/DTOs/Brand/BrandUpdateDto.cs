using FluentValidation;

namespace Api.Helpers.DTOs.Brand
{
    public class BrandUpdateDto
    {
        public int? id { get; set; }
        public string? name { get; set; }
    }
    public class BrandUpdateValidator : AbstractValidator<BrandUpdateDto>
    {
        public BrandUpdateValidator()
        {
            RuleFor(model => model.id).NotEmpty().WithMessage("Id is required");
        }
    }
}
