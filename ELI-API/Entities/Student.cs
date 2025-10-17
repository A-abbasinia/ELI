using System.ComponentModel.DataAnnotations;

namespace ELI.Entities;

public class Student
{
    public int ID { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    // relations
    public ICollection<Enrollment> Enrollments { get; set; }
}