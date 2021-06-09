using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Models.DbModels
{
    public class Teacher
    {
        public Teacher()
        {
            this.TeacherClasses = new HashSet<SchoolClass>();
        }
        public int Id { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Pesel{ get; set; }

        public virtual ICollection<SchoolClass> TeacherClasses { get; set; }

    }
}
