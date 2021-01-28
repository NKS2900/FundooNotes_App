﻿// -----------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Nijam Sayyad"/>
// -----------------------------------------------------------------------------------------------------

namespace FundooRepositiory
{
    using System.Collections.Generic;
    using FundooModel.Models;

    /// <summary>
    /// Interface for Repository
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// RegisterUser Method
        /// </summary>
        /// <param name="model">passing model</param>
        /// <returns>it returns True or False</returns>
        public bool RegisterUser(FundooModels model);

        /// <summary>
<<<<<<< HEAD
=======
        /// Password Encryption method
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string PasswordEncryption(string password);

        /// <summary>
>>>>>>> UC1_FundooNotes
        /// Login Validation method
        /// </summary>
        /// <param name="email">user Email</param>
        /// <param name="password">user Password</param>
        /// <returns>it returns True or False</returns>
        public bool LoginValidation(string email, string password);

        /// <summary>
        /// Generate JWT token
        /// </summary>
        /// <param name="email">user Email</param>
        /// <returns>it return the JWT token</returns>
        public string GenerateTokens(string email);

        /// <summary>
        /// Forgot Password to send mail.
        /// </summary>
        /// <param name="email">user E-mail</param>
        /// <returns>it returns True or False</returns>
        public bool ForgotPassword(string email);
<<<<<<< HEAD

        /// <summary>
        /// Reset password
        /// </summary>
        /// <param name="login">passing loginModel</param>
        /// <returns>return True or False</returns>
        public bool ResetPassword(LoginModel login);

        /// <summary>
=======

        /// <summary>
        /// Reset password
        /// </summary>
        /// <param name="login">passing loginModel</param>
        /// <returns>return True or False</returns>
        public bool ResetPassword(LoginModel login);

        /// <summary>
>>>>>>> UC1_FundooNotes
        /// Get all user records
        /// </summary>
        /// <returns>it returns all records</returns>
        public IEnumerable<FundooModels> GetAllRecords();
    }
}
