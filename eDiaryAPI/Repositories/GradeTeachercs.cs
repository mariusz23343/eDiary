using eDiaryAPI.Models.DbModels;
using eDiaryAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Repositories
{
    public class GradeTeachercs : IGradeTeacher
    {

        private readonly ApplicationDbContext _context;

        public GradeTeachercs(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Grade> ChangeGrande(GradeDTO gradeDTO)
        {
            var grade = await _context.Grades.FirstOrDefaultAsync(x => x.Id == gradeDTO.Id);

            if(grade==null)
            {
                return null;
            }
            
            grade.Mark = gradeDTO.Mark;
            
            _context.Grades.Update(grade);
            await _context.SaveChangesAsync();

            return grade;
        }

        public async Task<Grade> PutGrade(GradeViewOnlyDTO gradeDTO)
        {
            Grade grade = new Grade
            {
                FkStudent = gradeDTO.StudentId,
                Mark = gradeDTO.Mark,
                FkSubject = gradeDTO.SubjectId,
                MyProperty = _context.Subjects.FirstOrDefault(x => x.Id==gradeDTO.SubjectId),
                Student = _context.Students.FirstOrDefault(x=>x.Id==gradeDTO.StudentId),
            };

            await _context.AddAsync(grade);
            await _context.SaveChangesAsync();
            return grade;
        }

        public Task<IList<Grade>> ShowGrade(GradeDTO gradeDTO)
        {
            //   var grades = _context.Grades.Where(x => x.FkSubject == gradeDTO.SubjectId);
            //  var students = _context.Students.Where(x=>)
            //  var response = _context.Grades.Join(_context.Students, grade => grade.Id, student => student.Id,(grade,student)
            //      =>new {GradeId=grade.Id,Name=student.Name,Surename=student.Surname,
            //          ClassId=student.ClassId,SubjectId=grade.FkSubject}).Join(_context.Grades,grade=>grade.,student=>student.Id);

            return null;
                    
                    
                
               // response.Add()
            
        }
    }
}
