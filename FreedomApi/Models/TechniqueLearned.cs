using System;
using System.Collections.Generic;

namespace FreedomApi.Models
{
    public partial class TechniqueLearned
    {
        public int Id { get; set; }
        public int? Cost { get; set; }
        public DateTime? LearnedAt { get; set; }
        public int CharacterId { get; set; }
        public int TechniqueId { get; set; }
    }
}
