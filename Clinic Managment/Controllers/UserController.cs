using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business_Layer;
namespace Clinic_Managment.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("GetAllUsers", Name = "get users")]
        public ActionResult<IEnumerable<List<UserBL_DTO>>> GetAllUsers()
        {

            return Ok(clsUser.GetAllUsers());

        }

        [HttpPost("AddUser", Name ="AddNewUser")]
        public ActionResult<int> AddNewUser([FromBody]UserBL_DTO DTO)
        {
            if (DTO == null)
            {

                return BadRequest();            
            }

            clsUser _NewUser = new clsUser(DTO);
            if (_NewUser.Save())
            {
                return Ok(_NewUser.UserID);

            }
            else
            {
                return BadRequest();
            }
        }


    }
}
