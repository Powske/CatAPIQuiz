
namespace CatQuiz.Persistence.Persistence;

public class CatQuizRepository : ICatQuizRepository
{
    private readonly CatQuizContext _catQuizContext;

    public CatQuizRepository(CatQuizContext catQuizContext)
    {
        _catQuizContext = catQuizContext;
    }
/// <summary>
/// getting quiz questions for the user and question ID
/// </summary>
/// <param name="userId"></param>
/// <param name="questionId"></param>
/// <returns></returns>
    public async Task<Questions> GetQuestions(int userId, int questionId)
    {
        var results = _catQuizContext.Questions.FirstOrDefault(b => b.UserId == userId & b.Id ==questionId);
        return results;
    }
/// <summary>
/// Adding asked questions to the database
/// </summary>
/// <param name="request"></param>
/// <exception cref="Exception"></exception>
    public async Task PostQuestionsResponse(Questions request)
    {
        try
        {
            await _catQuizContext.Questions.AddAsync(request);
            await _catQuizContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception(e.InnerException.Message);
        }
    }
}