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

        public async Task<List<Student>> GetStudent(int classId)
        {
            var studentsList = await _context.Students.Where(x => x.FkClass == classId).ToListAsync();
            return studentsList;
        }
        public async Task<Student> DeleteStudent(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student == null) return null;
            else
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return student;
            }
        }
        public async Task<IList<Student>> GetAllStudent()
        {
            var studentList = await _context.Students.ToListAsync();
            return studentList;
        }
        public async Task<IList<Student>> GetAllStudentWithoutClass()
        {
            var list = await _context.Students.Where(x => x.ClassId == null).ToListAsync();
            return list;
        }
        public async Task<Student> PutStudentsClass(PutStudentsClassDto dto)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == dto.StudentId);
            var studentClass = await _context.SchoolClasses.FirstOrDefaultAsync(x => x.Id == dto.ClassId);

            student.FkClass = dto.ClassId;
            student.ClassId = studentClass;

            await _context.SaveChangesAsync();
            return student;
        }
        public async Task<Student> DeleteStudentFromClass(int id)
        {
            var student = await _context.Students.Include(c=>c.ClassId).FirstOrDefaultAsync(i=>i.Id==id);
            student.FkClass = 0;
            student.ClassId = null;
            await _context.SaveChangesAsync();
            return student;
        }
        public async Task<Student> GetOneStudentToEdit(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            return student;
        }

        public async Task<Student> EditStudent(EditStudent studentFromClient)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == studentFromClient.Id);
            student.Login = studentFromClient.Login;
            student.Name = studentFromClient.Name;
            student.Surname = studentFromClient.Surname;
            student.Pesel = studentFromClient.Pesel;
            student.ParentEmail = studentFromClient.ParentEmail;
            student.BirthDate = studentFromClient.BirthDate;

            await _context.SaveChangesAsync();
            return student;

        }
    }

}
