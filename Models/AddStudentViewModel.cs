using System.ComponentModel.DataAnnotations;

namespace First_Web_Application.Models
{
    public class AddStudentViewModel
    {
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter the Email")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
    }
}
