using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Models.DTOs
{
    public class GradeDTO
    {
        public int? Id { get; set; }
        public double Mark { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
    }
}
