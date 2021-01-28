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
    using System.IdentityModel.Tokens;
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


        public bool SendEmail(string emailAddress)
        {
            string body;
            string subject = "Fundoo Notes";
            var dbEntry = fundooContext.FundooTable.FirstOrDefault(e => e.Email == emailAddress);
            if (dbEntry != null)
            {
                body = "<h1>Fundoo Notes Credential</h1><div><b>Hi " + dbEntry.FirstName + " </b>,<br></div>" +
                    "<table border=1px;><tr><td>User_ID</td><td>" + dbEntry.Email + "</td></tr>"
                    + "<tr><td>Password</td><td><b>" + dbEntry.Password + "</b></td></tr></table>";
            }
            else
            {
                return false;
            }

            using (MailMessage mailMessage = new MailMessage("example@gmail.com", emailAddress))
            {
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    EnableSsl = true
                };
                NetworkCredential NetworkCred = new NetworkCredential("example@gmail.com", Pass@123");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
                return true;
            }
        }

        public IEnumerable<FundooModels> GetAllRecords()
        {
            var users = fundooContext.FundooTable.ToList();
            return users;
        }

    }
}
