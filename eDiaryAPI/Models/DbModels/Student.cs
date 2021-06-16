using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Models.DbModels
{
    public class Student
    {
        public int Id { get; set; }
        public virtual SchoolClass ClassId { get; set; }
        public int FkClass { get; set; }

        public string Login { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Pesel { get; set; }
        public string ParentEmail { get; set; }


    }
}
