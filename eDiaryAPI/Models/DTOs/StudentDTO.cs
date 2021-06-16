using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Models.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? Date { get; set; }
        public string? EmailParent { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}
