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
    public class LabelRL : ILabelRL
    {
        private readonly FundoContext fundoContext;
        public LabelRL(FundoContext fundoContext)
        {
            this.fundoContext = fundoContext;
        }
        public LabelEntity LabelCreate(long userId, long noteId, string labelName)
        {
            try
            {
                LabelEntity label = new LabelEntity();
                label.UserId = userId;
                label.NotesId = noteId;
                label.LabelName = labelName;
                fundoContext.Add(label);
                int res = fundoContext.SaveChanges();
                if(res > 0)
                {
                    return label;
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
        public string LabelDelete(long labelId, long noteId)
        {
            try
            {
                var labelTable = fundoContext.LabelTable.Where(x => x.LabelID == labelId && x.NotesId == noteId).FirstOrDefault();
                if(labelTable != null)
                {
                    fundoContext.LabelTable.Remove(labelTable);
                    fundoContext.SaveChanges();
                    return "Successfully Deleted The Label";
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
        public LabelEntity LabelUpdate(long labelId, string newLabelName)
        {
            try
            {
                var labelNameCheck = fundoContext.LabelTable.Where(x => x.LabelID == labelId).FirstOrDefault();
                if(labelNameCheck != null)
                {
                    labelNameCheck.LabelName = newLabelName;
                    fundoContext.SaveChanges();
                    return labelNameCheck ;
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
        public IEnumerable<LabelEntity> LabelRetrieve(long noteId, long userId)
        {
            try
            {
                var result = fundoContext.LabelTable.Where(x => x.NotesId == noteId && x.UserId == userId).ToList();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
