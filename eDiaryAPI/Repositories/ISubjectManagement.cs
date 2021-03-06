using eDiaryAPI.Models.DbModels;
using eDiaryAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Repositories
{
    public interface ISubjectManagement
    {
        public Task<Subject> AddSubject(SubjectDTO subjectDTO);
        public Task<Subject> RemoveSubject(SubjectDTO subjectDTO);
    }
}
