#region Usings

using System.Collections.Generic;

#endregion

namespace Vkm.Smalta.Network
{
    public class TeamWithStudentsWithoutLoginsDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public IEnumerable<StudentDto> Students { get; set; }
    }
}