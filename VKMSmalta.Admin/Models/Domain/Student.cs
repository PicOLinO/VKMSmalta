using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VKMSmalta.Admin.Models.Domain
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string UniversityGroup { get; set; }
        public Team Team { get; set; }
        public double AverageScore { get; set; }
    }
}