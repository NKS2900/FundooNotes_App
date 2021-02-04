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
    using FundooRepositiory.IRepositorys;
    using FundooManager;
    using System;

    /// <summary>
    /// UserManager Class
    /// </summary>
    public class UserManager : IUserManager
    {
        /// <summary>
        /// IRepository reference created
        /// </summary>
        private readonly IUserRepository repository;

        /// <summary>
        /// UserManager Constructor initializing IRepository
        /// </summary>
        /// <param name="repository">initializing IRepository</param>
        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Registeration of user
        /// </summary>
        /// <param name="model">passing model</param>
        /// <returns></returns>
        public bool RegisterManager(UserModel model)
        {
            try
            {
                bool result = this.repository.RegisterUser(model);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Login authentication
        /// </summary>
        /// <param name="model">passing login model</param>
        /// <returns>return true or false</returns>
        public bool LoginManager(LoginModel model)
        {
            try
            {
                bool result = this.repository.LoginValidation(model.Email, model.Password);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// generating JWT tokens.
        /// </summary>
        /// <param name="email">user email</param>
        /// <returns>Token</returns>
        public string GenerateToken(string email)
        {
            try
            {
                string getToken = this.repository.GenerateTokens(email);
                return getToken;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// sending resent password link in ForgotPass.
        /// </summary>
        /// <param name="mail">user email</param>
        /// <returns>true or false</returns>
        public bool ForgotPass(string mail)
        {
            try
            {
                var result = this.repository.ForgotPassword(mail);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Reset password using Email
        /// </summary>
        /// <param name="model">login model</param>
        /// <returns>true or false</returns>
        public bool ResetPasswordManager(LoginModel model)
        {
            try
            {
                var result = this.repository.ResetPassword(model);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get all user data
        /// </summary>
        /// <returns>UserModel</returns>
        public IEnumerable<UserModel> GetAllUsers()
        {
            try
            {
                var getAll = this.repository.GetAllRecords();
                return getAll;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
