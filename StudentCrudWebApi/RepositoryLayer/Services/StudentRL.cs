using Microsoft.EntityFrameworkCore;
using StudentCrudWebApi.DAL;
using StudentCrudWebApi.Models;
using StudentCrudWebApi.RepositoryLayer.Interfaces;

namespace StudentCrudWebApi.RepositoryLayer.Services
{
    public class StudentRL : IStudentRL
    {
        private readonly DataContext _context;
        public StudentRL(DataContext context)
        {
            _context = context;
        }

        public async Task<Student> CreateStudent(Student student)
        {
            _context.students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task DeleteStudent(int id)
        {
            var student = await _context.students.FindAsync(id);
            if (student != null)
            {
                _context.students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _context.students.ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _context.students.FindAsync(id);
        }

        public bool StudentExists(int id)
        {
            return _context.students.Any(e => e.Id == id);
        }

        public async Task<Student?> UpdateStudent(int id, Student student)
        {
            if (!StudentExists(id))
            {
                return null;
            }

            try
            {
                _context.Entry(student).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return student;
        }
    }
}
