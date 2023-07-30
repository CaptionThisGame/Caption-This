using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaptionThis.Data.Models
{
    [Table("examples")]
    public class Example : BaseModel
    {
        [Column("number")]
        public int? Zahl { get; set; }

        [Column("word"), MaxLength(64)]
        public string? Wort { get; set; }
    }
}
