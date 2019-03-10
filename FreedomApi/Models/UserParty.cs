using System;
using System.Collections.Generic;

namespace FreedomApi.Models
{
    public partial class UserParty
    {
        public int Id { get; set; }
        public sbyte? Master { get; set; }
        public DateTime? JoinedAt { get; set; }
        public int UserId { get; set; }
        public int PartyId { get; set; }

        public virtual Party Party { get; set; }
        public virtual User User { get; set; }
    }
}
