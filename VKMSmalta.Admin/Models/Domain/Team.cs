using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VKMSmalta.Admin.Models.Domain
{
    public class Team
    {
        [Key]
        
        public int ID { get; set; }
        public int Number { get; set; }
    }
}