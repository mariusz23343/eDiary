using eDiaryAPI.Models.DbModels;
using eDiaryAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Repositories
{
    public class DataChange : IDataChange
    {
        private readonly ApplicationDbContext _context;

        public DataChange(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Student> ChangeData(StudentDTO studentDTO)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == studentDTO.Id);

            if (student == null)
            {
                return null;
            }

            if (studentDTO.Login != null)
            {
                student.Login = studentDTO.Login;
            }
            if (studentDTO.Password != null)
            {
                student.Password = studentDTO.Password;
            }
            if (studentDTO.Name != null)
            {
                student.Name = studentDTO.Name;
            }
            if (studentDTO.Surname != null)
            {
                student.Surname = studentDTO.Surname;
            }
            if (studentDTO.Date != null)
            {
                student.BirthDate = studentDTO.Date;
            }
            if (studentDTO.EmailParent != null)
            {
                student.ParentEmail = studentDTO.EmailParent;
            }

            _context.Students.Update(student);
            await _context.SaveChangesAsync();

            return student;
        }

        public async Task<Teacher> ChangeData(TeacherDTO teacherDTO)
        {


            var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == teacherDTO.Id);

            if (teacher == null)
            {
                return null;
            }

            if (teacherDTO.Login != null)
            {
                teacher.Login = teacherDTO.Login;
            }
            if (teacherDTO.Password != null)
            {
                teacher.Password = teacherDTO.Password;
            }
            if (teacherDTO.Name != null)
            {
                teacher.Name = teacherDTO.Name;
            }
            if (teacherDTO.Surname != null)
            {
                teacher.Surname = teacherDTO.Surname;
            }
            if (teacherDTO.TelephoneNumber != null)
            {
                teacher.PhoneNumber = teacherDTO.TelephoneNumber;
            }
            if (teacherDTO.Email != null)
            {
                teacher.Email = teacherDTO.Email;
            }


            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();

            return teacher;
        }
    }
}
