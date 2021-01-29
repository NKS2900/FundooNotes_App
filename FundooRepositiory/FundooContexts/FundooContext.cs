// -----------------------------------------------------------------------------------------------------
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

        /// <summary>
        /// Dbset for performing querys on table.
        /// </summary>
        public DbSet<FundooModels> FundooTable { get; set; }

        /// <summary>
        /// Performign query on NoteTable
        /// </summary>
        public DbSet<NoteModel> NoteTable { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
