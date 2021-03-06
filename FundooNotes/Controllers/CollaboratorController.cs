﻿
namespace FundooNotes.Controllers
{
    using FundooManager;
    using FundooModel.Models;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;

    [ApiController]
    [Route("api/[controller]")]
    public class CollaboratorController : Controller
    {
        private readonly ICallboratorManager manager;
        public CollaboratorController(ICallboratorManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Controller for Add New Collaborator.
        /// </summary>
        /// <param name="model">Collaborator Model</param>
        /// <returns></returns>
        [HttpPost]
        [Route("addColl")]
        public IActionResult AddCoallaborator([FromBody] CollaboratorModel model)
        {
            try
            {
                bool result = manager.AddCollaborator(model);
                if (result)
                {
                    return this.Ok(new ResponseModel<CollaboratorModel>() { Status = true, Masseage = "Collaborator added Successfully", Data = model });
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

        /// <summary>
        /// Controller For Retriving Collaborator.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getColl")]
        public IActionResult RetriveCollaborator()
        {
            try
            {
                IEnumerable<CollaboratorModel> collaborator = manager.RetriveCollaborator();
                return this.Ok(new ResponseModel<IEnumerable<CollaboratorModel>>() { Status = true, Masseage = "All Notes Retrived is Successfully.", Data = collaborator });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Controller for Delete Collaborator.
        /// </summary>
        /// <param name="collId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{collId}")]
        public IActionResult DeletCollaborator(int collId)
        {
            try
            {
                bool result = manager.DeleteCollaborator(collId);
                if (result)
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Masseage = "Collaborator Deleted Successfully", Data = collId });
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
    }
}
