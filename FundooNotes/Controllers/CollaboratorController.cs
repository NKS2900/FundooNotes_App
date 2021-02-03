
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

        [HttpPost]
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


    }
}
