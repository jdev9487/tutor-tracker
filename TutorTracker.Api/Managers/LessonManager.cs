using TutorTracker.Model;

namespace TutorTracker.Api.Managers;

using Entities;
using Repositories;

public class LessonManager : ILessonManager
{
    private readonly IRepository _repository;
    private readonly ILogger<LessonManager> _logger;

    public LessonManager(IRepository repository, ILogger<LessonManager> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Guid?> CreateLessonAsync(Lesson lesson, Guid studentId, CancellationToken token)
    {
        try
        {
            var student = await _repository.GetStudentAsync(studentId, token);
            if (student is null) throw new KeyNotFoundException($"Student with id {studentId} does not exist");
            lesson.Student = student;
            return await _repository.SaveLessonAsync(lesson, token) ? lesson.Id : null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Could not create lesson");
            throw;
        }
    }

    public async Task<Lesson?> UpdateLessonAsync(UpdateLesson updateLesson, CancellationToken token)
    {
        try
        {
            return await _repository.UpdateLessonAsync(updateLesson, token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Could not update lesson with id {id}", updateLesson.LessonId);
            throw;
        }
    }

    public async Task<Lesson?> DeleteLessonAsync(Guid lessonId, CancellationToken token)
    {
        try
        {
            return await _repository.DeleteLessonAsync(lessonId, token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Could not delete lesson with id {id}", lessonId);
            throw;
        }
    }
}