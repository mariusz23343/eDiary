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
        public Task<List<Student>> GetStudent(int classId);
        public  Task<Student> DeleteStudent(int id);
        public  Task<IList<Student>> GetAllStudent();
        public Task<IList<Student>> GetAllStudentWithoutClass();
        public Task<Student> PutStudentsClass(PutStudentsClassDto dto);
        public Task<Student> DeleteStudentFromClass(int id);
        public Task<Student> GetOneStudentToEdit(int id);
        public Task<Student> EditStudent(EditStudent student);
    }
}
