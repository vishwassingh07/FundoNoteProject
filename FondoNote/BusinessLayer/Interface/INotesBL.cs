using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
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
        public NotesEntity NoteUpdate(NotesPostModel notesUpdate, long UserId, long NotesId);
        public IEnumerable<NotesEntity> NotesRetrieve(long UserId);
<<<<<<< HEAD
        public NotesEntity NotePin(long NotesId, long UserId);
        public bool NoteArchive(long UserId, long NotesId);
        public bool NoteTrash(long UserId, long NotesId);
        public string NoteUploadImage(IFormFile image, long UserId, long NotesId);
        public NotesEntity NoteColourChange(long NotesId, string Colour);

=======
        public bool NotePin(long NotesId, long UserId);
        public NotesEntity NoteArchive(long UserId, long NotesId);
>>>>>>> NoteArchive


    }
}
