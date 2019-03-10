using System;
using System.Collections.Generic;

namespace FreedomApi.Models
{
    public partial class Skills
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
