// -----------------------------------------------------------------------------------------------------
// <copyright file="NoteController.cs" company="Bridgelabz">
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
    public class NoteController : Controller
    {
        private readonly INoteManager manager;
        public NoteController(INoteManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        public IActionResult AddNewNote([FromBody] NoteModel model)
        {
            bool result = manager.AddNotes(model);
            if (result)
            {
                return this.Ok(new { success = true, Message = "Note Created successfully" });
            }
            else
            {
                return BadRequest(new { success=false, Message="Somthing went wrong..."});
            }
        }

        [HttpGet]
        public IActionResult GetNotes()
        {
            try
            {
                var note = manager.RetrieveNotes();
                if (note != null)
                {
                    return this.Ok(new ResponseModel<IEnumerable<NoteModel>>() { Status = true, Masseage = "Retrieve Notes Successfully", Data = note });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Failed to Retrieve Notes" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        
    }
}
