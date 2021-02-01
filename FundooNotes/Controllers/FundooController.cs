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
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;

    [ApiController]
    [Route("api/[controller]")]
    public class FundooController : Controller
    { 
        private readonly IUserManager manager;

        private readonly ILogger<FundooController> _logger;
        public FundooController(IUserManager manager, ILogger<FundooController> _logger)
        {

            this.manager = manager;
            this._logger = _logger;
        }

        [HttpPost]
        public IActionResult RegisterUsers([FromBody] UserModel model)
        {
            _logger.LogInformation("The API for Registering new User.");
            try
            {
                bool result = manager.RegisterManager(model);
                _logger.LogInformation("Registeration successfull.");
                if (result)
                {
                    return this.Ok(new { success = true, Message = "User Reginstered successfully" });
                }
                else
                {
                    return BadRequest(new { success = false, Message = "Somthing went wrong..." });
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception occure " + ex.Message);
                return this.NotFound(new { seccess = false, Massage = ex.Message });
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult LoginUser([FromBody] LoginModel model)
        {
            _logger.LogInformation("The API LoginUser Called");
            try
            {
                bool result = this.manager.LoginManager(model);
                _logger.LogInformation("User Login Successfull api.");
                if (result)
                {
                    string getToken = manager.GenerateToken(model.Email);
                    return this.Ok(new { success = true, Message = "Login successfully" });
                }
                else
                {
                    return BadRequest(new { success = false, Message = "Somthing went wrong..." });
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception Occurs at the time of login "+ex.Message);
                return this.NotFound(new { seccess=false, Massage=ex.Message});
            }
            
        }

        [HttpPost]
        [Route("forgot")]
        public IActionResult ForgotPasswords(string emailAddress)
        {
            _logger.LogInformation("The API ForgotPasswords Called");
            try
            {
                var result = this.manager.ForgotPass(emailAddress);
                _logger.LogInformation("Forgot password operation successfull.");
                if (result)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Masseage = "Reset link Send to your Registered E-mail", Data = emailAddress });
                }
                else
                {
                    return BadRequest(new { success = false, Message = "Somthing went wrong..." });
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception Occurs " + ex.Message);
                return this.NotFound(new { seccess = false, Massage = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult ResetPasswords([FromBody] LoginModel model)
        {
            try
            {
                bool result = this.manager.ResetPasswordManager(model);
                if (result)
                {
                    return this.Ok(new { success = true, Message = "Password Reset successfully" });
                }
                else
                {
                    return BadRequest(new { success = false, Message = "Somthing went wrong..." });
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception Occurs at the time of resetPassword " + ex.Message);
                return this.NotFound(new { seccess = false, Massage = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult ShowAllUsers()
        {
            try
            {
                IEnumerable<UserModel> list = this.manager.GetAllUsers();
                return this.Ok(list);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception Occurs " + ex.Message);
                return BadRequest(new { success = false, Message = ex.Message });
            }
        }
    }
}