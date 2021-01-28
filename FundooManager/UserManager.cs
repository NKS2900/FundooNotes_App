// ----------------------------------------------------------------------------------------------------
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
        /// <summary>
        /// IRepository reference created
        /// </summary>
        private readonly IRepository repository;

        /// <summary>
        /// UserManager Constructor initializing IRepository
        /// </summary>
        /// <param name="repository">initializing IRepository</param>
        public UserManager(IRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Registeration of user
        /// </summary>
        /// <param name="model">passing model</param>
        /// <returns></returns>
        public bool RegisterManager(FundooModels model)
        {
            bool result = this.repository.RegisterUser(model);
            return result;
        }

        /// <summary>
        /// Login authentication
        /// </summary>
        /// <param name="model">passing login model</param>
        /// <returns>return true or false</returns>
        public bool LoginManager(LoginModel model)
        {
            bool result = this.repository.LoginValidation(model.Email, model.Password);
            return result;
        }

        /// <summary>
        /// generating JWT tokens.
        /// </summary>
        /// <param name="email">user email</param>
        /// <returns></returns>
        public string GenerateToken(string email)
        {
            string getToken = this.repository.GenerateTokens(email);
            return getToken;
        }

        /// <summary>
        /// sending resent password link in ForgotPass.
        /// </summary>
        /// <param name="mail">user email</param>
        /// <returns></returns>
        public bool ForgotPass(string mail)
        {
            var result = this.repository.ForgotPassword(mail);
            return result;
        }

        /// <summary>
        /// Reset password using Email
        /// </summary>
        /// <param name="model">login model</param>
        /// <returns></returns>
        public bool ResetPasswordManager(LoginModel model)
        {
            var result = this.repository.ResetPassword(model);
            return result;
        }

        /// <summary>
        /// Get all user data
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FundooModels> GetAllUsers()
        {
            var getAll = this.repository.GetAllRecords();
            return getAll;
        }
    }
}
