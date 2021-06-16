using eDiaryAPI.Models.DbModels;
using eDiaryAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Repositories
{
    public interface IDataChange
    {
        public Task<Student> ChangeData(StudentDTO studentDTO);
        public Task<Teacher> ChangeData(TeacherDTO teacherDTO);
    }
}
