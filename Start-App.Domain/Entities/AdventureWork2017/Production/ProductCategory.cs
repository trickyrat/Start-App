using System.Collections.Generic;
using Start_App.Domain.Common;
#nullable disable

namespace Start_App.Domain.Entities
{
    public class ProductCategory : AuditableEntity, IHasDomainEvent
    {
        public ProductCategory()
        {
            ProductSubcategories = new HashSet<ProductSubcategory>();
        }

        public int ProductCategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductSubcategory> ProductSubcategories { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
