#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace Vkm.Smalta.Domain
{
    public class DeviceEntry
    {
        public List<Algorithm> Algorithms { get; set; }
        public Enum FirstPageKey { get; set; }
        public Device Name { get; set; }
        public List<Enum> Pages { get; set; }
        public string ReadableName { get; set; }
    }
}