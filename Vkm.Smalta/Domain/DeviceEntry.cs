using System;
using System.Collections.Generic;
using Vkm.Smalta.Services.Navigate;
using Vkm.Smalta.View.InnerPages.ViewModel;

namespace Vkm.Smalta.Domain
{
    public class DeviceEntry
    {
        public Device Name { get; set; }
        public string ReadableName { get; set; }
        public List<Algorithm> Algorithms { get; set; }
        public List<Enum> Pages { get; set; }
        public Enum FirstPageKey { get; set; }
    }
}