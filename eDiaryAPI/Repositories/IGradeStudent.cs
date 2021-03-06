using eDiaryAPI.Models.DbModels;
using eDiaryAPI.Models.DTOs;
using eDiaryAPI.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Repositories
{
    public interface IGradeStudent
    {
        public Task<StudentGradesViewModel> ShowGrade(int id);
        public Task<Grade> AddGrade(Grade grade);
        public Task<IList<Subject>> GetSubject();
        public Task<Grade> DeleteGrade(int id);
    }
}
