using System.Collections.Generic;

namespace VKMSmalta.Domain
{
    public class Algorithm
    {
        public Dictionary<string, int> StartStateOfElements { get; }
        public Dictionary<string, int> EndStateOfElements { get; }

        public string Name { get; set; }
        public LinkedList<Action> Actions { get; set; }

        public Algorithm(Dictionary<string, int> startStateOfElements, Dictionary<string, int> endStateOfElements)
        {
            StartStateOfElements = startStateOfElements;
            EndStateOfElements = endStateOfElements;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}