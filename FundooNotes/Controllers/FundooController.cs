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
    }
}
