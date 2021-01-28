// -----------------------------------------------------------------------------------------------------
// <copyright file="Repository.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Nijam Sayyad"/>
// -----------------------------------------------------------------------------------------------------

namespace FundooRepositiory
{
    using FundooModel.Models;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using Experimental.System.Messaging;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Security.Claims;
    using System.Text;

    /// <summary>
    /// Repository for FundooNotes
    /// </summary>
    public class Repository : IRepository
    {
        public static readonly SymmetricSecurityKey SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Repository.SECRET_KEY));

        private const string SECRET_KEY = "This is Secret authentication Key";

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

        public bool LoginValidation(string email, string password)
        {
            var userData = fundooContext.FundooTable.Where(x => x.Email == email && x.Password == password).SingleOrDefault();
            
            if (userData != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GenerateTokens(string UserEmail)
        {
            var token = new JwtSecurityToken(
                claims: new Claim[]
                {
                    new Claim(ClaimTypes.Name, UserEmail)
                },
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(DateTime.Now.AddMinutes(60)).DateTime,
                signingCredentials: new SigningCredentials(SIGNING_KEY, SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool ForgotPassword(string emailAddress)
        {
            var forgoturl = "Reset password link for FundooNotes App: https://localhost:44379/swagger/index.html";
            MessageQueue msmqQueue = new MessageQueue();
            if (MessageQueue.Exists(@".\Private$\MyQueue"))
            {
                msmqQueue = new MessageQueue(@".\Private$\MyQueue");
            }
            else
            {
                msmqQueue = MessageQueue.Create(@".\Private$\MyQueue");
            }
            Message message = new Message();
            message.Formatter = new BinaryMessageFormatter();
            message.Body = forgoturl;
            msmqQueue.Label = "url link";
            msmqQueue.Send(message);
            var reciever = new MessageQueue(@".\Private$\MyQueue");
            var recieving = reciever.Receive();
            recieving.Formatter = new BinaryMessageFormatter();
            string linkToSend = recieving.Body.ToString();

            string body;
            string subject = "Fundoo Notes";
            var dbEntry = fundooContext.FundooTable.FirstOrDefault(e => e.Email == emailAddress);
            if (dbEntry != null)
            {
                body = linkToSend;
            }
            else
            {
                return false;
            }

            using (MailMessage mailMessage = new MailMessage("nijamsayyad95@gmail.com", emailAddress))
            {
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    EnableSsl = true
                };
                NetworkCredential NetworkCred = new NetworkCredential("nijamsayyad95@gmail.com", "Nijam$2900@");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
                return true;
            }
        }
    }
}
