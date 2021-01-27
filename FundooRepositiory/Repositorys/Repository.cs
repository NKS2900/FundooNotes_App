// -----------------------------------------------------------------------------------------------------
// <copyright file="Repository.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Nijam Sayyad"/>
// -----------------------------------------------------------------------------------------------------

namespace FundooRepositiory
{
    using FundooModel.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;

    /// <summary>
    /// Repository for 
    /// </summary>
    public class Repository : IRepository
    {
        private readonly FundooContext fundooContext;
        public Repository(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }
        public bool RegisterUser(FundooModels model)
        {
            fundooContext.FundooTable.Add(model);
            var emp = fundooContext.SaveChanges();
            if (emp > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
      	}
    }
}
