namespace ELI.Entities;

public class Course
{
    public int ID { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    // navigation - teacher
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    // relations
    public IEnumerable<Enrollment>? Enrollments { get; set; }
}