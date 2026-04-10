using System.ComponentModel.DataAnnotations;

namespace JWTPractice.DTOs
{
    public class RegisterDtocs
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
