namespace ELI.Entities
{
    public class Enrollment
    {
        public int ID { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string? Grade { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
        
    }
}