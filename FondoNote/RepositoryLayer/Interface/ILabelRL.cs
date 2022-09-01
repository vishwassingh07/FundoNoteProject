using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ILabelRL
    {
        public LabelEntity LabelCreate(long userId, long noteId, string labelName);
        public string LabelDelete(long labelId, long noteId);
        public LabelEntity LabelUpdate(long labelId, string newLabelName);
        public IEnumerable<LabelEntity> LabelRetrieve(long noteId, long userId);
    }
}
