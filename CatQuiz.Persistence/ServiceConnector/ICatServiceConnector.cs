using CatQuiz.Domain;

namespace CatQuiz.Persistence.ServiceConnector;

public interface ICatServiceConnector
{
    Task<CatResponse[]> GetCatResponse();
    Task<Breed[]> GetCatBreeds(int? pageNumber);
}