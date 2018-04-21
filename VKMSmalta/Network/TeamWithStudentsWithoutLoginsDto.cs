using System.Collections.Generic;

namespace VKMSmalta.Network
{
    public class TeamWithStudentsWithoutLoginsDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public IEnumerable<StudentDto> Students { get; set; }
    }
}