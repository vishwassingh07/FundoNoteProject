using BusinessLayer.Interface;
using CommonLayer.Model;
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
    }
}
