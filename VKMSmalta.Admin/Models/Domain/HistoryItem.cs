using System;

namespace VKMSmalta.Admin.Models.Domain
{
    public class HistoryItem
    {
        public DateTime Date { get; set; }
        public int Value { get; set; }
        public string Algorithm { get; set; }
    }
}