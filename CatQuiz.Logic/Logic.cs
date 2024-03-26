using CatQuiz.Domain;
using CatQuiz.Persistence.Persistence;
using CatQuiz.Persistence.ServiceConnector;

namespace CatQuiz.Logic;

public class Logic : ILogic
{
    private readonly ICatServiceConnector _serviceConnector;
    private readonly ICatQuizRepository _repo;

    public Logic(ICatServiceConnector serviceConnector, ICatQuizRepository repo)
    {
        _serviceConnector = serviceConnector;
        _repo = repo;
    }
/// <summary>
/// Initial API request to get the picture of a cat and return a list of breeds for
/// the user to choose from
/// </summary>
/// <param name="userId"></param>
/// <returns></returns>
    public async Task<QuestionResponse> GetQuestion(int userId)
    {
        var catResponse = await _serviceConnector.GetCatResponse();

        var question = new Questions()
        {
            QuestionAnswer = catResponse[0].Breeds[0].Name,
            UserId = userId
        };

        await _repo.PostQuestionsResponse(question);
        
        var cat = new Cat()
        {
            PictureUrl = catResponse[0].Url,
            QuestionId = question.Id
            
        };
        var extraBreeds = await _serviceConnector.GetCatBreeds(RandomPageNumber());
        var questionResponse = new QuestionResponse()
        {
            Cat = cat,
            Breed = extraBreeds
        };
        return questionResponse;
    }

/// <summary>
/// Task that checks if the user answer is correct 
/// </summary>
/// <param name="userId"></param>
/// <param name="userAnswer"></param>
/// <param name="questionId"></param>
    public async Task PostQuestionResponse(int userId, string userAnswer, int questionId)
    {
        var answerRecord = await _repo.GetQuestions(userId, questionId);

        var mappedRecord = new Questions()
        {
            QuestionAnswer = answerRecord.QuestionAnswer,
            UserId = userId
        };

        if (userAnswer == mappedRecord.QuestionAnswer)
        {
            //Adding to the score for user leader board
           // await _repo.AddToScore(userId);
        }
    }

    private int RandomPageNumber()
    {
        int pageNumber = new Random().Next(10);
        return pageNumber;
    }
    
}