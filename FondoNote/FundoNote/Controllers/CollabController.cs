using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoNote.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CollabController : ControllerBase
    {
        private readonly ICollabBL collabBL;
        private readonly IMemoryCache memoryCache;
        private readonly FundoContext fundocontext;
        private readonly IDistributedCache distributedCache;

        public CollabController(ICollabBL collabBL, IMemoryCache memoryCache, FundoContext fundocontext, IDistributedCache distributedCache)
        {
            this.collabBL = collabBL;
            this.memoryCache = memoryCache;
            this.fundocontext = fundocontext;
            this.distributedCache = distributedCache;
        }
        [Authorize]
        [HttpPost]
        [Route("Add")]
        public ActionResult CollabAdd(long noteId, string email)
        {
            try
            {
                //long UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserID").Value);
                var result = collabBL.AddCollab(noteId, email);
                if(result != null)
                {
                    return Ok(new { success = true, message = "Collaborator Successfully Added", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Collaborator Could Not Be Added" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public ActionResult CollabDelete(long collabId, string email)
        {
            try
            {
                long UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserID").Value);
                var result = collabBL.DeleteCollab(collabId, email);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Collaborator Successfully Deleted", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Collaborator Could Not Be Deleted" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpGet]
        [Route("Retrieve")]
        public ActionResult RetrieveCollab(long noteId)
        {
            try
            {
                long UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserID").Value);
                var result = collabBL.RetrieveCollab(noteId, UserID);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Notes Successfully Retrieved", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Notes Could Not Be Retrieved" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpGet("redis")]
        public async Task<IActionResult> GetAllCollabUsingRedisCache()
        {
            var cacheKey = "CollabList";
            string serializedCollabList;
            var collabList = new List<CollabEntity>();
            var redisCollabList = await distributedCache.GetAsync(cacheKey);
            if (redisCollabList != null)
            {
                serializedCollabList = Encoding.UTF8.GetString(redisCollabList);
                collabList = JsonConvert.DeserializeObject<List<CollabEntity>>(serializedCollabList);
            }
            else
            {
                collabList = await fundocontext.CollabTable.ToListAsync();
                serializedCollabList = JsonConvert.SerializeObject(collabList);
                redisCollabList = Encoding.UTF8.GetBytes(serializedCollabList);
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                await distributedCache.SetAsync(cacheKey, redisCollabList, options);
            }
            return Ok(collabList);
        }
    }
}
