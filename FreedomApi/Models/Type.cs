using System;
using System.Collections.Generic;

namespace FreedomApi.Models
{
    public partial class Type
    {
        public Type()
        {
            ItemType = new HashSet<ItemType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Category { get; set; }

        public virtual ICollection<ItemType> ItemType { get; set; }
    }
}
