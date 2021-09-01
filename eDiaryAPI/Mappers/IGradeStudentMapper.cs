using eDiaryAPI.Models.DbModels;
using eDiaryAPI.Models.DTOs;
using eDiaryAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Mappers
{
    public interface IGradeStudentMapper
    {
        public Grade AddGrade(GradeDTO dto, int id);
        public IList<GradeDTO> showGrade(StudentGradesViewModel model);
    }
}
