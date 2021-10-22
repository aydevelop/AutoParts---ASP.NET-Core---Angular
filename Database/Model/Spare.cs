using FluentValidation;
using System;

namespace Database.Model
{
    public class Spare : BaseEntity
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public Guid ModelId { get; set; }
        public virtual Model Model { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }

    public class SpareValidator : AbstractValidator<Spare>
    {
        public SpareValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Price).NotEmpty();
            RuleFor(p => p.ImageUrl).NotEmpty();
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.Url).NotEmpty();
        }
    }
}
