namespace ELI.Data.DTOs.enrollment;

public class EnrollmentDto
{
    public int ID { get; set; }
    
    public int StudentId { get; set; }
    public string StudentName { get; set; }

    public int CourseId { get; set; }
    public string CourseTitle { get; set; }

    public DateTime EnrollmentDate { get; set; }
    
    public string? Grade { get; set; }
}