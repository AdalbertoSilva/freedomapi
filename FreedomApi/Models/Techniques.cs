using System;
using System.Collections.Generic;

namespace FreedomApi.Models
{
    public partial class Techniques
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Difficulty { get; set; }
        public int? Effect { get; set; }
        public string Form { get; set; }
        public int? Area { get; set; }
        public int? Duration { get; set; }
        public int? Execution { get; set; }
        public int? Restriction { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int UserId { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual User User { get; set; }
    }
}
