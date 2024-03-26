using CatQuiz.Domain;

namespace CatQuiz.Logic;

public interface ILogic
{
    Task<QuestionResponse> GetQuestion(int id);
    Task PostQuestionResponse(int userId, string userAnswer, int questionId);
}