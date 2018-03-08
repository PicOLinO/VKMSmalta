using System.Collections.Generic;

namespace VKMSmalta.Admin.Models.Domain
{
    public class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string UniversityGroup { get; set; }
        public Team Team { get; set; }
        public double AverageScore { get; set; }
        public List<HistoryItem> History { get; set; }
    }
}