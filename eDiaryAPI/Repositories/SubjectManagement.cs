using eDiaryAPI.Models.DbModels;
using eDiaryAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Repositories
{
    public class SubjectManagement : ISubjectManagement
    {
        private readonly ApplicationDbContext _context;
        public SubjectManagement(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Subject> AddSubject(SubjectDTO subjectDTO)
        {
            Subject subject = new Subject
            {
                SubjectName = subjectDTO.SubjectName,
                
                
            };

            await _context.AddAsync(subject);
            await _context.SaveChangesAsync();
            return subject;
        }

        public async Task<Subject> RemoveSubject(SubjectDTO subjectDTO)
        {
            //var subject = await _context.Subjects.FirstOrDefaultAsync(x=>x.Id==subjectDTO.Id);

            //if(subject==null)
            //{
            //    return null;
            //}
            return null;



        }
    }
}
