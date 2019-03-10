using System;
using System.Collections.Generic;

namespace FreedomApi.Models
{
    public partial class CharacterStatus
    {
        public int CharacterId { get; set; }
        public int StatusId { get; set; }

        public virtual Status Status { get; set; }
    }
}
