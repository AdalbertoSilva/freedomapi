using System;
using System.Collections.Generic;

namespace FreedomApi.Models
{
    public partial class Player
    {
        public Player()
        {
            Character = new HashSet<Character>();
            Item = new HashSet<Item>();
            RemarkableTrait = new HashSet<RemarkableTrait>();
            Restriction = new HashSet<Restriction>();
            Skills = new HashSet<Skills>();
            Talent = new HashSet<Talent>();
            Techniques = new HashSet<Techniques>();
            UserParty = new HashSet<PlayerParty>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual ICollection<Character> Character { get; set; }
        public virtual ICollection<Item> Item { get; set; }
        public virtual ICollection<RemarkableTrait> RemarkableTrait { get; set; }
        public virtual ICollection<Restriction> Restriction { get; set; }
        public virtual ICollection<Skills> Skills { get; set; }
        public virtual ICollection<Talent> Talent { get; set; }
        public virtual ICollection<Techniques> Techniques { get; set; }
        public virtual ICollection<PlayerParty> UserParty { get; set; }
    }
}
