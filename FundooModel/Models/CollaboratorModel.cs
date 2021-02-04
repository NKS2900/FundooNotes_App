// ----------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorModel.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Nijam Sayyad"/>
// -----------------------------------------------------------------------------------------------------

namespace FundooModel.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CollaboratorTable")]
    public class CollaboratorModel
    {
        [Key]
        public int CallId { get; set; }

        [Required]
        [RegularExpression("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Invalid Sender Email Id!!!")]
        public string Sender { get; set; }

        [Required]
        [RegularExpression("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Invalid Reciver Email Id!!!")]
        public string Reciver { get; set; }

        public int NoteId { get; set; }

        [ForeignKey("NoteId")]
        public virtual NoteModel NoteModel { get; set; }
    }
}
