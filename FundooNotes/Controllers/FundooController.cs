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
                return this.Ok(new { success = true, Message = "User Reginstered successfully", Data = result });
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
                return this.Ok(new { success = true, Message = "Login successfully", Data = result });
            }
            else
            {
                return this.BadRequest();
            }
        }

        [HttpGet]
        [Route("api/sendEmail")]
        public IActionResult ResetPasswords([FromBody] ForgotPasswordModel emailAddress)
        {
            var result = this.manager.SendEmailManager(emailAddress);
            if (result)
            {
                return this.Ok(new { success = true, Message = "Password Send successfully", Data = result });
            }
            else
            {
                return this.BadRequest();
            }
        }
    }
}
