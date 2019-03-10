using System;
using System.Collections.Generic;

namespace FreedomApi.Models
{
    public partial class Status
    {
        public Status()
        {
            CharacterStatus = new HashSet<CharacterStatus>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Complication { get; set; }
        public string Exhaustion { get; set; }
        public string Description { get; set; }

        public virtual ICollection<CharacterStatus> CharacterStatus { get; set; }
    }
}
