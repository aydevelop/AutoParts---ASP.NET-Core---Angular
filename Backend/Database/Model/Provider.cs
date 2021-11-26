
using FluentValidation;
namespace Database.Model
{
    public class Provider : BaseEntity
    {
        public string Name { get; set; }
        public string SiteUrl { get; set; }
    }

    public class ProviderValidator : AbstractValidator<Provider>
    {
        public ProviderValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.SiteUrl).NotEmpty();
        }
    }
}
