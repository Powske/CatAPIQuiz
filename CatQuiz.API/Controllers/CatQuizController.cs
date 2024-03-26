using CatQuiz.Domain;
using CatQuiz.Logic;
using Microsoft.AspNetCore.Mvc;
namespace CatQuiz.Controllers;

[ApiController]
public class CatQuizController : ControllerBase
{
    private readonly ILogic _logic;

    public CatQuizController(ILogic logic)
    {
        _logic = logic;
    }
    /// <summary>
    /// Initial Question request to bring back an image and question ID 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("Question")]
    public async Task<QuestionResponse> QuizQuestion(int userId)
    {
        var question = await _logic.GetQuestion(userId);
        return question;
    }
    /// <summary>
    /// Second endpoint to check the answer against the question ID
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="userAnswer"></param>
    /// <param name="correctAnswer"></param>
    [HttpPost]
    [Route("Answer")]
    public async Task PostQuestionResponse(int userId, string userAnswer, int questionId)
    {
        await _logic.PostQuestionResponse(userId, userAnswer, questionId);
    }
}