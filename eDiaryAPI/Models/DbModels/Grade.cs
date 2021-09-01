using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Models.DbModels
{
    public class Grade
    {
        public int? Id { get; set; }
        public virtual Student Student { get; set; }
        public int FkStudent { get; set; }
        public virtual Subject MyProperty { get; set; }
        public int FkSubject { get; set; }
        public double Mark { get; set; }

    }
}
