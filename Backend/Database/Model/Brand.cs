using FluentValidation;

namespace Database.Model
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
    }

    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}
