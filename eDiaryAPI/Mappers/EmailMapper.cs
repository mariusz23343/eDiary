using eDiaryAPI.Models.DbModels;
using eDiaryAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Mappers
{
    public class EmailMapper : IEmailMapper
    {   
        public EmailDTO MapResponse(Student student, Teacher teacher)
        {
            var emailDTO = new EmailDTO();

            emailDTO.Id = student.Id;
            emailDTO.Name = student.Name;
            emailDTO.Surname = student.Surname;
            emailDTO.EmailParent = student.ParentEmail;

            emailDTO.TeacherName = teacher.Name;
            emailDTO.TeacherSurname = teacher.Surname;
            emailDTO.TeacherEmail = teacher.Email;

            return emailDTO;
        }
    }
}
