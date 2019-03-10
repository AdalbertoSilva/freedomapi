using System;
using System.Collections.Generic;

namespace FreedomApi.Models
{
    public partial class Party
    {
        public Party()
        {
            Character = new HashSet<Character>();
            UserParty = new HashSet<UserParty>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Level { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Character> Character { get; set; }
        public virtual ICollection<UserParty> UserParty { get; set; }
    }
}
