using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Models.DbModels
{
    public class Student
    {
        public int Id { get; set; }
<<<<<<< HEAD
        public virtual SchoolClass? ClassId { get; set; }
=======
        public virtual SchoolClass ClassId { get; set; }
        public int FkClass { get; set; }
>>>>>>> 2cb7d86690012ae952d54a9f7e3837ebe8c5ffc8

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
