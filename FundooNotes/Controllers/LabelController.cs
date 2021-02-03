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
                    return this.Ok(new ResponseModel<LabelModel>() { Status = true, Masseage = "Label Created Successfully", Data = model });
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
                return this.Ok(new ResponseModel<IEnumerable<LabelModel>>() { Status = true, Masseage = "All Notes Retrived is Successfully.", Data = labels });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("getById")]
        public IActionResult GetLabelById(int id)
        {
            try
            {
                LabelModel labels = manager.RetrieveLabelById(id);
                return this.Ok(new ResponseModel<LabelModel>() { Status = true, Masseage = "Label Retrived Successfully.", Data = labels });
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

        [HttpDelete]
        public IActionResult DeletLabel(int id)
        {
            try
            {
                bool result = manager.DeleteLable(id);
                if (result)
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Masseage = "Label Deleted Successfully", Data = id });
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
