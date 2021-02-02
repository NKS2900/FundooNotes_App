// -----------------------------------------------------------------------------------------------------
// <copyright file="NoteModel.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Nijam Sayyad"/>
// -----------------------------------------------------------------------------------------------------

namespace FundooModel.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class NoteModel
    {
        [Key]
        public int NoteId { get; set; }
     
        public string Title { get; set; }

        public string Description { get; set; }

        [DefaultValue(false)]
        public bool Pin { get; set; }

        public string Reminder { get; set; }

        public string Collaborator { get; set; }

        public string Colour { get; set; }

        public string Image { get; set; }

        [DefaultValue(false)]
        public bool Archive { get; set; }

        [DefaultValue(false)]
        public bool Trash { get; set; }

        [ForeignKey("UserModel")]
        public int UserId { get; set; }
    }
}
