using System;
using System.Collections.Generic;

namespace FreedomApi.Models
{
    public partial class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Charge { get; set; }
        public int? MaximumCharge { get; set; }
        public int? Exhaustion { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int CharacterId { get; set; }
        public int UserId { get; set; }

        public virtual Player User { get; set; }
    }
}
