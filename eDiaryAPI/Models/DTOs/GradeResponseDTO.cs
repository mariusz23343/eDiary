using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Models.DTOs
{
    public class GradeResponseDTO
    {
        public int GradeId { get; set; }
        public int SubjectId { get; set; }
        public double Grade { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StudentSurname { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }

    }
}
