using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class NotesBL : INotesBL
    {
        private readonly INotesRL notesRL;
        public NotesBL(INotesRL notesRL)
        {
            this.notesRL = notesRL;
        }

        public NotesEntity NotesPost(NotesPostModel notesPost, long UserId)
        {
            try
            {
                return notesRL.NotePost(notesPost, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool NoteDelete(long UserId, long NotesId)
        {
            try
            {
                return notesRL.NoteDelete(UserId, NotesId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public NotesEntity NoteUpdate(NotesPostModel notesUpdate, long UserId, long NotesId)
        {
            try
            {
                return notesRL.NoteUpdate(notesUpdate, UserId, NotesId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<NotesEntity> NotesRetrieve(long UserId)
        {
            try
            {
                return notesRL.NotesRetrieve(UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public NotesEntity NotePin(long NotesId, long UserId)
        {
            try
            {
                return notesRL.NotePin(NotesId, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public NotesEntity NoteArchive(long UserId, long NotesId)
        {
            try
            {
                return notesRL.NoteArchive(UserId, NotesId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool NoteTrash(long UserId, long NotesId)
        {
            try
            {
                return notesRL.NoteTrash(UserId, NotesId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string NoteUploadImage(IFormFile image, long UserId, long NotesId)
        {
            try
            {
                return notesRL.NoteUploadImage(image, UserId, NotesId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public NotesEntity NoteColourChange(long NotesId, string Colour)
        {
            try
            {
                return notesRL.NoteColourChange(NotesId, Colour);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
