namespace ELI.Data.DTOs.enrollment;

public class CreateEnrollmentDto
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public string? Grade { get; set; }
}