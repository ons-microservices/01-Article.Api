namespace Article.Api.Models;

/// <summary>
/// Entity for articles
/// </summary>
public class ArticleEntity
{
    /// <summary>
    /// Get or set for id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Get or set for title
    /// </summary>
    public string? Title{ get; set; }

    /// <summary>
    /// Article descrition
    /// </summary>
    public string? Description{ get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string? Author{ get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DateTime? PublishedOn{ get; set; }
}