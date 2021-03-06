﻿// -----------------------------------------------------------------------------------------------------
// <copyright file="FundooContext.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Nijam Sayyad"/>
// -----------------------------------------------------------------------------------------------------

namespace FundooRepositiory
{
    using FundooModel.Models;
    using Microsoft.EntityFrameworkCore;  

    /// <summary>
    /// Fundoo Context to Performing operation on DataBase
    /// </summary>
    public class FundooContext : DbContext
    {
        /// <summary>
        /// Fundoo Context Constructor
        /// </summary>
        /// <param name="options"></param>
        public FundooContext(DbContextOptions<FundooContext> options) : base(options)
        {
        }

        public DbSet<UserModel> UserTable { get; set; }

        public DbSet<NoteModel> NoteTable { get; set; }

        public DbSet<LabelModel> LabelTable { get; set; }

        public DbSet<CollaboratorModel> CollaboratorTable { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
