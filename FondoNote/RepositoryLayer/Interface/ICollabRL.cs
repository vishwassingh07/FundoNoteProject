﻿using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ICollabRL
    {
        public CollabEntity AddCollab(long noteId, string email);
        public string DeleteCollab(long collabId, string email);
        public IEnumerable<CollabEntity> RetrieveCollab(long noteId);
    }
}
