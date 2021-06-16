using eDiaryAPI.Models.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDiaryAPI.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;
        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> IsUserExist(string username)
        {
            if ((await _context.Students.AnyAsync(x => x.Login == username))
                     || (await _context.Teachers.AnyAsync(x => x.Login == username)))
                            return true;
            else return false;
        }

        public async Task<Student> LoginStudent(string username, string password)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Login == username);
            if (student == null) return null;

            if(!VerifyPasswordHash(password, student.PasswordHash, student.PasswordSalt))
            {
                return null;
            }
            return student;
        }

        public async Task<Teacher> LoginTeacher(string username, string password)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Login == username);
            if (teacher == null) return null;

            if (!VerifyPasswordHash(password, teacher.PasswordHash, teacher.PasswordSalt))
            {
                return null;
            }
            return teacher;
        }

        public async Task<Student> RegisterStudent(Student student, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHashSatl(password, out passwordHash, out passwordSalt);
            student.PasswordHash = passwordHash;
            student.PasswordSalt = passwordSalt;

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

            return student;
        }

        public async Task<Teacher> RegisterTeacher(Teacher teacher, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHashSatl(password, out passwordHash, out passwordSalt);
            teacher.PasswordHash = passwordHash;
            teacher.PasswordSalt = passwordSalt;

            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();

            return teacher;
            
        }

        private void CreatePasswordHashSatl(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            }

        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }

                }
                return true;
            }
        }

    }
}
