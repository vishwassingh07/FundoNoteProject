using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FundoNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL;
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }
        [HttpPost]
        [Route("Register")]
        public ActionResult Registration(UserRegistrationModel userRegistration)
        {
            try
            {
                var result = userBL.Register(userRegistration);
                if(result !=null)
                {
                    return Ok(new {success=true,message="Registration Successfull",data=result});
                }
                else
                {
                    return BadRequest(new { success = false, message = "Registration Not Successfull"});
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("Login")]
        public ActionResult Login(UserLoginModel userLogin)
        {
            try
            {
                var result = userBL.Login(userLogin);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Login is Successfull", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Login is Not Successfull" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("ForgotPassword")]
        public ActionResult ForgotPassword(string Email)
        {
            try
            {
                var result = userBL.ForgotPassword(Email);
                if(result != null)
                {
                    return Ok(new { success = true, message = "Reset Link Sent Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Resent Link Could Not Be Generated" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
