using CatQuiz.Domain;

namespace CatQuiz.Persistence.Persistence;

public interface ICatQuizRepository
{
    Task<Questions> GetQuestions(int userId, int questionId);
    Task PostQuestionsResponse(Questions question);
}