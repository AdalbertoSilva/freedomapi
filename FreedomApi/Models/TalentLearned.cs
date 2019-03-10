using System;
using System.Collections.Generic;

namespace FreedomApi.Models
{
    public partial class TalentLearned
    {
        public int Id { get; set; }
        public int? Cost { get; set; }
        public DateTime? LearnedAt { get; set; }
        public int CharacterId { get; set; }
        public int TalentId { get; set; }
    }
}
