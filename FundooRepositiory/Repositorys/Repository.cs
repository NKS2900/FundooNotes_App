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

        public bool LoginValidation(string email, string password)
        {
            var userData = fundooContext.FundooTable.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
            
            if (userData != null)
            {
                return true;
            }
            else
            {
                return false;
            }
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
    }
}
