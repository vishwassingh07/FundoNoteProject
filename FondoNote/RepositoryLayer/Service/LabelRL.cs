using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Service
{
    public class LabelRL : ILabelRL
    {
        private readonly FundoContext fundoContext;
        private readonly IConfiguration configuration;
        public LabelRL(FundoContext fundoContext, IConfiguration configuration)
        {
            this.fundoContext = fundoContext;
            this.configuration = configuration;
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
    }
}
