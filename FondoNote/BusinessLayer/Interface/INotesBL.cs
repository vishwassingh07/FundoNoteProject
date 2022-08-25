using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface INotesBL
    {
        public NotesEntity NotesPost(NotesPostModel notesPost, long UserId);
        public bool NoteDelete(long UserId, long NotesId);
    }
}
