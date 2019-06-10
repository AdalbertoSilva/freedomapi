using System;
using System.Collections.Generic;

namespace FreedomApi.Models
{
    public partial class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CharacterPoints { get; set; }
        public int? DestinoPoints { get; set; }
        public int? ExhaustionLevel { get; set; }
        public int? ComplicationLevel { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int UserId { get; set; }
        public int PartyId { get; set; }

        public virtual Party Party { get; set; }
        public virtual Player User { get; set; }
    }
}
