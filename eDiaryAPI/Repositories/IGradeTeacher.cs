using eDiaryAPI.Models.DbModels;
using eDiaryAPI.Models.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Repositories
{
    public interface IGradeTeacher
    {
        public Task<IList<Grade>> ShowGrade(GradeDTO gradeDTO);
        public Task<Grade> ChangeGrande(GradeDTO gradeDTO);
        public Task<Grade> PutGrade(GradeViewOnlyDTO gradeDTO);
    }
}
