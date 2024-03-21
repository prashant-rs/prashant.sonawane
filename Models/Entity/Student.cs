using System.ComponentModel.DataAnnotations;

namespace First_Web_Application.Models.Entity
{
    public class Student
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
       
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }

        
    }
}
