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
    public class CollabRL : ICollabRL
    {
        private readonly FundoContext fundoContext;
        private readonly IConfiguration configuration;
        public CollabRL(FundoContext fundoContext, IConfiguration configuration)
        {
            this.fundoContext = fundoContext;
            this.configuration = configuration;
        }
        public CollabEntity AddCollab(long noteId, string email)
        {
            try
            {
                var notesModel = fundoContext.NotesTable.Where(x => x.NotesId == noteId).FirstOrDefault();
                var userModel = fundoContext.UserTable.Where(x => x.Email == email).FirstOrDefault();
                if(notesModel != null && userModel != null)
                {
                    CollabEntity collab = new CollabEntity();
                    collab.UserId = userModel.UserId;
                    collab.NotesId = noteId;
                    collab.CollabEmail = email;
                    fundoContext.Add(collab);
                    fundoContext.SaveChanges();
                    return collab;
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
