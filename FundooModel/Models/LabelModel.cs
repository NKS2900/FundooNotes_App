// ----------------------------------------------------------------------------------------------------
// <copyright file="LabelModel.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Nijam Sayyad"/>
// -----------------------------------------------------------------------------------------------------

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

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserModel UserModel { get; set; }

    }
}
