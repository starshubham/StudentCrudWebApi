using System.ComponentModel.DataAnnotations;

namespace StudentCrudWebApi.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }

        [Required]
        public string Department { get; set; }
        public int CourseId { get; set; }
    }
}
