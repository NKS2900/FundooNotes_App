// -----------------------------------------------------------------------------------------------------
// <copyright file="LabelConroller.cs" company="Bridgelabz">
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
    public class LabelController : Controller
    {
        private readonly ILabelManager manager;
        public LabelController(ILabelManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        public IActionResult AddLabels([FromBody] LabelModel model)
        {
            try
            {
                bool result = manager.AddLabel(model);
                if (result)
                {
                    return this.Ok(new ResponseModel<LabelModel>() { Status = true, Masseage = "Retrieve Notes Successfully", Data = model });
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
        public IActionResult RetriveAllLabels()
        {
            try
            {
                IEnumerable<LabelModel> labels = manager.RetriveLabeles();
                return this.Ok(labels);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, Message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdateLabel(LabelModel label)
        {
            try
            {
                var result = manager.UpdateLable(label);
                if (result)
                {
                    return this.Ok(new ResponseModel<LabelModel>() { Status = true, Masseage = "Label updated Successfully", Data = label });
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
