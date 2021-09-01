using eDiaryAPI.Models.DbModels;
using eDiaryAPI.Models.DTOs;
using eDiaryAPI.ViewModels;
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

        public async Task<StudentGradesViewModel> ShowGrade(int id)
        {
            StudentGradesViewModel sg = new StudentGradesViewModel();
            sg.subjects = new List<Subject>();
            sg.grades = await _context.Grades.Where(x=>x.FkStudent == id).ToListAsync();
            for(int i = 0; i < sg.grades.Count; i++)
            {
                sg.subjects.Add(await _context.Subjects.FirstOrDefaultAsync(x => x.Id == sg.grades[i].FkSubject));
               
            }

            return sg;
        }
        public async Task <Grade> AddGrade(Grade grade)
        {
            
            await _context.AddAsync(grade);
            _context.SaveChanges();

           
            return null;

        }
    }
}
