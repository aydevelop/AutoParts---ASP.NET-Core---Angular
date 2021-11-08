using Database.Contract;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace Database.Model
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
    }

    public class CategoryValidator : AbstractValidator<Category>
    {
        private readonly ICategoryRepository _db;

        public CategoryValidator(ICategoryRepository db)
        {
            _db = db;

            RuleFor(p => p.Name)
                .MustAsync((name, token) => IsDuplicateAsync(name, token))
                .WithMessage("Сategory already exists");
        }

        private async Task<bool> IsDuplicateAsync(string name, CancellationToken token)
        {
            var category = await _db.GetByFiler(q => q.Name == name);
            if (category.Length > 0)
            {
                return false;
            }

            return true;
        }
    }
}
