using System.ComponentModel.DataAnnotations;

namespace DotNetCoreSixPractice.Models.MainModel
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }
        public int Age { get; set; }
        [Required(ErrorMessage = "Do not hesitate, Your Email is secured here.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The CourseYearSec field is required.")]
        public string CourseYearSec { get; set; }
        public DateTime In { get; set; } = DateTime.Now;
    }
}
