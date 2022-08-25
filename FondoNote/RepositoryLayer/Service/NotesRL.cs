using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Service
{
    public class NotesRL : INotesRL
    {
        private readonly FundoContext fundoContext;
        private readonly IConfiguration _Appsettings;
        public object UserId { get; private set; }
        public NotesRL(FundoContext fundoContext, IConfiguration _Appsettings)
        {
            this.fundoContext = fundoContext;
            this._Appsettings = _Appsettings;
        }
        public NotesEntity NotePost(NotesPostModel notesPost, long UserId)
        {
            try
            {
                NotesEntity notes = new NotesEntity();
                var result = fundoContext.NotesTable.FirstOrDefault(x=> x.UserId == UserId);
                notes.UserId = UserId;
                notes.Title = notesPost.Title;
                notes.Description = notesPost.Description;
                notes.colour = notesPost.colour;
                notes.Image = notesPost.Image;
                notes.Archive = notesPost.Archive;
                notes.Pin = notesPost.Pin;
                notes.Trash = notesPost.Trash;
                notes.Reminder = notesPost.Reminder;
                notes.CreateTime = notesPost.CreateTime;
                notes.EditedTime = notesPost.EditedTime;

                fundoContext.NotesTable.Add(notes);
                int res = fundoContext.SaveChanges();
                if(res > 0)
                {
                    return notes;
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
