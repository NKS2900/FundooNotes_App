// -----------------------------------------------------------------------------------------------------
// <copyright file="UserManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Nijam Sayyad"/>
// -----------------------------------------------------------------------------------------------------

namespace FundooManager
{
    using System.Collections.Generic;
    using FundooModel.Models;
    using FundooRepositiory;
    
    /// <summary>
    /// UserManager Class
    /// </summary>
    public class UserManager : IUserManager
    {
        private readonly IRepository repository;

        public UserManager(IRepository repository)
        {
            this.repository = repository;
        }

        public bool RegisterManager(FundooModels model)
        {
            bool result = repository.RegisterUser(model);
            return result;
        }
    }
}
