using eDiaryAPI.Models.DbModels;
using eDiaryAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Repositories
{
    public class ClassManagement : IClassManagement
    {
        private readonly ApplicationDbContext _context;

        public ClassManagement (ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<SchoolClass> AddClass(ClassDTO classDTO)
        {
            SchoolClass schoolclass = new SchoolClass
            {
                ClassName = classDTO.ClassName,
                SchoolYear = classDTO.SchoolYear,
                
             
            };

            await _context.AddAsync(schoolclass);
            await _context.SaveChangesAsync();
            return schoolclass;
        }

        public async Task<IList<SchoolClass>> GetClasses()
        {
            return await _context.SchoolClasses.ToListAsync();
        }
    }
}
