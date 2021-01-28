// -----------------------------------------------------------------------------------------------------
// <copyright file="FundooController.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Nijam Sayyad"/>
// -----------------------------------------------------------------------------------------------------

namespace FundooNotes.Controllers
{
    using FundooManager;
    using FundooModel.Models;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
 
    [ApiController]
    public class FundooController : Controller
    { 
        private readonly IUserManager manager;
        public FundooController(IUserManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        [Route("api/register")]
        public IActionResult AddEmployee([FromBody] FundooModels model)
        {
            bool result = manager.RegisterManager(model);
            if (result)
            {
                return this.Ok(new { success = true, Message = "User Reginstered successfully" });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("api/login")]
        public IActionResult LoginEmployee([FromBody] LoginModel model)
        {
            bool result = this.manager.LoginManager(model);
            if (result)
            {
                string getToken = manager.GenerateToken(model.Email);
                return this.Ok(new { success = true, Message = "Login successfully", getToken });
            }
            else
            {
                return this.BadRequest();
            }
        }

        [HttpGet]
        [Route("api/forgot")]
        public IActionResult ForgotPasswords(string emailAddress)
        {
            var result = this.manager.ForgotPass(emailAddress);
            if (result)
            {
                return this.Ok(new { success = true, Message = "Reset link Send to your Registered E-mail" });
            }
            else
            {
                return this.BadRequest();
            }
        }

        [HttpPost]
        [Route("api/reset")]
        public IActionResult ResetPasswords([FromBody] LoginModel model)
        {
            bool result = this.manager.ResetPasswordManager(model);
            if (result)
            {
                return this.Ok(new { success = true, Message = "Password Reset successfully" });
            }
            else
            {
                return this.BadRequest();
            }
        }

        [HttpGet]
        [Route("api/show")]
        public IActionResult ShowAllUsers()
        {
            try
            {
                IEnumerable<FundooModels> list = this.manager.GetAllUsers();
                return this.Ok(list);
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }
    }
}