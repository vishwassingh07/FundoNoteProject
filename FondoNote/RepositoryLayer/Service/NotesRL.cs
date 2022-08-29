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
                var result = fundoContext.NotesTable.FirstOrDefault(x => x.UserId == UserId);
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
                if (res > 0)
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
        public bool NoteDelete(long UserId, long NotesId)
        {
            try
            {
                var result = fundoContext.NotesTable.Where(x => x.UserId == UserId && x.NotesId == NotesId).FirstOrDefault();
                if (result != null)
                {
                    fundoContext.NotesTable.Remove(result);
                    this.fundoContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
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
                var result = fundoContext.NotesTable.Where(x => x.UserId == UserId && x.NotesId == NotesId).FirstOrDefault();
                if (result != null)
                {
                    result.Title = notesUpdate.Title;
                    result.Description = notesUpdate.Description;
                    result.colour = notesUpdate.colour;
                    result.Reminder = notesUpdate.Reminder;
                    result.Image = notesUpdate.Image;
                    result.EditedTime = DateTime.Now;
                    fundoContext.SaveChanges();
                    return result;
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
        public IEnumerable<NotesEntity> NotesRetrieve(long UserId)
        {
            try
            {
                var result = fundoContext.NotesTable.Where(x => x.UserId == UserId);
                return result;
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
                var result = fundoContext.NotesTable.Where(x => x.UserId == UserId && x.NotesId == NotesId).FirstOrDefault();
                if (result.Pin == true)
                {
                    result.Pin = false;
                    fundoContext.SaveChanges();
                    return result;
                }
                else
                {
                    result.Pin = true;
                    fundoContext.SaveChanges();
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
