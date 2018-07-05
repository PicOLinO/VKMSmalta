#region Usings

using System.Collections.Generic;

#endregion

namespace Vkm.Smalta.Domain
{
    public class Team
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}