using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;


namespace CatQuiz.Persistence.Persistence;
/// <summary>
/// Initial Entity framework set up
/// </summary>
public class CatQuizContext : DbContext
{
    private readonly IConfiguration _configuration;
    public DbSet<Questions> Questions { get; set; }
    public CatQuizContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
}

public class Questions
{
    [Key]
    public int Id { get; set; }
    public string QuestionAnswer { get; set; }
    public int UserId { get; set; }
}