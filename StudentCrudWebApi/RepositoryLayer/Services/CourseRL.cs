using Microsoft.EntityFrameworkCore;
using StudentCrudWebApi.DAL;
using StudentCrudWebApi.Models;
using StudentCrudWebApi.RepositoryLayer.Interfaces;

namespace StudentCrudWebApi.RepositoryLayer.Services
{
    public class CourseRL : ICourseRL
    {
        private readonly DataContext _context;
        public CourseRL(DataContext context)
        {
           _context = context;
        }

        public bool CourseExists(int id)
        {
            return _context.courses.Any(x => x.Id == id);
        }

        public async Task<Course> CreateCourse(Course course)
        {
            _context.courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task DeleteCourse(int id)
        {
            var course = await _context.courses.FindAsync(id);
            if (course != null)
            {
                _context.courses.Remove(course);
                await _context.SaveChangesAsync();
            }
            
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return await _context.courses.ToListAsync();
        }

        public async Task<Course> GetCourseById(int id)
        {
            return await _context.courses.FindAsync(id);
        }

        public async Task<Course> UpdateCourse(int id, Course course)
        {

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    throw new KeyNotFoundException($"Student with id {id} not found");
                }
                else
                {
                    throw;
                }
            }

            return course;
            
        }
    }
}
