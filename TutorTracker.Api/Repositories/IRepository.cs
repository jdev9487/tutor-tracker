namespace TutorTracker.Api.Repositories;

using Entities;
using M = Model;

public interface IRepository
{
    Task<bool> SaveStudentAsync(Student student, CancellationToken token);
    Task<bool> SaveCustomerAsync(Customer customer, CancellationToken token);
    Task<Customer?> UpdateCustomerAsync(M.UpdateCustomer customer, CancellationToken token);
    Task<bool> SaveLessonAsync(Lesson lesson, CancellationToken token);
    Task<IEnumerable<Customer>> GetCustomersAsync(string? firstName, string? lastName, CancellationToken token);
    Task<Customer?> GetCustomerAsync(Guid id, CancellationToken token);
    Task<Student?> GetStudentAsync(Guid id, CancellationToken token);
    Task<IEnumerable<Lesson>> GetLessonsAssociatedWithCustomerAsync(Guid customerId, DateTimeOffset? from,
        DateTimeOffset? to, CancellationToken token);
    Task<IEnumerable<Student>> GetStudentsAsync(CancellationToken token);
    Task<IEnumerable<Lesson>> GetLessonsAssociatedWithStudentAsync(Guid studentId, CancellationToken token);
    Task<Lesson?> UpdateLessonAsync(M.UpdateLesson updateLesson, CancellationToken token);
    Task<Lesson?> DeleteLessonAsync(Guid lessonId, CancellationToken token);
}