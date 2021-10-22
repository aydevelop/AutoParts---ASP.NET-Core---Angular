using FluentValidation;
using System;

namespace Database.Model
{
    public class Model : BaseEntity
    {
        public string Name { get; set; }

        public Guid BrandId { get; set; }
        public virtual Brand Brand { get; set; }
    }

    public class ModelValidator : AbstractValidator<Model>
    {
        public ModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}
