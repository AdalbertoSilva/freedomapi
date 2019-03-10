using System;
using System.Collections.Generic;

namespace FreedomApi.Models
{
    public partial class TechniqueRestriction
    {
        public int Id { get; set; }
        public DateTime? AppliedAt { get; set; }
        public int TechniqueId { get; set; }
        public int RestrictionId { get; set; }
    }
}
