using System;
using System.Collections.Generic;

namespace DukkanTek.Models
{
    public partial class LookupStatus
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public bool? IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModififedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
