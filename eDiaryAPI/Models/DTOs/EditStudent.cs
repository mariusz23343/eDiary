using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Models.DTOs
{
    public class EditStudent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public DateTime BirthDate { get; set; }
        public string ParentEmail{ get; set; }
        public string Pesel { get; set; }

    }
}
