using System.Collections.Generic;

namespace VKMSmalta.Admin.Models.Domain
{
    public class Team
    {
        public int Number { get; set; }
        public List<Student> Students { get; set; }
    }
}