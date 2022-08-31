using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FundoNote.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CollabController : ControllerBase
    {
        private readonly ICollabBL collabBL;
        public CollabController(ICollabBL collabBL)
        {
            this.collabBL = collabBL;
        }
        [HttpPost]
        [Route("Add")]
        public ActionResult CollabAdd(long noteId, string email)
        {
            try
            {
                //long UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserID").Value);
                var result = collabBL.AddCollab(noteId, email);
                if(result != null)
                {
                    return Ok(new { success = true, message = "Collaborator Successfully Added", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Collaborator Could Not Be Added" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public ActionResult CollabDelete(long collabId, string email)
        {
            try
            {
                long UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserID").Value);
                var result = collabBL.DeleteCollab(collabId, email);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Collaborator Successfully Deleted", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Collaborator Could Not Be Deleted" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("Retrieve")]
        public ActionResult RetrieveCollab(long noteId)
        {
            try
            {
                long UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserID").Value);
                var result = collabBL.RetrieveCollab(UserID);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Notes Successfully Retrieved", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Notes Could Not Be Retrieved" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
