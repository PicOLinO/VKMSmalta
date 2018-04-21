using System.Collections.Generic;

namespace VKMSmalta.Domain
{
    public class Team
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}