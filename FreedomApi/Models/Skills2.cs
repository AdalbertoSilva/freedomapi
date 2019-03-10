using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FreedomApi.Models
{
    public class Skill2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
    }
}
