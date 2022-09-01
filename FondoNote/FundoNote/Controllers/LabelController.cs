using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using RepositoryLayer.Context;

namespace FundoNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        private readonly ILabelBL labelBL;
        public LabelController(ILabelBL labelBL)
        {
            this.labelBL = labelBL;
        }
        [Authorize]
        [HttpPost]
        [Route("Create")]
        public ActionResult CreateLabel(long noteId, string labelName)
        {
            try
            {
                long UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserID").Value);
                var result = labelBL.LabelCreate(UserID, noteId, labelName);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Label Successfully Created", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Label Could Not Be Created" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpDelete]
        [Route("Delete")]
        public ActionResult DeleteLabel(long labelId, long noteId)
        {
            try
            {
                long UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserID").Value);
                var result = labelBL.LabelDelete(UserID, labelId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Label Successfully Deleted", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Label Could Not Be Deleted" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpPut]
        [Route("Update")]
        public ActionResult UpdateLabel(long labelId, string newLabelName)
        {
            try
            {
                long UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserID").Value);
                var result = labelBL.LabelUpdate(labelId, newLabelName);
                if(result != null)
                {
                     return Ok(new { success = true, message = "Label Successfully Updated", data = result });
                }
                else
                {
                     return BadRequest(new { success = false, message = "Label Could Not Be Updated" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpPut]
        [Route("Retrieve")]
        public ActionResult RetrieveLabel(long noteId)
        {
            try
            {
                long UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserID").Value);
                var result = labelBL.LabelRetrieve(noteId,UserID);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Label Successfully Retrieved", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Label Could Not Be Retrieved" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
