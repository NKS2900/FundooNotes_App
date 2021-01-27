// -----------------------------------------------------------------------------------------------------
// <copyright file="FundooModels.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Nijam Sayyad"/>
// -----------------------------------------------------------------------------------------------------

namespace FundooModel.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Fundoo model to set and get the data.
    /// </summary>
    [Table("FundooTable")]
    public class FundooModels
    {
        /// <summary>
        /// Id with primary key
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// set and get FirstName
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// set and get LastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// set and get Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// set and get Password
        /// </summary>
        public string Password { get; set; }
    }
}
