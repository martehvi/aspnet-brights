namespace Domain.Entities;

public class ArticleTag
{
    public int ArticleId { get; set; }
    public Article Article { get; set; } = new();

    public int TagId { get; set; }
    public Tag Tag { get; set; } = new();
}