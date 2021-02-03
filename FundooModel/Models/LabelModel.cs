

namespace FundooModel.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using FundooModel.Models;

    [Table("LabelTable")]
    public class LabelModel
    {
        [Key]
        public int LabelId { get; set; }

        public string LabelName { get; set; }

        public int NoteId { get; set; }

        [ForeignKey("UserModel")]
        public int UserId { get; set; }

    }
}
