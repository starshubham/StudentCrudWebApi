using Microsoft.AspNetCore.Mvc;
using StudentCrudWebApi.Models;

namespace StudentCrudWebApi.RepositoryLayer.Interfaces
{
    public interface IStudentRL
    {
        Task<List<Student>> GetAllStudents();
        Task<Student> GetStudentById(int id);
        Task<Student> UpdateStudent(int id, Student student);
        Task<Student> CreateStudent(Student student);
        Task DeleteStudent(int id);
        bool StudentExists(int id);
    }
}
