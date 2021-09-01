using eDiaryAPI.Models.DbModels;
using eDiaryAPI.Models.DTOs;
using eDiaryAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Mappers
{
    public class GradeStudentMapper : IGradeStudentMapper
    {
        public IList<GradeDTO> showGrade(StudentGradesViewModel model)
        {
            var gradeDTO = new List<GradeDTO>();

            foreach(var item in model.grades)
            {
                var tmp = new GradeDTO();
                tmp.Mark = item.Mark;
                tmp.Id = item.Id;
                tmp.StudentId = item.FkStudent;
                tmp.SubjectId = item.FkSubject;

                gradeDTO.Add(tmp);
            }
            int i = 0;
            foreach (var item in gradeDTO)
            {

                item.SubjectName = model.subjects[i].SubjectName;
                i++;
            }

            return gradeDTO;
        }
        public Grade AddGrade(GradeDTO dto, int id)
        {
            var grade = new Grade
            {
                FkStudent = dto.StudentId,
                FkSubject = dto.SubjectId,
                Mark = dto.Mark

            };
            return grade;
        }
    }
}
