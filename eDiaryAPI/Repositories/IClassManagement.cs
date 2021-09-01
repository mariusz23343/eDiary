using eDiaryAPI.Models.DbModels;
using eDiaryAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Repositories
{
    public interface IClassManagement
    {
        public Task<SchoolClass> AddClass(ClassDTO classDTO);
        public Task<IList<SchoolClass>> GetClasses();

    }
}
