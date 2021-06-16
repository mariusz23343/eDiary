using eDiaryAPI.Models.DbModels;
using eDiaryAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Repositories
{
    public class GradeStudent : IGradeStudent
    {
        private readonly ApplicationDbContext _context;

        public GradeStudent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Grade>> ShowGrade(GradeDTO gradeDTO)
        {
            var gradeList = await _context.Grades.Where(x=>x.FkStudent == gradeDTO.StudentId).ToListAsync();

            return gradeList;
        }
    }
}
