using System;
using System.Collections.Generic;

namespace FreedomApi.Models
{
    public partial class CharacterRemarkableTrait
    {
        public int Id { get; set; }
        public DateTime? ObtainedAt { get; set; }
        public int CharacterId { get; set; }
        public int RemarkableTraitId { get; set; }
    }
}
