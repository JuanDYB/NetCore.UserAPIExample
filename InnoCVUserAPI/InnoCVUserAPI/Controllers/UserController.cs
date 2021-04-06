using InnoCV.DatabaseModel.Database;
using InnoCV.Infrastructure.User;
using InnoCV.Model.ExceptionModel;
using InnoCV.Model.ViewModel;
using InnoCVUserAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InnoCVUserAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserController : Controller
    {
        private readonly UserManager UManager;

        public UserController(InnoCVEntities Db)
        {
            this.UManager = new UserManager(Db);
        }

        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult NewUser([FromBody]User User)
        {
            //No need to check validation because it is enabled automatically
            UManager.AddUser(User);
            return Ok();
        }

        /// <summary>
        /// Modify User
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Modify([FromBody] User User)
        {
            //No need to check validation because it is enabled automatically
            UManager.ModifyUser(User);
            return Ok();
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            return Ok(await UManager.GetUsersAsyc());
        }

        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public IActionResult GetUser([FromRoute]int Id)
        {
            return Ok(UManager.GetUser(Id));
        }

        /// <summary>
        /// Delete User by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public IActionResult DeleteUser([FromRoute] int Id)
        {
            UManager.DeleteUser(Id);
            return Ok();
        }
    }
}
