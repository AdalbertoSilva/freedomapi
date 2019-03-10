using System;
using System.Collections.Generic;

namespace FreedomApi.Models
{
    public partial class ItemType
    {
        public int IdItem { get; set; }
        public int IdType { get; set; }

        public virtual Type IdTypeNavigation { get; set; }
    }
}
