using System.ComponentModel.DataAnnotations;
namespace WebApplicationDemo1.Models
{
    public class Department
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="Department name is must")]
        [StringLength(50)]
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
