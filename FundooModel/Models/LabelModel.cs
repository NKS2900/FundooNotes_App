

namespace FundooModel.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using FundooModel.Models;
    public class LabelModel
    {
        [Key]
        public int LabelId { get; set; }

        public string LabelName { get; set; }

        [ForeignKey("NoteModel")]
        public int NoteId { get; set; }

        public NoteModel NoteModel;
    }
}
