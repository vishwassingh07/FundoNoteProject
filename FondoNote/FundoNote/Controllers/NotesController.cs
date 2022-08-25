using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;


namespace FundoNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController:ControllerBase
    {
        private readonly INotesBL notesBL;
        public NotesController(INotesBL notesBL)
        {
            this.notesBL = notesBL;
        }
        [Authorize]
        [HttpPost]
        [Route("Create")]
        public ActionResult CreateNotes(NotesPostModel notesPostModel)
        {
            try
            {
                long UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserID").Value);
                var result = notesBL.NotesPost(notesPostModel, UserID);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Notes Created Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Notes Could Not Be Created" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public ActionResult DeleteNote(long NoteId)
        {
            try
            {
                long UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserID").Value);
                var result = notesBL.NoteDelete(UserID, NoteId);
                if(result != null)
                {
                    return Ok(new { success = true, message = "Notes Successfully Deleted", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Notes Could Not Be Deleted" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut]
        [Route("Update")]
        public ActionResult UpdateNote(NotesPostModel notesPostModel, long NotesId)
        {
            try
            {
                long UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserID").Value);
                var result = notesBL.NoteUpdate(notesPostModel,UserID, NotesId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Notes Successfully Updated", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Notes Could Not Be Updated" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("Retrieve")]
        public ActionResult RetrieveNote(long UserId)
        {
            try
            {
                long UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserID").Value);
                var result = notesBL.NotesRetrieve(UserID);
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
