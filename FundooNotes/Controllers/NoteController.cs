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
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class NoteController : Controller
    {
        private readonly INoteManager manager;
        public NoteController(INoteManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        [Route("addNote")]
        public IActionResult AddNewNote([FromBody] NoteModel model)
        {
            try
            {
                bool result = manager.AddNotes(model);
                if (result)
                {
                    return this.Ok(new ResponseModel<NoteModel>() { Status = true, Masseage = "Note Created successfully", Data = model });
                }
                else
                {
                    return BadRequest(new { success = false, Message = "Somthing went wrong..." });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("getAllNotes")]
        public IActionResult RetriveAllNotes()
        {
            try
            {
                IEnumerable<NoteModel> notes = manager.RetriveAllNotes();
                return this.Ok(new ResponseModel<IEnumerable<NoteModel>>() { Status = true, Masseage = "All Notes Retrived Successfully.", Data = notes });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("{noteId}")]
        public IActionResult GetNotesById(int noteId)
        {
            try
            {
                var note = manager.RetrieveNotes(noteId);
                if (note != null)
                {
                    return this.Ok(new ResponseModel<NoteModel>() { Status = true, Masseage = "Retrieve Notes Successfully", Data = note });
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

        [HttpDelete]
        [Route("{noteId}")]
        public IActionResult DeleteNotes(int noteId)
        {
            try
            {
                var result = manager.RemoveNotes(noteId);
                if (result)
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Masseage = "Note Trashed Successfully.", Data = noteId });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Somethin went wrong." });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("updateNotes")]
        public IActionResult UpdateNotes(NoteModel model)
        {
            try
            {
                var result = manager.UpdateNotes(model);
                if (result)
                {
                    return this.Ok(new ResponseModel<NoteModel>() { Status = true, Masseage = "Note Updated Successfully.", Data = model });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Somethin went wrong." });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("pin")]
        public IActionResult PinUnpin(int noteId)
        {
            try
            {
                var result = manager.PinOrUnpin(noteId);
                if (result=="PIN")
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Masseage = "Note Pined is Successfully.", Data = noteId });
                }
                if (result == "UNPIN")
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Masseage = "Note UnpinPined is Successfully.", Data = noteId });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Somethin went wrong." });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("archive")]
        public IActionResult Archive(int noteId)
        {
            try
            {
                var result = manager.IsArchive(noteId);
                if (result == "ARCHIVE")
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Masseage = "Note Added to archive Successfully.", Data = noteId });
                }
                if (result == "UNARCHIVE")
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Masseage = "Note Unarchived is Successfull.", Data = noteId });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Somethin went wrong." });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("archive")]
        public IActionResult RetriveArchiveNotes()
        {
            try
            {
                IEnumerable<NoteModel> notes = manager.RetriveArchiveNotes();
                return this.Ok(new ResponseModel<IEnumerable<NoteModel>>() { Status = true, Masseage = "All Notes Retrived Successfully.", Data = notes });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("trash")]
        public IActionResult RetriveTrashedNotes()
        {
            try
            {
                IEnumerable<NoteModel> notes = manager.RetriveTrashedNotes();
                return this.Ok(new ResponseModel<IEnumerable<NoteModel>>() { Status = true, Masseage = "All Notes Retrived Successfully.", Data = notes });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("restore")]
        public IActionResult RestoreTrash(int noteId)
        {
            try
            {
                var result = manager.RestoreTrashed(noteId);
               
                if (result == "RESTORE")
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Masseage = "Note Restored Successfully.", Data = noteId });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Somethin went wrong." });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("deletNoteForever")]
        public IActionResult DeleteNoteForever(int noteId)
        {
            try
            {
                bool result = manager.DeletNoteForever(noteId);
                if (result)
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Masseage = "Note Deleted Successfully.", Data = noteId });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Somethin went wrong." });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("emptyTrash")]
        public IActionResult EmptyTrash()
        {
            try
            {
                bool result = manager.EmptyTrash();
                if (result)
                {
                    return this.Ok(new ResponseModel<bool>() { Status = true, Masseage = "All Trashed Notes Deleted Successfully.", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Somethin went wrong." });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("color")]
        public IActionResult ChangeColor(int noteId,string color)
        {
            try
            {
                var result = manager.ChangeColor(noteId, color);

                if (result)
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Masseage = "Note Color Changed.", Data = noteId });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Somethin went wrong." });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("setReminder")]
        public IActionResult SetReminder(int noteId, string dateTime)
        {
            try
            {
                var result = manager.SetReminder(noteId, dateTime);

                if (result)
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Masseage = "Reminder Set Seccssfull.", Data = noteId });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Somethin went wrong." });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("reminder")]
        public IActionResult GetAllReminderNotes()
        {
            try
            {
                IEnumerable<NoteModel> notes = manager.GetAllReminderNotes();
                return this.Ok(new ResponseModel<IEnumerable<NoteModel>>() { Status = true, Masseage = "All Notes Retrived Successfully.", Data = notes });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("unsetReminder")]
        public IActionResult UnsetReminder(int noteId)
        {
            try
            {
                var result = manager.UnsetReminder(noteId);

                if (result)
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Masseage = "Reminder Unset Seccssfull.", Data = noteId });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Somethin went wrong." });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("image")]
        public IActionResult InsertImage(int noteId, IFormFile image)
        {
            try
            {
                var result = this.manager.UploadImage(noteId, image);
                if (result)
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Masseage = "Image Inserted Seccssfully.", Data = noteId });
                }
                return this.BadRequest(new { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
    }
}