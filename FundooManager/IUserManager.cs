// -----------------------------------------------------------------------------------------------------
// <copyright file="IUserManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Nijam Sayyad"/>
// -----------------------------------------------------------------------------------------------------

namespace FundooManager
{
    using FundooModel.Models;
    using System.Collections.Generic;

    public interface IUserManager
    {
        public bool RegisterManager(FundooModels model);

        public bool LoginManager(LoginModel model);

        public string GenerateToken(string UserEmail);

        public bool SendEmailManager(string mail);

        public IEnumerable<FundooModels> GetAllUsers();
    }
}
