using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Models.DbModels
{
    public class Email
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailParent { get; set; }
        public string Password { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
        public string TeacherEmail { get; set; }
    }
}
