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
        /// <summary>
        /// adding new User
        /// </summary>
        /// <param name="model">passing model</param>
        /// <returns>return True or False</returns>
        public bool RegisterManager(FundooModels model);

        /// <summary>
        /// Login validation
        /// </summary>
        /// <param name="model">passing login model</param>
        /// <returns>return True or False</returns>
        public bool LoginManager(LoginModel model);

        /// <summary>
        /// Generating JWT token
        /// </summary>
        /// <param name="userEmail">user Email</param>
        /// <returns>returns JWT token</returns>
        public string GenerateToken(string userEmail);

        /// <summary>
        /// Forgot password to send ResetPassword link
        /// </summary>
        /// <param name="mail">user email</param>
        /// <returns>return True or False</returns>
        public bool ForgotPass(string mail);

        /// <summary>
        /// Reset password using Email
        /// </summary>
        /// <param name="model">login model</param>
        /// <returns></returns>
        public bool ResetPasswordManager(LoginModel model);

        /// <summary>
        /// get all user records
        /// </summary>
        /// <returns>return all records</returns>
        public IEnumerable<FundooModels> GetAllUsers();
    }
}
