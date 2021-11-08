using System;

namespace Database.Model
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
    }
}
