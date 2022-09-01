using BusinessLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class LabelBL : ILabelBL
    {
        private readonly ILabelRL labelRL;
        public LabelBL(ILabelRL labelRL)
        {
            this.labelRL = labelRL;
        }
        public LabelEntity LabelCreate(long userId, long noteId, string labelName)
        {
            try
            {
                return labelRL.LabelCreate(userId, noteId, labelName);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string LabelDelete(long labelId, long noteId)
        {
            try
            {
                return labelRL.LabelDelete(labelId, noteId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public LabelEntity LabelUpdate(long labelId, string newLabelName)
        {
            try
            {
                return labelRL.LabelUpdate(labelId, newLabelName);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<LabelEntity> LabelRetrieve(long noteId, long userId)
        {
            try
            {
                return labelRL.LabelRetrieve(noteId,userId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
