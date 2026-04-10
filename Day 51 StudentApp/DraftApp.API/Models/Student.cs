using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DraftApp.Models;

public partial class Student
{
    public int StudentId { get; set; }
    [Required(ErrorMessage = "Full Name is required.")]
    [StringLength(50, MinimumLength =3, ErrorMessage ="Name length must be between 3 and 50 characters")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Full Name can only contain letters and spaces.")]
    public string FullName { get; set; } = null!;
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Phone number is required.")]
    [Phone(ErrorMessage ="Invalid Phone Number")]
    [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Phone number must be a valid Indian number")]
    public string? Phone { get; set; }
    [Required(ErrorMessage = "Status is required.")]
    public string Status { get; set; } = null!;
    [DataType(DataType.Date)]
    public DateOnly JoinDate { get; set; }

    public DateTime CreatedAt { get; set; }

        public string MaskedEmail
        {
            get
            {
                if (string.IsNullOrEmpty(Email))
                    return string.Empty;

                return Regex.Replace(Email, @"(^.).+(@.+$)", "$1***$2");
            }
        }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<TblLog> TblLogs { get; set; } = new List<TblLog>();
}
