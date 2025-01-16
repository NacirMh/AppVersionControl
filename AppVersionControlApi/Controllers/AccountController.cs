using AppVersionControlApi.Dtos.Account;
using AppVersionControlApi.Entities;
using AppVersionControlApi.Interfaces;
using KRM_Events_API.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AppVersionControlApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        public readonly RoleManager<IdentityRole> _roleManager;
        public readonly SignInManager<AppUser> _signInManager;
        public readonly ITokenService _tokenService;
        public AccountController(UserManager<AppUser> um, RoleManager<IdentityRole> rm, SignInManager<AppUser> sm, ITokenService tokenService)
        {
            _userManager = um;
            _roleManager = rm;
            _signInManager = sm;
            _tokenService = tokenService;
        }

        [HttpPost("CreateUser")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateUser([FromBody] RegisterDTO registerDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                AppUser? appUser = null;

                if (registerDTO.Role.ToLower().Equals("admin"))
                {
                    appUser = registerDTO.ToAdminFromRegisterDTO();
                }

                if (registerDTO.Role.ToLower().Equals("user"))
                {
                    appUser = registerDTO.ToUserFromRegisterDTO();
                }
                
                if (appUser != null)
                {
                    var result = await _userManager.CreateAsync(appUser, registerDTO.Password);
                    if (!result.Succeeded)
                    {
                        return BadRequest(result.Errors);
                    }
                }


                IdentityResult? roleResult = null;

                if (appUser is Admin)
                {
                    roleResult = await _userManager.AddToRoleAsync(appUser, "ADMIN");
                }
                if (appUser is User)
                {
                    roleResult = await _userManager.AddToRoleAsync(appUser, "USER");
                }
                

                if (roleResult.Succeeded)
                {
                    return Ok(appUser.ToUserDetailsFromUser());

                }
                else
                {
                    return BadRequest(roleResult.Errors);
                }


            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userManager.FindByNameAsync(loginDTO.UserName);
            if (user == null)
            {
                return Unauthorized(new AuthResponseDTO
                {
                    isSuccess = false,
                    Message = $"User {loginDTO.UserName} not found"
                });
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized(new AuthResponseDTO
                {
                    isSuccess = false,
                    Message = "Invalid Password"
                });
            }
            return Ok(new AuthResponseDTO
            {
                isSuccess = true,
                Message = "User Logged in",
                Token = _tokenService.CreateToken(user).Result
            });
        }

        [HttpGet("Details")]
        [Authorize]
        public async Task<IActionResult> GetUserDetails()
        {

            var user = await _userManager.GetUserAsync(User);

            if (user is null)
            {
                return NotFound(new AuthResponseDTO
                {
                    isSuccess = false,
                    Message = "user not found"
                });
            }
            var userDetails = user.ToUserDetailsFromUser();
            return Ok(userDetails);
        }

        [HttpGet("Details/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetUserDetails(string id)
        {

            var user = await _userManager.FindByIdAsync(id);

            if (user is null)
            {
                return NotFound(new AuthResponseDTO
                {
                    isSuccess = false,
                    Message = "user not found"
                });
            }
            var userDetails = user.ToUserDetailsFromUser();
            return Ok(userDetails);
        }

        [HttpPut("UpdateProfile")]
        [Authorize]
        public async Task<IActionResult> UpdateDetails(UpdateProfileDTO updateDto)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user is null)
            {
                return NotFound(new AuthResponseDTO
                {
                    isSuccess = false,
                    Message = "user not found"
                });
            }
            user.City = updateDto.City;
            user.UserName = updateDto.UserName;
            user.FirstName = updateDto.FirstName;
            user.LastName = updateDto.LastName;
            user.PhoneNumber = updateDto.PhoneNumber;
            user.Email = updateDto.EmailAddress;
            await _userManager.UpdateAsync(user);
            var userDetails = user.ToUserDetailsFromUser();
            return Ok(userDetails);
        }

        [HttpGet("AllUsers")]
        [Authorize]
        public async Task<IActionResult> GetAllUsers([FromQuery] string? Role)
        {
            var users = _userManager.Users.ToList();

            if (Role != null)
            {
                users = _userManager.GetUsersInRoleAsync(Role).Result.ToList();
            }

            return Ok(users.Select(x => x.ToUserDetailsFromUser()).ToList());

        }

    }
}
