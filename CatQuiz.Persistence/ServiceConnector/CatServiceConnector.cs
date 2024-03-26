using CatQuiz.Domain;
using Newtonsoft.Json;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace CatQuiz.Persistence.ServiceConnector;
/// <summary>
/// Service connector class used to call external APIs
/// </summary>
public class CatServiceConnector : ICatServiceConnector
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CatServiceConnector(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    /// <summary>
    /// Get API for the CAT image
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<CatResponse[]> GetCatResponse()
    {
        var client = _httpClientFactory.CreateClient("Cat");
        HttpResponseMessage clientResponseMessage = await client.GetAsync(client.BaseAddress);
        if (clientResponseMessage.IsSuccessStatusCode)
        {
            var getCatResponse = await clientResponseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CatResponse[]>(getCatResponse);
        }
        else
        {
            throw new Exception("Failed to deserialize");
        }
        
    }

    /// <summary>
    /// GET API to get the list of Cat breeds
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<Breed[]> GetCatBreeds(int? pageNumber)
    {
        var client = _httpClientFactory.CreateClient("Breed");
        HttpResponseMessage clientResponseMessage = await client.GetAsync(client.BaseAddress);
        
        if (clientResponseMessage.IsSuccessStatusCode)
        {
            var getBreedResponse = await clientResponseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Breed[]>(getBreedResponse);
        }
        else
        {
            throw new Exception("Failed to deserialize breeds");
        }
    }
}