namespace TutorTracker.Api.Controllers;

using Managers;
using M = Model;
using AutoMapper;
using E = Entities;

public class LessonController
{
    private readonly IMapper _mapper;
    private readonly ILessonManager _lessonManager;

    public LessonController(IMapper mapper, ILessonManager lessonManager)
    {
        _mapper = mapper;
        _lessonManager = lessonManager;
    }

    public async Task<IResult> CreateLessonAsync(M.Lesson lesson, CancellationToken token)
    {
        try
        {
            var lessonEntity = _mapper.Map<E.Lesson>(lesson);
            var id = await _lessonManager.CreateLessonAsync(lessonEntity, lesson.StudentId, token);
            return id is null ? Results.BadRequest() : Results.Ok(id);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}