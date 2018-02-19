using System.Collections.Generic;

namespace VKMSmalta.Domain
{
    public class ExamineResult
    {
        public int Value { get; set; }
        public List<Action> Actions { get; set; }
        public Algorithm Algorithm { get; set; }
    }
}