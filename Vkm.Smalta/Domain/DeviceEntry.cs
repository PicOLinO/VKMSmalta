using System.Collections.Generic;

namespace Vkm.Smalta.Domain
{
    public class DeviceEntry
    {
        public Device Name { get; set; }
        public string ReadableName { get; set; }
        public List<Algorithm> Algorithms { get; set; }
    }
}