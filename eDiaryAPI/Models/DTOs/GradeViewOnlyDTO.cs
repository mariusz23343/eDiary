using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Models.DTOs
{
    public class GradeViewOnlyDTO
    {
        public double Mark { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
    }
}
