using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Models.DTOs.Auth
{
    public class TeacherRegisterDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }
        public string? Email { get; set; }
        public string?  PhoneNumber { get; set; }
    }
}
