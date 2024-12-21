namespace Article.Api.ServicesClients;

/// <summary>
/// 
/// </summary>
public class CommentsEntity
{
    /// <summary>
    /// 
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? CommentText { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string User { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int ArticleId { get; set; }
}
