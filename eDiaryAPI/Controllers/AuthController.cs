using eDiaryAPI.Models.DbModels;
using eDiaryAPI.Models.DTOs.Auth;
using eDiaryAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eDiaryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repository;
        private readonly IConfiguration  _config;
        public AuthController(IAuthRepository repository, IConfiguration config)
        {
            _repository = repository;
            _config = config;
        }

        [HttpPost("registerStudent")]
        public async Task<IActionResult> RegisterStudent(StudentRegisterDTO dto)
        {
            dto.Login = dto.Login.ToLower();

            if (await _repository.IsUserExist(dto.Login))
                return BadRequest("Użytkownik o takiej nazwie istnieje już w bazie");

            var userToCreate = new Student
            {
                Login = dto.Login,
                Surname = dto.Surname,
                Name = dto.Name,
                BirthDate = dto.BirthDate,
                Pesel = dto.Pesel,
                ParentEmail = dto.ParentEmail

            };

            var createdStudent = await _repository.RegisterStudent(userToCreate, dto.Password);

            return StatusCode(201);


        }
        [HttpPost("registerTeacher")]
        public async Task<IActionResult> RegisterTeacher(TeacherRegisterDTO dto)
        {
            dto.Login = dto.Login.ToLower();

            if (await _repository.IsUserExist(dto.Login))
                return BadRequest("Użytkownik o takiej nazwie istnieje już w bazie");

            var userToCreate = new Teacher
            {
                Login = dto.Login,
                Surname = dto.Surname,
                Name = dto.Name,
                Pesel = dto.Pesel,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
            };

            var createdStudent = await _repository.RegisterTeacher(userToCreate, dto.Password);

            return StatusCode(201);


        }
        [HttpPost("loginTeacher")]
        public async Task<IActionResult> Login (LoginDTO loginDTO)
        {
            var userFromRepo = await _repository.LoginTeacher(loginDTO.Username.ToLower(),
                loginDTO.Password);
            if (userFromRepo == null) return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(12),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { token = tokenHandler.WriteToken(token) });
        }
        [HttpPost("loginStudent")]
        public async Task<IActionResult> LoginStudent(LoginDTO loginDTO)
        {
            var userFromRepo = await _repository.LoginStudent(loginDTO.Username.ToLower(),
                loginDTO.Password);
            if (userFromRepo == null) return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(12),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { token = tokenHandler.WriteToken(token) });
        }
    }
}
