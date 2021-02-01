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
    [Route("api/[controller]")]
    public class FundooController : Controller
    { 
        private readonly IUserManager manager;
        public FundooController(IUserManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        public IActionResult RegisterUsers([FromBody] UserModel model)
        {
            try
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
            catch (Exception ex)
            {
                return this.NotFound(new { seccess = false, Massage = ex.Message });
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult LoginEmployee([FromBody] LoginModel model)
        {
            try
            {
                bool result = this.manager.LoginManager(model);
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
                return this.NotFound(new { seccess=false, Massage=ex.Message});
            }
            
        }

        [HttpPost]
        [Route("forgot")]
        public IActionResult ForgotPasswords(string emailAddress)
        {
            try
            {
                var result = this.manager.ForgotPass(emailAddress);
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
                return BadRequest(new { success = false, Message = "Somthing went wrong..." });
            }
        }
    }
}