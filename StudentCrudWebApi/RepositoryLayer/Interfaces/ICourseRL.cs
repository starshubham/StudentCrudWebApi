using StudentCrudWebApi.Models;

namespace StudentCrudWebApi.RepositoryLayer.Interfaces
{
    public interface ICourseRL
    {
        Task<List<Course>> GetAllCourses();
        Task<Course> GetCourseById(int id);
        Task<Course> UpdateCourse(int id, Course course);
        Task<Course> CreateCourse(Course course);
        Task DeleteCourse(int id);
        bool CourseExists(int id);
    }
}
