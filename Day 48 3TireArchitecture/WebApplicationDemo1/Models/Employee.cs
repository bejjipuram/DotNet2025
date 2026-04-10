using System.ComponentModel.DataAnnotations;
namespace WebApplicationDemo1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is Mandatory")]
        [MinLength(2)]
        [StringLength(50)]
        public string Name { get; set; }
        [Range(1,10000000,ErrorMessage ="Salary must be greater than 0 and should be in limit")]
        public int Salary { get; set; }
        [Required(ErrorMessage ="Phone number is required")]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage="Enter a valid 10-digit Indian Phone number")]
        public string Phone { get; set; }
        [Required(ErrorMessage ="Select Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
