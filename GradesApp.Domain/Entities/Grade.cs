namespace GradesApp.Domain.Entities;

public class Grade
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
    public decimal Score { get; set; }
    public DateTime GradeDate { get; set; }
}