using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;


namespace FundoNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
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
                if (result != null)
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
                var result = notesBL.NoteUpdate(notesPostModel, UserID, NotesId);
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
        [HttpPut]
        [Route("Pin")]
        public ActionResult PinNote(long NotesId)
        {
            try
            {
                long UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserID").Value);
                var result = notesBL.NotePin(NotesId, UserID);
                if (result != null)
                {
<<<<<<< HEAD
                    return Ok(new {success = true, message = "Successfully Pinned The Note" , data = result});
                }
                else if(result == null)
                {
                    return Ok(new { success = false, message = "Could Not Pinned The Note" });
                }
                return BadRequest(new { success = false, message = "Operation Failed" });

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut]
        [Route("Archive")]
        public ActionResult ArchiveNote(long noteId)
        {
            try
            {
                long userID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserID").Value);
                var result = notesBL.NoteArchive(noteId, userID);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Successfully Archived The Note", data = result });
                }
                else if (result == null)
                {
                    return Ok(new { success = true, message = "Could Not Archived The Note", data = result });
=======
                    return Ok(new { success = true, message = "Successfully Pinned The Note" , data = result});
>>>>>>> NotePin
                }
                else
                {
                    return BadRequest(new { success = false, message = "Operation Failed" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [HttpPut]
        [Route("Trash")]
        public ActionResult TrashNote(long NotesId)
        {
            try
            {
                long UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserID").Value);
                var result = notesBL.NoteTrash(UserID, NotesId);
                if (result != false)
                {
                    return Ok(new { success = true, message = "Successfully Trashed The Note" });
                }
                else if (result != true)
                {
                    return Ok(new { success = true, message = "Could Not Trashed The Note" });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Operation Failed" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut]
        [Route("Image")]
        public ActionResult ImageUpload(IFormFile image, long NoteId)
        {
            try
            {
                long UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserID").Value);
                var result = notesBL.NoteUploadImage(image, UserID, NoteId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Successfully Uploaded The Image", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Could Not Upload The Image" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut]
        [Route("ColourChange")]
        public ActionResult ColourChange(long NotesId, string Colour)
        {
            try
            {
                long UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserID").Value);
                var result = notesBL.NoteColourChange(UserID, Colour);
                if(result != null)
                {
                    return Ok(new { success = true, message = "Successfully Changed The Colour", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Could Not Changed The Colour" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
