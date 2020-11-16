using System.Collections.Generic;
using Start_App.Domain.Common;

#nullable disable

namespace Start_App.Domain.Entities
{
    public class ProductSubcategory : AuditableEntity, IHasDomainEvent
    {
        public ProductSubcategory()
        {
            Products = new HashSet<Product>();
        }

        public int ProductSubcategoryId { get; set; }
        public string Name { get; set; }
        public int ProductCategoryId { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
