#region Usings

using System.Collections.Generic;

#endregion

namespace Vkm.Smalta.Domain
{
    public class Algorithm
    {
        public Algorithm(Dictionary<string, int> startStateOfElements, Dictionary<string, int> endStateOfElements)
        {
            StartStateOfElements = startStateOfElements;
            EndStateOfElements = endStateOfElements;
        }

        public LinkedList<Action> Actions { get; set; }
        public Dictionary<string, int> EndStateOfElements { get; }

        public string Name { get; set; }
        public Dictionary<string, int> StartStateOfElements { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}