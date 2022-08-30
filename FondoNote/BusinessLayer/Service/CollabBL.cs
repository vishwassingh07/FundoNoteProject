using BusinessLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class CollabBL : ICollabBL
    {
        private readonly ICollabRL collabRL;
        public CollabBL(ICollabRL collabRL)
        {
            this.collabRL = collabRL;
        }
        public CollabEntity AddCollab(long noteId, string email)
        {
            try
            {
                return collabRL.AddCollab(noteId,email);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string DeleteCollab(long collabId, string email)
        {
            try
            {
                return collabRL.DeleteCollab(collabId, email);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
