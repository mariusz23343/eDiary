using eDiaryAPI.Models.DbModels;
using eDiaryAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Mappers
{
    public class DataChangeMapper : IDataChangeMapper
    {
        public TeacherDTO MapResponse(Teacher teacher)
        {
            var teacherDTO = new TeacherDTO();

            teacherDTO.Login = teacher.Login;
            teacherDTO.Password = teacher.Password;
            teacherDTO.Name = teacher.Name;
            teacherDTO.Surname = teacher.Surname;
            teacherDTO.TelephoneNumber = teacher.PhoneNumber;
            teacherDTO.Email = teacher.Email;

            return teacherDTO;
            
        }

        public StudentDTO MapResponse(Student student)
        {
            var studentDTO = new StudentDTO();

            studentDTO.Login = student.Login;
            studentDTO.Password = student.Password;
            studentDTO.Name = student.Name;
            studentDTO.Surname = student.Surname;
            studentDTO.Date = student.BirthDate;
            studentDTO.EmailParent = student.ParentEmail;

            return studentDTO;
        }
    }
}
