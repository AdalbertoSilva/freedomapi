using System;
using System.Collections.Generic;

namespace FreedomApi.Models
{
    public partial class SkillLearned
    {
        public int Id { get; set; }
        public int? Cost { get; set; }
        public int? Experience { get; set; }
        public DateTime? LearnedAt { get; set; }
        public int CharacterId { get; set; }
        public int SkillId { get; set; }
    }
}
