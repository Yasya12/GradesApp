namespace GradesApp.Domain.Entities;

public record Student (Guid Id, string FullName, string Email, int Year, string Speciality);