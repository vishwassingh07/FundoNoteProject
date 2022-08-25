using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface INotesRL
    {
        public NotesEntity NotePost(NotesPostModel notesPost, long UserId);
        public bool NoteDelete(long UserId,long NotesId);
        public NotesEntity NoteUpdate(NotesPostModel notesUpdate, long UserId, long NotesId);
        public IEnumerable<NotesEntity> NotesRetrieve(long UserId);
    }
}
