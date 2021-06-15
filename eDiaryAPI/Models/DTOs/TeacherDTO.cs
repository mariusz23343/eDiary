using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Models.DTOs
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? TelephoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }

    }
}
