using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using rsAPI.Data.Entities;
using rsAPI.Data.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace rsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthController(IConfiguration configuration, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager = null)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // Kullanıcı kaydı (Register)
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new ApplicationUser
            {
                UserName = registerModel.Username,
                Email = registerModel.Email,
                FullName = registerModel.FullName,
                ProfilePictureUrl = registerModel.ProfilePictureUrl,
                PhoneNumber = registerModel.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);

            if (result.Succeeded)
            {
                // Kayıt başarılı, token dönebiliriz ya da sadece başarılı yanıt dönebiliriz
                return Ok(new { Message = "Kullanıcı başarıyla oluşturuldu." });
            }

            // Hata mesajlarını döndür
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var result = await _signInManager.PasswordSignInAsync(
               loginModel.Username,
               loginModel.Password,
               isPersistent: false, 
               lockoutOnFailure: false); 

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(loginModel.Username);

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            return Unauthorized();
        }
        // Kullanıcı bilgilerini getiren endpoint
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var userId = User.FindAll(ClaimTypes.NameIdentifier).Last().Value; 
            if (userId == null)
                return Unauthorized();

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound();

            return Ok(new
            {
                user.Id,
                user.UserName,
                user.Email,
                user.FullName ,
                user.ProfilePictureUrl// veya diğer gerekli alanlar
            });
        }

        //Ilan sahibinin bilgilerini getiren endpoint
        [HttpGet("getUser")]
        public async Task<IActionResult> GetUser(string userId)
        {
           var user = await _userManager.FindByIdAsync(userId);
            return Ok(new
            {
                user.PhoneNumber,
                user.NormalizedEmail,
                user.FullName,
                user.ProfilePictureUrl
            });
        }
    }

}

