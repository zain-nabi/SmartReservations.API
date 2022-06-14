using Application.Interface.Roles;
using Application.Interface.User;
using Application.Interface.User.Custom;
using Application.Model.User;
using Application.Model.UserRoles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IExternalUser _externalUser;
        private readonly IExternalUserRole _externalUserRole;


        public UserController(IExternalUser externalUser, IExternalUserRole externalUserRole)
        {
            _externalUser = externalUser;
            _externalUserRole = externalUserRole;
        }

        #region ====================  User  ====================
        [HttpGet("{username}")]
        [SwaggerOperation(Summary = "FindByNameAsync - Gets the user by their username", Description = "Returns a single user")]
        public async Task<ActionResult<ExternalUser>> Get(string username)
        {
            return await _externalUser.FindByNameAsync(username);
        }

        [HttpGet("{userId:int}")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<ActionResult<ExternalUser>> Get(int userId)
        {
            return await _externalUser.FindByIdAsync(userId);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "GetAllUsersInclLockedOut - Gets all the users including locked out users", Description = "Returns a list of users")]
        public async Task<ActionResult<List<ExternalUser>>> Get()
        {
            return await _externalUser.GetAllUsersInclLockedOut();
        }


        [HttpPost, Route("CreateAsync")]
        [SwaggerOperation(Summary = "CreateAsync - Creates a new user and returns the user object", Description = "Returns a user object")]
        public async Task<ActionResult<ExternalUser>> CreateAsync(ExternalUser user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _externalUser.CreateAsync(user);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Post - Creates a new user and returns a UserID", Description = "Returns a UserID")]
        public async Task<ActionResult<long>> Post(ExternalUser user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _externalUser.Post(user);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Put - Updates an existing user", Description = "Returns a boolean")]
        public async Task<ActionResult<bool>> Put(ExternalUser user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _externalUser.PutUpdateAsync(user);
        }

        [HttpGet("CheckIfEmailExist/{email}")]
        [SwaggerOperation(Summary = "CheckIfEmailExist - Checks if email exists", Description = "Returns true/false")]
        public async Task<ActionResult<ExternalUser>> CheckIfEmailExist(string email)
        {
            return await _externalUser.CheckIfEmailExist(email);
        }

        [HttpGet("GetUserWithRoles")]
        [SwaggerOperation(Summary = "Users - Gets all users", Description = "Returns true/false")]
        public async Task<ActionResult<List<ExternalUserModel>>> GetUserWithRoles()
        {
            return await _externalUser.GetUserWithRoles();
        }

        [HttpGet("FindByExternalUserID/{externalUserID}")]
        [SwaggerOperation(Summary = "FindByExternalUserID - Finds external user by ID", Description = "Returns true/false")]
        public async Task<ActionResult<ExternalUserModel>> FindByExternalUserID(int externalUserID)
        {
            return await _externalUser.FindByExternalUserID(externalUserID);
        }

        #endregion

        #region ====================  UserRole  ====================
        [HttpGet("UserRoles/{userRoleId:int}")]
        [SwaggerOperation(Summary = "GetUserRole - Gets the UserRoles by UserRoleID", Description = "Returns a single UserRole")]
        public async Task<ActionResult<ExternalUserRole>> GetUserRole(int userRoleId)
        {
            return await _externalUserRole.GetUserRole(userRoleId);
        }

        [HttpPost("UserRoles")]
        [SwaggerOperation(Summary = "Post - Creates a new user role", Description = "Returns a long")]
        public async Task<ActionResult<long>> Post(ExternalUserRole userRole, string dbName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _externalUserRole.Post(userRole, dbName);
        }

        [HttpPut("UserRoles")]
        [SwaggerOperation(Summary = "Put - Updates the user role", Description = "Returns a boolean")]
        public async Task<ActionResult<bool>> Put(ExternalUserRole userRole, string dbName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _externalUserRole.Put(userRole, dbName);
        }

        [HttpGet("GetUserRoleByID/{externalUserID:int}")]
        [SwaggerOperation(Summary = "GetUserRoleByID - Gets the UserRoles by ExternalUserRoleID", Description = "Returns a single UserRole")]
        public async Task<ActionResult<ExternalUserRole>> GetUserRoleByID(int externalUserID)
        {
            return await _externalUserRole.GetUserRoleByID(externalUserID);
        }

        #endregion

        #region ====================  Roles  ====================
        [HttpGet, Route("Roles/{userId:int}/{dbName}")]
        [SwaggerOperation(Summary = "GetRolesByUserId - Gets all the roles for the users", Description = "Returns a list of Roles")]
        public async Task<ActionResult<List<Roles>>> Get(int userId, string dbName)
        {
            return await _externalUserRole.GetRolesByUserId(userId, dbName);
        }

        [HttpGet, Route("Roles/{roleIDs}/{dbName}")]
        [SwaggerOperation(Summary = "GetRolesByIds - Gets all the roles by ID's", Description = "Returns a list of Roles")]
        public async Task<ActionResult<List<Roles>>> Get(string roleIDs, string dbName)
        {
            return await _externalUserRole.GetRolesByIds(roleIDs, dbName);
        }

        [HttpGet, Route("GetActiveUserRoles")]
        [SwaggerOperation(Summary = "GetActiveUserRoles - Gets all the roles", Description = "Returns a list of Roles")]
        public async Task<ActionResult<List<Roles>>> GetActiveUserRoles()
        {
            return await _externalUserRole.GetActiveUserRoles();
        }
        #endregion
    }
}