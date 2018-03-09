using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VKMSmalta.Admin.Models.Domain
{
    [Table("Test")]
    public class Test
    {
        [Key]
        public int ID { get; set; }
    }
}