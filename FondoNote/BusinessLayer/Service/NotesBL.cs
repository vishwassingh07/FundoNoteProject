﻿using BusinessLayer.Interface;
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
    }
}
