using eDiaryAPI.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Repositories
{
    public interface IAuthRepository
    {
        Task<Student> LoginStudent(string username, string password);
        Task<Teacher> LoginTeacher(string username, string password);

        Task<Student> RegisterStudent(Student student, string password);
        Task<Teacher> RegisterTeacher(Teacher teacher, string password);

        Task<bool> IsUserExist(string username);

    }
}
