using BusinessLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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
        [HttpDelete]
        [Route("Delete")]
        public ActionResult DeleteLabel(long labelId, long noteId)
        {
            try
            {
                long UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserID").Value);
                var result = labelBL.LabelDelete(UserID, noteId);
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
    }
}
