using System;
using System.Collections.Generic;

namespace DukkanTek.Models
{
    public partial class LookupCategory
    {
        public LookupCategory()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
