using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Models.DbModels
{
    public class SchoolClass
    {
        public SchoolClass()
        {
            this.Teachers = new HashSet<Teacher>();
        }
        public int Id{ get; set; }
       
        [Required]
        public string ClassName { get; set; }

        public string SchoolYear { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
        
       


    }
}
