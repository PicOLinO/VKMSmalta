using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VKMSmalta.Admin.Models.Domain
{
    [Table("Histories")]
    public class HistoryItem
    {
        [Key]
        public int ID { get; set; }
        public int StudentID { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }
        public string Algorithm { get; set; }
    }
}