using eDiaryAPI.Models.DbModels;
using eDiaryAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Mappers
{
    public class GradeStudentMapper : IGradeStudentMapper
    {
        public IList<GradeDTO> showGrade(IList<Grade> grade)
        {
            var gradeDTO = new List<GradeDTO>();

            foreach(var item in grade)
            {
                var tmp = new GradeDTO { Mark = item.Mark };
                gradeDTO.Add(tmp);
            }

            return gradeDTO;
        }
    }
}
