// -----------------------------------------------------------------------------------------------------
// <copyright file="Repository.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Nijam Sayyad"/>
// -----------------------------------------------------------------------------------------------------

namespace FundooRepositiory
{
    using System;
    using MSMQ_Email;
    using FundooModel.Models;
    using Microsoft.IdentityModel.Tokens;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Security.Claims;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using FundooRepositiory.IRepositorys;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Repository for FundooNotes
    /// </summary>
    public class UserRepository : IUserRepository
    {
        
        private readonly FundooContext fundooContext;

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Constructor to Initializing FundooContext
        /// </summary>
        /// <param name="fundooContext">fundooContext</param>
        public UserRepository(FundooContext fundooContext, IConfiguration configuration)
        {
            this.fundooContext = fundooContext;
            Configuration = configuration;
        }

        /// <summary>
        /// Password Encryption
        /// </summary>
        /// <param name="password">user password</param>
        /// <returns></returns>
        public string PasswordEncryption(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = Encoding.UTF8.GetBytes(password);
                string encodedPassword = Convert.ToBase64String(encData_byte);
                return encodedPassword;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        /// <summary>
        /// adding user in database 
        /// </summary>
        /// <param name="model">passing model</param>
        /// <returns>return True or False</returns>
        public bool RegisterUser(UserModel model)
        {
            string encodedPass = PasswordEncryption(model.Password);
            model.Password = encodedPass;
            fundooContext.UserTable.Add(model);
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

        /// <summary>
        /// validating user details
        /// </summary>
        /// <param name="email">user email</param>
        /// <param name="password">user password</param>
        /// <returns>return True or False</returns>
        public bool LoginValidation(string email, string password)
        {
            string encodedPass = PasswordEncryption(password);
            var userData = fundooContext.UserTable.Where(x => x.Email == email && x.Password == encodedPass).SingleOrDefault();
            
            if (userData != null)
            { 
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// gernerating JWT token
        /// </summary>
        /// <param name="userEmail">user Email</param>
        /// <returns>Return Token</returns>
        public string GenerateTokens(string userEmail)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: new Claim[]
                {
                    new Claim(ClaimTypes.Name, userEmail)
                },
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(DateTime.Now.AddMinutes(60)).DateTime,
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Forgot password to send Reset Password link
        /// </summary>
        /// <param name="emailAddress">user Email</param>
        /// <returns>return True or False</returns>
        public bool ForgotPassword(string emailAddress)
        {     
            string body;
            string subject = "Fundoo Notes";
            var dbEntry = fundooContext.UserTable.FirstOrDefault(e => e.Email == emailAddress);
            if (dbEntry != null)
            {
                Sender send = new Sender();
                send.MailSender();
                Reciver recive = new Reciver();
                var linkToSend = recive.MailReciver();
                body = linkToSend;
            }
            else
            {
                return false;
            }

            MailMessage mailMessage = new MailMessage("nijamsayyad@gmail.com", emailAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                EnableSsl = true
            };
            NetworkCredential NetworkCred = new NetworkCredential("nijamsayyad@gmail.com", "Pass@123");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mailMessage);
            return true;
        }

        /// <summary>
        /// Reset password
        /// </summary>
        /// <param name="login">passing loginModel</param>
        /// <returns>return True or False</returns>
        public bool ResetPassword(LoginModel login)
        {
            var dbEntry = fundooContext.UserTable.FirstOrDefault(acc => acc.Email == login.Email);
            string newPass = login.Password;
            string encodedPass = PasswordEncryption(newPass);
            if (dbEntry != null)
            {
                dbEntry.Password = encodedPass;
                fundooContext.Entry(dbEntry).State = EntityState.Modified;
                fundooContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Geting all user records
        /// </summary>
        /// <returns>returns all records</returns>
        public IEnumerable<UserModel> GetAllRecords()
        {
            var users = fundooContext.UserTable.ToList();
            return users;
        }
    }
}