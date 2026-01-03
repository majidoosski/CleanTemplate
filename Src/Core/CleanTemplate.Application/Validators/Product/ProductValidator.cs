using CleanTemplate.Application.DTOs.Product;
using FluentValidation;

namespace CleanTemplate.Application.Validations.Product;

public class ProductValidator : AbstractValidator<ProductDTO>
{
    public ProductValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").Must(exp=>exp.Any(char.IsDigit)).WithMessage("Name should not Contain any Numbers");
        RuleFor(x => x.ImagePath).MaximumLength(400).WithMessage("the imagePath length is too long");
        RuleFor(x => x.Description).MaximumLength(500).WithMessage("the length of description is too long");
        //RuleFor(x=>x.Price).Must(exp=>)
    }
}
