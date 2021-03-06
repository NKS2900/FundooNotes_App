﻿// ---------------------------------------------------------------------------------------------
// <copyright file="FundooModels.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Nijam Sayyad"/>
// ---------------------------------------------------------------------------------------------

namespace FundooModel.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Fundoo model to set and get the data.
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// set and get id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserId { get; set; }

        /// <summary>
        /// set and get FirstName
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// set and get LastName
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// set and get Email
        /// </summary>
        [Required]
        [RegularExpression("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Invalid Email Id!!!")]
        public string Email { get; set; }

        /// <summary>
        /// set and get Password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
