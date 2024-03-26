namespace CatQuiz.Domain;

public class QuestionRequest
{
    public int userId { get; set; }
    public string userAnswer { get; set; }
    public string correctAnswer { get; set; }
}