using eDiaryAPI.Models.DbModels;
using eDiaryAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Mappers
{
    public class GradeTeacherMapper : IGradeTeacherMapper
    {
        public GradeDTO MapGradeChange(Grade grade)
        {
            var gradeDTO = new GradeDTO();

            gradeDTO.Mark = grade.Mark;

            return gradeDTO;
        }

        public GradeViewOnlyDTO MapGradePut(Grade grade)
        {
            var gradeDTO = new GradeViewOnlyDTO
            {
                StudentId = grade.FkStudent,
                Mark = grade.Mark,
                SubjectId = grade.FkSubject,
                

            };
            return gradeDTO;
        }
    }
}
